from classy_fastapi import Routable, post
from fastapi import Depends
from contracts.demand import Demand
from contracts.error import Error
from contracts.responses import AnalysisResponse
from services.authentication import BearerToken
from services.interfaces.ianalysis import IAnalysisService


class Analyze(Routable):
    def __init__(self, analyzer: IAnalysisService):
        super().__init__(prefix="/analyze", tags=["Analyze"], dependencies=[Depends(BearerToken())], responses={400: {"model": Error}})
        self.analyzer = analyzer

    @post("/demand", response_model=list[AnalysisResponse])
    async def analyze_demand(self, demand: Demand) -> list[AnalysisResponse]:
        return await self.analyzer.analyze(demand)
