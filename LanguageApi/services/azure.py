import os
from typing import List
from settings import Settings
from contracts.keyword import Keyword
from contracts.description import Description
from azure.core.credentials import AzureKeyCredential
from azure.ai.textanalytics import TextAnalyticsClient


class AzureServices:
    def __init__(self):
        self.client = TextAnalyticsClient(endpoint=Settings.endpoint, credential=AzureKeyCredential(os.environ["AZURE_LANGUAGE_KEY"]))

    def extract(self, description: Description) -> List[Keyword]:
        return [Keyword(text=keyword, weight=Settings.keyword_threshhold) for keyword in self.client.extract_key_phrases([description.text], language=Settings.language)[0].get("key_phrases")]
