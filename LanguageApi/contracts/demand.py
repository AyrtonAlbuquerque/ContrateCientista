from pydantic import BaseModel
from contracts.laboratory import Laboratory


class Demand(BaseModel):
    text: str
    laboratories: list[Laboratory]
