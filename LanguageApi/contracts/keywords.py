from pydantic import BaseModel, Field


class Words(BaseModel):
    text: str
    weight: float = Field(ge=-1, le=1)


class Keywords(BaseModel):
    keywords: list[Words] = []
