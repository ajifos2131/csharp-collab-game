using System;

// WSPOLNY KONTRAKT. Wszystkie dane inicjalizujemy przed Start().
const int MAKS_ENERGIA = 10;
int pokoj = 1;
int energia = MAKS_ENERGIA;
bool karta = false;
bool bezpiecznik = false;
bool zasilanie = false;
bool koniec = false;
bool wygrana = false;
int liczbaRuchow;
// SEKCJA 0: GOTOWY SILNIK NAUCZYCIELA. Nie zmieniaj w zadaniu podstawowym.
Start();
while (true)
{
    Console.Write("> ");
    string? wejscie = Console.ReadLine();
    if (wejscie == null)
    {
        Console.WriteLine("Koniec wejscia. Zamykam program.");
        break;
    }

    string polecenie = wejscie.Trim().ToLowerInvariant();
    if (polecenie == "koniec")
    {
        Console.WriteLine("Do zobaczenia!");
        break;
    }
    if (polecenie == "")
    {
        Console.WriteLine("Wpisz polecenie albo pomoc.");
        continue;
    }

    // Rozdzielacz dziala od poczatku, zeby zespoly mogly testowac niezaleznie.
    switch (polecenie)
    {
        case "start": Start(); break;
        case "pomoc": Pomoc(); break;
        case "status": Status(); break;
        case "mapa": Mapa(); break;
        case "opis": Rozejrzyj(); break;
        case "lewo": Idz("lewo"); break;
        case "prawo": Idz("prawo"); break;
        case "karta": Akcja("karta"); break;
        case "bezpiecznik": Akcja("bezpiecznik"); break;
        case "napraw": Akcja("napraw"); break;
        case "wyjdz": Akcja("wyjdz"); break;
        default: Console.WriteLine("Nieznane polecenie. Wpisz pomoc."); break;
    }
}

void Start()
{
    liczbaRuchow = 0;
    pokoj = 1;
    energia = MAKS_ENERGIA;
    karta = false;
    bezpiecznik = false;
    zasilanie = false;
    koniec = false;
    wygrana = false;
    Console.WriteLine("UCIECZKA Z SERWEROWNI: PIATEK, 16:59.");
    Console.WriteLine("Administrator napisal: u mnie dziala. Drzwi twierdza inaczej.");
    Console.WriteLine("Masz " + MAKS_ENERGIA + " energii. Wpisz pomoc. Koniec zamyka program.");
    Rozejrzyj();
}

void ZakonczTure()
{
    energia = energia - 1;
    Console.WriteLine("Pozostala energia: " + energia);
    if (wygrana)
    {
        koniec = true;
        Console.WriteLine("WYGRANA! Drzwi otwarte. Weekend uratowany.");
    }
    else if (energia <= 0)
    {
        koniec = true;
        Console.WriteLine("PRZEGRANA. Energia sie skonczyla. Wpisz start albo koniec.");
    }
}

// tworzenie pasku energii
string PasekEnergii()
{
    string pasek = "";
    int miejsca = MAKS_ENERGIA;
    for (int i = 0; i < energia; i ++){
        pasek += "#";
        miejsca -= 1;
    }

    for (int i = 0; i < miejsca; i ++){
        pasek += ".";
    }

    return pasek;
}

// Status jest gotowy: sluzy do testow, zanim autor mapy skonczy swoja sekcje.
void Status()
{
    Console.WriteLine("Pokoj: " + pokoj);
    // Console.WriteLine("Energia: " + energia + "/" + MAKS_ENERGIA);
    Console.WriteLine("Energia: " + PasekEnergii());
    Console.WriteLine("Liczba ruchów: " + liczbaRuchow);
    Console.WriteLine("Karta: " + karta);
    Console.WriteLine("Bezpiecznik: " + bezpiecznik);
    Console.WriteLine("Zasilanie: " + zasilanie);
    Console.WriteLine("Koniec: " + koniec);
    Console.WriteLine("Wygrana: " + wygrana);
}

// SEKCJA A: INFORMACJE I MAPA. Wlasciciel: osoba A.
string NazwaPokoju(int numer)
{
    // TODO A1: zwroc nazwe dla 1, 2, 3, 4 oraz wartosc dla nieznanego numeru.
    string Nazwapokoju = "";
    if(numer == 1){
        Nazwapokoju = "Recepcja";
    }else if(numer == 2){
        Nazwapokoju = "Magazyn";
    }else if(numer == 3){
        Nazwapokoju = "Serwerownia";
    }else if(numer == 4){
        Nazwapokoju = "Wyjście";
    }else{
        Nazwapokoju = "Nieznane pomieszczenie";
    }
    return Nazwapokoju;
}

void Pomoc()
{
    // TODO A2: wypisz wszystkie komendy oraz koszt czynnosci.
    Console.WriteLine("----- Komendy i koszt -----");
    Console.WriteLine("\n--- Informacje ---");
    Console.WriteLine("pomoc - koszt: 0");
    Console.WriteLine("status - koszt: 0");
    Console.WriteLine("mapa - koszt: 0");
    Console.WriteLine("opis - koszt: 0");
    Console.WriteLine("\n--- Ruch ---");
    Console.WriteLine("lewo - koszt: 1");
    Console.WriteLine("prawo - koszt: 1");
    Console.WriteLine("wyjdz - wychodzi z budynku jeżeli ma taką opcje:  koszt: 1");
    Console.WriteLine("start - rozpoczyna rozgrywkę od początkowych ustawień: koszt: 1");
    Console.WriteLine("\n--- Przedmioty ---");
    Console.WriteLine("karta - koszt: 1");
    Console.WriteLine("bezpiecznik - koszt: 1");
    Console.WriteLine("\n--- Działanie ---");
    Console.WriteLine("napraw - koszt: 1");
    Console.WriteLine("koniec - Kończy program: koszt: 1");
}

