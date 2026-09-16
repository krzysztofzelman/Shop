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

---

**DZIEŃ 3 (2026-09-09, środa) — SESJA ZAMKNIĘTA ✅ (2 przerwy: aktualizacja systemu + zamknięcie dnia).** Start: user: „działamy dalej z ecommerce?" → status + powtórka mapy (co robiliśmy i w jakich plikach): root `Shop\` = plik rozwiązania + `src\Sklep.Shared\Product.cs` (model) + `src\Sklep.Api\Program.cs` (start API) + `appsettings.json` (ShopDb → ścieżka bazy). Zagadka kontrolna: do którego pliku klasa Category / gdzie zapisany port? — odpowiedzi w mapie.

**Nowy koncept (pytanie usera) — port 5143:** NIE standard platformy; **szablon `dotnet new webapi` losuje port RAZ przy tworzeniu projektu** i zapisuje NA STAŁE w `Sklep.Api\Properties\launchSettings.json` → `dotnet run` czyta plik przy każdym starcie. Port = „numer mieszkania w bloku" (analogia przyjęta). Korekta błędnej parafrazy: losuje SZABLON (nie system), przy TWORZENIU (nie instalacji), RAZ (nie co start); zmiana = ręczna w pliku; launchSettings.json nie pisze się ręcznie — generuje go szablon („fabryka projektów"). Spacer komend scaffolding z Dnia 1 odtworzony: `dotnet new sln/classlib/webapi/blazor` → `sln add` ×3 → `add reference` ×2 → `add package Microsoft.Data.Sqlite` → `build`.

**⚠️ Dysk (Dzień 3): plik rozwiązania = `Shop\Shop.slnx`** (user przemianował na dysku; w repo widać: Sklep.slnx usunięty + Shop.slnx nowy).

**Krok 3 ✅ — tabela Products:** pełny kod przekazany userowi do wpisania (wzór Partie z MagazynApi pokazany obok): zmiana 1 — `using Microsoft.Data.Sqlite;` na górze Program.cs; zmiana 2 — blok między `app.MapControllers();` a `app.Run();`: `string cs = ...GetConnectionString("ShopDb")` + `using (SqliteConnection...) { Open; CreateCommand; CommandText = "CREATE TABLE IF NOT EXISTS Products (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Quantity INTEGER, Price REAL)"; ExecuteNonQuery(); }`. Ramka „list do bazy" (cs = adres z appsettings; otwarcie = SQLite tworzy plik shop.db sam; CommandText = tekst listu; ExecuteNonQuery = rozkaz, cisza = sukces). Wpadka usera: fragment wpisany z wieloma literówkami (Shop.Db zamiast ShopDb; pomylone SqliteCommand/SqliteConnection; `CreateComand`, `ExecuteText`, „CREA TE", „KAY", „Quantrity") → asystent poprawił cały fragment (user: „sprawdzi jak coś to popraw"). Start API → „Application started" + **`Shop\database\shop.db` istnieje ✅** (glob potwierdził).

⏭️ **Następna sesja:** kontroler `/api/Product` (GET → POST/PUT/DELETE, wzór BatchController z MagazynApi) → potem strona Blazor (porządki szablonu + jeden klawisz startu). ⚠️ Push na GitHub wciąż CZEKA — repo Shop nie ma remote.

---

**DZIEŃ 4 (2026-09-16, środa) — POWRÓT PO PRZERWIE + WIELKI RENAME NA EN ✅.**

**Powrót:** nauka stała od 2026-09-12 (chłoniak psa, nadal leczony sterydowo). User: „chciałem wrócić do nauki kodu... chciałbym coś popisać" → rytm wg planu: status → zagadka → jedna przeróbka.

**Zagadka (rozgrzewka na własnym kodzie):** różnica tabela `Products` (SQL) vs klasa `Product` (C#). User odpowiedział poprawnie konceptowo („określają co to jest ID, nazwa, ilość, cena"), sam wyłapał cenę z przecinkiem — REAL ↔ `decimal` ✅. Tabelka typów SQL↔C#: INTEGER↔`int`, TEXT↔`string`, REAL↔`decimal`. Jedyna rzecz, której klasa nie ma = `AUTOINCREMENT` — numer Id nadaje baza, dlatego w POST Id nie wysyłamy.

**Kontroler GET ✅ (Etap 0 cd.):** `Shop.Api\Controllers\ProductController.cs` — wzór 1:1 `PrzedmiotyController` z MagazynApi; różni się 5 nazwami: `ProductController`, `"ShopDb"`, `FROM Products`, `Name, Quantity, Price`, `List<Product>`. Ramka: `SELECT` = pytanie do bazy → odpowiedź tabelką → `ExecuteReader`. Plik utworzony przez asystenta na wyraźną delegację usera („zrób to za mnie z tym dodaniem folderów i plików, ja sprawdzę").

**Wpadki po drodze:** (1) VS — „Nie można zmienić nazwy pliku *Nowy folder* na *Controllers*, ponieważ nowa nazwa powoduje konflikt" → folder `Controllers` już istniał, obok został śmieciowy `Nowy folder` (oba usunięte/uporządkowane); (2) „widzę plik w Eksploratorze Windows, nie widzę go w VS" → folder powstał poza VS; fix: prawy klik na projekt → *Odśwież*.

**⚠️ KRYZYS NAZW (główny punkt dnia):** asystent przeniósł z Magazynu polską nazwę zmiennej `lista` → user: „miało być pro i nie być żadnych polskich nazw" + ultimatum „albo budujemy projekt od zera". **Audyt całego Shop** (grep `Sklep`): 13 miejsc w kodzie + nazwy 3 projektów. **Decyzje usera (A/B):** A — przemianować w miejscu (nie od zera); styl z kropkami `Shop.*`. Wykonane (VS zamknięty): `git mv` folderów i plików (`Sklep.Api/Shared/Web` → `Shop.Api/Shared/Web`, `.csproj` + `.http`), 13 podmian (`Shop.slnx` ×3, 2× `ProjectReference`, `Shop.Web\Program.cs`, `_Imports.razor` ×3, `App.razor` → `Shop.Web.styles.css`, `NavMenu.razor` → napis na stronie, `Shop.Api.http` → `/api/Product`), wyczyszczone `.vs`/`obj`/`bin`/stare `.csproj.user`. **`dotnet build Shop.slnx` = SUKCES** (2 warningi CS8600: `GetConnectionString` może zwrócić null — nie błędy). Nietknięte: folder główny `Shop`, `ShopDb` + ścieżka `Shop\database\shop.db`, porty 5143/7104, ten dziennik (treść PL).

**⚠️ Lekcja dla asystenta:** nie powtarzać wulgaryzmów usera w etykietach wyboru — user to zauważył i sam przeprosił za własny ton („wulgarator z ciebie się zrobił prze mnie").

⏭️ **Następna sesja:** otworzyć VS → `Shop.slnx`, ustawić **Shop.Api jako projekt startowy** (skasowany `.csproj.user`), Ctrl+F5 → `http://localhost:5143/api/Product` ma zwrócić `[]` → potem `POST` (żeby user zobaczył prawdziwy produkt, nie pustą listę) → potem strona Blazor.
