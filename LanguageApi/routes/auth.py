from classy_fastapi import Routable, post
from contracts.error import Error
from contracts.login import Login, Token
from services.interfaces.iauthentication import IAuthenticationService


class Auth(Routable):
    def __init__(self, auth: IAuthenticationService):
        super().__init__(prefix="/auth", tags=["Auth"], responses={400: {"model": Error}})
        self.auth = auth

    @post("/login", response_model=Token)
    async def login(self, login: Login) -> Token:
        return self.auth.generate_token(login)
