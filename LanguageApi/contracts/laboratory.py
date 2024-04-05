from pydantic import BaseModel
from contracts.keyword import Keyword


class Laboratory(BaseModel):
    id: int
    keywords: list[Keyword]