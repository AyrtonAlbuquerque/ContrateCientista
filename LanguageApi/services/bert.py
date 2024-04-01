from typing import List
from keybert import KeyBERT
from flair.embeddings import TransformerDocumentEmbeddings
from flair.models import SequenceTagger
from flair.splitter import SegtokSentenceSplitter
from keyphrase_vectorizers import KeyphraseCountVectorizer
from settings import Settings
from contracts.keyword import Keyword
from contracts.description import Description


class BertService:
    def __init__(self):
        self.tagger = SequenceTagger.load('pos')
        self.splitter = SegtokSentenceSplitter()
        self.model = KeyBERT(model=TransformerDocumentEmbeddings(Settings.bert_model))
        self.vectorizer = KeyphraseCountVectorizer(spacy_pipeline=Settings.pipeline, stop_words=Settings.stop_words, custom_pos_tagger=self.pos_tagger)

    def extract(self, description: Description) -> List[Keyword]:
        return [Keyword(text=text, weight=weight)
                for text, weight in self.model.extract_keywords(docs=description.text, vectorizer=self.vectorizer)
                if weight >= Settings.keyword_threshhold]

    def pos_tagger(self, raw_documents: List[str]) -> List[tuple]:
        tags = []
        words = []
        sentences = []

        for document in raw_documents:
            sentences.extend(self.splitter.split(document))

        self.tagger.predict(sentences)

        for sentence in sentences:
            tags.extend([label.value for label in sentence.get_labels('pos')])
            words.extend([word.text for word in sentence])

        return list(zip(words, tags))
