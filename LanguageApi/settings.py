class Settings:
    secret: str = "8eb02c36a038cd2c6f2a888b926ff3ff5812a1855e55bba3b33577e15977eee2"
    minutes: int = 60
    algorithm: str = "HS256"
    email: str = "direc-ct@utfpr.edu.br"
    password: str = "ozxelq12"
    language: str = "pt"
    ngram_size: int = 5
    keyword_threshhold: float = 0.6

    #SBERT
    sbert_model: str = "sentence-transformers/paraphrase-multilingual-mpnet-base-v2" # list of pre-treined models: https://www.sbert.net/docs/pretrained_models.html and on hub: https://huggingface.co/sentence-transformers

    # Bert
    bert_model: str = "neuralmind/bert-large-portuguese-cased"
    pipeline: str = "pt_core_news_lg" # ["pt_core_news_lg" => accuracy] or ["pt_core_news_sm" => efficiency]
    stop_words: str = "portuguese"

    # Yake
    deduplication_threshold: float = 0.9

    # GPT
    # openai_api_key: Using OS environment variable: On windows: setx OPENAI_API_KEY “<yourkey>” On Linux: echo "export OPENAI_API_KEY='yourkey'" >> ~/.zshrc then source ~/.zshrc (.bash_profile if bash)
    gpt_model: str = "gpt-3.5-turbo"
    temperature: float = 0.2
    top_p: float = 0.1
    max_tokens: int = 1024
    system_content: str = "You will be provided with a block of text, and your task is to extract a list of keywords/keyphrases from it and attribute a score of how accurate the keyword/keyphrase is in relation to the text. The score must be between 0 and 1. The response should be in the format: [{\"text\": \"keyword1\", \"weight\": 0.9}, {\"text\": \"keyword2\", \"weight\": 0.8}]"

    # AWS Comprenhend
    region: str = "us-east-2"
    # aws_access_key: Using OS environment variable: On windows: setx AWS_ACCESS_KEY “<yourkey>” On Linux: echo "export AWS_ACCESS_KEY='yourkey'" >> ~/.zshrc then source ~/.zshrc (.bash_profile if bash)
    # aws_secret_key: Using OS environment variable: On windows: setx AWS_SECRET_KEY “<yourkey>” On Linux: echo "export AWS_SECRET_KEY='yourkey'" >> ~/.zshrc then source ~/.zshrc (.bash_profile if bash)

    # Azure
    # azure_language_key: Using OS environment variable: On windows: setx AZURE_LANGUAGE_KEY “<yourkey>” On Linux: echo "export AZURE_LANGUAGE_KEY='yourkey'" >> ~/.zshrc then source ~/.zshrc (.bash_profile if bash)
    endpoint: str = "https://contrate-cientista-language-service.cognitiveservices.azure.com/"
