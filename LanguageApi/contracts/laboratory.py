from typing import List
from pydantic import BaseModel, Field
from contracts.keyword import Keyword


class Laboratory(BaseModel):
    id: int
    keywords: List[Keyword]