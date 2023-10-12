from pydantic import BaseModel


class Demand(BaseModel):
    description: str
