from fastapi import Depends
from classy_fastapi import Routable, post
from services.bert import BertService
from services.token import BearerToken
from contracts.description import Description
from contracts.keywords import Keywords
from contracts.error import Error


class Language(Routable):
    def __init__(self):
        super().__init__(prefix="/language", tags=["Language"], dependencies=[Depends(BearerToken())], responses={400: {"model": Error}})
        self.bert = BertService()

    @post("/extract", response_model=Keywords)
    async def post(self, description: Description) -> Keywords:
        return self.bert.extract(description)
