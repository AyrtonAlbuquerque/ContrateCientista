from pydantic import BaseModel, Field


class Word(BaseModel):
    word: str
    score: float = Field(ge=0, le=1)


class Keywords(BaseModel):
    keywords: list[Word]
