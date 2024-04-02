from typing import List
from pydantic import BaseModel, Field


class AnalysisResponse(BaseModel):
    id: int = Field(serialization_alias='laboratory_id')
    score: float = Field(ge=-1, le=1)
