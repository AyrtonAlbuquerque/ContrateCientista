from typing import List
from fastapi import Depends
from classy_fastapi import Routable, post
from services.bert import BertService
from services.gpt import GPTService
from services.token import BearerToken
from services.aws import AWSService
from services.azure import AzureService
from services.yakes import YakeService
from contracts.description import Description
from contracts.keyword import Keyword
from contracts.error import Error


class Extract(Routable):
    def __init__(self):
        super().__init__(prefix="/extract", tags=["Extract"], dependencies=[Depends(BearerToken())], responses={400: {"model": Error}})
        self.aws = AWSService()
        self.gpt = GPTService()
        self.bert = BertService()
        self.yake = YakeService()
        self.azure = AzureService()

    @post("/bert", response_model=List[Keyword])
    async def extract_bert(self, description: Description) -> List[Keyword]:
        return self.bert.extract(description)

    @post("/gpt", response_model=List[Keyword])
    async def extract_gpt(self, description: Description) -> List[Keyword]:
        return self.gpt.extract(description)

    @post("/aws", response_model=List[Keyword])
    async def extract_aws(self, description: Description) -> List[Keyword]:
        return self.aws.extract(description)

    @post("/azure", response_model=List[Keyword])
    async def extract_azure(self, description: Description) -> List[Keyword]:
        return self.azure.extract(description)

    @post("/yake", response_model=List[Keyword])
    async def extract_yake(self, description: Description) -> List[Keyword]:
        return self.yake.extract(description)
