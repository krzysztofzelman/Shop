# Jak wrócić do Shopa po przerwie

Kartka na start po każdej przerwie — nie trzeba nic pamiętać ani niczego szukać.

## 1. Uruchomienie lokalnie (Windows, Visual Studio)
1. Otwórz `D:\Dane\Projekty\NaukaCSharp\Shop\Shop.slnx` w Visual Studio.
2. `Ctrl+F5` (nie F5) — startuje API **i** stronę.
3. Wejdź na: **http://localhost:5107/products**
4. Hasło bramy lokalnie: **dev123** (`Shop\src\Shop.Web\appsettings.json` i `Shop\src\Shop.Api\appsettings.json`).
5. Zatrzymanie: `Shift+F5`.

## 2. Wersja na serwerze (VPS)
- Adres: **https://shop.kzelman.pl/products** (HTTPS; dawny adres po IP `http://31.3.218.196:5107` jest WYŁĄCZONY i nie odpowiada)
- Hasło bramy: w pliku `C:\Users\krzys\shop-vps-haslo.txt` (inne niż lokalne `dev123`).
- SSH na serwer: klucz `vps_magazyn`, port 2022, kod w `/root/shop`.
- Wdrożenie zmiany: na serwerze `git pull --ff-only` → `docker compose up -d --build shop-web` (albo `shop-api`, jeśli zmieniał się backend).

## 3. Gdzie co leży
- `Shop\src\Shop.Web\` — strona (Blazor): `Components\Pages\Products.razor`, `Orders.razor`, `OrderDetails.razor`
- `Shop\src\Shop.Api\` — serwer: `Program.cs` (brama `X-Secret`) + `Controllers\`
- `Shop\src\Shop.Shared\` — modele `Product`, `Order`, `OrderItem`
- `Shop\shop-notes.md` — dziennik: każdy dzień, co weszło i co zostało
- `Shop\docker-compose.yml` + `Shop\.env` — Docker lokalnie

## 4. Co dalej (kolejka)
1. **Backend najpierw** (ustalone 2026-11-04): walidacja i kody błędów — `POST` ZROBIONY (2026-11-05), `PUT` ZROBIONY (2026-11-06), `PUT` na nieistniejący `id` → `404` ZROBIONY (2026-11-07), `DELETE` na nieistniejący `id` → `404` ZROBIONY (2026-11-07), strona pokazuje błąd z API (pasek `Name is required` / `API Error: NotFound`, wspólna metoda `SetError`) ZROBIONE (2026-11-07 wieczór), paginacja (`GET /api/Product?page=2` + przyciski `Poprzednia` / `Strona: N` / `Następna` na `/products`) ZROBIONA (2026-11-08), wyszukiwanie (`GET /api/Product?search=…`, `LIKE` + `%` + `Trim()`, pole „Szukaj" na `/products`) ZROBIONE (2026-11-08, druga sesja); dalej: konta (`Users`, hash hasła, token zamiast wspólnego `SecretKey`) → kilka testów kontrolera.
2. Czytanie kodu: przystanek 5 — `@code` w `Shop\src\Shop.Web\Components\Pages\Products.razor`. **2026-11-09 (Dzień 34):** przeczytane do końca `SearchProducts()` (dwie linie: `currentPage = 1;` i `await LoadProducts();`) — dalej od `LoadProducts()` i linii z adresem, po jednej linii i jednym zdaniu, bez tabelek.
3. Etap 2 — koszyk. React dopiero osobno, po JS/TS i po tym, jak API ma co pokazać.

## 5. Po przerwie: pierwszy krok to 5 minut
Nie „nadrabianie" — jedno kliknięcie: `Ctrl+F5` → `http://localhost:5107/products` → zaloguj `dev123` → zobacz, że tabela działa. To wystarczy, żeby wejść z powrotem w projekt.
