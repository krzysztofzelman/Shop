# Nauka C# — Sklep (dziennik)

**DZIEŃ 1 (2026-09-06, niedziela) — START Etapu 0 ✅.** User: „tworzymy ten e-commerce?" → rusza projekt-powtórka SKLEP (decyzja z sesji po Dniu 29 Magazynu). Wybory usera (A/B/C): nazwa **Sklep**, struktura **własny folder + własne rozwiązanie** (portfolio, „żeby wyglądało profesjonalnie").

**Struktura (utworzona przez asystenta CLI):** `D:\Dane\Projekty\NaukaCSharp\Sklep\` = `Sklep.slnx` + `src\Sklep.Shared` (classlib) + `src\Sklep.Api` (webapi --use-controllers) + `src\Sklep.Web` (blazor InteractiveServer). Refs: Api→Shared, Web→Shared; `Microsoft.Data.Sqlite` 10.0.11 w Api. Usunięte próbki: Class1.cs + WeatherForecast.cs + WeatherForecastController.cs (w Web Counter/Weather/NavMenu NA RAZIE zostają — porządki przy stronie). Build zielony ×2 (CLI).

**⚠️ Wpadka 1 — scaffolding bez pytania:** user: „czemu to zrobiłeś a nie ja to robiłem" → szkielet zostaje (wybór usera), zasada na przyszłość: **każdy plik pisze user, asystent prowadzi/sprawdza; operacje strukturalne (tworzenie projektów) — pytać PRZED**. (Ten sam wzorzec co MagazynShared 08-29.)

**Krok 1 — Product.cs ✅ (wpisany przez usera, w Sklep.Shared):** wzorzec 1:1 `MagazynShared\Item.cs` — klasa BEZ namespace i usings (jak modele Magazynu; cross-project działa — sprawdzone): `Id`, `Name`, `Quantity`, `Price`.

**⚠️ Wpadka 2 — odpowiedź na pytanie rozrośnięta w wykład:** pytanie usera mid-typing: „{ get; set; } co to jest?" → asystent pokazał PEŁNĄ wersję (pole `_id`, `value`, auto-property, „drzwi") → user: „coś mi tu nie podoba się... znowu jedziesz z kodem co ja nie wiem co znaczy. tak to nie będzie" → reset + przeprosiny; minimalna wersja, która została: **„get = pozwala czytać, set = pozwala pisać; C# sam trzyma wartość w środku" — tyle na dziś** (to NIE był koncept tej sesji; wzorzec w Product.cs = ten sam co setki razy w Magazynie). Wzorzec → feedback/student-writes-code: na pytanie mid-typing odpowiadać MINIMALNIE, zero nowego kodu/terminów bez potrzeby.

**Krok 2 — API wstaje ✅ (user):** start Sklep.Api → „Application started", „Now listening on: http://localhost:5143" (+ https 7104) → to też dowód, że Product.cs się kompiluje (dotnet run buduje całość przed startem). 404 na starcie = OK — API nie ma jeszcze endpointów (prze-frame'd przed otwarciem przeglądarki).

⏭️ **Następna sesja (Etap 0 cd.):** 1) baza: folder `Sklep\Baza\` (wzór MagazynBaza) + `ConnectionStrings:SklepDb` w `Sklep.Api\appsettings.json` (absolutna ścieżka, wzór MagazynDb) + `CREATE TABLE IF NOT EXISTS Produkty` w `Program.cs` (wzór Partie) → restart API → sprawdzić, czy `sklep.db` powstał; 2) kontroler `/api/Product` (GET pierwszy, potem POST/PUT/DELETE); 3) strona Blazor. Przy okazji Web: decyzja portów/startup (wzór Magazyn: jeden klawisz, usunąć https, stałe porty).

---

**DZIEŃ 2 (2026-09-07, poniedziałek) — SESJA KRÓTKA, ZAMKNIĘTA ✅ (user zmęczony, późno).** Cel: baza danych (Etap 0 cd.).

**Zmiany nazw (user, sam):** folder projektu `Sklep` → **`Shop`** (`D:\Dane\Projekty\NaukaCSharp\Shop`); folder na bazę → **`database`** (próby: Base → database). Nazwy wewnątrz (Sklep.slnx, Sklep.Api...) bez zmian — nie przeszkadza.

**Decyzja (user):** baza **od razu po angielsku** — tabela `Products` (kolumny 1:1 z Product.cs: Id, Name, Quantity, Price), spójnie z klasą EN; folder/projekt (niekod) zostają PL/Shop. Wzorzec → user/english-level: podawać GOTOWE słowa EN z PL znaczeniem.

**Krok 2 ✅ — `ConnectionStrings:ShopDb` w `Sklep.Api\appsettings.json`:** `"Data Source=D:\\Dane\\Projekty\\NaukaCSharp\\Shop\\database\\shop.db"` (wzór MagazynDb). JSON: 3 sekcje na równym poziomie, przecinek między parami, `\\` = jeden `\` w ścieżce. Wpadka: wklejenie rozjechało strukturę (sekcja w środku Logging, zgubiony LogLevel, brak klamry, stara nazwa Base) → asystent przepisał plik całością (write_file; VS → „zmieniony poza edytorem" → Tak). `appsettings.Development.json` miał przypadkowe zmiany wcięć (residuum wklejania) → cofnięte `git checkout`. **Uwaga dla asystenta: user mylił appsettings.json z appsettings.Development.json przy wklejaniu.**

**Krok 3 NIEZROBIONY** (Program.cs: `using Microsoft.Data.Sqlite;` na górze + blok `CREATE TABLE IF NOT EXISTS Products` przed `app.Run();`, wzór Partie z MagazynApi). User: „za duży tu jest chaos nauki" — po 2 nieporozumieniach (asystent tłumaczył Program.cs zamiast JSON-a) → reset + mapa + wybór zamknięcia dnia (A/B). Wzorzec: pacing-check-first — nie lecieć do następnego kroku, zanim poprzedni nie zostanie ZROZUMIANY.

⏭️ **Następna sesja:** Krok 3 (2 zmiany w Program.cs, małe kawałki) → restart API (user) → sprawdzić, czy `Shop\database\shop.db` powstał → potem kontroler `/api/Product`.
