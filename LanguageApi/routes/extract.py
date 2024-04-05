from classy_fastapi import Routable, post
from fastapi import Depends
from contracts.description import Description
from contracts.error import Error
from contracts.keyword import Keyword
from services.authentication import BearerToken
from services.interfaces.iextraction import IExtractionService


class Extract(Routable):
    def __init__(self, extractor: IExtractionService):
        super().__init__(prefix="/extract", tags=["Extract"], dependencies=[Depends(BearerToken())], responses={400: {"model": Error}})
        self.extractor = extractor

    @post("/bert", response_model=list[Keyword])
    async def extract_bert(self, description: Description) -> list[Keyword]:
        return self.extractor.extract_bert(description)

    @post("/gpt", response_model=list[Keyword])
    async def extract_gpt(self, description: Description) -> list[Keyword]:
        return self.extractor.extract_gpt(description)

    @post("/aws", response_model=list[Keyword])
    async def extract_aws(self, description: Description) -> list[Keyword]:
        return self.extractor.extract_aws(description)

    @post("/azure", response_model=list[Keyword])
    async def extract_azure(self, description: Description) -> list[Keyword]:
        return self.extractor.extract_azure(description)

    @post("/yake", response_model=list[Keyword])
    async def extract_yake(self, description: Description) -> list[Keyword]:
        return self.extractor.extract_yake(description)
