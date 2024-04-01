from typing import List
from settings import Settings
from contracts.demand import Demand
from contracts.responses import AnalysisResponse
from sentence_transformers import SentenceTransformer, util


class AnalyzerService:
    def __init__(self):
        self.model = SentenceTransformer(Settings.sbert_model)

    def analyze(self, demand: Demand) -> List[AnalysisResponse]:
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
