import uvicorn
from fastapi import FastAPI
from keybert import KeyBERT
from settings import Settings
from routes import language, auth

app = FastAPI(title="Language Processing API", version="1.0")
model = KeyBERT(model=Settings.model)


@app.get("/", name="Health Check", tags=["Health"])
async def get():
    return {"message": "Language Processing API"}


if __name__ == "__main__":
    app.include_router(auth.router)
    app.include_router(language.router)
    uvicorn.run(app)
