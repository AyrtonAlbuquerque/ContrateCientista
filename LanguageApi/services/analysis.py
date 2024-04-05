from sentence_transformers import SentenceTransformer, util
from contracts.demand import Demand
from contracts.responses import AnalysisResponse
from services.interfaces.ianalysis import IAnalysisService


class AnalysisService(IAnalysisService):
    def __init__(self, model: SentenceTransformer):
        self.model = model

    def analyze(self, demand: Demand) -> list[AnalysisResponse]:
        response = []
        embedding = self.model.encode(demand.text, convert_to_tensor=True)

        for laboratory in demand.laboratories:
            score = 0

            if len(laboratory.keywords) > 0:
                for keyword in laboratory.keywords:
                    score += util.cos_sim(self.model.encode(keyword.text, convert_to_tensor=True), embedding).item() * keyword.weight

                score /= len(laboratory.keywords)

            response.append(AnalysisResponse(id=laboratory.id, score=round(score, 4)))

        return response
