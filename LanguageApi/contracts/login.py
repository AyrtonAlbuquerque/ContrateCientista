from typing import Optional
from pydantic import BaseModel


class Login(BaseModel):
    username: str
    password: str


class Token(BaseModel):
    token: str
    type: str
    expiration: Optional[float]
