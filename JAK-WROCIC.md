# Jak wrócić do Shopa po przerwie

Kartka na start po każdej przerwie — nie trzeba nic pamiętać ani niczego szukać.

## 1. Uruchomienie lokalnie (Windows, Visual Studio)
1. Otwórz `D:\Dane\Projekty\NaukaCSharp\Shop\Shop.slnx` w Visual Studio.
2. `Ctrl+F5` (nie F5) — startuje API **i** stronę.
3. Wejdź na: **http://localhost:5107/products**
4. Hasło bramy lokalnie: **dev123** (`Shop\src\Shop.Web\appsettings.json` i `Shop\src\Shop.Api\appsettings.json`).
5. Zatrzymanie: `Shift+F5`.

## 2. Wersja na serwerze (VPS)
- Adres: **http://31.3.218.196:5107/products**
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
1. Kolumna „Wartość" (ilość × cena) w `Products.razor`.
2. Domena + HTTPS przez nginx (dziś hasło idzie po HTTP jawnym tekstem).
3. Utrwalanie kodu — po JEDNYM pliku na sesję.

## 5. Po przerwie: pierwszy krok to 5 minut
Nie „nadrabianie" — jedno kliknięcie: `Ctrl+F5` → `http://localhost:5107/products` → zaloguj `dev123` → zobacz, że tabela działa. To wystarczy, żeby wejść z powrotem w projekt.
