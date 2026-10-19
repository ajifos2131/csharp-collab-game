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

// Status jest gotowy: sluzy do testow, zanim autor mapy skonczy swoja sekcje.
void Status()
{
    Console.WriteLine("Pokoj: " + pokoj);
    Console.WriteLine("Energia: " + energia + "/" + MAKS_ENERGIA);
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
    return "Pokoj " + numer;
}

void Pomoc()
{
    // TODO A2: wypisz wszystkie komendy oraz koszt czynnosci.
    Console.WriteLine("TODO A: pomoc, status, mapa, opis, lewo, prawo,");
    Console.WriteLine("karta, bezpiecznik, napraw, wyjdz, start, koniec.");
}

void Mapa()
{
    // TODO A3: petla for, numery 1..4, jeden znacznik aktualnego pokoju.
    Console.WriteLine("TODO A: mapa.");
}

void Rozejrzyj()
{
    Console.WriteLine("Jestes w: " + NazwaPokoju(pokoj));
    // TODO A4: opis zalezy od pokoju oraz obecnosci przedmiotow/zasilania.
    Console.WriteLine("TODO A: opis pokoju.");
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
            }
        }else if(kierunek == "lewo"){
            if(pokoj == 1){
                Console.WriteLine("Nieznany pokoj. Zostajesz na Recepcji.");
                // energia += 1;
                return;
            }else{
                nastepnyPokoj -= 1;
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
        if (pokoj != 1 || karta)
        {
            Console.WriteLine("Tutaj nie ma karty do zabrania.");
            return;
        }

        karta = true;
        Console.WriteLine("Zabierasz karte.");
    }

    else if (co == "bezpiecznik")
    {
        if (pokoj != 2 || bezpiecznik || zasilanie)
        {
            Console.WriteLine("Nie mozesz zabrac bezpiecznika.");
            return;
        }

        bezpiecznik = true;
        Console.WriteLine("Zabierasz bezpiecznik.");
    }

    else if (co == "napraw")
    {
        if (pokoj != 3 || !bezpiecznik || zasilanie)
        {
            Console.WriteLine("Nie mozesz naprawic zasilania. Potrzebujesz bezpiecznika i wylaczonego zasilania.");
            return;
        }

        bezpiecznik = false;
        zasilanie = true;
        Console.WriteLine("Montujesz bezpiecznik. Zasilanie zostalo przywrocone.");
    }

    else if (co == "wyjdz")
    {
        if (pokoj != 4 || !karta || !zasilanie)
        {
            Console.WriteLine("Nie mozesz otworzyc drzwi. Potrzebujesz karty i dzialajacego zasilania.");
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
}

