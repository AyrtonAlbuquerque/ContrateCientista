from pydantic import BaseModel, Field


class Keyword(BaseModel):
    text: str
    weight: float = Field(ge=0, le=1)
