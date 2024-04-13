from sentence_transformers import SentenceTransformer, util
from contracts.demand import Demand
from contracts.responses import AnalysisResponse
from services.interfaces.ianalysis import IAnalysisService


class AnalysisService(IAnalysisService):
    def __init__(self, model: SentenceTransformer):
        self.model = model

    async def analyze(self, demand: Demand) -> list[AnalysisResponse]:
        embedding = self.model.encode(demand.text, convert_to_tensor=True)

        return [AnalysisResponse(id=laboratory.id, score=round(sum(laboratory.keywords[item.get('corpus_id')].weight * item.get('score')
            for item in util.semantic_search(embedding, self.model.encode([keyword.text for keyword in laboratory.keywords]), top_k=len(laboratory.keywords))[0]) / len(laboratory.keywords), 4)
                if len(laboratory.keywords) > 0 else 0)
            for laboratory in demand.laboratories]
