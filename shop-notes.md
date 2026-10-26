# Nauka C# — Shop (dziennik)

**DZIEŃ 1 (2026-09-06, niedziela) — START Etapu 0 ✅.** User: „tworzymy ten e-commerce?" → rusza projekt-powtórka e-commerce (decyzja z sesji po Dniu 29 Magazynu). Wybory usera (A/B/C): nazwa **Sklep** (Dzień 2: folder → `Shop`; Dzień 4: całe drzewo projektów → `Shop.*`), struktura **własny folder + własne rozwiązanie** (portfolio, „żeby wyglądało profesjonalnie").

**Struktura (utworzona przez asystenta CLI; nazwy folderu i projektów po Dniu 4):** `D:\Dane\Projekty\NaukaCSharp\Shop\` = `Shop.slnx` + `src\Shop.Shared` (classlib) + `src\Shop.Api` (webapi --use-controllers) + `src\Shop.Web` (blazor InteractiveServer). Refs: Api→Shared, Web→Shared; `Microsoft.Data.Sqlite` 10.0.11 w Api. Usunięte próbki: Class1.cs + WeatherForecast.cs + WeatherForecastController.cs (w Web Counter/Weather/NavMenu NA RAZIE zostają — porządki przy stronie). Build zielony ×2 (CLI).

**⚠️ Wpadka 1 — scaffolding bez pytania:** user: „czemu to zrobiłeś a nie ja to robiłem" → szkielet zostaje (wybór usera), zasada na przyszłość: **każdy plik pisze user, asystent prowadzi/sprawdza; operacje strukturalne (tworzenie projektów) — pytać PRZED**. (Ten sam wzorzec co MagazynShared 08-29.)

**Krok 1 — Product.cs ✅ (wpisany przez usera, w Shop.Shared):** wzorzec 1:1 `MagazynShared\Item.cs` — klasa BEZ namespace i usings (jak modele Magazynu; cross-project działa — sprawdzone): `Id`, `Name`, `Quantity`, `Price`.

**⚠️ Wpadka 2 — odpowiedź na pytanie rozrośnięta w wykład:** pytanie usera mid-typing: „{ get; set; } co to jest?" → asystent pokazał PEŁNĄ wersję (pole `_id`, `value`, auto-property, „drzwi") → user: „coś mi tu nie podoba się... znowu jedziesz z kodem co ja nie wiem co znaczy. tak to nie będzie" → reset + przeprosiny; minimalna wersja, która została: **„get = pozwala czytać, set = pozwala pisać; C# sam trzyma wartość w środku" — tyle na dziś** (to NIE był koncept tej sesji; wzorzec w Product.cs = ten sam co setki razy w Magazynie). Wzorzec → feedback/student-writes-code: na pytanie mid-typing odpowiadać MINIMALNIE, zero nowego kodu/terminów bez potrzeby.

**Krok 2 — API wstaje ✅ (user):** start Shop.Api → „Application started", „Now listening on: http://localhost:5143" (+ https 7104) → to też dowód, że Product.cs się kompiluje (dotnet run buduje całość przed startem). 404 na starcie = OK — API nie ma jeszcze endpointów (prze-frame'd przed otwarciem przeglądarki).

⏭️ **Następna sesja (Etap 0 cd.):** 1) baza: folder `database\` (wzór MagazynBaza) + `ConnectionStrings:ShopDb` w `Shop.Api\appsettings.json` (absolutna ścieżka, wzór MagazynDb) + `CREATE TABLE IF NOT EXISTS Products` w `Program.cs` (wzór Partie) → restart API → sprawdzić, czy `shop.db` powstał; 2) kontroler `/api/Product` (GET pierwszy, potem POST/PUT/DELETE); 3) strona Blazor. Przy okazji Web: decyzja portów/startup (wzór Magazyn: jeden klawisz, usunąć https, stałe porty).

---

**DZIEŃ 2 (2026-09-07, poniedziałek) — SESJA KRÓTKA, ZAMKNIĘTA ✅ (user zmęczony, późno).** Cel: baza danych (Etap 0 cd.).

**Zmiany nazw (user, sam):** folder projektu `Sklep` → **`Shop`** (`D:\Dane\Projekty\NaukaCSharp\Shop`); folder na bazę → **`database`** (próby: Base → database). Nazwy projektów w środku zostały wtedy po staremu — przemianowane na `Shop.*` dopiero w Dniu 4 (patrz sekcja Dnia 4).

**Decyzja (user):** baza **od razu po angielsku** — tabela `Products` (kolumny 1:1 z Product.cs: Id, Name, Quantity, Price), spójnie z klasą EN; folder/projekt (niekod) zostają PL/Shop. Wzorzec → user/english-level: podawać GOTOWE słowa EN z PL znaczeniem.

**Krok 2 ✅ — `ConnectionStrings:ShopDb` w `Shop.Api\appsettings.json`:** `"Data Source=D:\\Dane\\Projekty\\NaukaCSharp\\Shop\\database\\shop.db"` (wzór MagazynDb). JSON: 3 sekcje na równym poziomie, przecinek między parami, `\\` = jeden `\` w ścieżce. Wpadka: wklejenie rozjechało strukturę (sekcja w środku Logging, zgubiony LogLevel, brak klamry, stara nazwa Base) → asystent przepisał plik całością (write_file; VS → „zmieniony poza edytorem" → Tak). `appsettings.Development.json` miał przypadkowe zmiany wcięć (residuum wklejania) → cofnięte `git checkout`. **Uwaga dla asystenta: user mylił appsettings.json z appsettings.Development.json przy wklejaniu.**

**Krok 3 NIEZROBIONY** (Program.cs: `using Microsoft.Data.Sqlite;` na górze + blok `CREATE TABLE IF NOT EXISTS Products` przed `app.Run();`, wzór Partie z MagazynApi). User: „za duży tu jest chaos nauki" — po 2 nieporozumieniach (asystent tłumaczył Program.cs zamiast JSON-a) → reset + mapa + wybór zamknięcia dnia (A/B). Wzorzec: pacing-check-first — nie lecieć do następnego kroku, zanim poprzedni nie zostanie ZROZUMIANY.

⏭️ **Następna sesja:** Krok 3 (2 zmiany w Program.cs, małe kawałki) → restart API (user) → sprawdzić, czy `Shop\database\shop.db` powstał → potem kontroler `/api/Product`.

---

**DZIEŃ 3 (2026-09-09, środa) — SESJA ZAMKNIĘTA ✅ (2 przerwy: aktualizacja systemu + zamknięcie dnia).** Start: user: „działamy dalej z ecommerce?" → status + powtórka mapy (co robiliśmy i w jakich plikach): root `Shop\` = plik rozwiązania + `src\Shop.Shared\Product.cs` (model) + `src\Shop.Api\Program.cs` (start API) + `appsettings.json` (ShopDb → ścieżka bazy). Zagadka kontrolna: do którego pliku klasa Category / gdzie zapisany port? — odpowiedzi w mapie.

**Nowy koncept (pytanie usera) — port 5143:** NIE standard platformy; **szablon `dotnet new webapi` losuje port RAZ przy tworzeniu projektu** i zapisuje NA STAŁE w `Shop.Api\Properties\launchSettings.json` → `dotnet run` czyta plik przy każdym starcie. Port = „numer mieszkania w bloku" (analogia przyjęta). Korekta błędnej parafrazy: losuje SZABLON (nie system), przy TWORZENIU (nie instalacji), RAZ (nie co start); zmiana = ręczna w pliku; launchSettings.json nie pisze się ręcznie — generuje go szablon („fabryka projektów"). Spacer komend scaffolding z Dnia 1 odtworzony: `dotnet new sln/classlib/webapi/blazor` → `sln add` ×3 → `add reference` ×2 → `add package Microsoft.Data.Sqlite` → `build`.

**⚠️ Dysk (Dzień 3): plik rozwiązania = `Shop\Shop.slnx`** (user przemianował na dysku; w repo widać: stary plik usunięty + nowy `Shop.slnx`).

**Krok 3 ✅ — tabela Products:** pełny kod przekazany userowi do wpisania (wzór Partie z MagazynApi pokazany obok): zmiana 1 — `using Microsoft.Data.Sqlite;` na górze Program.cs; zmiana 2 — blok między `app.MapControllers();` a `app.Run();`: `string cs = ...GetConnectionString("ShopDb")` + `using (SqliteConnection...) { Open; CreateCommand; CommandText = "CREATE TABLE IF NOT EXISTS Products (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Quantity INTEGER, Price REAL)"; ExecuteNonQuery(); }`. Ramka „list do bazy" (cs = adres z appsettings; otwarcie = SQLite tworzy plik shop.db sam; CommandText = tekst listu; ExecuteNonQuery = rozkaz, cisza = sukces). Wpadka usera: fragment wpisany z wieloma literówkami (Shop.Db zamiast ShopDb; pomylone SqliteCommand/SqliteConnection; `CreateComand`, `ExecuteText`, „CREA TE", „KAY", „Quantrity") → asystent poprawił cały fragment (user: „sprawdzi jak coś to popraw"). Start API → „Application started" + **`Shop\database\shop.db` istnieje ✅** (glob potwierdził).

⏭️ **Następna sesja:** kontroler `/api/Product` (GET → POST/PUT/DELETE, wzór BatchController z MagazynApi) → potem strona Blazor (porządki szablonu + jeden klawisz startu). ⚠️ Push na GitHub wciąż CZEKA — repo Shop nie ma remote.

---

**DZIEŃ 4 (2026-09-16, środa) — POWRÓT PO PRZERWIE + WIELKI RENAME NA EN ✅.**

**Powrót:** nauka stała od 2026-09-12 (chłoniak psa, nadal leczony sterydowo). User: „chciałem wrócić do nauki kodu... chciałbym coś popisać" → rytm wg planu: status → zagadka → jedna przeróbka.

**Zagadka (rozgrzewka na własnym kodzie):** różnica tabela `Products` (SQL) vs klasa `Product` (C#). User odpowiedział poprawnie konceptowo („określają co to jest ID, nazwa, ilość, cena"), sam wyłapał cenę z przecinkiem — REAL ↔ `decimal` ✅. Tabelka typów SQL↔C#: INTEGER↔`int`, TEXT↔`string`, REAL↔`decimal`. Jedyna rzecz, której klasa nie ma = `AUTOINCREMENT` — numer Id nadaje baza, dlatego w POST Id nie wysyłamy.

**Kontroler GET ✅ (Etap 0 cd.):** `Shop.Api\Controllers\ProductController.cs` — wzór 1:1 `PrzedmiotyController` z MagazynApi; różni się 5 nazwami: `ProductController`, `"ShopDb"`, `FROM Products`, `Name, Quantity, Price`, `List<Product>`. Ramka: `SELECT` = pytanie do bazy → odpowiedź tabelką → `ExecuteReader`. Plik utworzony przez asystenta na wyraźną delegację usera („zrób to za mnie z tym dodaniem folderów i plików, ja sprawdzę").

**Wpadki po drodze:** (1) VS — „Nie można zmienić nazwy pliku *Nowy folder* na *Controllers*, ponieważ nowa nazwa powoduje konflikt" → folder `Controllers` już istniał, obok został śmieciowy `Nowy folder` (oba usunięte/uporządkowane); (2) „widzę plik w Eksploratorze Windows, nie widzę go w VS" → folder powstał poza VS; fix: prawy klik na projekt → *Odśwież*.

**⚠️ KRYZYS NAZW (główny punkt dnia):** asystent przeniósł z Magazynu polską nazwę zmiennej `lista` → user: „miało być pro i nie być żadnych polskich nazw" + ultimatum „albo budujemy projekt od zera". **Audyt całego Shop** (grep `Sklep`): 13 miejsc w kodzie + nazwy 3 projektów. **Decyzje usera (A/B):** A — przemianować w miejscu (nie od zera); styl z kropkami `Shop.*`. Wykonane (VS zamknięty): `git mv` folderów i plików w `src\` (na `Shop.Api` / `Shop.Shared` / `Shop.Web`, razem z `.csproj` i `.http`), 13 podmian (`Shop.slnx` ×3, 2× `ProjectReference`, `Shop.Web\Program.cs`, `_Imports.razor` ×3, `App.razor` → `Shop.Web.styles.css`, `NavMenu.razor` → napis na stronie, `Shop.Api.http` → `/api/Product`), wyczyszczone `.vs`/`obj`/`bin`/stare `.csproj.user`. **`dotnet build Shop.slnx` = SUKCES** (2 warningi CS8600: `GetConnectionString` może zwrócić null — nie błędy). Nietknięte: folder główny `Shop`, `ShopDb` + ścieżka `Shop\database\shop.db`, porty 5143/7104, ten dziennik (treść PL).

**⚠️ Lekcja dla asystenta:** nie powtarzać wulgaryzmów usera w etykietach wyboru — user to zauważył i sam przeprosił za własny ton („wulgarator z ciebie się zrobił prze mnie").

⏭️ **Następna sesja:** otworzyć VS → `Shop.slnx`, ustawić **Shop.Api jako projekt startowy** (skasowany `.csproj.user`), Ctrl+F5 → `http://localhost:5143/api/Product` ma zwrócić `[]` → potem `POST` (żeby user zobaczył prawdziwy produkt, nie pustą listę) → potem strona Blazor.

