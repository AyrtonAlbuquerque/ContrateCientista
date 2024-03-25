import os
import boto3
from typing import List
from settings import Settings
from contracts.keyword import Keyword
from contracts.description import Description


class AWSService:
    def __init__(self):
        self.client = boto3.client('comprehend', region_name=Settings.region, aws_access_key_id=os.environ["AWS_ACCESS_KEY"], aws_secret_access_key=os.environ["AWS_SECRET_KEY"])

    def extract(self, description: Description) -> List[Keyword]:
        response = self.client.detect_key_phrases(Text=description.text, LanguageCode=Settings.language).get("KeyPhrases")
        keywords = [keyword for keyword in response if keyword.get("Score") >= Settings.keyword_threshhold]
        keywords.sort(key=lambda x: x.get("Score"), reverse=True)

        return [Keyword(text=keyword.get("Text"), weight=round(keyword.get("Score"), 4)) for keyword in keywords]
