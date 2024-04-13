from abc import ABC, abstractmethod
from contracts.demand import Demand
from contracts.responses import AnalysisResponse


class IAnalysisService(ABC):
    @abstractmethod
    async def analyze(self, demand: Demand) -> list[AnalysisResponse]:
        pass