void Mapa()
{
    // TODO A3: petla for, numery 1..4, jeden znacznik aktualnego pokoju.
    Console.WriteLine("TODO A: mapa.");
    for(int numer=1; numer<=4; numer++){
        if(pokoj == numer){
        Console.WriteLine("Pokój "+numer+": "+NazwaPokoju(numer)+" <-- jesteś tutaj");
        }else{
            Console.WriteLine("Pokój "+numer+": "+NazwaPokoju(numer));
        }
    }
}

void Rozejrzyj()
{
    Console.WriteLine("Jestes w: " + NazwaPokoju(pokoj));
    // TODO A4: opis zalezy od pokoju oraz obecnosci przedmiotow/zasilania.
    if(NazwaPokoju(pokoj) == "Recepcja"){
        if(karta == false){
            Console.WriteLine("karta jest na biurku");
        }else{
            Console.WriteLine("jest biurko");
        }
    }else if((NazwaPokoju(pokoj) == "Magazyn")){
        if(bezpiecznik == false && zasilanie == false){
            Console.WriteLine("Bezpiecznik jest na półce");
        }else{
            Console.WriteLine("Półki");
        }
    }else if((NazwaPokoju(pokoj) == "Serwerownia")){
        if(zasilanie){
            Console.WriteLine("Zasialnie przywrócone");
        }else{
            Console.WriteLine("Brak zasilania");
        }
    }
}

// SEKCJA B: RUCH. Wlasciciel: osoba B.
void Idz(string kierunek)
{
    int nastepnyPokoj = pokoj;
    // TODO B1: odrzuc ruch po zakonczeniu gry (return).
    if(koniec == true){
        return;
    }else{
    // TODO B2: policz nastepnyPokoj, nie zmieniaj jeszcze wspolnego pokoj.
    // TODO B3: odrzuc nieznany kierunek i ruch poza pokoje 1..4.
        if (kierunek == "prawo"){
            if(pokoj == 4){
                Console.WriteLine("Nieznany pokoj. Zostajesz na Wyjściu.");
                // energia += 1;
                return;
            }else{
                nastepnyPokoj += 1;
                liczbaRuchow +=1;
            }
        }else if(kierunek == "lewo"){
            if(pokoj == 1){
                Console.WriteLine("Nieznany pokoj. Zostajesz na Recepcji.");
                // energia += 1;
                return;
            }else{
                nastepnyPokoj -= 1;
                liczbaRuchow +=1;
            }
        }

    // TODO B4: zatwierdz pokoj, wywolaj Rozejrzyj i raz ZakonczTure.
        pokoj = nastepnyPokoj;
        Rozejrzyj();
        ZakonczTure();
    }
    Console.WriteLine("TODO B: ruch " + kierunek);
}

// SEKCJA C: PRZEDMIOTY I WYGRANA. Wlasciciel: osoba C.
void Akcja(string co)
{
    if (koniec)
    {
        Console.WriteLine("Gra jest juz zakonczona. Wpisz start, aby zagrac ponownie.");
        return;
    }
    else if (co == "karta")
    {
        if (pokoj != 1)
        {
            Console.WriteLine("Tutaj nie ma karty do zabrania.");
            return;
        }
        else if (karta)
        {
            Console.WriteLine("już zabrałeś kartę");
            return;
        }

        karta = true;
        Console.WriteLine("Zabierasz karte.");
    }

    else if (co == "bezpiecznik")
    {
        if (pokoj != 2)
        {
            Console.WriteLine("Tutaj nie ma bezpiecznika do zabrania.");
            return;
        }
        else if(bezpiecznik)
        {
            Console.WriteLine("Masz już bezpiecznik.");
            return;
        }
        else if(zasilanie)
        {
            Console.WriteLine("Zasilanie jest już włączone.");
            return;
        }

        bezpiecznik = true;
        Console.WriteLine("Zabierasz bezpiecznik.");
    }

    else if (co == "napraw")
    {
        if (pokoj != 3)
        {
            Console.WriteLine("W tym pokoju nie mozesz naprawic zasilania.");
            return;
        }
        else if(!bezpiecznik)
        {
            Console.WriteLine("Nie masz bezpiecznika");
            return;
        }
        else if(zasilanie)
        {
            Console.WriteLine("Zasilanie jezt już włączone.");
            return;
        }

        bezpiecznik = false;
        zasilanie = true;
        Console.WriteLine("Montujesz bezpiecznik. Zasilanie zostalo przywrocone.");
    }

    else if (co == "wyjdz")
    {
        if (pokoj != 4)
        {
            Console.WriteLine("Nie mozesz otworzyc drzwi na tym piętrze.");
            return;
        }
        else if(!karta)
        {
            Console.WriteLine("Brakuje ci karty.");
            return;
        }
        else if(!zasilanie)
        {
            Console.WriteLine("Brakuje ci zasilania.");
            return;
        }

        wygrana = true;
        koniec = true;
        Console.WriteLine("Udało się wyjść!");
    }
    else
    {
        Console.WriteLine("Nieznana akcja.");
        return;
    }

    ZakonczTure();
    // Rozróżnij niewłaściwe pomieszczenie, już zabraną kartę, brak bezpiecznika oraz już naprawione zasilanie.
    // Przy wyjściu rozróżnij brak karty, brak prądu i brak obu. Najpierw obsłuż koniec gry, potem niewłaściwy pokój, następnie pozostałe warunki.
    // Każda odmowa kończy gałąź przed zmianą stanu i wywołaniem ZakonczTure(). Zachowaj dotychczasowe warunki sukcesu.
}

