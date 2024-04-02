from pydantic import BaseModel


class Error(BaseModel):
    detail: str

    def toJSON(self):
        return {"detail": f'LanguageAPI Error: {self.detail}'}
