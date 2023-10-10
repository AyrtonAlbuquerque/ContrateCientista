from keybert import KeyBERT
from models.keywords import Keywords, Word


class BertService:
    def __init__(self):
        self.model = KeyBERT(model='paraphrase-multilingual-MiniLM-L12-v2')

    def extract(self, text) -> Keywords:
        result = Keywords(keywords=[])
        keywords = self.model.extract_keywords(text, keyphrase_ngram_range=(1, 1))

        for word, score in keywords:
            result.keywords.append(Word(word=word, score=score))

        return result
