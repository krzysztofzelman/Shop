# Jak wrócić do Shopa po przerwie

Kartka na start po każdej przerwie — nie trzeba nic pamiętać ani niczego szukać.

## 1. Uruchomienie lokalnie (Windows, Visual Studio)
1. Otwórz `D:\Dane\Projekty\Nauka C#\Shop\Shop.slnx` w Visual Studio.
2. `Ctrl+F5` (nie F5) — startuje API **i** stronę.
3. Wejdź na: **http://localhost:5107/products**
4. Logowanie lokalnie: **`anna` / `secret1`** (konto z bazy `database/shop.db`). Stare `dev123` **już nie działa** — bramy z `SecretKey` nie ma.
5. **Stan 2026-11-17: działa.** Po zalogowaniu `anna`/`secret1` → `/products` pokazuje 7 produktów. Krok 4 część 3 (klient tokenu) zamknięty: token z `POST /api/User/Login` siedzi w `AuthState`, a `TokenHandler` dokleja nagłówek `X-Token` do każdego żądania. `krzys` / `test123` NIE działa (w bazie ma hasło jawne, a `Login` porównuje odciski SHA256).
6. Zatrzymanie: `Shift+F5`.

## 2. Wersja na serwerze (VPS)
- Adres: **https://shop.kzelman.pl/products** (HTTPS; dawny adres po IP `http://31.3.218.196:5107` jest WYŁĄCZONY i nie odpowiada)
- Hasło bramy: w pliku `C:\Users\krzys\shop-vps-haslo.txt` (inne niż lokalne `dev123`).
- SSH na serwer: klucz `vps_magazyn`, port 2022, kod w `/root/shop`.
- Wdrożenie zmiany: na serwerze `git pull --ff-only` → `docker compose up -d --build shop-web` (albo `shop-api`, jeśli zmieniał się backend).

