import uvicorn
from fastapi import FastAPI
from routes import language, auth

app = FastAPI(title="Language Processing API", version="1.0")

if __name__ == "__main__":
    auth = auth.Auth()
    language = language.Language()
    app.include_router(auth.router)
    app.include_router(language.router)
    uvicorn.run(app)
