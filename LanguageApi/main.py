import uvicorn
from fastapi import FastAPI
from routes import language
from keybert import KeyBERT

app = FastAPI(title="Language Processing API", version="1.0")
model = KeyBERT(model='paraphrase-multilingual-MiniLM-L12-v2')


@app.get("/", name="Health Check", tags=["Health"])
async def get():
    return {"message": "Language Processing API"}


if __name__ == "__main__":
    app.include_router(language.router)
    uvicorn.run(app)
