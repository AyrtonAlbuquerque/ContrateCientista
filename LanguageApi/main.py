import uvicorn
from fastapi import FastAPI
from middleware.exception import ExceptionMiddleware
from routes import language, auth

# Endpoints
auth = auth.Auth()
language = language.Language()

# Configurations
app = FastAPI(title="Language Processing API", version="1.0")
app.add_middleware(ExceptionMiddleware)
app.include_router(auth.router)
app.include_router(language.router)

if __name__ == "__main__":
    uvicorn.run(app)
