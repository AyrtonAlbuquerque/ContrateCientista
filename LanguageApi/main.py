import uvicorn
from fastapi import FastAPI
from routes import language

app = FastAPI(title="Language Processing API", version="1.0")


@app.get("/", name="Health Check", tags=["Health"])
async def get():
    return {"message": "Language Processing API"}


if __name__ == "__main__":
    app.include_router(language.router)
    uvicorn.run(app)
