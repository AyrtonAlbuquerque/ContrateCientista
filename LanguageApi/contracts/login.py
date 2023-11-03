from typing import Optional
from pydantic import BaseModel


class Login(BaseModel):
    username: str
    password: str


class Token(BaseModel):
    value: str
    type: str
    expires: Optional[float]
