import yake
from typing import List
from settings import Settings
from contracts.keyword import Keyword
from contracts.description import Description


class YakeService:
    def __init__(self):
        self.extractor = yake.KeywordExtractor(lan=Settings.language, n=Settings.ngram_size, dedupLim=Settings.deduplication_threshold)

    def extract(self, description: Description) -> List[Keyword]:
        return [Keyword(text=text, weight=round((1 - weight), 4)) for text, weight in self.extractor.extract_keywords(description.text) if round((1 - weight), 4) >= Settings.keyword_threshhold]
