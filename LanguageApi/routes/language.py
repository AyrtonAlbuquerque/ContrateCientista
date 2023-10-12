from typing import Annotated
from fastapi import APIRouter, Depends, HTTPException, status
from fastapi_restful.cbv import cbv
from services.bert import BertService
from services.token import BearerToken
from contracts.demand import Demand
from contracts.keywords import Keywords
from contracts.error import Error

router = APIRouter(prefix="/language", tags=["Language"])


@cbv(router)
class Language:
    def __init__(self, bert: Annotated[BertService, Depends()]):
        self.bert = bert

    @router.post("/extract", name="Keyword Extraction", dependencies=[Depends(BearerToken())], response_model=Keywords, responses={400: {"model": Error}})
    async def post(self, demand: Demand) -> Keywords:
        try:
            return self.bert.extract(demand)
        except Exception as e:
            raise e if type(e) is HTTPException else HTTPException(status_code=status.HTTP_400_BAD_REQUEST, detail=str(e))
