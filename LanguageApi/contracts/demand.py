from typing import List
from pydantic import BaseModel, Field
from contracts.laboratory import Laboratory


class Demand(BaseModel):
    text: str
    laboratories: List[Laboratory]
