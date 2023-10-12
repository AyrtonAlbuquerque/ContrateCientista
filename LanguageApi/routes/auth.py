from typing import Annotated
from fastapi import APIRouter, Depends, HTTPException, status
from fastapi_restful.cbv import cbv
from services.token import TokenService
from contracts.login import Login, Token
from contracts.error import Error

router = APIRouter(prefix="/auth", tags=["Authentication"])


@cbv(router)
class Auth:
    def __init__(self, token: Annotated[TokenService, Depends()]):
        self.token = token

    @router.post("/login", name="Login", response_model=Token, responses={400: {"model": Error}})
    async def post(self, login: Login) -> Token:
        try:
            return self.token.generate(login)
        except Exception as e:
            raise e if e is HTTPException else HTTPException(status_code=status.HTTP_400_BAD_REQUEST, detail=str(e))
