import os
import json
from typing import List
from openai import OpenAI
from settings import Settings
from contracts.description import Description
from contracts.keyword import Keyword


class GPTService:
    def __init__(self):
        self.client = OpenAI(api_key=os.environ["OPENAI_API_KEY"])

    def extract(self, description: Description) -> List[Keyword]:
        response = json.loads(self.client.chat.completions.create(
            model=Settings.gpt_model,
            messages=[
                {
                    "role": "system",
                    "content": Settings.system_content
                },
                {
                    "role": "user",
                    "content": description.text
                }
            ],
            temperature=Settings.temperature,
            max_tokens=Settings.max_tokens,
            top_p=Settings.top_p
        ).choices[0].message.content)
        keywords = [keyword for keyword in response if keyword.get("weight") >= Settings.keyword_threshhold]
        keywords.sort(key=lambda x: x.get("weight"), reverse=True)

        return [Keyword(text=keyword.get("text"), weight=keyword.get("weight")) for keyword in keywords]
