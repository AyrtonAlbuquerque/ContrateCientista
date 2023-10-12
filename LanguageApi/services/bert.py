from keybert import KeyBERT
from settings import Settings
from contracts.keywords import Keywords, Word
from contracts.demand import Demand


class BertService:
    def __init__(self):
        self.model = KeyBERT(model=Settings.model)

    def extract(self, demand: Demand) -> Keywords:
        result = Keywords(keywords=[])
        keywords = self.model.extract_keywords(demand.description)

        for word, score in keywords:
            result.keywords.append(Word(word=word, score=score))

        return result
