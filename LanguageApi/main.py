import uvicorn
from fastapi import FastAPI
from keybert import KeyBERT
from flair.embeddings import TransformerDocumentEmbeddings
from settings import Settings
from routes import language, auth

app = FastAPI(title="Language Processing API", version="1.0")

# Preloading
KeyBERT(model=TransformerDocumentEmbeddings(Settings.model))

if __name__ == "__main__":
    app.include_router(auth.router)
    app.include_router(language.router)
    uvicorn.run(app)
