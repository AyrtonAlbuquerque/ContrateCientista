from abc import ABC, abstractmethod
from contracts.description import Description
from contracts.keyword import Keyword


class IExtractionService(ABC):
    @abstractmethod
    async def extract_aws(self, description: Description) -> list[Keyword]:
        pass

    @abstractmethod
    async def extract_gpt(self, description: Description) -> list[Keyword]:
        pass

    @abstractmethod
    async def extract_bert(self, description: Description) -> list[Keyword]:
        pass

    @abstractmethod
    async def extract_yake(self, description: Description) -> list[Keyword]:
        pass

    @abstractmethod
    async def extract_azure(self, description: Description) -> list[Keyword]:
        pass
