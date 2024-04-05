import os
import boto3
import uvicorn
from azure.ai.textanalytics import TextAnalyticsClient
from azure.core.credentials import AzureKeyCredential
from botocore.client import BaseClient
from dotenv import load_dotenv
from fastapi import FastAPI
from flair.embeddings import TransformerDocumentEmbeddings
from keybert import KeyBERT
from keyphrase_vectorizers import KeyphraseCountVectorizer
from openai import OpenAI
from sentence_transformers import SentenceTransformer
from simple_injection import ServiceCollection
from yake import KeywordExtractor
from middleware.exception import ExceptionMiddleware
from routes.analyze import Analyze
from routes.auth import Auth
from routes.extract import Extract
from services.analysis import AnalysisService
from services.authentication import AuthenticationService
from services.extraction import ExtractionService
from services.interfaces.ianalysis import IAnalysisService
from services.interfaces.iauthentication import IAuthenticationService
from services.interfaces.iextraction import IExtractionService

load_dotenv()

# Dependency Injection
services = ServiceCollection()

# Add Routes
services.add_singleton(Auth)
services.add_singleton(Analyze)
services.add_singleton(Extract)

# Add Services
services.add_transient(IAuthenticationService, AuthenticationService)
services.add_transient(IAnalysisService, AnalysisService)
services.add_transient(IExtractionService, ExtractionService)

# Add Dependencies
services.add_instance(SentenceTransformer, SentenceTransformer(os.environ["SBERT_MODEL"]))
services.add_instance(BaseClient, boto3.client('comprehend', region_name=os.environ["REGION"], aws_access_key_id=os.environ["AWS_ACCESS_KEY"], aws_secret_access_key=os.environ["AWS_SECRET_KEY"]))
services.add_instance(OpenAI, OpenAI(api_key=os.environ["OPENAI_API_KEY"]))
services.add_instance(KeyBERT, KeyBERT(model=TransformerDocumentEmbeddings(os.environ["BERT_MODEL"])))
services.add_instance(KeyphraseCountVectorizer, KeyphraseCountVectorizer(spacy_pipeline=os.environ["PIPELINE"], stop_words=os.environ["STOP_WORDS"], custom_pos_tagger=ExtractionService.pos_tagger))
services.add_instance(KeywordExtractor, KeywordExtractor(lan=os.environ["LANGUAGE"], n=int(os.environ["NGRAM_SIZE"]), dedupLim=float(os.environ["DEDUPLICATION_THRESHOLD"])))
services.add_instance(TextAnalyticsClient, TextAnalyticsClient(endpoint=os.environ["ENDPOINT"], credential=AzureKeyCredential(os.environ["AZURE_LANGUAGE_KEY"])))

# Configure FastAPI
app = FastAPI(title="Language Processing API", version="1.0")
app.add_middleware(ExceptionMiddleware)
app.include_router(services.resolve(Auth).router)
app.include_router(services.resolve(Analyze).router)
app.include_router(services.resolve(Extract).router)

if __name__ == "__main__":
    uvicorn.run(app)
