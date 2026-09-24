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
