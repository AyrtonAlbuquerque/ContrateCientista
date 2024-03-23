class Settings:
    secret: str = "8eb02c36a038cd2c6f2a888b926ff3ff5812a1855e55bba3b33577e15977eee2"
    minutes: int = 60
    algorithm: str = "HS256"
    email: str = "direc-ct@utfpr.edu.br"
    password: str = "ozxelq12"
    # Bert
    bert_model: str = "neuralmind/bert-large-portuguese-cased"
    pipeline: str = "pt_core_news_lg" # "pt_core_news_lg" => accuracy or "pt_core_news_sm" => efficiency
    stop_words: str = "portuguese"
    # GPT
    openai_key: str = "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"
    gpt_model: str = "gpt-3.5-turbo"
    temperature: float = 0.2
    top_p: float = 0.1
    max_tokens: int = 1024
    system_content: str = "You will be provided with a block of text, and your task is to extract a list of keywords/keyphrases from it and attribute a score of how accurate the keyword/keyphrase is in relation to the text. The score must be between 0 and 1. The response should be in the format: [{\"text\": \"keyword1\", \"weight\": 0.9}, {\"text\": \"keyword2\", \"weight\": 0.8}]"
