from fastapi import HTTPException, status
from classy_fastapi import Routable, post
from services.token import TokenService
from contracts.login import Login, Token
from contracts.error import Error


class Auth(Routable):
    def __init__(self):
        super().__init__(prefix="/auth", tags=["Authentication"], responses={400: {"model": Error}})
        self.token = TokenService()

    @post("/login", response_model=Token)
    async def post(self, login: Login) -> Token:
        try:
            return self.token.generate(login)
        except Exception as e:
            raise e if type(e) is HTTPException else HTTPException(status_code=status.HTTP_400_BAD_REQUEST, detail=str(e))
