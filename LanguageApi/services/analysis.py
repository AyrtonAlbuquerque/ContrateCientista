from sentence_transformers import SentenceTransformer
from contracts.demand import Demand
from contracts.responses import AnalysisResponse
from services.interfaces.ianalysis import IAnalysisService


class AnalysisService(IAnalysisService):
    def __init__(self, model: SentenceTransformer):
        self.model = model

    async def analyze(self, demand: Demand) -> list[AnalysisResponse]:
        embedding = self.model.encode(demand.text)

        return [AnalysisResponse(id=laboratory.id, score=round(sum(keyword.weight * self.model.similarity(embedding, self.model.encode(keyword.text)).item()
            for keyword in laboratory.keywords) / len(laboratory.keywords), 4) if len(laboratory.keywords) > 0 else 0)
            for laboratory in demand.laboratories]
