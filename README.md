# WordCounterApp

**Zadatak:**

*Potrebno je napraviti klijent aplikaciju (Console, Wpf, Angular... )koja ce da cita tekst na tri nacina iz File-a, baze ili sam korisnik unosi tekst. Tekst treba da se posalje na server (REST ili WCF) koji ce da izracuna broj reci u tekstu i posalje odgovor na klijent aplikaciju koja ce rezultat obrade prikazati klijentu. Fokus zadatka jeste na aritekturi i pattern-ima, i primeni tog znanja na zadatak - n-tier, SOA, Dependency Injection, Factory, Repository i slično.*

*Koriscenje third party biblioteka je dozvoljeno.*

---

# Brief Instructions:

WordCounter.Server is a .Net Core Web Api app, run it and it will listen for requests
 on port 3000. WordCounter.Client is a .Net Core Console app, run it and it will prompt you for input. Options are *c* - parses text entered through console, *f* - searches and parses a file on the file system, *d* - connects to database and parses text (implemented only for Mongo DB). 

## A quick way to standup a Mongo DB instance with Docker

Create an instance:
*docker run -p 27017:27017 --name mongo_instance -d mongo*

Open Mongo shell:
*docker exec -it mongo_instance mongo*

Create a database:
*use word_counter_db*

Insert into collection:
*db.word_counter_collection.insertOne({_id: "1234", sample_text: "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit"})*

# Reqest body for database option
```json
{
  "Config": {
    "Provider": "MongoDB",
    "HostUrl": "localhost",
    "Database": "word_counter_db",
    "Username": "",
    "Password": "",
    "Table": "word_counter_collection",
    "RecordId": "1234",
    "ColumnName": "sample_text"
  },
  "Type": 1
}
```