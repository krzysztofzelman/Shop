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
