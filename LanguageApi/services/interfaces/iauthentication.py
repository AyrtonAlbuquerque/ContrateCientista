from abc import ABC, abstractmethod
from contracts.login import Login, Token


class IAuthenticationService(ABC):
    @abstractmethod
    def generate_token(self, login: Login) -> Token:
        pass
