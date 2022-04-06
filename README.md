# Contacts App
## Sadržaj
Projekt se sastoji od 3 aplikacije:
- ASP.NET Web API
- ASP.NET MVC Web aplikcaije
- C# Library sa podacima

Kako bi Web aplikacija mogla raditi, prvo je potrebno pokrenuti REST API. Po defaultu, projekt je sam sebi složio da se REST API pokreće na adresi `http://localhost:61436`. Nakon što je pokrenuta aplikcaija od REST API, Web aplikacija bi trebala raditi ispravno.

## Web App
Web aplikacija se sastoji od dvije stranice. Pregled svih kontakata i dodavanje novog kontaka.

Ukoliko je potrebno mijenjati adresu do REST API-a, potrebno je u klasi `Contacts_App.Api.Factories.ApiFactory` promijeniti vrijednost konstante `ENDPOINT_URL` na novu adresu. (Nakon toga bi, nadam se, trebalo biti sve u redu).

## REST API
Nakon što je pokrenuta aplikacija za REST API nude se sljedeće mogučnosti. REST API sprema podatke u file `contacts.json` koji se nalazi na REST API poslužitelju.

REST API url: http://localhost:61436/api
| Endpoint              | HttpMethod    | Prima         | Vraća     | Opis  |
| -                     |-              | -             | -         | -     |
| `/Contacts`           | `GET`         | `-`           | `json`    | Popis svih kontakata |
| `/Contacts/Add`       | `POST`        | `json`        | `-`       | Pohranjuje kontakt |
| `/Contacts/Delete`    | `DELETE`      | ?email=`str`  | `-`       | Briše kontakt |