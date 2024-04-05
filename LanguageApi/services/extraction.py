import json
import os
from azure.ai.textanalytics import TextAnalyticsClient
from botocore.client import BaseClient
from flair.models import SequenceTagger
from flair.splitter import SegtokSentenceSplitter
from keybert import KeyBERT
from keyphrase_vectorizers import KeyphraseCountVectorizer
from openai import OpenAI
from yake import KeywordExtractor
from contracts.description import Description
from contracts.keyword import Keyword
from services.interfaces.iextraction import IExtractionService


class ExtractionService(IExtractionService):
    tagger = SequenceTagger.load('pos')
    splitter = SegtokSentenceSplitter()

    def __init__(self, aws: BaseClient, gpt: OpenAI, bert: KeyBERT, yake: KeywordExtractor, azure: TextAnalyticsClient, vectorizer: KeyphraseCountVectorizer):
        self.aws = aws
        self.gpt = gpt
        self.bert = bert
        self.yake = yake
        self.azure = azure
        self.vectorizer = vectorizer
        self.model = os.environ["GPT_MODEL"]
        self.language = os.environ["LANGUAGE"]
        self.top_p = float(os.environ["TOP_P"])
        self.content = os.environ["SYSTEM_CONTENT"]
        self.max_tokens = int(os.environ["MAX_TOKENS"])
        self.temperature = float(os.environ["TEMPERATURE"])
        self.threshhold = float(os.environ["KEYWORD_THRESHHOLD"])

    def extract_aws(self, description: Description) -> list[Keyword]:
        response = self.aws.detect_key_phrases(Text=description.text, LanguageCode=self.language).get("KeyPhrases")
        keywords = [keyword for keyword in response if keyword.get("Score") >= self.threshhold]
        keywords.sort(key=lambda x: x.get("Score"), reverse=True)

        return [Keyword(text=keyword.get("Text"), weight=round(keyword.get("Score"), 4)) for keyword in keywords]

    def extract_gpt(self, description: Description) -> list[Keyword]:
        response = json.loads(self.gpt.chat.completions.create(
            model=self.model,
            messages=[
                {
                    "role": "system",
                    "content": self.content
                },
                {
                    "role": "user",
                    "content": description.text
                }
            ],
            temperature=self.temperature,
            max_tokens=self.max_tokens,
            top_p=self.top_p
        ).choices[0].message.content)
        keywords = [keyword for keyword in response if keyword.get("weight") >= self.threshhold]
        keywords.sort(key=lambda x: x.get("weight"), reverse=True)

        return [Keyword(text=keyword.get("text"), weight=keyword.get("weight")) for keyword in keywords]

    def extract_bert(self, description: Description) -> list[Keyword]:
        return [Keyword(text=text, weight=weight)
                for text, weight in self.bert.extract_keywords(docs=description.text, vectorizer=self.vectorizer)
                if weight >= self.threshhold]

    def extract_yake(self, description: Description) -> list[Keyword]:
        return [Keyword(text=text, weight=round((1 - weight), 4))
                for text, weight in self.yake.extract_keywords(description.text)
                if round((1 - weight), 4) >= self.threshhold]

    def extract_azure(self, description: Description) -> list[Keyword]:
        return [Keyword(text=keyword, weight=self.threshhold)
                for keyword in self.azure.extract_key_phrases([description.text], language=self.language)[0].get("key_phrases")]

    @staticmethod
    def pos_tagger(raw_documents: list[str], tagger: SequenceTagger = tagger, splitter: SegtokSentenceSplitter = splitter) -> list[tuple]:
        tags = []
        words = []
        sentences = []

        for document in raw_documents:
            sentences.extend(splitter.split(document))

        tagger.predict(sentences)

        for sentence in sentences:
            tags.extend([label.value for label in sentence.get_labels('pos')])
            words.extend([word.text for word in sentence])

        return list(zip(words, tags))
