from fastapi import Depends, HTTPException, status
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
        try:
            return self.bert.extract(description)
        except Exception as e:
            raise e if type(e) is HTTPException else HTTPException(status_code=status.HTTP_400_BAD_REQUEST, detail=str(e))
