import uvicorn
from fastapi import FastAPI
from middleware.exception import ExceptionMiddleware
from routes import extract, auth, analyze

# Endpoints
auth = auth.Auth()
extract = extract.Extract()
analyze = analyze.Analyze()


# Configurations
app = FastAPI(title="Language Processing API", version="1.0")
app.add_middleware(ExceptionMiddleware)
app.include_router(auth.router)
app.include_router(extract.router)
app.include_router(analyze.router)

if __name__ == "__main__":
    uvicorn.run(app)
