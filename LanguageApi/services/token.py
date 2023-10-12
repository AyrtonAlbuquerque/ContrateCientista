import jwt
import time
from settings import Settings
from jwt.exceptions import DecodeError
from fastapi import HTTPException, Request, status
from fastapi.security import HTTPBearer, HTTPAuthorizationCredentials
from contracts.login import Login, Token


class BearerToken(HTTPBearer):
    def __init__(self, auto_error: bool = True):
        super(BearerToken, self).__init__(auto_error=auto_error)

    async def __call__(self, request: Request):
        credentials: HTTPAuthorizationCredentials = await super(BearerToken, self).__call__(request)

        if credentials:
            try:
                token = jwt.decode(credentials.credentials, Settings.secret, algorithms=[Settings.algorithm])

                if not credentials.scheme == "Bearer":
                    raise HTTPException(status_code=status.HTTP_403_FORBIDDEN, detail="Invalid authentication scheme.")

                if token['expires'] < time.time():
                    raise HTTPException(status_code=status.HTTP_403_FORBIDDEN, detail="Token expired")
            except DecodeError:
                raise HTTPException(status_code=status.HTTP_403_FORBIDDEN, detail="Invalid token")

            return credentials.credentials
        else:
            raise HTTPException(status_code=status.HTTP_403_FORBIDDEN, detail="Invalid credentials")


class TokenService:
    def __init__(self):
        self.secret = Settings.secret
        self.minutes = Settings.minutes
        self.username = Settings.username
        self.password = Settings.password
        self.algorithm = Settings.algorithm

    def generate(self, login: Login) -> Token:
        expiration = time.time() + (self.minutes * 60)

        if login.username != self.username or login.password != self.password:
            raise HTTPException(status_code=status.HTTP_403_FORBIDDEN, detail="Invalid credentials")

        return Token(
            token=jwt.encode({'user': login.username, 'expires': expiration}, self.secret, algorithm=self.algorithm),
            type='Bearer',
            expiration=expiration
        )
