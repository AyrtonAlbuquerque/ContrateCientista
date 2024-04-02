from typing import List
from fastapi import Depends
from classy_fastapi import Routable, post
from services.token import BearerToken
from services.analyzers import AnalyzerService
from contracts.responses import AnalysisResponse
from contracts.demand import Demand
from contracts.error import Error


class Analyze(Routable):
    def __init__(self):
        super().__init__(prefix="/analyze", tags=["Analyze"], dependencies=[Depends(BearerToken())], responses={400: {"model": Error}})
        self.analyzer = AnalyzerService()

    @post("/demand", response_model=List[AnalysisResponse])
    async def analyze_demand(self, demand: Demand) -> List[AnalysisResponse]:
        return self.analyzer.analyze(demand)
