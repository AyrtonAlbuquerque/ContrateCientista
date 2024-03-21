class Settings:
    secret: str = "8eb02c36a038cd2c6f2a888b926ff3ff5812a1855e55bba3b33577e15977eee2"
    minutes: int = 60
    algorithm: str = "HS256"
    username: str = "utfpr.direc"
    password: str = "ozxelq12"
    model: str = "neuralmind/bert-large-portuguese-cased"
    pipeline: str = "pt_core_news_lg" # "pt_core_news_lg" => accuracy or "pt_core_news_sm" => efficiency
    stop_words: str = "portuguese"
