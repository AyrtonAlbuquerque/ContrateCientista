import os
import time
import jwt
from fastapi import HTTPException, Request, status
from fastapi.security import HTTPBearer, HTTPAuthorizationCredentials
from jwt.exceptions import DecodeError
from contracts.login import Login, Token
from services.interfaces.iauthentication import IAuthenticationService


class BearerToken(HTTPBearer):
    def __init__(self, auto_error: bool = True):
        super(BearerToken, self).__init__(auto_error=auto_error)
        self.secret = os.environ["SECRET"]
        self.algorithm = os.environ["ALGORITHM"]

    async def __call__(self, request: Request):
        credentials: HTTPAuthorizationCredentials = await super(BearerToken, self).__call__(request)

        if credentials:
            try:
                token = jwt.decode(credentials.credentials, self.secret, algorithms=[self.algorithm])

                if not credentials.scheme == "Bearer":
                    raise HTTPException(status_code=status.HTTP_403_FORBIDDEN, detail="Invalid authentication scheme.")

                if token['expires'] < time.time():
                    raise HTTPException(status_code=status.HTTP_403_FORBIDDEN, detail="Token expired")
            except DecodeError:
                raise HTTPException(status_code=status.HTTP_403_FORBIDDEN, detail="Invalid token")

            return credentials.credentials
        else:
            raise HTTPException(status_code=status.HTTP_403_FORBIDDEN, detail="Invalid credentials")


class AuthenticationService(IAuthenticationService):
    def __init__(self):
        self.secret = os.environ["SECRET"]
        self.minutes = float(os.environ["MINUTES"])
        self.email = os.environ["EMAIL"]
        self.password = os.environ["PASSWORD"]
        self.algorithm = os.environ["ALGORITHM"]

    def generate_token(self, login: Login) -> Token:
        expires = time.time() + (self.minutes * 60)

        if login.email != self.email or login.password != self.password:
            raise HTTPException(status_code=status.HTTP_403_FORBIDDEN, detail="Invalid credentials")

        return Token(
            value=jwt.encode({'user': login.email, 'expires': expires}, self.secret, algorithm=self.algorithm),
            type='Bearer',
            expires=expires
        )