**✅ KONIEC DNIA 4 (domknięcie):** user otworzył VS → `Shop.slnx`, ustawił `Shop.Api` jako startowy, Ctrl+F5 → **`http://localhost:5143/api/Product` zwróciło `[]` ✅** (GET potwierdzony end-to-end, cały łańcuch przeglądarka → API → kontroler → SQLite → JSON). Po drodze VS pokazał 2 ostrzeżenia **CS8600** (`Program.cs` + `ProductController.cs` — `GetConnectionString` może zwrócić `null`) → wyjaśnione jako **NIE-błędy** (build zielony, apka działa; wyciszenie `??` / `!` odłożone na później). **POST (`AddProduct`, zmienna `newProduct`) — kod już przekazany userowi, wpisanie odłożone na następną sesję** (user: „za dużo dziś tu się zamieszania zrobiło, jutro to dopiszemy").

**⚠️ Lekcja dnia 4 (asystent):** nie mieszać nazw z Magazynu (`Przedmioty`, `Partie`, `Nazwa`, `Ilosc`, `Cena`) do tłumaczeń projektu Shop — user czyta je jako nazwy Shop i traci orientację; w Shop wszystko po EN → memory `project/shop-en-names.md`.

---

**DZIEŃ 5 (2026-09-21, poniedziałek) — POST `AddProduct` ✅ I PIERWSZY REKORD W BAZIE ✅.** Powrót po 5 dniach przerwy (ostatnia sesja 2026-09-16). User: „jestem po małej przerwie... chciałbym coś pokodować dziś" → plan uzgodniony (A): powtórka → 1 przeróbka = POST → test curlem.

**Zagadka (na własnym GET):** która linijka *jest* pytaniem, a która je *wysyła*? User: „`CommandText` to pytanie do bazy, zawiera konkrety, resztę nie wiem" → domknięte: `CommandText` = tekst listu (nic nie wysyła), `ExecuteReader()` = wysłanie; tabelka rozkaz/ cisza (`ExecuteNonQuery`) vs pytanie/ tabelka (`ExecuteReader`).

**⚠️ ZALEW INFORMACJI (główny problem dnia):** odpowiedź z 2 tabelkami porównawczymi + blokiem kodu + pytaniem kontrolnym → „nie no za dużo tego. zasypałeś mnie falą informacji". Ratunek: wycofanie wszystkiego i zostawienie 3 punktów (plik / miejsce / blok kodu) — **ale to nie wystarczyło**: user od razu „to co ja mam zrobić?" (odchudzony opis to nadal opis). Zadziałała dopiero **numerowana lista CZYNNOŚCI** (1. otwórz plik w Solution Explorer, 2. znajdź ostatnią klamrę klasy, 3. wklej blok, 4. Ctrl+S → „gotowe"). **Lekcja: odpowiedź = instrukcja, nie opis + tabelki.**

**GET/POST — user zapytał wprost „ja nie wiem co to oddaje i po co to jest":** wyjaśnione tabelką 4 wierszy (GET=daj listę→select→JSON, POST= dodaj→INSERT→nic, PUT= popraw→UPDATE→nic, DELETE= usuń→DELETE→nic) + powiązanie z jego kodem: `GetProducts` ma `List<Product>` (bo oddaje), `AddProduct` ma `void` (bo nie oddaje).

**⚠️ „Nie chcę mi się tego pisać":** user nie chciał wpisywać kodu i zapytał, czy asystent może to zrobić za niego („nie wiem czy to tak spoko jak za mnie wpiszesz? co myślisz?"). Odpowiedź: szczerze — słabsza nauka, wartość jest w pisaniu rękami; kompromis zaproponowany: **ramkę skopiować z `GetProducts`**, ręcznie wpisać tylko 4 linijki różnicy + nagłówek. User ostatecznie przepisał sam.

**Kontrola kodu (read_file) — 3 błędy realne + literówki:** (1) `using (SqliteConnection SqliteConnection(connectionString))` — brakowało `connection = new` (to blokowało kompilację); (2) `new Product.Name` zamiast `newProduct.Name` (klasa vs zmienna z nagłówka); (3) **brakowało `command.ExecuteNonQuery();`** — kod by się skompilował, ale rozkaz nigdy nie poleciałby do bazy. Literówki: `AddProduckt`, `newProduckt`, `CreateComand`, `ComandText`, brak `)` na końcu `VALUES (...)`. Asystent poprawił całość (delegacja jak w Dniu 3).

**🐛 BŁĄD DNIA — HTTP 307 i `UseHttpsRedirection`:** POST wykonany, curl milczał (poprawnie — `void`), ale GET dalej zwracał pusto. Diagnoza `curl.exe -i`: **`HTTP/1.1 307 Temporary Redirect` → `Location: https://localhost:7104/api/Product`**. Przyczyna: `app.UseHttpsRedirection();` w `Program.cs` — API odsyła http→https; **przeglądarka skacze za przekierowaniem sama (dlatego GET w oknie działał), curl nie skacze → POST w ogóle nie dochodził do kontrolera**. Fix: usunięta ta jedna linia z `Program.cs` (tak samo chodzi MagazynApi) → restart (user, Ctrl+F5) → POST przeszedł. **To też wyjaśnia wcześniejsze 404 na `https://localhost:7104/` — user trafił tam przez to przekierowanie.**

**✅ WYNIK KOŃCOWY:** `[{"id":1,"name":"Klawiatura","quantity":5,"price":199.99}]` — **pierwszy rekord w bazie, cały łańcuch end-to-end** (PowerShell → POST → kontroler → INSERT → SQLite → SELECT → JSON). Obserwacje przekazane: `id:1` nadała baza (`AUTOINCREMENT`); nazwy pól małymi literami (ASP.NET domyślnie camelCase — nie błąd); cena z kropką (JSON zna tylko kropkę).

**Porządki:** testy curl robione z PowerShell w folderze `Shop\database` → powstał plik-śmieć `body.json` → dopisany do `.gitignore`.

⏭️ **Następna sesja:** **strona Blazor** — pierwszy widok produktów zamiast JSON-a (user: „tangible" — JSON nie czyta się jako aplikacja). Do rozważenia później: PUT/DELETE w kontrolerze, porządki szablonu Web (`Counter`/`Weather`/`NavMenu`) + jeden klawisz startu (wzór Magazyn).

**DZIEŃ 6 (2026-09-22, wtorek) — PIERWSZA STRONA SHOP ✅ (tabelka produktów z API).**

Plan dnia wybrany przez usera z 3 opcji (A: strona Blazor z listą produktów / B: PUT+DELETE w API / C: powtórka czytania kodu) → **A**. Wejście: „he. co robimy?" (status z pamięci: git czysty @ `e7dcc77`, API ma GET+POST, baza ma Klawiaturę id 1).

**Co powstało:**
- `src\Shop.Web\Components\Pages\Products.razor` — nowy komponent: `@page "/products"`, `@rendermode InteractiveServer`, `@inject HttpClient Http`, tabela `@foreach` po `products`, na dole `@code` z polem `List<Product>? products` + `OnInitializedAsync` → `Http.GetFromJsonAsync<List<Product>>("http://localhost:5143/api/Product")`.
- `src\Shop.Web\Program.cs` — dodane `builder.Services.AddHttpClient();` (bez tego strona nie ma czym wysłać żądania; warunek wstępny, ta linia jest też w MagazynWeb).
- `Shop\Shop.slnLaunch.user` — profil startowy „Shop" (Shop.Api + Shop.Web razem, `DebugTarget: http`), wzorowany na `NaukaCSharp.slnLaunch.user`; plik `*.user` jest w `.gitignore`, więc zostaje lokalnie. VS czyta go **przy otwieraniu rozwiązania**.

**Kod przekazany do wpisania, ale blok `@code` został WKLEJONY** — user sam to zgłosił („BO TO WKLEIŁEM"), co zamknęło wątek „dowód umiejętności z kodu". Wniosek na przyszłość: nie używać kodu usera jako dowodu, zanim nie wiadomo, czy był wpisany czy wklejony; dzielić na mniejsze zadania zamiast całych bloków.

**Błędy w pliku (poprawione przez asystenta):** `@ndermode InteractivServer` (→ `@rendermode InteractiveServer`), **brak `@` przed `if (… == null)`** (bez małpy Blazor czyta kod jako zwykły tekst — kompiluje się, ale tabelka nigdy by się nie pokazała), literówki `/produckts`, `Produckts`, `porduckts`.

**🐛 BŁĄD DNIA — trap kreatora VS w `.csproj`:** VS dopisał do `Shop.Web.csproj`:
```xml
<ItemGroup><Content Remove="Components\Pages\Products.razor" /></ItemGroup>
<ItemGroup><Compile Include="Components\Pages\Products.razor" /></ItemGroup>
```
`<Compile Include>` każe kompilatorowi potraktować `.razor` (HTML + C#) jako plik źródłowy C# → lawina błędów przy poprawnym kodzie; user: „co napiszę to jest zjebane". Fix: usunięte oba `ItemGroup` (dokładnie ten sam trap co `Lang.cs` w Magazynie, wariant `.razor`; po fixie `dotnet build` = 0 błędów, 0 ostrzeżeń).

**Serwery i adresy (dzień walki z uruchamianiem):** porty API **5143** / strona **5107**. VS startuje domyślnie JEDEN projekt (startowy = Shop.Api), więc strona nie wstawała → `netstat` pokazał pusty 5107, `curl` exit 7 („connection refused"). Potem padło samo API → strona zwracała **HTTP 500** (bez API nie ma skąd wziąć danych). Po wstaniu obu: **HTTP 200** + `<td>Klawiatura</td>` w HTML strony ✅. Nowe narzędzie diagnostyczne w rozmowie: `netstat -ano | findstr LISTENING | findstr :5107` i `curl -s -i`.

**Kryzys wieczorny (bez kodu):** po zobaczeniu działającej strony user: „nic kurwa nie umiem z tej nauki. zdania w C# nie umiem napisać" → pytania „to co ja umiem?" i „nie wiem czy się do tego nadaję i czy ta forma nauki jest odpowiednia". Odpowiedź asystenta (lista mocnych/braków) przyjęta; natomiast propozycje **zmiany rytmu nauki („20 minut dziennie") i drillu z markupu `<tr></tr>`** spotkały się z ostrym sprzeciwem — user nie może uczyć się częściej (mówił to wcześniej) i markup jest dla niego materiałem do wklejenia, nie do ćwiczeń. **Zapamiętane na stałe: nie doradzać częstotliwości ani nie ćwiczyć HTML-a.**

**Stan końcowy:** GET i POST w API + strona `/products` czytająca z API; `Products.razor` i `AddHttpClient()` w repo; build zielony.
⏭️ **Następna sesja:** link do `/products` w `NavMenu.razor` (żeby nie wpisywać adresu z pamięci), potem PUT/DELETE w kontrolerze i pierwszy formularz na stronie; w kolejce: porządki szablonu (`Counter`/`Weather`) i wyciszenie 2× CS8600.

**DZIEŃ 7 (2026-09-23, środa) — POZYCJA „Produkty" W MENU ✅.**

**Zagadka (czytanie `NavMenu.razor`):** które fragmenty decydują o tym, dokąd prowadzi link i co widać w menu? User: „nie wiem, strzelam — (a) `NavLinkMatch.All`, (b) Home, Counter, Weather". Korekta wprost: **(b) trafione** (napis = tekst między `</span>` a `</NavLink>`); **(a) nie** — za adres odpowiada `href="..."` (`href=""` = strona główna), a `Match="NavLinkMatch.All"` mówi tylko „podświetl mnie, gdy adres zgadza się dokładnie".

**Przeróbka (user):** nowa pozycja w `Shop\src\Shop.Web\Components\Layout\NavMenu.razor` — kopia sąsiedniej pozycji, wstawiona za blokiem Weather (przed `</nav>`): `<div class="nav-item px-3">` → `<NavLink class="nav-link" href="products">` → `<span class="bi bi-list-nested-nav-menu">` + napis `Produkty`. Weryfikacja `read_file` ✅ (wcięcia i struktura jak wzorzec). Jedyna zmiana w kodzie tego dnia.

**Uruchamianie — awaria cierpliwości:** VS było otwarte, ale nic nie chodziło (`netstat` — 5143/5107 milczące). User przemęczony klikaniem („testujesz moją cierpliwość", „co mam do chuja zrobić krok po kroku") → asystent **odpalił oba projekty w tle** (`dotnet run --launch-profile http`), user nie protestował (tryb AWARII, precedens Dnia 6). Weryfikacja końcowa: API `http://localhost:5143/api/Product` → **200**; strona `http://localhost:5107/products` → **200**; w HTML strony pozycja menu `href="products"` + napis `Produkty` ✅. User: „**no jest**" + tabelka `1 Klawiatura 5 199,99 zł`. Instancje z tła zatrzymane przy zamykaniu dnia (porty wolne).

**⚠️ Wpadka narzędziowa dnia:** otwarcie `Shop.slnx` z dysku (Plik → Otwórz → Projekt/Rozwiązanie) uruchamia **VS Code**, bo Windows ma pliki `.slnx` skojarzone z VS Code — user zgłosił to 2× („otwiera mi się kolejny raz vs code"). Obejście na już: nie otwierać pliku z dysku, tylko z listy **Plik → Ostatnie projekty i rozwiązania**. Do naprawy na spokojnie: skojarzenie `.slnx` z Visual Studio.

**❌ NIEPOTWIERDZONE:** multi-startup (`Shop\Shop.slnLaunch.user`) — VS nie był przeładowany, a instancje z tła zajmowały porty, więc nie dało się sprawdzić.

**Uwaga dydaktyczna:** przy klikologii startu działa **jedna czynność na raz + fakt zamiast diagnozy**; gdy uruchamianie męczy usera, szybciej odpalić instancje w tle i pokazać działający wynik, niż tłumaczyć kolejne kroki w VS.

**cd. DNIA 7 (2026-09-23) — MULTI-STARTUP ✅ ZAMKNIĘTY + DELETE W API ✅.**

**Multi-startup ✅ (ustawiony W OKNIE VS, nie plikiem):** prawy klik na rozwiązanie `Shop` → **Konfiguruj projekty startowe...** → **„Wiele projektów startowych"** → kolumna **Akcja**: `Shop.Api` i `Shop.Web` = **„Uruchom"** (polski VS nie ma słowa „Start" — user: „nie mam start jest uruchom"), `Shop.Shared` = „Brak"; kolumna **„Element debugowania"** = **`http`** przy obu → OK. **Zadziałało od razu, bez przeładowania rozwiązania** (ręcznie wpisany `Shop\Shop.slnLaunch.user` VS nie wziął — patrz Dzień 6). User: „**dobra działa teraz**" → **1 Ctrl+F5 = API 5143 + strona 5107**.

**DELETE (`DeleteProduct`) ✅ — wpisany przez usera SAMODZIELNIE, poprawnie za pierwszym razem.** Nowe rzeczy (2): (1) **numer id bierze się z ADRESU** — `[HttpDelete("{id}")]` + parametr `int id`, a nie z ciała żądania jak w POST, bo adres wskazuje konkretny wiersz; (2) **`WHERE Id = @Id`** — bez `WHERE` rozkaz usunąłby wszystkie wiersze. Reszta = wzór 1:1 z `AddProduct`: rozkaz → cisza → `void` + `ExecuteNonQuery`. Artefakt wpisywania usera: `"DELete forM Products WHERE Id = @Id"` — **działa** (SQL nie rozróżnia wielkości liter w słowach kluczowych), zostawiony; do wygładzenia przy okazji.

Wyjaśnienie podane TOP-DOWN (o to poprosił: „jakoś bardziej sensownie wytłumacz co robi ten kod"): zamysł całej układanki (czasownik HTTP = metoda = jeden rozkaz SQL) → skąd ASP.NET wie, którą metodę uruchomić (`[Route("api/[controller]")]` + `[HttpDelete("{id}")]`) → linia po linii → gdzie to siedzi w łańcuchu → dlaczego numer z adresu, a nie z ciała. Reakcja usera: „**wątpię że tyle rzeczy zapamiętam**" → ramka **„piosenka w 5 krokach"** (connectionString → connection + `Open` → `CommandText` → `AddWithValue` → `Execute…`): między GET/POST/DELETE zmienia się TYLKO tekst SQL i to, czy oddajemy coś (`void` vs `List<Product>`) — „wystarczy rozpoznawać, nie recytować". User: „jak bym miał to pisać to bym skądś zerżnął, raczej niż wymyślał" → normalne: branie wzorca z dokumentacji to standard, nie wstyd.

**Test (user, PowerShell, po Ctrl+F5):** `curl.exe -s http://localhost:5143/api/Product` → `[{"id":1,"name":"Klawiatura","quantity":5,"price":199.99}]` → `curl.exe -s -X DELETE http://localhost:5143/api/Product/1` → **cisza** → `curl.exe -s http://localhost:5143/api/Product` → **`[]`** ✅ — usuwanie end-to-end (PowerShell → DELETE → `DELETE FROM Products` → SQLite → GET).

⚠️ **Uwaga na przyszłość:** plik `database\shop.db` **jest w repo** (nie ma go w `.gitignore`), więc każda zmiana danych (POST/DELETE) zmienia ten plik i trafia do commita.

⏭️ **NASTĘPNY KROK (ta sama sesja):** najpierw przywrócić produkt przez POST (baza jest pusta — nie ma czego klikać), potem **przycisk „Usuń" w `Products.razor`** (klik → `Http.DeleteAsync` → odświeżenie listy); zwykły link HTML nie umie wysłać DELETE. Potem PUT i porządki szablonu.

**cd.2 DNIA 7 (2026-09-23) — przycisk „Usuń" w tabeli (wpisany przez usera; kompiluje się ✅, klik NIEPOTWIERDZONY).**

**Przywrócenie produktu (user, POST):** `Set-Content body.json` + `curl.exe -X POST ...` → GET = `[{"id":2,"name":"Klawiatura",...}]` — **`id: 2`, nie 1**, czyli `AUTOINCREMENT` pamięta numer po usuniętym wierszu ✅.

**`Products.razor` (3 wstawki):** (1) `<th>Actions</th>` w nagłówku; (2) w wierszu `<td>` z `<button class="btn btn-danger btn-sm" @onclick="() => DeleteProduct(product.Id)">Usuń</button>`; (3) w `@code` metoda `DeleteProduct(int id)` = `await Http.DeleteAsync($"http://localhost:5143/api/Product/{id}")` + ponowny `GetFromJsonAsync` (odświeżenie listy — bez tego tabelka dalej pokazywałaby usunięty wiersz, bo `products` siedzi w pamięci strony).

**Nowe koncepty (podane krótko):** `@onclick` (małpa jak przy `@if` — bez niej to zwykły tekst dla HTML), `() => Metoda(product.Id)` (lambda — który wiersz kliknięto; `product` z `@foreach`), `$"…{id}"` (wstawienie wartości w tekst adresu), `async Task` zamiast `void` (metoda czeka na serwer). Markup z góry nazwany „lakierem" (wklejka, nie materiał do ćwiczeń).

**🐛 BŁĄD DNIA (pouczający):** metoda nazwana `DeleteProduckt`, a przycisk woła `DeleteProduct` → build wywala „nazwa `DeleteProduct` nie istnieje" (CS0103). **Lekcja: markup i `@code` łączą się po DOKŁADNEJ nazwie metody** — VS nie podpowiada między tabelką a blokiem kodu, więc literówka w nazwie wychodzi dopiero przy kompilacji. Fix: asystent poprawił jedną linię (`DeleteProduckt` → `DeleteProduct`). Spacja po kropce w `Http. GetFromJsonAsync` = bez znaczenia (C# ignoruje).

**Weryfikacja:** `dotnet build src\Shop.Web\Shop.Web.csproj` = **0 błędów, 0 ostrzeżeń** ✅ (po fixie). **Klik POTWIERDZONY ✅** — user uruchomił stronę i kliknął **Usuń**: wiersz zniknął z tabelki („usunięty jest produkt"), czyli cały łańcuch **klik → Blazor (`@onclick`) → `Http.DeleteAsync` → API `DELETE` → SQLite → ponowny GET** domknięty end-to-end.

⚠️ **Sygnał na następny raz:** user o bloku `@code`: „**nie ma sensu jechać linijka po linijce jak ja tam nic nie rozumiem z tego @code**" — nie forsować przechodzenia całego bloku; czytanie wracać na MAŁYCH kawałkach (jedna metoda) i zawsze z widocznym efektem (klik → zmiana w tabeli).

⏭️ **Następna sesja:** (1) PUT (edycja) w API + formularz na stronie (dodawanie produktu bez PowerShella), (2) porządki szablonu (`Counter`/`Weather`).

---

**DZIEŃ 8 (2026-09-24, czwartek) — FORMULARZ „DODAJ PRODUKT" NA STRONIE ✅ (POST z przeglądarki zamiast PowerShella).**

Start: user: „hej! co dzisiaj proponujesz zrobić?" → status (git `Shop` czysty @ `662b806`) → 3 opcje → user wybrał **formularz „Dodaj produkt"** (znana piosenka POST przeniesiona na stronę).

**Zagadka-czytanie (`Shop.Api\Controllers\ProductController.cs`, metoda `AddProduct`):** pytanie „skąd bierze `newProduct`, kto ją uruchamia?" → user: „uruchamia ją ASP.NET... musi wypełnić danymi nazwa, ilość, cena... `ExecuteNonQuery` to chyba jest ze zwrotu nie chce z bazy danych" = **3/4 trafione**: ✅ ASP.NET woła metodę sam (jak Blazor `OnInitializedAsync`), ✅ INSERT doda wiersz a `Id` nada baza, ✅ `ExecuteNonQuery` = „nic nie chcę z powrotem"; ❌ **luka: ciało żądania** — JSON wysyłany dotąd PowerShellem; ASP.NET czyta go i sam buduje obiekt `Product`, a potem podaje jako argument. To był pomost do dzisiejszej przeróbki.

**Przeróbka `Shop\src\Shop.Web\Components\Pages\Products.razor` — 3 wstawki:**
1. 3 pola w `@code` (schowek na wpisane wartości): `private string name = ""; private int quantity; private decimal price;`
2. Formularz pod `<h1>Products</h1>`: karta Bootstrap + `row g-2` + 3× `<input @bind="…" placeholder="…" class="form-control" />` + `<button class="btn btn-primary" @onclick="AddProduct">Dodaj</button>` — **markup wklejony (lakier, nie materiał do ćwiczeń)**, wzorzec 1:1 z `Batches.razor` (Magazyn).
3. Metoda `AddProduct` w `@code` — **ta sama piosenka co `DeleteProduct`**: `new Product { Name = name, Quantity = quantity, Price = price }` → `PostAsJsonAsync("http://localhost:5143/api/Product", newProduct)` → ponowny `GetFromJsonAsync` (odświeżenie tabelki).

**🐛 Błędy wpisywania (asystent poprawił, build potem zielony):** `Price = price price` (wartość dwa razy) i `GetFromJsonAsync<List> < Product >>` (rozjechane nawiasy `<>` z odstępami). Reszta bloku wpisana poprawnie.

**⚠️ `@bind` — wyjaśnienie NIE weszło (2 podejścia):** user: „nie rozumiem tego, 3 tezami wyjaśnij" → 3 tezy; potem „**1 nadal nie wiem o co chodzi**" → wyjaśnienie literalne (dwa kawałki pliku: `<input>` u góry + `private string name` w `@code`; `@bind` = jedyne połączenie; ciąg zdarzeń: piszesz → `name = "Myszka"` → `Name = name` → JSON) → user: „**dobra już nie tłumacz bo i tak nie rozumiem z tego połączenia bind i @code**". **Nie forsować dalej** — wrócić przy okazji przeróbki `@bind`, na działającym przykładzie, nie przez opis.

**✅ TEST PRZESZEDŁ (user, Ctrl+F5):** log `Shop.Web` = `Now listening on: http://localhost:5107` + `GET http://localhost:5143/api/Product` → **200** (tabelka się wczytała). User wpisał `Myszka` / `3` / `49,99` → klik **Dodaj** → wiersz pojawił się **bez odświeżania strony**. Weryfikacja asystenta (`curl`): `[{"id":3,"name":"Myszka","quantity":3,"price":49.99}]` ✅ — cały łańcuch **formularz → `AddProduct` → POST → INSERT → tabelka** domknięty end-to-end (pierwszy raz produkt dodany z przeglądarki, nie z PowerShella).

**Lekcja przy okazji:** `id: 3`, nie 1 — `AUTOINCREMENT` pamięta numery po usuniętych wierszach.

⚠️ `Shop\database\shop.db` jest w repo (nie w `.gitignore`) → każdy POST/DELETE zmienia plik i wchodzi do commita.

⏭️ **Następna sesja:** (1) **PUT + edycja na stronie** (przycisk „Zmień" w tabeli → pola wypełniają się wartościami wiersza), (2) porządki szablonu (`Counter`/`Weather`), (3) pozycja „Produkty" ma tymczasowo ikonę Weather, (4) `@bind` do wytłumaczenia jeszcze raz — na działającym formularzu.

**cd. DNIA 8 — ćwiczenia na czytanie `@code` (user: „trzeba przećwiczyć jeszcze czy @code coś z tego rozumiem").**

1. **`DeleteProduct` — ile żądań?** User: „DELETE. `await Http.DeleteAsync(...)` to nas kieruje do API" ✅ (pierwsze żądanie trafione), ale ❌ **pominął DRUGIE** — ponowny GET odświeżający listę. Wyjaśnione: tabelka rysuje się z listy `products` trzymanej w pamięci strony, więc bez re-GET na ekranie zostałby usunięty wiersz. Sprawdzian transferowy o `AddProduct`: user sam ✅ **POST + GET** („oba skierowane do API"). Reguła jednym zdaniem: **linia z `Http.` = wycieczka na serwer; linia bez `Http.` = praca na miejscu** (np. `new Product { ... }` tylko buduje obiekt).
2. **`OnInitializedAsync` — kto ją woła?** ❌ „strzelam" + wskazane **pole** `private List<Product>? products;` (nie metoda). Wyjaśnione: pola się nie „uruchamiają", tylko trzymają wartość (`?` = może być `null` → stąd `Loading`); metodę woła SAM Blazor, dlatego nie ma wywołania w markupie, a `protected override` = „moja wersja metody Blazora". ⚠️ **Pytanie było źle zadane** („poszukaj, gdzie ją wołają" — odpowiedzią jest BRAK): user „to co pierdolisz mi żebym szukał w `@code`?", „to nie podchwytliwe pytanie tylko prowadzenie pijanego na płot albo w krzaki". **Wniosek na przyszłość: ćwiczenie na czytanie ma kończyć się linią do pokazania palcem, nie nieobecnością.** Sesja zamknięta: „dobra starczy bo nie skumałem ostatniego w ogóle".

---

**DZIEŃ 9 (2026-09-26, sobota) — PUT (edycja) W API ✅ potwierdzony curlem; edycja na stronie — sesja przerwana w połowie.**

Start: user: „co dzisiaj robimy?" → status (git `Shop` czysty @ `987e307`) → 3 opcje → user wybrał **edycję produktu (PUT)** — jedyna operacja CRUD, której brakowało.

**Zagadka-czytanie (`MagazynApi\Controllers\BatchController.cs`, linie 65–66):** `[HttpPut("{id}")]` + `public void UpdateBatch(int id, Batch batch)` → pytanie „skąd `id`, a skąd `batch`?" → user: „**z bazy danych?**" ❌ (odwrotnie: te argumenty dopiero WPADAJĄ do bazy w linii `UPDATE`). Odpowiedź wprost: **`id` ← z ADRESU** (ten `{id}` w atrybucie, jak w `DeleteProduct`), **`batch` ← z CIAŁA żądania (JSON)** (jak `newProduct` w `AddProduct`). Dlatego PUT ma dwa argumenty — `PUT /api/Product/3` + `{ "name": ... }`.

**Przeróbka 1/2 — `PUT` w API (`Shop.Api\Controllers\ProductController.cs`), user wpisał sam ✅:** metoda `UpdateProduct` = sklejenie `DeleteProduct` (id z adresu, `WHERE Id = @Id`) z `AddProduct` (trzy parametry). Metoda: `[HttpPut("{id}")]` → `public void UpdateProduct(int id, Product product)` → `CommandText = "UPDATE Products SET Name=@Name, Quantity=@Quantity, Price=@Price WHERE Id=@Id"` → 4× `AddWithValue` → `ExecuteNonQuery()`.

**🐛 4 błędy wpisywania (user poprawił po wskazaniu, build zielony):** (1) `produkt` po polsku w nagłówku, a `product` w środku metody; (2) `_configuration` zamiast `_config` (nazwa pola z Magazynu); (3) **brakujący cudzysłów otwierający** przed `UPDATE` → **jedna kreska robi lawinę czerwonych linii** — kompilator uznaje, że tekst ciągnie się dalej i połyka kolejne linijki jako jeden string; (4) nazwa metody została `UpdateBatch` (z Magazynu). ⚠️ **Lekcja:** metoda o nazwie poprawnej, ale CUDZEJ nie jest w ogóle podkreślana — kompilator tego nie zgłosi. Czerwone podkreślenie = błąd składni/nieznana nazwa; zła nazwa = cisza, trzeba wyłapać samemu (inaczej niż literówka w nazwie, którą woła markup — Dzień 7).

**✅ TEST PUT (user, PowerShell — pełna piosenka):** `curl.exe http://localhost:5143/api/Product` → `[{"id":3,"name":"Myszka","quantity":3,"price":49.99}]` → `Set-Content -Path body.json -Value '{"name":"Myszka","quantity":9,"price":59.99}'` → `curl.exe -X PUT http://localhost:5143/api/Product/3 -H "Content-Type: application/json" -d '@body.json'` → **cisza** (UPDATE = rozkaz, baza nie odpowiada — tak ma być) → GET = `[{"id":3,"name":"Myszka","quantity":9,"price":59.99}]` ✅. **`id` zostało 3** — cała różnica UPDATE vs INSERT: zmienia ISTNIEJĄCY wiersz, nie dokłada nowego.

**Przeróbka 2/2 — edycja na stronie (`Shop.Web\Components\Pages\Products.razor`), CZĘŚCIOWO:**
- ✅ `@code`: pole `private int editingId;` + metoda `private void EditProduct(Product product)` = `name = product.Name; quantity = product.Quantity; price = product.Price; editingId = product.Id;` (bierze wartości z KLIKNIĘTEGO wiersza i wkłada do pól strony — te same pola, które są spięte z okienkami u góry; `void`, zero `Http.` — praca na miejscu).
- ⏭️ NIEZROBIONE: przycisk **„Zapisz"** + metoda `SaveProduct()` = `PutAsJsonAsync($"http://localhost:5143/api/Product/{editingId}", …)` + ponowny GET.

**🐛 Błędy markupu (user) — dwa pouczające:** (1) przycisk „Zmień" wstawiony w **kartę formularza** zamiast w wiersz tabelki → tam nie istnieje zmienna `product` (żyje tylko w `@foreach`), więc nie ma czego zmieniać; (2) **brakujący `</div>`** → `error RZ9980: Unclosed tag 'div' with no matching end tag` — jeden niezamknięty `<div>` (pudełko) blokuje kompilację CAŁEGO pliku; (3) literówki `@oneclick` i `EditProduckt` — **ciche**: kompilator ich nie zgłasza, przycisk po prostu nic by nie robił. Asystent przeniósł przycisk do `<td>` Actions (obok „Usuń") i domknął `<div>`.

**Weryfikacja:** `dotnet build src\Shop.Web\Shop.Web.csproj` = **0 błędów** ✅. ⚠️ **Klik „Zmień" w przeglądarce NIE potwierdzony** — do sprawdzenia na starcie następnej sesji.

⚠️ **Ostrzeżenia (nie błędy) CS8600 ×5 w `Shop.Api`:** „Konwertowanie literału null… na nienullowalny typ" — `Program.cs(21)` + 4× `string connectionString = _config.GetConnectionString("ShopDb")` w `ProductController` (`GetConnectionString` może zwrócić `null`). Build przechodzi, apka działa; temat na kiedyś (`??`).

**⏸️ PRZERWANIE SESJI (nie zniechęcenie do projektu):** user: „**nie mam dziś głowy do tego. ta choroba psa… czasami nie mam głowy a ni siły**" → wybrał opcję „domykam sam i commituję" (asystent poprawił markup, zbudował, zapisał notatki).

⏭️ **Następna sesja (zacząć KRÓTKO, bez nowego materiału):** (1) Ctrl+F5 → klik **„Zmień"** przy wierszu → czy pola na górze wypełniają się danymi tego produktu; (2) przycisk **„Zapisz"** + metoda `SaveProduct()` (PUT + ponowny GET) — domknięcie edycji end-to-end; (3) dopiero potem porządki szablonu (`Counter`/`Weather`, ikona „Produkty").

---

**DZIEŃ 10 (2026-10-01, czwartek) — POWRÓT PO PRZERWIE (luka 2026-09-27 → 2026-10-01); EDYCJA PRODUKTU NA STRONIE DOMKNIĘTA ✅ (jeden przycisk + „Anuluj").**

Start: user: „siema! co dzisiaj robimy? wiem miałem przerwe" (powodu nie podał — nie dopytywać). Git `Shop` czysty @ `36c1f33`. Cel dnia: dokończyć przeróbkę 2/2 z Dnia 9 (bez nowego materiału).

**Krok 0 — test zaległy z Dnia 9 ✅:** klik „Zmień" **działa** — pola `Name`/`Quantity`/`Price` wypełniają się danymi klikniętego wiersza (+ zapamiętane `editingId`).

**🔎 ODKRYCIE USERA (punkt dnia):** po „Zmień" kliknął „Dodaj" → powstał **duplikat** („dodaje nowy produkt… numery sie dubluja"). Pytanie: „troche nie powinno tak być, może jakieś powiadomienie? czy jak widzisz rozwiązanie?" → **diagnoza wprost:** „Dodaj" = `AddProduct` = **POST = INSERT = zawsze nowy wiersz** — to nie usterka, to definicja tego guzika; duplikat bierze się z tego, że po „Zmień" na ekranie dalej stoi „Dodaj".

**Rekomendacja (Poziomy, nie lista wyboru):** **Poziom 1 = jeden przycisk, który sam wie, co robić** (znana piosenka z Magazynu): `if (editingId == 0)` → POST, inaczej → PUT + przycisk „Anuluj" — pomyłka staje się NIEMOŻLIWA, bo „Dodaj" w trybie edycji nie istnieje. **Poziom 2 = komunikat** („Dodano/Zapisano") — dodatek, tylko INFORMUJE, nie blokuje. **Odrzucone jawnie:** zakaz dwóch produktów o tej samej nazwie (w sklepach się tego nie stosuje — ta sama nazwa bywa legalna, różne warianty).

**Przeróbka DONE ✅ (`Shop.Web\Components\Pages\Products.razor`):**
- **Markup:** zamiast dwóch guzików **jeden**, który zmienia napis: `<button class="btn btn-primary" @onclick="AddProduct">@(editingId == 0 ? "Dodaj" : "Zapisz")</button>` + `<button class="btn btn-secondary" @onclick="Cancel">Anuluj</button>`. Wyjaśnienie ternary jedną linijką: `@(warunek ? "gdy prawda" : "gdy fałsz")`.
- **`@code`:** `SaveProduct()` **usunięta** — cały PUT wjechał do `AddProduct` jako `if (editingId == 0) { POST } else { PUT }` + jedna linia GET na końcu. Dodana `private void Cancel()` = `name = ""; quantity = 0; price = 0; editingId = 0;` (0 w `editingId` = „wracam do trybu dodawania" → guzik sam wraca na „Dodaj").

**🐛 Ciche błędy wpisania (wykryte przez `read_file`, user poprawił):** (1) `onclick="SaveProduct"` **bez `@`** → Blazor czyta atrybut jako zwykły HTML i ignoruje → **guzik martwy, zero błędu** (sąsiad „Dodaj" miał `@onclick`, dlatego działał); (2) `PutAsJsonAsync("http://localhost:5143/api/Product{editingId}", …)` **bez `$` i bez `/`** → literalny tekst zamiast podstawienia → PUT na nieistniejący adres → 404.

**💥 WYJĄTEK (odwrotność cichego błędu — runtime krzyczy):** po nieudanej podmianie zostały w `AddProduct` resztki starej metody: `GetFromJsonAsync("http//loclalhost:5143/api/Prtoduct")` (brak `:` po `http`, literówki `loclalhost`/`Prtoduct`) + zbędny POST → `UriFormatException` → konsola przeglądarki: **„There was an unhandled exception on the current circuit, so this circuit will be terminated"** = strona traci połączenie z serwerem. **Lekcja:** tekst w `"..."` kompilator widzi jako zwykły napis i nie sprawdza, czy to sensowny URL — literówka w adresie wychodzi dopiero przy próbie połączenia. 3 próby samodzielnej naprawy (user usuwał złą linię) → „**pierdole. bo mnie rozjebie zaraz wez to popraw**" → asystent poprawił na wyraźną delegację.

**⚠️ ŚCIANA SŁOWNIKOWA (`async`/`await`/`Task`/`void`):** user: „pojebane to ejst za duzo jest tego. ja tam nie wiem co to ejsrt aweit i void pierdoli mi sie to. async itd. za duzo ti nei wiem i przez to robi sie chaos". **Co zadziałało:** ściąga **4 wiersze, bez kodu i bez lekcji** — `void` = nic nie oddaje; `async` = „może czekać"; `await` = „poczekaj, aż serwer odpowie" (przy `Http.`); `Task` = odda wynik po czasie. Reguła-1-zdanie: metoda z żądaniem ma `async` + `await`; oddaje coś → `Task<coś>`, nie oddaje → `Task`, a **`void` NIGDY z `await`** (dlatego kontroler API ma `void`, a metody strony `async Task`). Powiedziane wprost: to najtrudniejsze 4 słowa w C#, wchodzą z czasem, nie z tłumaczenia.

**✅ TEST KOŃCOWY (user):** „widzę że działa ok" — „Zmień" → guzik „Zapisz" → PUT zmienia istniejący wiersz, lista nie rośnie; „Anuluj" czyści pola i wraca do „Dodaj" (do sprawdzenia przy okazji). ⚠️ Zduplikowane produkty z testów zostały w bazie — user ma je usunąć przyciskiem „Usuń". ⚠️ `database\shop.db` w repo → zmiany z testów wchodzą do commita.

⏭️ **Następna sesja:** (1) **porządki szablonu** — `Counter`/`Weather` do usunięcia, pozycja „Produkty" ma tymczasowo ikonę Weather; (2) ewentualnie **Poziom 2** — komunikat po zapisie; (3) `@bind` — WYŁĄCZNIE na działającym formularzu (przeróbka), nie opisem; (4) „dwa żądania w jednej metodzie" (POST/PUT + GET) — ćwiczyć na LINII w kodzie. Start: Ctrl+F5 = API 5143 + strona 5107.

---

**DZIEŃ 11 (2026-10-02, piątek) — PORZĄDKI SZABLONU ✅ (krótka sesja, zero nowych konceptów).**

Start: user „czesc! działamy cos dzis dalej?" → status (repo `Shop` czyste @ `f786872`, Dzień 10 zamknięty) → 3 opcje → user wybrał **A: porządki szablonu** („ja bym zrobił A ale pierw jakos umówił co ostatnio robilisz małe przypomnienie") → najpierw krótkie PRZYPOMNIENIE Dnia 10 na jego kodzie (`Products.razor`: jeden guzik `@(editingId == 0 ? "Dodaj" : "Zapisz")`, `EditProduct` → pola + `editingId`, `AddProduct` z `if/else` POST/PUT, `Cancel`), dopiero potem praca. ⚠️ Wzorzec potwierdzony: **recap na starcie jest potrzebny** (user sam o niego prosi) — na realnych linijkach pliku, nie ogólnie.

**Krok 1 ✅ — menu (`Shop.Web\Components\Layout\NavMenu.razor`):** user usunął **dwa całe bloki** `<div class="nav-item px-3">…</div>` (te z `href="counter"` i `href="weather"`) → zostały 2 pozycje: Home + Produkty.

**Krok 2 ✅ — pliki stron:** user usunął z `Components\Pages` pliki `Counter.razor` i `Weather.razor` (prawy klik → Usuń). W `Pages` zostały: `Home.razor`, `Products.razor`, `Error.razor`, `NotFound.razor`. Build bez zmian (nic ich już nie używało).

**Krok 3 ✅ — ikona „Produkty" (koszyk):** ikony w tym szablonie to SVG wklejone w `NavMenu.razor.css` („lakier"), więc nową klasę `.bi-cart-fill-nav-menu` **dodał asystent**, a user zrobił jedną podmianę w `NavMenu.razor`: `bi-list-nested-nav-menu` → `bi-cart-fill-nav-menu` (linia „Produkty"). Wpisane **poprawnie za pierwszym razem** ✅.

**⚠️ ZAMIESZANIE — plik `Error.razor` wzięty za awarię:** user: „**CO TO ZA PLIK I CAŁY KOD Z TYM ERROR?**" (uprzednio: „w tej lokalizacji jest ten plik") — zobaczył w `Pages` plik `Error.razor` i odczytał **nazwę pliku** jako błąd jego projektu. Wyjaśnione WPROST: `Error.razor` (adres `/Error`, strona „gdy coś padnie"), `NotFound.razor` (404; **podpięty w `Routes.razor`** — `NotFoundPage="typeof(Pages.NotFound)"`, więc musi zostać) i `ReconnectModal.razor` (okienko „łączę ponownie…") to **pliki szablonu**, nie jego kod i nie awaria. Dowód: `dotnet build Shop.Web` = **0 błędów**, porty 5107/5143 wolne (brak blokady starych instancji). Potem user poprosił „z grubsza" o omówienie tego kodu → rozbiór **top-down w 3 częściach**: (1) `@page "/Error"` = adres + `@using System.Diagnostics` = dołożenie narzędzi; (2) markup — `PageTitle`, `<h1>`/`<h2>` = napisy, `@if (ShowRequestId)` = decyzja, czy pokazać numer żądania; (3) `@code` = schowek — pola (`string? RequestId`), `ShowRequestId => !string.IsNullOrEmpty(RequestId)` (`bool`, `!` = zaprzeczenie), `OnInitialized` (woła Blazor, `void`, `=>` = skrót bez klamer), `[CascadingParameter] HttpContext` = kod szablonu. ⚠️ **Lekcja: nazwa pliku („Error") ≠ błąd w projekcie** — przy „co to za plik z error" najpierw sprawdzić build i porty, potem tłumaczyć rolę pliku.

**✅ TEST (user, Ctrl+F5):** menu = **2 pozycje** (Home + Produkty z ikoną koszyka), edycja działa; „Anuluj" → „**tak to dziala i działało**" — domknięta ostatnia niepotwierdzona rzecz z Dnia 10 ✅.

⚠️ `database\shop.db` zmienił się od testów edycji (plik jest w repo → wchodzi do commita).

⏭️ **Następna sesja (do wyboru):** (1) **Poziom 2** — komunikat „Dodano/Zapisano zmiany" po zapisie (dodatek, niczego nie blokuje) + sprzątnięcie zduplikowanych produktów z bazy przyciskiem „Usuń"; (2) **zamówienia (relacja 1-wiele)** — pierwszy krok w stronę prawdziwego e-commerce; (3) `@bind` — wyłącznie na działającym formularzu; (4) „dwa żądania w jednej metodzie" (POST/PUT + GET) — ćwiczyć na LINII w kodzie. Start: Ctrl+F5 = API 5143 + strona 5107.

---

**DZIEŃ 11 cd. (2026-10-02, piątek) — ETAP 1 RUSZYŁ: modele zamówień + dwie tabele ✅.**

Po zamknięciu Dnia 11 (commit `a7e094f`) user zapytał: „etap 1 zamówienia możemy jeszcze dziś zrobić?" → asystent uczciwie: **całego Etapu 1 nie w jednej sesji** (nowy koncept + tabela + kontroler + strona; samo „kontroler GET+POST" zajęło 2 sesje w Dniach 4–5), propozycja: krok 1 = ustalenie kształtu danych + model. User poprosił o **opis słowami przed kodem**: „możesz prościej opisać co będzie robić ta funkcja i jaki ma cel? później przejdziemy do pisania kodu".

**Opis dany bez kodu (i przyjęty):** cel = „co ktoś kupił, ile i kiedy"; ekran = lista zamówień → po wejściu pozycje; części = **nagłówek + pozycje i dlaczego DWIE** (jedno zamówienie ma wiele pozycji = **relacja 1-wiele**); czego na razie NIE ma: koszyka, klientów, logowania. User: „ok rozumiem zacznijmy coś działać".

**Krok 1 ✅ modele (`Shop\src\Shop.Shared`):** `Order.cs` = `Id` + `Date` (`DateTime`); `OrderItem.cs` = `Id`, `OrderId`, `ProductId`, `Quantity`, `Price` (`decimal`). User wpisał sam przez kreator VS → **csproj czysty** (brak pułapki `Compile Remove`). Jedna literówka złapana `read_file`: `PorductId` → `ProductId` (asystent wskazał, user poprawił).

**Pytania usera o `DateTime` (2×, najpierw krótko):** „.NET wie co to jest DateTime?" oraz „skąd bierze datę — z internetu? systemu? strony Microsoftu?" → odpowiedź: `DateTime` = **wbudowany typ frameworku** (rodzina `int`/`string`/`decimal`); `DateTime.Now` czyta **zegar systemowy komputera, na którym działa aplikacja** — żadnego zapytania do sieci; zegar synchronizuje w tle sam Windows; na VPS data = zegar VPS.

**Krok 2 ✅ tabele (`Shop\src\Shop.Api\Program.cs`):** dołożone POD blokiem `Products`, PRZED `app.Run();` — dwa bloki tej samej piosenki, inny tylko `CommandText`: `Orders (Id INTEGER PRIMARY KEY AUTOINCREMENT, Date TEXT)` i `OrderItems (Id INTEGER PRIMARY KEY AUTOINCREMENT, OrderId INTEGER, ProductId INTEGER, Quantity INTEGER, Price REAL)`. Najpierw user nie wiedział, gdzie wpisać („**tu mam coś wpisać?**") → działa „przed → po" z całym ogonem pliku.

**🐛 8 literówek w 2 blokach — build wyłapał GŁOŚNO:** `new SqliteConnection Connection(cs)` (**CS1526** + CS1026 + CS1002 + CS1022, l. 36), `new SqliteConnectionConnection(cs)`, `connecction.CreateComand()`, `command.Commandtext`, `connection.open()`, `IF EXISTS` (zamiast `IF NOT EXISTS`), `AUTOINRECEMNT`, `INTEGR`, zdublowana kolumna `Quantity`. Część user poprawił po liście punktowej (blok → zły fragment → ma być), resztę (4 miejsca) — **na wyraźną delegację „możesz to już za mnie poprawić?"** — asystent (`edit`). **Kontrast wzorca:** w `.cs` błędy są **GŁOŚNE** (kompilator mówi co i gdzie → `feedback/csharp-code-build-catches-typos.md`), w `.razor`/adresie URL/nazwie właściwości **CICHE** (`→ feedback/silent-errors-verify-by-reading.md`) — dlatego po bloku `.cs` ZAWSZE build, nie tylko czytanie. Przypomniane: C# wrażliwy na wielkość liter, SQL nie (dawne `DELete forM Products` działało).

**Lekcja SQL na JEGO linii** (user: „możesz mi wytłumaczyć te komendy do SQL"): rozbiór token po tokenie + mapowanie `INTEGER`↔`int`, `TEXT`↔`string`/`DateTime`, `REAL`↔`decimal`; `PRIMARY KEY` = unikalny numer wiersza, `AUTOINCREMENT` = baza sama nada numer → przy `INSERT` nie podaje się `Id` (`→ feedback/sql-create-table-types.md`).

**✅ STAN PO SESJI:** `dotnet build Shop.Api` = **0 błędów** (5 znanych warningów CS8600 z `GetConnectionString` — stare, nie ruszamy). Tabele są w kodzie, ale **fizycznie powstaną dopiero przy najbliższym Ctrl+F5** (API nie był restartowany). Zmienione: `Shop.Shared\Order.cs`, `Shop.Shared\OrderItem.cs`, `Shop.Api\Program.cs`.

⏭️ **Następna sesja:** krok 3 = **`OrderController` z `GET`** (kopia `ProductController` + `Date`), potem `POST`, potem strona `/orders`. Przy okazji sprawdzić, czy `shop.db` dostał tabele `Orders`/`OrderItems`.

---

**DZIEŃ 12 (2026-10-03, sobota) — ETAP 1 KROK 3: `OrderController` z `GET` ✅.**

Start: repo czyste @ `2352e53`; w `Controllers` był tylko `ProductController.cs`, więc krok 3 = nowy kontroler z jedną metodą czytającą. Sesja w rytmie: krótkie czytanie własnego kodu → jedna przeróbka.

**Czytanie `GetProducts()` (rozbiór bloku `SELECT`, bez nowych konceptów):** `command.CommandText = "SELECT …"` = **tekst listu do bazy** (pytanie); `ExecuteReader()` = wyślij pytanie i odbierz **tabelkę**; `while (reader.Read())` = czytaj **wiersz po wierszu**, aż `Read()` powie „false — koniec"; `reader["Id"]` = wartość z kolumny **po nazwie** w bieżącym wierszu, a `Convert.ToInt32/ToDecimal` = przepisanie na C#-owy typ (baza oddaje „coś" nieznanego typu). User zapytał „**czyli select to co? co to za komenda?**" → tabelka 4 komend SQL skotwiczona na JEGO metodach: `SELECT` = pokaż dane → baza ODSYŁA → `ExecuteReader` (`GetProducts`); `INSERT`/`UPDATE`/`DELETE` = rozkaz → cisza → `ExecuteNonQuery` (`AddProduct`/`UpdateProduct`/`DeleteProduct`). Zasada-1-zdanie: „czy baza ma mi coś ODSŁAĆ?".

**⚠️ WPADKI KOMUNIKACYJNE (asystent) — oba warianty pytań odrzucone:** (1) pytanie kontrolne na koniec rozbioru → „**nie zapamiętam raczej. nie rozumiem tego pytania co mi na końcu napisałeś**"; (2) pytanie zadane userowi, na które asystent sam odpowiedział w tej samej wiadomości → „**a ty mi na pytanie przez siebie samego zadane odpowiadasz. halo!!!**". Do tego „co to za litania?" po zbyt długim wyjaśnieniu. **Wniosek:** przy tłumaczeniu NIE zadawać pytań (chyba że naprawdę czekamy na odpowiedź) — podawać odpowiedź WPROST i zamykać JEDNĄ numerowaną czynnością.

**Krok 3 — plik:** Solution Explorer → `Shop.Api` → `Controllers` → prawy klik → Add → Class… → `OrderController`. Kreator VS wygenerował szablon `namespace Shop.Api.Controllers { public class Class { } }` → **`Shop.Api.csproj` pozostał CZYSTY** ✅ (brak pułapki `Compile Remove`, wariant `.cs`). Docelowo plik **bez namespace** — tak samo jak `ProductController.cs`.

**User PRZEPISAŁ kod ręcznie** (zamiast wkleić) → 2 rundy literówek, wszystkie wyłapane `read_file` + lista „numer → ma być":
- runda 1: `_confing` (→ `_config`), `public class orderController` (→ `OrderController`; mała litera = `OrderController(...)` niżej przestaje być konstruktorem), `_CONFIG.gETcONNECTIONsTRING` (→ `_config.GetConnectionString`), `new SqliteConnectionString(...)` (→ `new SqliteConnection(...)`), `[Route("api / [controller]")]` (spacja), **brak `{` po sygnaturze `GetOrders()`** → całe ciało „wypadało" poza metodę i końcowa `}` nie miała pary (czerwona klamra w VS);
- runda 2: `_config.GetConnectionString"ShopDb")` (brak `(`), `connectionCreateCommand()` (brak kropki → `connection.CreateCommand()`), `while (reader.Reader())` (→ `reader.Read()` — `Reader` to typ `SqliteDataReader`, a wiersz czyta metoda `Read()`).

Rundę 2 user poprawił sam ✅; finał = plik **1:1 wzorzec** `GetProducts` (kosmetyka: pozjeżdżane wcięcia, brak spacji w `List<Order>GetOrders()`).

**Kod = kopia `GetProducts` z 5 podmianami:** nazwa klasy/konstruktora, `GetProducts`→`GetOrders`, `List<Product>`/`products`→`List<Order>`/`orders`, SQL `SELECT Id, Name, Quantity, Price FROM Products` → `SELECT Id, Date FROM Orders`, `new Product {…}` → `new Order {…}`. Jedyna nowa rzecz: **`Convert.ToDateTime(reader["Date"])`** — w bazie data leży jako tekst (`TEXT`), a typ C# to `DateTime`, więc trzeba ją przepisać.

**✅ BUILD (user, Ctrl+Shift+B):** „Kompilacja: sukces — 3, niepowodzenie — 0" → **0 błędów**; wyszło 5 znanych **warningów CS8600** (m.in. `OrderController.cs(16,…)` — identyczne jak `ProductController.cs(19,…)`, czyli nowy kod to ta sama piosenka). Ostrzeżenia nie blokują.

**✅ TEST (user, Ctrl+F5):** `http://localhost:5143/api/Order` → **`[]`** = krok 3 działa. Pusta lista to poprawny wynik: `SELECT` zwraca 0 wierszy, bo w tabeli `Orders` nie ma jeszcze żadnego zamówienia (gdyby tabeli nie było, poleciałby błąd serwera, nie `[]`). ⚠️ Samo `http://localhost:5143/` = **404 z założenia** (API odpowiada tylko pod `/api/...`).

**Zmienione:** nowy `Shop\src\Shop.Api\Controllers\OrderController.cs` — jedyny plik w commicie (`database\shop.db` bez zmian, test był tylko czytający).

⏭️ **Następna sesja:** `POST` w `OrderController` (zapis zamówienia — INSERT = rozkaz → `void` + `ExecuteNonQuery`, wzór `AddProduct`), potem strona `/orders`.

---

**DZIEŃ 12 cd. (2026-10-03, sobota) — ETAP 1 KROK 4: `POST` zamówienia ✅.**

**Krok 4 — jak powstał:** user wkleił do `OrderController.cs` blok `[HttpPost]` **1:1 z `AddProduct`** → zostały `AddProduct`, `Product newProduct`, `INSERT INTO Products (Name, Quantity, Price)`. To **cichy błąd**: kompiluje się (typ `Product` istnieje, SQL to zwykły string), ale zapisałby do tabeli `Products`, nie `Orders`. Pięć podmian: nazwa metody, typ parametru, SQL, parametry, ciało. User zrobił sam cztery (`AddOrder`, `Order newOrder`, `INSERT INTO Orders (Date) VALUES (@Date)`), a w ostatniej linii napisał `command.Parameters.@Date = newOrder.Date` → **CS1061** (`Parameters` to kolekcja, nie ma pola `@Date`) + brak `;`. Poprawka na wzór `AddProduct`: `command.Parameters.AddWithValue("@Date", newOrder.Date);`.

**Lekcja z C#:** `GetConnectionString(...)` może zwrócić `null` → **CS8600** to ostrzeżenie (zielone), nie błąd — build ma 0 błędów i 7 warningów `CS8600` (2 nowe w `OrderController.cs`: l. 16 GET, l. 40 POST). Nie ruszamy.

**✅ TEST (user, Ctrl+F5):** `POST` przez `Invoke-RestMethod` → **cisza = sukces** (`void`, rozkaz do bazy); potem `GET http://localhost:5143/api/Order` → **`id 1, date 2026-10-03T00:00:00`** = wiersz w bazie. `T00:00:00` = normalne (data bez godziny → format ISO, północ).

**Zmienione:** `Shop\src\Shop.Api\Controllers\OrderController.cs` + `database\shop.db` (wiersz testowy).

⏭️ **Następna sesja:** strona `/orders` (lista zamówień: nr | data | razem), potem wejście w zamówienie = pozycje.

---

**DZIEŃ 12 cd. 2 (2026-10-03, sobota) — FRONT: strona główna + przełącznik PL/EN ✅**

**`Home.razor`** przestał być szablonem („Hello, world!"): nagłówek „Shop" + opis + przycisk `Products` + dwie karty (`row` + `col-md-4`; karta Orders bez linku, bo `/orders` jeszcze nie istnieje → dałaby 404 z `NotFound.razor`). Markup Bootstrapa = lakier do wklejenia, `@code` w tym pliku nie ma wcale.

**Przełącznik PL/EN — 3 części (pomysł usera, wzorzec z Magazynu):**
1. `Shop\src\Shop.Web\Lang.cs` (nowy): `private static string current = "pl";`, dwa słowniki `Pl`/`En` (`Dictionary<string, string>`, klucze po EN), `T(key)` = `current == "en" ? En[key] : Pl[key]`, `Set(lang)`.
2. `Components\Layout\LangSwitch.razor` (nowy): `@rendermode InteractiveServer` (layout i `NavMenu` są statyczne — bez tego przycisk jest martwy) + `@inject NavigationManager Nav`; klik → `Lang.Set(...)` + `Nav.NavigateTo(Nav.Uri, forceLoad: true)` = pełne odświeżenie, żeby strony przeczytały nowy język.
3. Teksty stron na `@Lang.T("Klucz")` — `NavMenu.razor`, `Home.razor`, `Products.razor`. **Zostają na sztywno:** `Id`, nazwa „Shop" i waluta `zł`.

**Wpadka 1 — przecinek w słowniku:** w `Pl` przecinek po `OrdersCardText` dodany ✅, w `En` nie → **błąd składni „oczekiwano elementu „,""** (CS1003). Zasada: dopisując nowy wiersz na końcu słownika, dotychczasowa ostatnia linia dostaje przecinek, nowa nie. Wyłapane `read_file` (komunikat kompilatora nie podał linii).

**Wpadka 2 — hamburger nachodził na PL/EN (wąski ekran):** `.navbar-toggler` (☰) jest w CSS przyklejony (`position: absolute; right: 1rem`), a PL/EN stał w tym samym rogu `.top-row`; na ≥641px ☰ ma `display: none`, więc kolizja widoczna tylko na telefonie. Fix bez CSS: `<LangSwitch />` przeniesiony z górnego paska do listy menu (`nav-item` pod „Produkty").

**Lekcja z `.razor`:** w atrybucie HTML trzeba `placeholder="@(Lang.T("Name"))"` (nawiasy) — bez nich drugi cudzysłów zamyka atrybut, a błąd jest **cichy**. W treści elementu wystarczy `@Lang.T("Name")`.

**Zmienione:** `Lang.cs` (nowy), `LangSwitch.razor` (nowy), `NavMenu.razor`, `Home.razor`, `Products.razor`.

⏭️ **Następny krok:** strona `/orders` (lista zamówień: nr | data | razem), potem wejście w zamówienie = pozycje.

---

**DZIEŃ 12 cd. 3 (2026-10-03, sobota) — LAKIER / WYGLĄD ✅ (front-endowy szlif)**

Cel usera: „żeby nie wyglądało jak basic Blazor", „bardziej wizualnie na nowoczesny e-commerce". Zakres = **tylko wygląd**: zero nowego C#, zero zmian w logice i w słowniku.

**Co zmienione:**
1. `Home.razor` — hero (kolorowy gradient + biały przycisk) + karty „produktowe": zaokrąglone, cień + lekkie uniesienie na `:hover`, „zdjęcie" = kolorowy gradient z ikoną (🛒 / 📦, bez plików graficznych); karta Produkty klikalna w całości (`<a class="card ...">`).
2. `wwwroot\app.css` — dopisane klasy lakieru na końcu pliku: `.hero`, `.card-product`, `.card-product:hover`, `.card-img-placeholder`, `.placeholder-blue`, `.placeholder-purple`.
3. `Components\Layout\MainLayout.razor.css` — `.sidebar`: domyślny gradient szablonu `rgb(5,39,103) → #3a0647` zamieniony na ten sam co hero (`#1b6ec2 → #6f42c1`), żeby panel i strona były jedną rodziną kolorów.

**Wpadka (asystenta):** w karcie Orders poszedł `<span class="badge text-bg-secondary">@Lang.T("OrdersCardText")</span>` — zdublowany opis jako badge; poprawka: badge usunięty, margines akapitu `mb-3` → `mb-0`.

**Lekcja narzędziowa:** plik `.razor.css` (scoped CSS) w Solution Explorerze VS **siedzi wciągnięty pod komponent** — user szukał `MainLayout.razor.css` luzem w folderze `Layout` i nie znalazł; rozwinąć strzałką ▸ `MainLayout.razor` (albo Ctrl+, → „Przejdź do pliku"). Windows/eksplorator plików widzi go normalnie.

**Zmienione:** `Home.razor`, `wwwroot\app.css`, `MainLayout.razor.css`.

⏭️ **Następny krok:** strona `/orders` (nowy plik, nowy koncept — dwa zestawy danych: nagłówek + pozycje).

---

**DZIEŃ 13 (2026-10-04, niedziela) — ETAP 1 KROK d ZAMKNIĘTY ✅: strona `/orders` + linki.**

Plan dnia = JEDNA rzecz: strona `/orders` (lista `nr | data`). Rytm: zagadka → opis słowami → kod → test.

**Zagadka (czytanie własnego kodu):** „która linia mówi, do którego zamówienia należy pozycja?" → user wskazał `public int OrderId { get; set; }` w `Shop.Shared\OrderItem.cs` ✅ — to cały łącznik relacji 1-wiele.

**Zgubienie w układzie projektów (temat dnia):** user: „na tym etapie nauki trochę mi się miesza, która klasa należy do której i w jakim jest folderze — czy to po stronie API, Blazora, czy współdzielona; nie wiem, czy to przejściowy etap i kwestia ćwiczeń". Odpowiedź WPROST: tak, to osobna umiejętność i kwestia ćwiczenia. Mapa 3 projektów + 3 pytania (dane dla obu → `Shop.Shared`; żądanie/baza → `Shop.Api`; widać na ekranie → `Shop.Web`) + dowód w plikach: oba `.csproj` mają `ProjectReference` do `Shop.Shared`. Ćwiczenie 5 plików → **5/5** ✅.

**Nowa strona `Orders.razor`** (VS: prawy klik na folderze `Pages` → Add → **Razor Component**; „Class" dałby `.cs` — nie to): `@page "/orders"` + `@rendermode InteractiveServer` + `@inject HttpClient Http` + tabela `Id | Data` + `OnInitializedAsync` → `GET http://localhost:5143/api/Order`. Wyjaśnione, że `@page` = „tabliczka z adresem" — bez niej plik byłby komponentem, a sam link nic nie tworzy.

**⚠️ Wpadka — podmiana bloku zjadła sąsiedztwo:** przy zmianie karty Zamówienia (`div` → `a href`) zaznaczenie w VS zjadło otwarcie `<div class="row g-4">` i całą kartę Produkty, a stara karta została → **„Unexpected closing tag 'div' with no matching start tag"** (osierocony `</div>`). Fix i zasada na przyszłość: przy zmianie markupu dawać CAŁY plik (Ctrl+A → Delete → wklej), nie „podmień ten blok".

**Linki:** karta Zamówienia na `Home.razor` = `<a class="card ..." href="/orders">` + przycisk „Otwórz"; pozycja „Zamówienia" w `NavMenu.razor` (bez ikony — nowa klasa wymagałaby dopisania SVG w CSS); tekst karty „Wkrótce…" poprawiony na „Lista złożonych zamówień." (przestał być prawdą).

**Słownik:** nowy klucz `Date` (Pl „Data" / En „Date") — `Orders` już był, więc **1 klucz, nie 2** (lekcja: sprawdzić przed zapowiedzią liczby).

**Mikro-poprawka (1 linia):** `@order.Date` → `@(order.Date.ToString("dd.MM.yyyy"))` — na ekranie `03.10.2026` zamiast `3.10.2026 00:00:00`; `dd` = dzień, `MM` = miesiąc (`mm` = minuty), `yyyy` = rok.

**✅ TEST (user, Ctrl+F5):** zakładka Zamówienia → tabela `1 | 03.10.2026` ✅. Build zielony, bez zmian w API i bazie.

**Zmienione:** `Orders.razor` (nowy), `Home.razor`, `NavMenu.razor`, `Lang.cs`.

⏭️ **Następny krok:** Etap 1 — pozycje zamówienia: `OrderItemController` (GET/POST) + wejście w zamówienie (podgląd pozycji), potem kolumna „razem". Dalej: koszyk (Etap 2), kategorie.

---

**DZIEŃ 14 (2026-10-05, poniedziałek) — pozycje zamówienia w API (GET + POST) ✅; dzień zamknięty twardym STOP-em „nie robię, czego nie rozumiem".**

Cel dnia: wejść w zamówienie (pozycje). Start dobry: zagadka „które słowo sprawia, że baza zwraca JEDEN wiersz" → user wskazał zaślepkę `("{id}")` z adresu (nie `WHERE`) — pytanie było niejednoznaczne, objaśnione i domknięte: `("{id}")` → `int id` → `WHERE Id = @Id`.

**Nowy plik `Shop.Api\Controllers\OrderItemController.cs`** — user sam, metodą „skopiuj swój kontroler i przerób": `[HttpGet("{orderId}")]` → `SELECT ... FROM OrderItems WHERE OrderId = @OrderId`. Po wyjątku `SQLite Error 1: 'no such column: PrductId'` **sam znalazł literówkę w stringu SQL** (błąd cichy — build go nie widzi, wychodzi dopiero w bazie). Test: `http://localhost:5143/api/OrderItem/1` → `[]` ✅ (pusty wynik = sukces). Doszedł `[HttpPost] AddOrderItem` (`INSERT INTO OrderItems`, 4 parametry) → po dwóch `Invoke-RestMethod` GET zwraca 2 pozycje: `id 1` (productId 1, ilość 2, 59.99) i `id 2` (productId 2, ilość 1, 19.99) — **oba `orderId = 1`** = relacja 1-wiele widoczna w danych ✅.

Build: **0 błędów, 9 ostrzeżeń** (7 starych `CS8600` + 2 nowe; nie ruszać).

**⚠️ Wpadka FORMY (lekcja dla asystenta):** blok `[HttpPost]` poszedł jako gotowa wklejka („kopia `AddOrder`", bez ścieżki pliku) → user: „add order? gdzie to jest?", potem „wklejam to, nie rozumiem tych poleceń z SQL", a wklejka wylądowała w złym miejscu (metoda w metodzie → CS0106), przy tym plik w edytorze VS ≠ plik na dysku. Koniec: twarde STOP „nie będę robił czegoś, czego nie rozumiem". **Wniosek: logikę C# (kontroler, `@code`, SQL) tłumaczyć linijka po linijce — wklejka tylko dla lakieru (markup/CSS/słownik) albo jawnie oznaczona jako poprawka mechaniczna.**

**Zmienione:** `src\Shop.Api\Controllers\OrderItemController.cs` (nowy), `database\shop.db` (2 pozycje testowe).

⏭️ **Następny krok:** ekran `/orders/{id}` w Blazor (`@page "/orders/{id}"` + tabela pozycji) — **bez wklejek, linijka po linijce**; potem link z wiersza listy na `/orders/{id}`.

---

**DZIEŃ 15 (2026-10-06, wtorek) — EKRAN POZYCJI ZAMÓWIENIA ✅ (`/orders/{id}`: Produkt | Ilość | Cena) + link z listy. Etap 1 DOMKNIĘTY.**

Cel dnia: wejść w zamówienie i zobaczyć jego pozycje. Zagadka #1 (czytanie `Orders.razor`): „jedna linia, która decyduje o adresie strony" → `@page "/orders"` ✅ za pierwszym razem (pytanie nazywało MIEJSCE).

**⚠️ Trzy wpadki w trasie z numerem — cała lekcja dnia:**
1. **`@page "/orders[id]"`** (kwadratowe nawiasy, nawyk od atrybutów `[HttpGet]`/`[Route]` z API) → Blazor czyta `[id]` jako **zwykły tekst** → **„Not Found"** (strona nie istnieje; to nie awaria i nie błąd kompilacji). Dziurę na numer robią **klamry**: `{id}`.
2. **`@page "/orders{id}"`** — zniknął **ukośnik**; bez niego adres to sklejony tekst, nie `/orders/2`.
3. **`@page "/orders/{id}"` + `[Parameter] public int Id`** → **wyjątek runtime**: `InvalidCastException: Unable to cast 'System.String' to 'System.Int32'` — z adresu przychodzi **tekst**, a właściwość jest `int`. Fix: **`{id:int}`** (route constraint). Sprawdzone na TYMCZASOWYM projekcie (`dotnet new blazor`): `{id}`+`int` = **500**, `{id:int}`+`int` = **200**, `{id}`+`string` = **200** — dlatego poprawka poszła dopiero po teście, jako jedna wersja.

**⚠️ `@@code {` — podwójny małp = blok kodu czytany jako MARKUP:** lawina „Found markup element with unexpected name 'OrderItem'/'Product'/'List'", „Unclosed tag", „Nazwa „items”/„Id”/„ProductName” nie istnieje". Przyczyna: JEDEN znak — `@@` w Razor wypisuje `@` jako tekst. Fix: `@@code` → `@code`. (Edytor VS sam dokleja drugi `@` przy wpisywaniu w `.razor`.)

**⚠️ IntelliSense blokował pisanie** („coś na siłę wpieprza te podpowiedzi") → działa **`Ctrl+Alt+Space`** (tryb, w którym nic nie wchodzi samo) oraz na stałe: Opcje → Edytor tekstu → C# → IntelliSense → odznaczyć „Pokaż listę uzupełniania po wpisaniu znaku".

**Nowy plik `Shop\src\Shop.Web\Components\Pages\OrderDetails.razor`:** `@page "/orders/{id:int}"` + `[Parameter] public int Id { get; set; }` + tabela `Produkt | Ilość | Cena`. Dwa `GET` w `OnInitializedAsync` (pozycje zamówienia + lista produktów) i metoda `ProductName(int productId)` — `foreach` po produktach + `if` numer się zgadza → `return` nazwa (znane klocki, zero nowych konceptów). Pozycja trzyma tylko `ProductId`, więc nazwa musi być dopasowana ze słownika produktów.

**Słownik:** 2 nowe klucze — `OrderDetails` (Szczegóły zamówienia / Order details) i `Product` (Produkt / Product); `Quantity` i `Price` już były.

**✅ TEST (user, Ctrl+F5):** `/orders/2` → nagłówek „Szczegóły zamówienia **2**" + same nagłówki tabeli (pusto — poprawne: testowe pozycje mają `orderId: 1`); `/orders/1` → `? | 2 | 59,99 zł`, `? | 1 | 19,99 zł`, a po `POST` z `productId: 3` doszedł trzeci wiersz **`Myszka | 1 | 49,99 zł`** ✅.

**⚠️ `?` w kolumnie Produkt = wisząca referencja (dane, nie kod):** `GET api/Product` = tylko `{"id":3,"name":"Myszka"}`, a pozycje wskazują `productId` **1** i **2** (wpisane z palca w Dniu 14). Baza milczy, bo nie ma wymuszonego klucza obcego. Starych 2 wierszy nie ruszamy — materiał z Dnia 14.

**Link z listy:** `Orders.razor` — `<td>@order.Id</td>` → `<td><a href="/orders/@order.Id">@order.Id</a></td>`; klik w `1` otwiera `/orders/1` ✅.

**Pytanie usera o METODĘ:** „jak zwykły zjadacz chleba może dojść do tego, że wystarczyło dopisać `int`? jak nie AI, to gdzie szukać?" → 4 kroki: (1) przeczytać tekst wyjątku dosłownie (nazwa właściwości + typy), (2) oficjalna dokumentacja (learn.microsoft.com → Blazor routing → **route constraints**), (3) wkleić DOKŁADNY komunikat błędu w wyszukiwarkę, (4) mały projekt próbny. Sedno: nikt nie trzyma `:int` w głowie — trzyma nawyk sprawdzania.

**Zmienione:** `OrderDetails.razor` (nowy), `Orders.razor`, `Lang.cs`, `database\shop.db` (3. pozycja testowa).

⏭️ **Następny krok:** kolumna „razem" (ilość × cena) i suma zamówienia; potem formularz dodawania pozycji na stronie zamówienia; dalej koszyk (Etap 2). W kolejce: 9 ostrzeżeń `CS8600` (`ProductController.cs` — osobna powtórka o `null`).

---

**DZIEŃ 16 (2026-10-07, środa) — KOLUMNA „RAZEM" + SUMA ZAMÓWIENIA ✅ (krok „razem" z planu Dnia 15).**

Cel dnia (wybrany przez usera) = kolumna **„Razem"** (Ilość × Cena) i linia **„Suma zamówienia"** pod tabelą na `/orders/1`. Rytm: zagadka → opis słowami → przeróbka → test.

**Zagadka (czytanie własnego kodu):** „która linia wypisuje cenę, która daje ilość" → user wskazał `@item.Quantity` i `@item.Price zł` ✅ (pytanie nazywało MIEJSCE — obie linie trafione od razu).

**Przeróbka (user, linijka po linijce):** nowa metoda `OrderSum()` w `@code` obok `ProductName` — ten sam wzorzec: strażnik `if (items == null) return 0;` → `decimal total = 0;` (**licznik**) → `foreach` → `total = total + item.Quantity * item.Price;` → `return total;`. Plus linia `<p>@Lang.T("Sum"): @OrderSum() zł</p>` po `</table>`. Rozkładane m.in.: `=` to **rozkaz przypisania** („wynik z prawej wpisz do zmiennej po lewej", dlatego `total = total + …` ma sens), a `@( … )` to **granica wyrażenia** (bez nawiasów `@item.Quantity * item.Price` wypisałoby dosłowny tekst `2 * item.Price`).

**⚠️ WPADKA 1 — `@item.Total` → CS1061:** user dopisał 4. komórkę jako `@item.Total zł` („weź pole `Total`"), a `OrderItem` ma tylko `Id`, `OrderId`, `ProductId`, `Quantity`, `Price`. **Lekcja dnia (koncept):** w tej tabeli są DWA rodzaje komórek — **odczyt z danych** (`@item.Quantity`, `@item.Price` — pole istnieje w klasie, wartość przyszła z JSON-a) vs **liczenie w miejscu** (`@(item.Quantity * item.Price)` — takiej wartości nigdzie nie ma, trzeba ją policzyć). Dodatkowo zgubiony `<` w nagłówku (`th>…` zamiast `<th>…`).

**⚠️ WPADKA 2 — literówka w nazwie metody:** metoda zapisana jako `OrderSUm` (duże `U`), wołanie `@OrderSum()` → **CS0103 „Nazwa „OrderSum" nie istnieje w bieżącym kontekście"**. C# **rozróżnia wielkie i małe litery**: `OrderSUm` ≠ `OrderSum`. Błąd GŁOŚNY — kompilator sam podaje nazwę, nic nie trzeba zgadywać.

**🚨 WPADKA 3 — błąd ASYSTENTA (główna lekcja dnia):** ten sam CS0103 wracał 3× mimo poprawionej nazwy. Asystent sprawdzał tylko `OrderDetails.razor` (tam metoda była, wołania nie było) i tłumaczył komunikat „starym wpisem w Liście błędów" — a prawdziwa przyczyna była w **`Orders.razor`**: linia `<p>@Lang.T("Sum"): @OrderSum() zł</p>` wylądowała między `</tbody>` a `</table>` na stronie LISTY zamówień (która nie ma ani `OrderSum`, ani `items`). Oba pliki kończą się identycznie (`</tbody>` → `</table>` → `}`), więc wystarczyła aktywna zła karta przy wklejaniu. **Zasada: przy „nazwa nie istnieje" i czystym pliku z rozmowy → grep po CAŁYM projekcie** (gdzie DEFINICJA, gdzie WOŁANIE). Fix: linia usunięta z `Orders.razor` (plik wrócił 1:1 do stanu z commita).

**Pytanie usera „co to jest runtime?":** brak klucza w słowniku wychodzi dopiero w runtime — kompilator widzi tylko `string key`, więc `@Lang.T("Total")` bez wpisu rzuca `KeyNotFoundException` przy otwarciu strony (build zielony). Stąd klucze `Total`/`Sum` dopisane PRZED kodem kolumny; przyjęta tabela **kompilacja (build) vs runtime**.

**Delegacja na koniec:** user zmęczony pętlą błędów („popraw to sam") → asystent zapisał CAŁY `OrderDetails.razor` na dysku (`write_file`); user w VS przeładował kartę („zmieniony poza edytorem" → **Tak/Przeładuj**).

**✅ TEST (user, Ctrl+F5):** `/orders/1` = 4 kolumny — `? | 2 | 59,99 zł | 119,98 zł`, `? | 1 | 19,99 zł | 19,99 zł`, `Myszka | 1 | 49,99 zł | 49,99 zł` + **`Suma: 189,96 zł`** pod tabelą ✅ (119,98 + 19,99 + 49,99).

**Słownik:** 2 nowe klucze — `Total` (Razem / Total) i `Sum` (Suma / Sum); `Sum` dodany „na zapas" przed użyciem.

**Zmienione:** `src\Shop.Web\Components\Pages\OrderDetails.razor` (kolumna „Razem", metoda `OrderSum`, linia „Suma"), `src\Shop.Web\Lang.cs` (klucze `Total`, `Sum`).

⏭️ **Następny krok:** formularz dodawania pozycji na stronie zamówienia (wybierz produkt + ilość → „dodaj pozycję") — nowy klocek (`@bind` + `POST api/OrderItem`); dalej koszyk (Etap 2). W kolejce: 9 ostrzeżeń `CS8600` (`ProductController.cs` — osobna powtórka o `null`).

---

**DZIEŃ 17 (2026-10-08, czwartek) — LICZNIK „POZYCJE" + LINK POWROTNY ✅ (krótka sesja, zero nowych konceptów C#).**

Start: user „moze jakas dzisiaj krótka sesja?" → status (repo `Shop` czyste @ `d2dc8c3` = `origin/master`) → cel dnia dobrany jako drobiazg bez nowego konceptu. Rytm: zagadka-czytanie → przeróbka → test.

**Zagadka (czytanie własnego kodu):** „liczba w tabeli pojawia się na dwa sposoby — znajdź, gdzie jest ODCZYTANA z danych, a gdzie LICZONA" → user wskazał `@item.Price zł` (odczyt) i `@(item.Quantity* item.Price) zł` (liczenie) ✅ — ta sama para co w Dniu 16, trafiona od razu. Uzupełnienie: trzecie miejsce to `@OrderSum()` pod tabelą (liczenie schowane w metodzie).

**Przeróbka DONE ✅ (`OrderDetails.razor` + `Lang.cs`):**
- **Słownik:** para kluczy `Items` — `Pl` linia 31 = `{ "Items", "Pozycje" }`, `En` linia 58 = `{ "Items", "Items" }` (przecinek wędruje do `Sum`, znana konwencja). Zrobione PRZED kodem — brak klucza = `KeyNotFoundException` w runtime.
- **Markup:** linia 38 (zaraz po linii sumy, jeszcze w środku `else`): `<p>@Lang.T("Items"): @items.Count</p>`.
- **Koncept dnia:** `items.Count` = **właściwość** (bez nawiasów — lista sama wie, ile ma elementów = odczyt), kontrast z `OrderSum()` = **metoda** (nawiasy = wywołanie/liczenie). Ta sama różnica co `@item.Price` vs `@( … )`.

**Pytanie usera „gdzie mam wpisać to 2?"** → odpowiedź numerami linii + `Ctrl+G` → 37/38 i obrazek „przed → po" (NOWA linia NAD klamrą `}` zamykającą `else` — pod klamrą byłoby poza blokiem, gdzie `items` może być `null`). Weryfikacja `read_file`: wpisane poprawnie ✅ (wcięcie i miejsce w `else`).

**Link powrotny (druga drobna rzecz dnia):** linia 8, pod `<h1>`: `<p><a href="/orders">@Lang.T("Orders")</a></p>` — wzorzec linku z Dnia 13 (`<a href="/orders/@order.Id">`), klucz `Orders` był już w słowniku (nic do dopisania). Rozbiór: `<a>` = link, `href` = dokąd prowadzi, `@Lang.T("Orders")` = co widać. **Weryfikacja linku = KLIKNIĘCIE** (sam napis widać od razu, różnica to kolor i kursor).

**Pytanie usera „co to jest dwa? pierwszych…"** → powtórka wiszącej referencji z dowodem z API: `api/Product` = tylko `{id: 3, "Myszka"}`, a `api/OrderItem/1` = `productId` 1, 2, 3 → wiersze 1 i 2 nie mają swojego produktu, więc `ProductName` oddaje zapasowe `"?"`. Dane, nie kod; SQLite nie pilnuje klucza obcego. Zostaje jako materiał.

**✅ TEST (user, Ctrl+F5):** `http://localhost:5107/orders/1` → `Suma: 189,96 zł`, pod nią **`Pozycje: 3`** ✅; link „Zamówienia" pod nagłówkiem wraca na `http://localhost:5107/orders` ✅ (potwierdzone kliknięciem).

**Chaotyczne pisanie usera w czacie:** opis „wchodzi się w zamówienie, żeby zobaczyć, co w nim jest" — treść POPRAWNA (mapa: lista `1 | 03.10.2026` → klik w numer → `/orders/1` → pozycje → link powrotny; numer `Id` = łącznik obu stron). Normalizować, nie poprawiać — liczy się mechanizm, nie literówki.

**Zmienione:** `src\Shop.Web\Components\Pages\OrderDetails.razor` (linia 8 link powrotny, linia 38 licznik), `src\Shop.Web\Lang.cs` (klucz `Items`).

⏭️ **Następny krok:** formularz dodawania pozycji na stronie zamówienia (wybierz produkt + ilość → „dodaj pozycję") — NOWY klocek (`@bind` + `POST api/OrderItem`), wchodzić tylko na wyraźne „tak"; dalej koszyk (Etap 2). W kolejce: 9 ostrzeżeń `CS8600` (`ProductController.cs`).

---

**DZIEŃ 17 cd. (2026-10-08) — CZYSZCZENIE OSTRZEŻEŃ `CS8600`: 9 → 0 ✅ (kolejka z Dni 14/16 domknięta).**

User sam wrócił do tematu: wkleił 9× „**Konwertowanie literału null lub możliwej wartości null na nienullowalny typ**" i zapytał „**a jak to poprawic?**".

- **Skąd ostrzeżenia (ustalone `grep`, nie zgadywane):** wszystkie 9 to `GetConnectionString("ShopDb")` — `Program.cs` linia 21, `OrderController.cs` 16 i 40, `OrderItemController.cs` 19 i 46, `ProductController.cs` 19, 43, 58 i 72. `Shop.Api.csproj` ma `<Nullable>enable</Nullable>`, a `GetConnectionString` oddaje **`string?`** („tekst ALBO nic"), więc wpada do zmiennej `string` („na pewno tekst") → ostrzeżenie (build nadal zielony).
- **Poprawka (user SAM, `Ctrl+H` → „Zamień wszystko" w 4 plikach):** `GetConnectionString("ShopDb");` → `GetConnectionString("ShopDb") ?? "";` — ten sam wzorzec, który już był w `ProductController.cs` w linii 32 przy `Convert.ToString`.
- **Wynik:** build usera = „**jest czysto**" (0 błędów, 0 ostrzeżeń); grep potwierdził 9/9 linii z `?? ""` ✅.
- **⚠️ Lekcja dnia:** do meldunku user dołożył „**choc nie wiem czy rozumeim cały proces i czy w sensie dodana tego**" — czysty build NIE jest dla niego dowodem zrozumienia. Rozłożone na jego linii: `GetConnectionString("ShopDb")` → `??` sprawdza WARTOŚĆ z lewej (nic → bierze `""`, tekst → przepuszcza bez zmian) → zmienna `connectionString` → `new SqliteConnection(connectionString)`. **Zachowanie apki BEZ ZMIAN** (klucz `ShopDb` istnieje w `appsettings.json`, więc `??` nigdy nie zadziała) — zmiana jest tylko dla KOMPILATORA; sens porządku: pusta lista ostrzeżeń, żeby NOWE było widać od razu. Gdyby klucza naprawdę brakowało → do bazy idzie `""` i `connection.Open()` rzuca wyjątkiem (głośno, nie cicho).
- **Zmienione:** `src\Shop.Api\Program.cs`, `src\Shop.Api\Controllers\ProductController.cs`, `OrderController.cs`, `OrderItemController.cs`.

---

**DZIEŃ 18 (2026-10-09, piątek) — FORMULARZ DODAWANIA POZYCJI, CZĘŚĆ A: pasek na ekranie ✅ — część B (metody + podpięcie przycisku) ODŁOŻONA na jutro na życzenie usera.**

Start: user „hej! jaka dzisiejsza sesja? jakie propozycje?" → status (`Shop` czyste @ `cab159a` = `origin/master`) → rekomendacja A (formularz pozycji = nowy klocek `@bind` + `POST`) albo B (utrwalenie) → user wybrał **A**.

**Pytanie usera „co znaczy bind? jakie jest tłumaczenie w tym kontekście?"** → najpierw dosłownie („wiązać / powiązać"), potem mechanika BEZ przenośni: `@bind` na polu robi **dwa kierunki naraz** — zmienna → pole (pokazuje wartość) ORAZ pole → zmienna (zapisuje wpisane). Bez `@bind` trzeba by pisać `value=…` i osobno `@onchange=…`. Kluczowe: `@bind` **zapisuje do zmiennej**, więc zmienna musi istnieć — to nie jest zwykłe wypisanie tekstu jak `@item.Price`.

**Klik-test z Dnia 17 ZALICZONY ✅:** link „Zamówienia" (linia 8) na `/orders/1` wraca na listę `/orders` — wisząca weryfikacja zamknięta.

**Zagadka (czytanie):** „wskaż linię, którą strona pobiera dane z API" → user wkleił **CAŁĄ metodę** `OnInitializedAsync` z DWOMA liniami `GetFromJsonAsync` (`linia 50` = `OrderItem/{Id}`, `linia 51` = `api/Product`) i zapytał „o to chodzi?" = TRAFIENIE. ⚠️ Lekcja: pytanie mówiło „jedną linię", a plik ma dwie o tej samej roli — **liczbę linii ustalać po `read_file`, nie z pamięci**. Most do dnia: te linie tylko CZYTAJĄ (GET), dziś dokładamy ich przeciwieństwo (POST + pole).

**Opis słowami (przed kodem):** cel = dopisać pozycję z ekranu zamiast przez PowerShell; ekran = pod tabelą pasek [lista produktów ▼][ilość][Dodaj]; 3 kawałki + 2 istniejące linie (lista = `products` z linii 51, odświeżenie = linia 50); bez koszyka/logowania, a `POST api/OrderItem` istnieje od Dnia 14 → user: „chyba rozumiem".

**CZĘŚĆ A DONE ✅ (`src\Shop.Web\Components\Pages\OrderDetails.razor`):**
- **Markup** (wstawiony PO bloku `else`): `@if (products != null) { … }` z kartą `card` → `card-body` → `row g-2` → 3 kolumny `col-md-4`:
  - `<select @bind="selectedProductId" class="form-control">` + `@foreach (var product in products)` → `<option value="@product.Id">@product.Name</option>` (value = co wpadnie do zmiennej, tekst = co widać),
  - `<input @bind="quantity" placeholder="@(Lang.T("Quantity"))" class="form-control" />` (skopiowane 1:1 z `Products.razor`),
  - `<button class="btn btn-primary">@Lang.T("Add")</button>` — NA RAZIE bez akcji (część B).
- **`@code`:** dopisane `private int selectedProductId = 3;` i `private int quantity = 1;` (po `private List<Product>? products;`).
- **`Lang.cs` BEZ ZMIAN** — klucze `Product`, `Quantity`, `Add` już istniały (sprawdzone przed dopisywaniem, nie na wyczucie).
- **Po co `@if (products != null)`:** strażnik — w środku kompilator wie, że `products` nie jest `null`; bez tego `foreach (var product in products)` dałby ostrzeżenie CS8602.

**5 rzeczy do poprawy po wpisce usera (literówki + struktura):** `@foreach (var pproduct …)` → `product` (w `<option>` używał `product` = „nazwa nie istnieje"), `@blind` → `@bind` (pole nie zapisywałoby wartości do zmiennej), `class=" col-md-4"` (spacja), **brakujący `</div>`** karty (niezamknięty element = błąd Razora), brak obu zmiennych w `@code`. Następnie user: „popraw" → asystent zapisał poprawiony CAŁY plik na dysku (jak w Dniu 14) — instrukcja z przeładowaniem karty w VS (VS pyta o zapis → **Nie**, żeby nie nadpisać dobrej wersji).

**✅ TEST (user):** build = **0 błędów, 0 ostrzeżeń** (ostrzeżeń `CS8600` nie ma — domknięte w Dniu 17); `Ctrl+F5` → `http://localhost:5107/orders/1` → **pasek pod tabelą WIDAĆ** (lista z Myszką, pole ilości, przycisk Dodaj) ✅ — klik przycisku jeszcze nic nie robi.

**⏭️ CZĘŚĆ B — NA JUTRO (user: „możemy to zrobić jutro?"):** dopisać do `@code`:
- `AddItem()` — składa `new OrderItem { OrderId = Id, ProductId = selectedProductId, Quantity = quantity, Price = ProductPrice(selectedProductId) }`, wysyła `Http.PostAsJsonAsync("http://localhost:5143/api/OrderItem", newItem)`, na końcu odświeża `items = await Http.GetFromJsonAsync<List<OrderItem>>($"…/api/OrderItem/{Id}")`;
- `ProductPrice(int)` — kopia `ProductName` z 3 zmianami: zwraca `decimal`, oddaje `product.Price`, zapasowo `0`; dlaczego: endpoint zapisuje `Price` **wprost** do kolumny, sam jej nie szuka, więc cena musi przyjść z produktu;
- `@onclick="AddItem"` na przycisku (⚠️ bez `@` przycisk byłby martwy, a kompilator tego NIE zgłosi).
Test części B: `Dodaj` → nowy wiersz + `Pozycje:` 3 → 4.

**Zmienione:** `src\Shop.Web\Components\Pages\OrderDetails.razor` (+27 linii: pasek + 2 zmienne).

---

**DZIEŃ 19 (2026-10-10, sobota) — CZĘŚĆ B FORMULARZA POZYCJI DZIAŁA ✅ (przycisk „Dodaj" dodaje wiersz); plus DECYZJA O CENACH (cennik vs kopia + warunek zwijania).**

Start: user „hej! co dziś proponujesz na sesję?" → status (`Shop` czyste @ `8cc159a` = `origin/master`) → rekomendacja: dokończyć CZĘŚĆ B (gotowa z Dnia 18).

**Rozbiór CZĘŚCI A na życzenie usera** („wytłumacz co było w części A, żebym dobrze zrozumiał") — top-down: NAJPIERW dwie zmienne (`selectedProductId = 3`, `quantity = 1` = „pamięć paska"), potem markup od `@if (products != null)`: `card` → `row g-2` → 3 kolumny `col-md-4` = lista produktów (`<select @bind>` + `@foreach` → `<option value="@product.Id">@product.Name</option>`), pole ilości (`<input @bind="quantity">`), przycisk (bez akcji). ⚠️ **Lekcja:** numery linii podane wcześniej Z PAMIĘCI (kolumny 47/56/61, przycisk 61–63) były BŁĘDNE — plik ma **47/55/58** i przycisk **59**; numery do kotwicy `Ctrl+G` ustalać `grep`, nie pamięcią.

**CZĘŚĆ B DONE ✅ — `src\Shop.Web\Components\Pages\OrderDetails.razor`:**
- **Przycisk** (linia 59): dopisane `@onclick="AddItem"`.
- **`AddItem()`** (po `OrderSum()`): `new OrderItem { OrderId = Id, ProductId = selectedProductId, Quantity = quantity, Price = ProductPrice(selectedProductId) }` → `Http.PostAsJsonAsync("http://localhost:5143/api/OrderItem", newItem)` → odświeżenie `items = await Http.GetFromJsonAsync<List<OrderItem>>($"…/api/OrderItem/{Id}")`.
- **`ProductPrice(int)`**: kopia `ProductName` z 3 zmianami — zwraca `decimal`, oddaje `product.Price`, zapas `0`.
- Koncepty: `async Task` = to samo co `OnInitializedAsync` (czeka przez `await`); `PostAsJsonAsync` = WYSYŁA (POST), arg 1 = adres, arg 2 = obiekt; cena MUSI być policzona na stronie, bo `AddOrderItem` zapisuje `Price` wprost do kolumny.

**⚠️ BŁĄD DNIA — GŁOŚNE vs CICHE (literówki po wpisce usera):**
1. **GŁOŚNY (build go złapał):** `var newitem = …` vs użycie `newItem` → **CS0103 „Nazwa «newItem» nie istnieje"** — C# rozróżnia wielkość liter (małe `i` vs wielkie `I` to dwie nazwy).
2. **CICHE (build milczy, wybuchają w runtime):** `@oneclic="AddItem"` zamiast `@onclick` (guzik martwy), `http;//loclahost:5143` (średnik zamiast dwukropka + literówka), `loclahost`, a po pierwszej poprawce nadal `localahost` (dodatkowe `a`) w OBU adresach.
- **Objaw:** build „0 błędów", klik „Dodaj" nic nie robi, w konsoli brak wyjątku → to znak CICHEGO błędu w adresie/dyrektywie, nie brak kodu.
- **Fix:** `Ctrl+H` → „Zamień wszystko" `localahost` → `localhost`; restart `Shift+F5` → `Ctrl+F5`.
- **✅ TEST:** `/orders/1` → Myszka + ilość 2 → **Dodaj** → nowy wiersz, `Pozycje:` 3 → 4 ✅ (user: „dodało jeszcze raz myszka ilosc 2").

**Pytanie usera o CENY (myślenie procesami sklepu):** „jak przyjdą dwie dostawy po sobie, cena się zmieni? jak ustalać ceny — marża czy sztywno, zmieniane przez admina/dział handlowy?" → odpowiedź: **trzy warstwy ceny** (katalogowa `Product.Price` / kopia w zamówieniu `OrderItem.Price` / koszt zakupu — jeszcze go nie ma); **rekomendacja: sztywny cennik + kopia w zamówieniu, bez marży** (brak ceny zakupu = nie ma z czego liczyć `koszt + %`). Skutek dla zwijania: **klucz = produkt ORAZ cena**, różna cena → osobne wiersze. **User POTWIERDZIŁ: „zapisz sobie że tą rekomendację będziemy wprowadzać".**

**Zmienione:** `src\Shop.Web\Components\Pages\OrderDetails.razor` (przycisk + `AddItem()` + `ProductPrice()`); `database\shop.db` (dane z testu kliknięcia).

⏭️ **Następny krok:** zaimplementować **zwijanie pozycji** na `/orders/{id}` — jeden wiersz na parę (produkt + cena), ilości sumowane; nowa metoda na stronie (wzorzec „Łopata już jest?" z Magazynu: pętla + `if` + szukanie) + podmiana źródła w tabeli i w `Pozycje:`. Dalej: koszyk (Etap 2).

**KIERUNEK NA PRZYSZŁOŚĆ — PRZYGOTOWANIA DO WDROŻENIA (życzenie usera 2026-10-10):** user: „chciałbym robić przygotowania w tym kierunku, może Docker albo jakoś podobnie" — czyli chce szykować Shop pod wdrożenie (Docker / podobne). Ocena asystenta: na publiczny VPS jeszcze NIE (brak logowania/kont, adresy `http://localhost:5143` wpisane na sztywno w stronach, SQLite ze ścieżką Windows, brak HTTPS/reverse proxy) → najpierw dokończyć Etap 1–2 (pozycje + koszyk) i dodać logowanie/konta, a przygotowania wdrożeniowe (Docker + nginx + HTTPS + publikacja) zrobić jako OSOBNĄ sesję.

---

**DZIEŃ 19 cd. (2026-10-10, wieczór) — ZWIJANIE POZYCJI (metoda `GroupedItems()`) DZIAŁA ✅; ROZBIÓR KODU ODŁOŻONY NA NASTĘPNĄ SESJĘ.**

Cel: na `/orders/{id}` dwie linie Myszki → **jeden wiersz** `Myszka | 3 | 49,99 zł | 149,97 zł`; klucz zwijania = **produkt ORAZ cena** (decyzja o cenach z Dnia 19 — patrz wyżej).

**Zmiana w `src\Shop.Web\Components\Pages\OrderDetails.razor` (+29 linii):**
- NOWA metoda **`GroupedItems()`** (zwraca `List<OrderItem>`) wstawiona między `OrderSum()` i `AddItem()` — przechodzi po `items`, buduje NOWĄ listę `result` (para produkt+cena = jeden wiersz, ilości sumowane); wzorzec z Magazynu: `bool found` + `foreach` + `if`.
- Tabela (linia 26): `@foreach (var item in GroupedItems())`; licznik (linia 39): `@GroupedItems().Count`.
- `OrderSum()` dalej liczy surowe `items` — dlatego `Suma:` **bez zmian** (suma kwot = suma ilości × cena, niezależnie od zwijania).

**⚠️ BŁĄD DNIA — jeden znak = lawina (literówki po wpisce usera):**
1. **GŁOŚNY:** `foreanch(var row in result)` zamiast `foreach` (linia 120) → kompilator zwrócił **10 komunikatów** („Nazwa «var»/«row» nie istnieje", 2× CS1003, „Oczekiwano średnika"). To NIE 10 błędów — to JEDNA literówka (kaskada).
2. **CICHY:** brak `@` przed `GroupedItems()` w linii `Pozycje:` — build zielony, ale strona pokazałaby DOSŁOWNY tekst „Pozycje: GroupedItems().Count" zamiast liczby.
- Fix naniesiony przez asystenta (user: „popraw to za mnie") → build **3 projekty, 0 błędów, 0 ostrzeżeń** ✅.

**⏭️ DO OGRODZENIA NA NASTĘPNĄ SESJĘ — ROZBIÓR `GroupedItems()`:** user: „to hardcore ten kod jak dla mnie… działać to działa, sprawdzałem, build wstaje, nie ma błędów, funkcja działa. ale zapisz sobie, żeby ze mną ogarnąć ten kod". Rozbiór **od zera, po jednym kawałku** (3 części): **(1)** `var result = new List<OrderItem>();` + strażnik `if (items == null) return result;`; **(2)** `bool found = false;` + zewnętrzna pętla `foreach (var item in items)`; **(3)** wewnętrzna pętla `foreach (var row in result)` + `if (row.ProductId == … && row.Price == …)` → dolicz ilość / dopisz nowy wiersz. Ściana usera = **4 rzeczy naraz** (nowa lista-wynik, pętla w pętli, `&&`, doliczanie do wiersza); dwie z nich ma już z Magazynu (`foreach`, `bool found` + `if`), nowe są: **pętla w pętli** i **`&&`**. Metoda: NIE zadawać pytań kontrolnych, iść kawałkami na JEGO „dalej" → `feedback/user-gates-progress-himself.md`.

**Zmienione:** `src\Shop.Web\Components\Pages\OrderDetails.razor` (+29), `database\shop.db` (dane z testów).

---

**DZIEŃ 20 (2026-10-11, niedziela) — ZWIJANIE POZYCJI POTWIERDZONE NA EKRANIE ✅; ROZBIÓR `GroupedItems()` ODŁOŻONY (kod za gęsty).**

Start: user „jaki pomysł na dzisiejsza sesje nauki?" → status (`Shop` czyste @ `aa72886` = `origin/master`) → rekomendacja: domknięcie zwijania (klik-test + rozbiór `GroupedItems()` kawałkami); lżejsza alternatywa: 1 zagadka na tym kodzie. User: „ok".

**✅ KLIK-TEST ZWIJANIA ZALICZONY** (wisząca weryfikacja z Dnia 19 cd. ZAMKNIĘTA): user: „tak zwineło sie w jeden wiersz sumuje sie wszystko działa" → na `/orders/1` linie Myszki zlały się w JEDEN wiersz, ilości zsumowane. Cała funkcja (metoda + tabela linia 26 + licznik `Pozycje:` linia 39) potwierdzona end-to-end na ekranie.

**Krok 2 — rozbiór `GroupedItems()` (linie 110–134): kawałek 1 podany** (linie 110–117: `result` = pusta lista wynikowa, strażnik `if (items == null) return result;`, pętla po `items`). User: „**to jest za trudne**" → **STOP** (wina asystenta za rozmiar kawałka: 4 linie + `List<OrderItem>`/`null`/`result` naraz), przypomniane KONKRETNE osiągnięcie (zwijanie działa, build 0/0), wybór A (jedna linia 124) / B (STOP) / C (zagadka).

**⚠️ DIAGNOZA USERA (najważniejsze z dnia):** user: „**a to ja wiem że metoda pozwala sumować te same produkty z tą samą ceną, bo ceny nie możemy edytować. kod moim zdaniem jest za gruby żebym tak go złapał. czytam to i mało co ogarniam z tego**" → user **rozumie PO CO i WARUNEK** (jego jedno zdanie = dosłownie **linia 122** `if (row.ProductId == item.ProductId && row.Price == item.Price)`), a barierą jest **GĘSTOŚĆ kodu** (jeden blok ~25 linii), nie pojęcia. Redukcja pokazana: w całej metodzie NOWE jest tylko **pętla w pętli**; reszta (lista, `foreach`, `if`, `+`, `new`) = znane z `Dodaj()` w Magazynie.
- **⚠️ Lekcja formy:** rozbiór takiego bloku dzielić na **~2 linie**, a zaczynać od warunku, który user SAM potrafi powiedzieć — wtedy kod „przykleja się" do jego zdania.

**DECYZJA USERA — dzień zamknięty:** „ja bym to zostawił na razie, później można wrócić do tej funkcji albo tłumaczenia kodu po czasie. zróbmy opcję B" → rozbiór `GroupedItems()` **ODŁOŻONY** (kod zostaje, działa), dzień domknięty notatką + commitem.

**Zmienione:** tylko `Shop\shop-notes.md` (kod bez zmian).

---

**DZIEŃ 20 cd. (2026-10-11, druga sesja) — KROK 1 WDROŻENIA: adres API do konfiguracji ✅ (kierunek VPS/Docker).**

Kontekst: user sam podniósł kierunek infrastruktury („czemu coś nie zrobimy żeby przenieść na vps? albo jakiś docker czy coś?"), a wcześniej zawetował powrót do zamówień. Sprawdzone fakty: Docker **29.4.1 zainstalowany, ale Docker Desktop wyłączony**; brak `Dockerfile`; adres API `http://localhost:5143` wpisany na sztywno w **11 liniach** Weba. Blokery VPS: (1) lokalny adres — w kontenerze/na VPS `localhost` = ta sama maszyna, a API i strona to dwa procesy; (2) brak logowania. Rekomendacja asystenta (przyjęta): wynieść adres API do **konfiguracji** — na ekranie ZERO zmian.

**Zmiany (3 kroki):**
1. `src\Shop.Web\appsettings.json` — nowy klucz `"ApiUrl": "http://localhost:5143"`.
2. `src\Shop.Web\Program.cs` — `builder.Services.AddHttpClient();` → `var apiUrl = builder.Configuration["ApiUrl"] ?? "http://localhost:5143";` + `builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });`.
3. **11 linii w 3 stronach** — usunięte `http://localhost:5143/` (zostaje `api/...`, dokleja je `BaseAddress`): `Products.razor` (6), `Orders.razor` (1), `OrderDetails.razor` (4). `launchSettings.json` **NIE ruszony**.

**Dowód:** build **0 błędów / 0 ostrzeżeń** + apka działa na `/products`, `/orders`, `/orders/1` bez różnicy na ekranie. Od teraz adres API zmienia się w JEDNYM miejscu (`appsettings.json`), bez dotykania kodu.

**⚠️ Lekcje formy:**
- **JSON:** user **podmienia ostatni wpis** zamiast dopisać nowy klucz (ustawił `"AllowedHosts": "http://localhost:5143"`, klucza `ApiUrl` nie było) → przy `appsettings.json`/każdym JSON podawać CAŁY plik po zmianie (jak dla `.razor`). Po pokazaniu całości — OK.
- **Ctrl+H:** nazwy z panelu VS („Szybkie zastępowanie"/„Szukaj") NIE trafiły — user: „nie ma tu czegoś takiego… **wystarczyło dawać ente**". Przy zmianach czysto mechanicznych dawać prostą drogę (zaznacz fragment → Delete) albo proponować naniesienie przez asystenta.

**Zmienione:** `src\Shop.Web\appsettings.json`, `src\Shop.Web\Program.cs`, `3× src\Shop.Web\Components\Pages\*.razor`.

⏭️ **Następny krok wdrożenia (Krok 2):** Docker — `Dockerfile` + `docker-compose` (API + strona w kontenerach lokalnie); wymaga włączonego Docker Desktop. Ostatecznie VPS = osobna sesja przez SSH. ⚠️ Wciąż **brak logowania** — dodać przed publicznym VPS.

---

**DZIEŃ 20 cd. (2026-10-11, druga sesja, cz. 2) — KROK 2 WDROŻENIA: DOCKER (API + strona w kontenerach) ✅.**

Start: user „wchodzimy w dockera". Silnik wstał po ręcznym starcie Docker Desktop (`docker info`: 29.4.1, OSType linux); obrazy `mcr.microsoft.com/dotnet/sdk:10.0` i `.../aspnet:10.0` sprawdzone `docker manifest inspect` — są. Pojęcia podane od zera: **obraz** = zamrożona instalacja, **kontener** = uruchomiony obraz.

**Nowe pliki:**
- `src\Shop.Api\Dockerfile` + `src\Shop.Web\Dockerfile` — 2 etapy: `FROM ...sdk:10.0 AS build` (kompiluje `dotnet publish -c Release`) → `FROM ...aspnet:10.0` (kopiuje gotowe pliki), `EXPOSE 8080`, `ENTRYPOINT ["dotnet", "Shop.X.dll"]`.
- `.dockerignore` (root Shop) — `**/bin`, `**/obj`, `.vs`, `.git`.
- `docker-compose.yml` (root Shop) — usługa **shop-api** (wolumen `shop-data:/app/data`, `ConnectionStrings__ShopDb=Data Source=/app/data/shop.db`, port `5143:8080`) + **shop-web** (`ApiUrl=http://shop-api:8080`, port `5107:8080`, `depends_on: shop-api`). Klucz: **nazwa usługi `shop-api` = adres API w sieci compose** (dlatego `localhost` tam nie działa).

**Komendy i wyniki:** `docker build -f src/Shop.Api/Dockerfile -t shop-api .` → obraz `shop-api:latest` (393 MB); `docker run -d --rm --name shop-api -p 5143:8080 -e "ConnectionStrings__ShopDb=…" -v shop-data:/app/data shop-api` → API w kontenerze, `curl localhost:5143/api/Product` = `[]`; potem `docker stop shop-api` + `docker compose up --build -d` → `shop-shop-api-1` i `shop-shop-web-1` `Up`, `localhost:5107/` = 200.

**Dowód end-to-end:** user dodał produkt przez przeglądarkę na `http://localhost:5107/products` („dodało się") → `curl localhost:5143/api/Product` = `[{"id":1,"name":"Klawiatura","quantity":5,"price":14999}]` ⇒ **strona w kontenerze gada z API w kontenerze** ✅.

**⚠️ Obserwacje:**
- **Cena wyszła `14999` zamiast `149,99`** — pole liczby zjada separator (przecinek/kropkę); do poprawy przy okazji (input ceny).
- **Lekcje formy:** plik bez rozszerzenia w VS = „Dodaj → Nowy element → Ogólne → Plik tekstowy" + sprawdzić `.txt`; plik kropkowy poza projektami = Notatnik „Zapisz jako typ: Wszystkie pliki" (wyszło `.dockerignore.txt` → rename); `docker build` MUSI mieć **kropkę na końcu** (kontekst); „gdzie są te flagi?" → cała komenda w JEDNEJ linii + tabela część → znaczenie.
- User sam poprawił kosmetykę w `Products.razor` (`Http. GetFromJsonAsync` → `Http.GetFromJsonAsync`).

**Zmienione:** `docker-compose.yml`, `.dockerignore`, `src\Shop.Api\Dockerfile`, `src\Shop.Web\Dockerfile` (nowe) + kosmetyka `src\Shop.Web\Components\Pages\Products.razor`. Dane w kontenerze siedzą w wolumenie `shop_shop-data` (świeża, pusta baza — NIE ta z Windowsa).

⏭️ **Następny krok (Krok 3): VPS** — osobna sesja przez SSH (nginx/HTTPS). ⚠️ Wciąż **brak logowania** — dodać PRZED publicznym VPS.

---

**DZIEŃ 21 (2026-10-11, trzecia sesja) — LOGOWANIE: BRAMA PRZED VPS (kroki 1–7) ✅ + rozpoznanie serwera.**

Pytanie otwierające: „co dalej robimy pod vps? jak pomysł na sesję?". User sam wkleił dane serwera → okazało się, że **klucz `vps_magazyn` (z wcześniejszych wdrożeń) działa** i wchodzimy bez hasła: `ssh -i "%USERPROFILE%\.ssh\vps_magazyn" -p 2022 -o BatchMode=yes root@31.3.218.196`. **Hasła roota nie zapisujemy** (user dostał zalecenie `passwd` po sesji).

**Rozpoznanie serwera (`vps16211`, awhost, Ubuntu 22.04):** Docker **29.5.2** + Compose **v5.1.4** + nginx **1.18** już stoją; ufw aktywny (80, 443, 2022, 3001, 5173, 5174, 9090); wolne porty m.in. **5107 i 5143**; na serwerze chodzi **8 cudzych projektów** (magazyn, restaurant, stitchcore, napraw-mnie, rezerwuj) — niczego z tego nie ruszamy. Repo `github.com/krzysztofzelman/Shop` jest **PUBLICZNE** → `git clone` na serwerze pójdzie bez tokenów.

**Sprzątanie (na wyraźne „możemy tam coś wywalić"):** `docker builder prune -f` → zwolnione **~5 GB** (dysk `30G/40G (79%)` → `25G/40G (66%)`, czyli **14 GB luzu**). Świadomie **NIE ruszone** obrazy nieużywane (2 GB — mogą być kopie do cofnięcia cudzych projektów) ani wolumeny (mogą trzymać dane).

**Decyzja:** logowanie **przed** wystawieniem na publiczny VPS (user: „**zrobmy to logowanie poerw**"). Mechanizm przyjęty słowami: pole hasła → po poprawnym haśle strona pamięta zalogowanie na czas sesji karty → żądanie do API wiezie hasło w nagłówku, a API bez niego odmawia (`401`). Dlaczego blokada MUSI być też w API: stronę można pominąć i wołać API wprost (`curl -X DELETE` — user nie znał `curl`, dostał wyjaśnienie).

**Kroki 1–2 — pudełko stanu:**
- `src\Shop.Web\AuthState.cs` (NOWY): `namespace Shop.Web` + `public class AuthState { public bool IsLoggedIn = false; }`. User wpisał `isLoggedIn` z małej → **konwencja C#: rzeczy `public` piszemy z dużej** (jak `AddProduct`, `GetProducts`) — user sam poprawił na `IsLoggedIn`.
- `src\Shop.Web\Program.cs`: `using Shop.Web;` (top-level `Program` siedzi w globalnej przestrzeni, więc bez tego `AuthState` nie istnieje) + `builder.Services.AddScoped<AuthState>();`. **`AddScoped` = jedno pudełko na jedną sesję** (circuit = jedna otwarta karta). Build czysty ✅ (user sam: „nie ma jest czysto", w pliku został odstęp w `AddScoped < AuthState>()` — działa, C# pozwala).

**Krok 3 — hasło w konfiguracji:** `src\Shop.Web\appsettings.json` dołożony klucz `"SecretKey": "dev123"` (podany CAŁY plik — user podmienia ostatni wpis, więc całość jest bezpieczniejsza). Hasło **deweloperskie**, bo repo jest publiczne; na serwerze nadpiszemy je zmienną środowiskową — tak jak `ConnectionStrings__ShopDb` w compose.

**Krok 4 — strona logowania:** `src\Shop.Web\Components\Pages\Login.razor` (NOWY, cały plik): `@page "/login"`, `@rendermode InteractiveServer`, `@inject AuthState Auth` / `IConfiguration Config` / `NavigationManager Nav`; `Config["SecretKey"]` = wartość z konfiguracji; po zgodzie `Auth.IsLoggedIn = true;` + `Nav.NavigateTo("/products")`, w przeciwnym razie `wrongPassword = true` → czerwony tekst. Do słownika `Lang.cs` doszły klucze **`Login`, `SignIn`, `Password`, `WrongPassword`, `Logout`** (PL/EN). Test: złe hasło = czerwony tekst, `dev123` = wejście na `/products` ✅.

**Konsola przeglądarki — „mam błędy" ≠ błędy:** user zgłosił z konsoli `Information: Normalizing '_blazor'…`, `Information: WebSocket connected to ws://localhost:5107/_blazor?id=…` oraz `browserLink: [Violation] Permissions policy violation: unload is not allowed…`. **To nie są błędy:** `Information:` = połączenie Blazora wstało, a `browserLink` to funkcja Visual Studio (widać po nazwie źródła). Prawdziwy błąd jest czerwony i pisze `Error:`.

**Sprawdzenie sesji (ważne dla całej bramy):** zamiast zgadywać, user policzył linie `WebSocket connected …?id=` po zalogowaniu i kliknięciu „Produkty" → **jedna linia** ⇒ przejście zostało w **tej samej sesji**. Potwierdzone dokumentacją MS: nawigacja w aplikacji nie robi pełnego przeładowania, więc `AuthState` się trzyma.

**Krok 6 — blokada strony:** `src\Shop.Web\Components\Pages\Products.razor` (cały plik): `@inject AuthState Auth` + `@if (!Auth.IsLoggedIn) { żółty panel z linkiem do /login } else { …cała strona… }` oraz na starcie `OnInitializedAsync`: `if (!Auth.IsLoggedIn) { return; }` (bez hasła strona nie strzela do API). Nowy klucz słownika **`LoginRequired`**. Test F5 → panel zamiast tabeli ✅.

**Krok 7 — „Wyloguj" w menu:** `src\Shop.Web\Components\Layout\AuthNav.razor` (NOWY) + jedna pozycja `<AuthNav />` w `NavMenu.razor`. Wzorzec skopiowany z `LangSwitch` (menu jest statyczne, więc „żywy" element musi być osobnym interaktywnym elementem).

**Trzy problemy z tego kroku (każdy rozwiązany):**
1. **Enter w polu hasła nie działał** („to już wcześniej też tak było"). Przyczyna: pole i przycisk stały **luzem** — HTML wysyła Enterem tylko pole należące do `<form>`, a `@onclick` nie łapie klawisza. Fix: `<form @onsubmit="TryLogin" @onsubmit:preventDefault>` + `<button type="submit">` bez `@onclick` — jedno zdarzenie obsługuje Enter ORAZ klik.
2. **`Nazwa „NavLinkAllAll" nie istnieje`** — błąd wprowadzony PRZEZ ASYSTENTA do wklejonego `NavMenu.razor` (zamiast `Match="NavLinkMatch.All"`). Naprawione edycją na dysku; lekcja: nie wstawiać do pliku do wklejenia żadnych „celowych" błędów.
3. **„Wyloguj" nie pojawiało się w menu** po zalogowaniu. Przyczyna: `NavMenu`/`AuthNav` siedzą w **statycznym układzie** i są rysowane RAZ — Blazor nie przerysowuje ich przy przejściu na inną stronę (strona TAK, dlatego blokada działała). Fix w `AuthNav.razor`: `@implements IDisposable`, `OnInitialized()` → `Nav.LocationChanged += Refresh;`, `Refresh(...)` → `StateHasChanged()`, `Dispose()` → `-=`. Test: po zalogowaniu menu pokazuje „Wyloguj", klik wraca na `/login` ✅.

**⚠️ Znane ograniczenie (nie usterka):** `AuthState` żyje w jednej sesji karty, więc **F5 / Ctrl+R i przełącznik PL/EN wylogowują** (przełącznik robi pełne przeładowanie — `Nav.NavigateTo(Nav.Uri, forceLoad: true)`), a przy wejściu na stronę **mignie** panel „Zaloguj się". Dla obcego użytkownika bez znaczenia (nie zna hasła); gdy zacznie przeszkadzać — przenosimy zalogowanie do **ciasteczka**.

**Zmienione/nowe:** `src\Shop.Web\AuthState.cs` (nowy), `src\Shop.Web\Components\Pages\Login.razor` (nowy), `src\Shop.Web\Components\Layout\AuthNav.razor` (nowy), `src\Shop.Web\Lang.cs`, `src\Shop.Web\Program.cs`, `src\Shop.Web\appsettings.json`, `src\Shop.Web\Components\Pages\Products.razor`, `src\Shop.Web\Components\Layout\NavMenu.razor`.

⏭️ **Zostało:** **krok 8 — brama w API** (bez hasła `curl` dostaje `401`, nie skasuje produktu), potem **wdrożenie na VPS** (osobna sesja przez SSH: klon repo, `docker compose up --build -d`, otwarcie portu 5107, potem nginx + domena + HTTPS), a przy okazji drobiazg **pola ceny** (`149,99` → `14999`).

---

**⏭️ USTALENIA NA NASTĘPNĄ SESJĘ (dopięte 2026-10-11 na koniec Dnia 21, na wyraźne życzenie usera: „zapisz sobie i na git również").**

1. **Krok 8 zaczynamy od OMÓWIENIA kroku** — najpierw opis słowami (co ma się stać, co będzie widać na ekranie, czego jeszcze nie ma), a kod dopiero po „rozumiem". To stały układ przy nowym etapie/funkcji.

2. **Osobna sesja na UTRWALENIE ZROZUMIENIA kodu i plików** — user: „**na koniec musimy pogadać o zrozumieniu kodu plików itd. przydałaby się taka sesja bo mocno idziemy do przodu a wiedza musi się trochę uleżeć a sporo ostatnio tego było**". Sens: NIE nowy kod, tylko czytanie JEGO plików — mapa „co gdzie leży" (Web / Api / Shared, `Components\Pages` vs `Components\Layout`), kto z kogo korzysta, i 1 zagadka na raz, tempo dyktuje user. Zaplanowane po kroku 8.

---

**DZIEŃ 22 (2026-10-12, poniedziałek) — KROK 9 W TOKU: omówienie ✅ + kawałek 1 ✅ (hasło dla API). Sesja przerwana na chwilę przez usera.**

**Krok 9 — NAJPIERW omówienie słowami (zgodnie z ustaleniem z Dnia 21), kod dopiero po „ok to idzmy dalej".** Cel jednym zdaniem: **API ma przestać wykonywać polecenia od kogoś, kto nie podał hasła — nawet gdy ominie stronę.** Kotwica na własnym kodzie: `@if (!Auth.IsLoggedIn)` w `Products.razor` to **zasłona tylko na ekranie** („brama pilnuje drzwi, a okno — API — stoi otwarte": `curl -X DELETE` nie widzi strony i dziś kasuje produkt).

Trzy kawałki (po jednym na wiadomość):
1. **hasło dla API** — API musi znać to samo hasło co strona,
2. **brama w API** — przed wykonaniem czegokolwiek sprawdzenie hasła w nagłówku żądania; brak/złe → `401`, nic się nie dzieje,
3. **strona dokleja nagłówek do każdego żądania** — jedno miejsce w `Shop.Web\Program.cs` (nie 20 poprawek w `.razor`) + `Orders.razor` dostaje tę samą blokadę co `Products.razor`.

Żądanie HTTP rozłożone literalnie: **linia z metodą i adresem → nagłówki (`Nazwa: wartość`) → treść**; hasło jedzie jako JEDEN nagłówek (`X-Secret: dev123`) — ten sam, który user wpisze ręcznie do `curl`-a. **Dowód końcowy:** `curl` bez nagłówka → `401` i produkt zostaje; ten sam `curl` z nagłówkiem → działa. **Czego NIE ma:** kont użytkowników, tokenów, dat wygaśnięcia, HTTPS — jedno hasło dla wszystkich. ⚠️ Zapowiedziane z góry: przy `401` strona pokaże „Ładowanie" bez końca (to wyjątek z API, nie zawieszenie) — normalnie nie dojdzie do tego stanu, bo strona bez logowania nie wysyła żądań.

**Dwa pytania usera w trakcie omówienia (dobre pytania, nie objaw niezrozumienia):**

- **„gdzie są przechowywane hasła w bazie danych czy w kodzie?"** → **ani tam, ani tam — w PLIKU KONFIGURACYJNYM**: `Shop\src\Shop.Web\appsettings.json`, klucz `SecretKey` = `dev123`, czytany kodem `Config["SecretKey"]` (`Login.razor`). Nie baza, bo baza trzyma DANE, które się zmieniają (produkty, zamówienia) — nie ma hasła po czym wyszukiwać ani sumować; API nie ma tabeli „Users" i jej nie robimy. Na przyszłość (duże apki, nie dziś): w bazie leży **odcisk (hash) + sól**, nigdy samo hasło.
- **„czy tam może być to hasło na vps i git jeśli aplikacja będzie wrzucona na vps?"** → **dwa środowiska, dwie wartości.** `dev123` w gicie **JEST OK** (wartość deweloperska, jawna = nie sekret; kogoś z `dev123` na jego PC nic nie daje). Na VPS: `git clone` przywozi plik z `dev123`, ale kontener dostaje **zmienną środowiskową** `SecretKey=<prawdziwe>`, która **nadpisuje plik** — tym samym wzorcem co `ConnectionStrings__ShopDb` w `docker-compose.yml`. Prawdziwe hasło zapisane **tylko na serwerze** w pliku `.env` (Compose czyta go sam), **nie w gicie**. Zasada: *co jest w gicie, widzi cały świat* — dlatego prawdziwe hasło nie wchodzi ani do `appsettings.json`, ani wpisane wprost do `docker-compose.yml` (ten też jest w repo). ⚠️ **Do zrobienia w sesji VPS:** dopisać `.env` do `Shop\.gitignore` (dziś są tam tylko `bin/`, `obj/`, `.vs/`, `*.user`, `body.json`).

**KAWAŁEK 1 ✅:** `Shop\src\Shop.Api\appsettings.json` — dopisany klucz `"SecretKey": "dev123"`, **podany CAŁY plik** (user podmienia ostatni wpis zamiast dopisywać klucz — całość jest bezpieczniejsza); `read_file` potwierdził wartość zgodną z `Shop.Web`. Efektu w przeglądarce jeszcze nie ma — **API zna hasło, ale nikt go jeszcze nie pyta**.

**Zmienione:** `src\Shop.Api\appsettings.json`.

⏭️ **ZOSTAŁO (następna sesja): kawałek 2** — brama w `Shop\src\Shop.Api\Program.cs`. ⚠️ Zapowiedzieć userowi PRZED wpisaniem: **po tym kroku strona przestanie działać (każde żądanie dostanie `401`) aż do kawałka 3** — to nie awaria, to dowód, że brama łapie. Potem **kawałek 3** — `HttpClient` w `Shop\src\Shop.Web\Program.cs` wysyła nagłówek + blokada `Shop\src\Shop.Web\Components\Pages\Orders.razor`. Dalej (osobne sesje): utrwalenie zrozumienia kodu, VPS przez SSH, drobiazg pola ceny (`149,99` → `14999`).

---

**DZIEŃ 23 (2026-10-22, czwartek) — KROK 9 DOMKNIĘTY W KODZIE: brama w API + nagłówek po stronie klienta + blokada `/orders`. Powrót po 10 dniach przerwy.**

Start sesji: stan sprawdzony samemu (`origin/master` = `f7d0d4c`, drzewo czyste, `SecretKey` w `Shop.Api` jest, ale nikt go nie pytał) → rekomendacja = dokończyć krok 9; user wybrał bramę w API i poprosił o wyjaśnienie „na prosty język".

**KAWAŁEK 2 ✅ — brama w `Shop\src\Shop.Api\Program.cs`** (między `if (app.Environment.IsDevelopment())` a `app.UseAuthorization()`):

- `string secret = app.Configuration["SecretKey"] ?? "brak-klucza";` — hasło z `appsettings.json`; fallback celowo NIE pusty, żeby brak klucza zamykał bramę, a nie wpuszczał bez hasła.
- `app.Use(async (context, next) => { ... })` — jedno miejsce dla KAŻDEGO żądania; `next` = „przepuść dalej".
- `context.Request.Headers["X-Secret"].ToString()` — brak nagłówka daje pusty napis, więc `!=` zadziała.
- `given != secret` → `StatusCode = 401` + `WriteAsync("Unauthorized")` + **`return;`** — `return` jest kluczowe: bez niego API odmówiłoby na papierze i poszło dalej do `next()`.
- Kolejność: `app.Use` przed `app.MapControllers()` — brama wcześniej w łańcuchu niż trasy. Skutek uboczny (poprawny): `/openapi` w dev też dostaje `401`.

**KAWAŁEK 3 cz. 1 ✅ — nagłówek w `Shop\src\Shop.Web\Program.cs`:** rejestracja `HttpClient` z jednej linii zamieniona na blok:

```csharp
string secret = builder.Configuration["SecretKey"] ?? "brak-klucza";

builder.Services.AddScoped(sp =>
{
    var client = new HttpClient { BaseAddress = new Uri(apiUrl) };
    client.DefaultRequestHeaders.Add("X-Secret", secret);
    return client;
});
```

`DefaultRequestHeaders` = nagłówki doklejane do KAŻDEGO żądania tym klientem ⇒ `Products.razor`, `Orders.razor`, `OrderDetails.razor` i wszystkie POST/PUT/DELETE dostają `X-Secret` bez zmiany w `.razor`. Wartość musi być identyczna jak w API (`dev123` w obu `appsettings.json`).

**KAWAŁEK 3 cz. 2 ✅ — blokada `Shop\src\Shop.Web\Components\Pages\Orders.razor`:** `@inject AuthState Auth`; `@if (!Auth.IsLoggedIn)` → żółty panel `LoginRequired` + link `SignIn`, `else` → dotychczasowa tabela (wcięta o poziom); strażnik `if (!Auth.IsLoggedIn) { return; }` w `OnInitializedAsync`, żeby bez logowania strona nie pytała API.

**Dowód:** `dotnet build Shop.slnx` → 0 błędów, 0 ostrzeżeń. User: „logowałem się działa", tabela produktów pokazuje cenę `49,99` ⇒ nagłówek doszedł do API i brama wpuściła. ⚠️ **NIE PRZETESTOWANE:** `/orders` po wylogowaniu (panel zamiast tabeli) — **pierwsza rzecz następnej sesji**, razem z dowodem `curl` bez nagłówka → `401`.

**BŁĄD DNIA — podwójna wklejka całego pliku:** w `Shop.Api\Program.cs` wklejone dwie kopie jedna w drugą (dowód: `command.ExecuteNonQuery();using Microsoft.Data.Sqlite;` w jednej linii) ⇒ 12 błędów z JEDNEJ przyczyny („`builder`/`app`/`secret`/`cs`/`connection`/`command` już użyta", „`Microsoft.Data.Sqlite` używany jak typ", „Oczekiwano znaku `}`"). Lekcja: czytać PIERWSZY błąd, nie wszystkie; wklejać przez `Ctrl+A` → `Delete` → wklej. User: „mój błąd przy wklejaniu".

**Lekcja 2 — `AddScoped(sp => { ... })`:** zapis PRZEPISU, nie robota; wykonuje się dopiero, gdy strona pierwszy raz prosi o `HttpClient`. Wcześniej jedno wyrażenie („od razu oddaj klienta"), teraz dwa kroki (zbuduj → dopisz nagłówek → `return`), stąd klamry.

**Lekcja 3 — konsola przeglądarki:** `Information: Normalizing '_blazor'`, `WebSocket connected …?id=…` i `browserLink [Violation] Permissions policy` to NIE błędy (dwa pierwsze = sesja Blazora wstała, trzeci = dopisek Visual Studio przy F5). Prawdziwy błąd = czerwony `Error:`.

**Zmienione:** `src\Shop.Api\Program.cs`, `src\Shop.Web\Program.cs`, `src\Shop.Web\Components\Pages\Orders.razor`.

⏭️ **ZOSTAŁO:** (1) test `/orders` bez logowania + `curl` `401` (dowód bramy), (2) osobna sesja utrwalająca zrozumienie kodu, (3) VPS przez SSH, (4) drobiazg pola ceny (`149,99` → `14999`).

---

**DZIEŃ 23 cd. — KROK 9 ZWERYFIKOWANY W CAŁOŚCI (2026-10-22).**

- **Blokada `/orders` ✅:** user: „1 potwierdzam" (po wylogowaniu strona pokazuje sam żółty panel, bez tabeli i bez „Ładowanie").
- **Brama w API ✅ — dowód z `curl`, sprawdzony przez asystenta:** `curl -i http://localhost:5143/api/Product` → `HTTP/1.1 401 Unauthorized` + `Unauthorized`; `curl -i -H "X-Secret: dev123" …` → `HTTP/1.1 200 OK` + `[{"id":3,"name":"Myszka","quantity":29,"price":49.99}]`.

**KROK 9 ZAMKNIĘTY ✅ — logowanie jest gotowe pod wystawienie na VPS.** Zostaje: sesja utrwalająca zrozumienie kodu, VPS przez SSH, pole ceny (`149,99` → `14999`).

---

**DZIEŃ 24 — SHOP WDROŻONY NA VPS (2026-10-26, po 4 dniach przerwy).**

**Najpierw teoria, bez kodu** (user: „na początku wyjaśnij co to jest ten .env ? co to jest zmienna środowiskowa ?"): zmienna środowiskowa = para nazwa+wartość podana URUCHOMIONEMU procesowi z zewnątrz (dowód w jego własnym `docker-compose.yml`: `ConnectionStrings__ShopDb`); `builder.Configuration` czyta kilka źródeł po kolei (appsettings.json → … → zmienne środowiskowe → linia poleceń), więc zmienna **nadpisuje plik**; `.env` = zwykły plik tekstowy z liniami `NAZWA=wartość`, czytany przez `docker compose` (nie przez aplikację), który podstawia `${...}` w compose.

**KROK 1 — sekrety poza gitem ✅:** `Shop\.gitignore` + linia `.env` (dowód: `git check-ignore -v .env` → `.gitignore:6:.env`), `Shop\.dockerignore` + `.env`. Potem **`docker-compose.yml`: `- SecretKey=${SecretKey:?brak SecretKey …}` w OBU usługach** (`shop-api` i `shop-web`, bo Web dokleja nagłówek `X-Secret`). Znaczenie `:?` = compose **odmówi startu**, gdy `.env` nie ma — lepsze niż puste hasło. Lokalnie powstał `Shop\.env` z `SecretKey=dev123` (gitignored), `docker compose config` pokazał `SecretKey: dev123` przy obu usługach. Commit **`d569f4a`** wypchnięty.

**KROK 2 — serwer ✅:** `git clone … /root/shop` → commit `d569f4a`; `printf 'SecretKey=…' > /root/shop/.env` + `chmod 600`; `git status --short` na serwerze **pusty** ⇒ git nie widzi `.env`. Hasło: **20 znaków losowych** (tylko litery i cyfry), wygenerowane na PC, pokazane userowi RAZ w czacie; w repo i w notatkach go NIE ma.

**KROK 3 — start ✅:** `docker compose up --build -d` → obrazy zbudowane, sieć `shop_default`, wolumen `shop_shop-data`, kontenery `shop-shop-api-1` (5143→8080) i `shop-shop-web-1` (5107→8080) `Up`; `ufw allow 5107/tcp`. Testy na serwerze: API bez nagłówka **401**, z `X-Secret` **200**, strona **200**.

**ZNALEZISKO DNIA — Docker omija `ufw`:** `curl` z PC na `http://31.3.218.196:5143/api/Product` zwrócił **401**, choć port miał być zamknięty — Docker publikuje porty własnymi regułami iptables, obok `ufw`. Poprawka: `ports: "127.0.0.1:5143:8080"` (API dostępne tylko z wnętrza serwera; strona i tak gada z API po nazwie usługi `shop-api` w sieci compose). Commit **`0b1a383`** → na serwerze `git pull` + `docker compose up -d` (kontener API przeładowany). Dowód po zmianie: `http://31.3.218.196:5107/products` → **200**, `http://31.3.218.196:5143/api/Product` → **brak odpowiedzi (timeout)**.

**Lekcja dnia:** `.env` to nie szyfrowanie, tylko „nie wkładaj tego do repo" — przed rootem serwera nie chroni (`cat /root/shop/.env`, `docker inspect`). Dodatkowo: publikowany port Dockera żyje POZA `ufw`, więc zamyka się go przypięciem do `127.0.0.1`.

**TEST AKCEPTACYJNY ZALICZONY ✅ (user, przeglądarka):** „**dodało się. wylogowałem się, zalogowałem i produkt nadal jest**" — logowanie hasłem z `/root/shop/.env` działa, produkt `Klawiatura` przeżył wylogowanie i ponowne zalogowanie (nowa sesja Blazora). Dowód od strony serwera: `curl -H 'X-Secret: …' http://localhost:5143/api/Product` → `[{"id":1,"name":"Klawiatura","quantity":5,"price":149}]`, wolumen `shop_shop-data`, plik `/app/data/shop.db` (20 KB). **Wniosek:** dane są w bazie na serwerze, nie w sesji przeglądarki; bez wolumenu zniknęłyby przy restarcie kontenera.

**POPRAWKA POLA CENY ✅ (ta sama sesja, po wdrożeniu):** problem `149,99` → `14999` rozwiązany. Przyczyna: `<input @bind="price" …>` był związany wprost z `private decimal price`, więc `@bind` konwertował napis na liczbę wg kultury i separator wypadał. Poprawka w `Shop\src\Shop.Web\Components\Pages\Products.razor` (4 miejsca, markup BEZ zmian): `private string price = ""`; w `AddProduct` → `Price = decimal.Parse(price.Replace(',','.'), System.Globalization.CultureInfo.InvariantCulture)`; w `EditProduct` → `price = product.Price.ToString(System.Globalization.CultureInfo.InvariantCulture)`; w `Cancel` → `price = ""`. **Nowe słowa:** `Parse` (napis → liczba), `Replace` (zamiana znaków), `CultureInfo`/`InvariantCulture` (stała kultura = zawsze kropka), `ToString` (liczba → napis). **TEST ZALICZONY (user):** produkt `Klawiatura`, ilość `2`, cena wpisana `129,50` → w tabeli **`129,5 zł`** (czyli 129.50, poprawnie; brak zera na końcu, bo `decimal` nie pamięta zer). Ograniczenie: poprawka obsługuje JEDEN separator — `1.500,50` nadal wywali wyjątek. Na VPS wciąż stara wersja — wejdzie po `git pull` + przebudowaniu obrazu Web.

**WDROŻENIE POPRAWKI CENY NA VPS ✅ (ta sama sesja):** na serwerze `git pull --ff-only` → commit `199a608`, `docker compose up -d --build shop-web` (przebudowa SAMEJ strony, API bez zmian; obraz `shop-shop-web` świeży, oba kontenery `Up`, strona z zewnątrz `200`). **TEST usera na żywej wersji:** `Monitor` / `1` / `899,99` → w tabeli **`899.99 zł`** — wartość poprawna. ⚠️ **Kropka vs przecinek:** na VPS liczba wyświetla się z KROPKĄ, bo kontener linuksowy nie ma polskich ustawień kultury (lokalnie na Windows było `129,5 zł`). To tylko FORMAT wyświetlania, nie wartość. Gdyby chcieć polski format na serwerze — trzeba ustawić kulturę w `Shop\src\Shop.Web\Program.cs` (`CultureInfo.DefaultThreadCurrentCulture`), to osobna kosmetyka.

**KULTURA pl-PL ✅ (ta sama sesja, po poprawce ceny):** w `Shop\src\Shop.Web\Program.cs` user dopisał `using System.Globalization;` + pod `var builder = …` trzy linie: `var polish = new CultureInfo("pl-PL"); CultureInfo.DefaultThreadCurrentCulture = polish; CultureInfo.DefaultThreadCurrentUICulture = polish;`. Rola: **wyświetlanie** liczb/dat po polsku (przecinek dziesiętny) — wpisywanie ceny nadal idzie przez `decimal.Parse(…, InvariantCulture)`, więc przyjmie i przecinek, i kropkę. Nazwa czytana po słowach: Default = domyślna, Thread = wątek, Current = bieżący, Culture = kultura. Build 0 błędów → commit **`d146d41`** → na VPS `git pull` + `docker compose up -d --build shop-web`, serwer na `d146d41`, strona z zewnątrz `200`. User sam nazwał takie ustawienia „**daniną dla polskiego języka, nie must-have do pamiętania**".

⏭️ **ZOSTAŁO:** (1) domena + HTTPS przez nginx (dziś hasło idzie po HTTP jawnym tekstem — to najsłabsze ogniwo), (2) sesja utrwalająca zrozumienie kodu.
