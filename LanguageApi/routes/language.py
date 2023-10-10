from fastapi import APIRouter, Depends
from fastapi_restful.cbv import cbv
from services.bert import BertService
from models.demand import Demand
from models.keywords import Keywords
from models.message import Message

router = APIRouter(prefix="/language", tags=["Language Processing"])


@cbv(router)
class Language:
    def __init__(self, bert: BertService = Depends(BertService)):
        self.bert = bert

    @router.post("/extract", response_model=Keywords, responses={400: {"model": Message}})
    async def post(self, demand: Demand) -> Keywords | Message:
        try:
            return self.bert.extract(demand.description)
        except Exception as e:
            return Message(message=str(e))