## 3. Gdzie co leży
- `Shop\src\Shop.Web\` — strona (Blazor): `Components\Pages\Products.razor`, `Orders.razor`, `OrderDetails.razor`
- `Shop\src\Shop.Api\` — serwer: `Program.cs` (brama `X-Token`) + `Controllers\`
- `Shop\src\Shop.Shared\` — modele `Product`, `Order`, `OrderItem`
- `Shop\shop-notes.md` — dziennik: każdy dzień, co weszło i co zostało
- `Shop\docker-compose.yml` + `Shop\.env` — Docker lokalnie

## 4. Co dalej (kolejka)
1. **Backend najpierw** (ustalone 2026-11-04): walidacja i kody błędów — `POST` ZROBIONY (2026-11-05), `PUT` ZROBIONY (2026-11-06), `PUT` na nieistniejący `id` → `404` ZROBIONY (2026-11-07), `DELETE` na nieistniejący `id` → `404` ZROBIONY (2026-11-07), strona pokazuje błąd z API (pasek `Name is required` / `API Error: NotFound`, wspólna metoda `SetError`) ZROBIONE (2026-11-07 wieczór), paginacja (`GET /api/Product?page=2` + przyciski `Poprzednia` / `Strona: N` / `Następna` na `/products`) ZROBIONA (2026-11-08), wyszukiwanie (`GET /api/Product?search=…`, `LIKE` + `%` + `Trim()`, pole „Szukaj" na `/products`) ZROBIONE (2026-11-08, druga sesja); konta (`Users`, hash hasła, token zamiast wspólnego `SecretKey`): krok 1 ZROBIONY (2026-11-10) — model `User`, tabela `Users`, `POST /api/User` z walidacją, oba testy przeszły; krok 2 ZROBIONY (2026-11-11) — `POST /api/User/Login` w `Shop\src\Shop.Api\Controllers\UserController.cs`: `SELECT Id FROM Users WHERE Login = @Login AND Password = @Password` + `ExecuteReader`/`Read()` → `Ok()` (200), inaczej `Unauthorized()` (401); test na `krzys`/`test123` → 200, na `krzys`/`zlehaslo` → 401 (nagłówek `X-Secret` obowiązkowy, inaczej brama oddaje 401 przed kontrolerem); krok 3 ZROBIONY (2026-11-11) — hash hasła `SHA256` w metodzie `HashPassword` (`GetBytes` → `HashData` → `ToHexString`), podpięty w `RegisterUser` (zapis odcisku) i `Login` (porównanie odcisków); test na nowym koncie `anna`/`secret1` → 200 i 200, złe hasło → 401, a stare `krzys`/`test123` → 401 (ma hasło jawne); dowód z bajtów `shop.db`: `secret1` nie występuje, login `anna` czytelny, jeden skrót 64-znakowy; krok 4 (token) CZĘŚĆ 1 ZROBIONA (2026-11-12) — piąty blok `CREATE TABLE ... Tokens` w `Shop\src\Shop.Api\Program.cs` (`Id`, `UserId`, `Value`); CZĘŚĆ 2 ZROBIONA I PRZETESTOWANA (2026-11-12) — `Login` w `UserController.cs` czyta `Id` do `userId`, robi strażnika `if (userId == 0) → Unauthorized()`, tworzy `Guid.NewGuid().ToString()`, wrzuca `INSERT INTO Tokens (UserId, Value)` na tym samym połączeniu i oddaje `Ok(token)`; test `anna`/`secret1` → 36-znakowy GUID; CZĘŚĆ 3 PO STRONIE API ZROBIONA I PRZETESTOWANA (2026-11-13) — metoda `TokenExists` w `Shop\src\Shop.Api\Program.cs` (`SELECT Id FROM Tokens WHERE Value = @Value` + `ExecuteReader`/`Read()`), brama czyta nagłówek `X-Token` i pyta bazę (`if (TokenExists(token) == false)`), `cs` przeniesione NAD bramę, wyjątek `StartsWithSegments("/api/User")` przepuszcza `Login` i `RegisterUser`; test: `Login` → GUID w `$t`, `GET /api/Product` z `X-Token` → 7 produktów, zły token → `401`; **krok 4 część 3 (KLIENT) ZROBIONY 2026-11-17 (Dzień 40)** — `AuthState.Token`, nowy `Shop\src\Shop.Web\TokenHandler.cs` (`DelegatingHandler` doklejający `X-Token` przy każdym żądaniu), `Shop.Web\Program.cs` bez `X-Secret`, `Login.razor` pyta `POST /api/User/Login` i zapisuje token, „Wyloguj" czyści token; test usera w przeglądarce ZALICZONY (7 produktów). **2026-11-16 (Dzień 39):** po rename folderu na „Nauka C#" sprawdzone — bazy, buildy i oba API zdrowe, winny był niedokończony klient; pełna diagnoza i plan w `shop-notes.md`, sekcja „DZIEŃ 39", a domknięcie w sekcji „DZIEŃ 40".
2. Czytanie kodu: przystanek 5 — `@code` w `Shop\src\Shop.Web\Components\Pages\Products.razor`. **2026-11-09 (Dzień 34):** przeczytane do końca `SearchProducts()` (dwie linie: `currentPage = 1;` i `await LoadProducts();`) — dalej od `LoadProducts()` i linii z adresem, po jednej linii i jednym zdaniu, bez tabelek.
3. Etap 2 — koszyk. React dopiero osobno, po JS/TS i po tym, jak API ma co pokazać.

**⚠️ Zrobione, ale NIE na serwerze (stan 2026-11-17):** krok 4 część 3 (klient tokenu) działa **tylko lokalnie**. Na VPS trzeba: `git pull --ff-only` → `docker compose up -d --build shop-api` **i** `shop-web` (brama i klient zmieniły się razem). Do tego czasu `https://shop.kzelman.pl` chodzi na starym układzie (hasło bramy z pliku `C:\Users\krzys\shop-vps-haslo.txt`).

**Drobne, zostawione na później:** wylogowanie nie unieważnia tokenu w tabeli `Tokens`; konto `krzys`/`test123` w bazie ma hasło jawne i nie działa (skasować albo zarejestrować od nowa).

## 5. Po przerwie: pierwszy krok to 5 minut
Nie „nadrabianie" — jedno kliknięcie: `Ctrl+F5` → `http://localhost:5107/products` → zaloguj **`anna` / `secret1`** → zobacz, że tabela pokazuje **7 produktów**. To cały „powrót do rytmu": kod, serwer i dane stoją, nic nie trzeba odtwarzać. Szczegóły i kolejka: `shop-notes.md`, sekcja „DZIEŃ 40".
