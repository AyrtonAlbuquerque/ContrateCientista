from classy_fastapi import Routable, post
from services.token import TokenService
from contracts.login import Login, Token
from contracts.error import Error


class Auth(Routable):
    def __init__(self):
        super().__init__(prefix="/auth", tags=["Auth"], responses={400: {"model": Error}})
        self.token = TokenService()

    @post("/login", response_model=Token)
    async def login(self, login: Login) -> Token:
        return self.token.generate(login)
