Консольное приложения для обновления какого-либо другого указанного в конфиге приложения. Для этого требуется загрузить
 билд приложения в приватный гитхаб репозиторий и создать приватный ключ.
 Далее создайте Config.json в билде updater-а и занесите в него следующую структуру:
 {
  "RepoOwner": "ВашЛогин",
  "RepoName": "НазваниеРепозитория",
  "Token": "ПриватныйКлюч",
  "AppName": "НазваниеExeФайлаОбновляемогоПриложения"
}