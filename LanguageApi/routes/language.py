from typing import List
from fastapi import Depends
from classy_fastapi import Routable, post
from services.bert import BertService
from services.gpt import GPTService
from services.token import BearerToken
from contracts.description import Description
from contracts.keyword import Keyword
from contracts.error import Error


class Language(Routable):
    def __init__(self):
        super().__init__(prefix="/language", tags=["Language"], dependencies=[Depends(BearerToken())], responses={400: {"model": Error}})
        self.bert = BertService()
        self.gpt = GPTService()

    @post("/extractBERT", response_model=List[Keyword])
    async def extract_bert(self, description: Description) -> List[Keyword]:
        return self.bert.extract(description)

    @post("/extractGPT", response_model=List[Keyword])
    async def extract_gpt(self, description: Description) -> List[Keyword]:
        return self.gpt.extract(description)
