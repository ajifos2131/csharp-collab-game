using System;
using System.Collections.Generic;

class DziennikWyprawy{
    public int LiczbaOdwiedzonych { get; private set;}
    public int LiczbaWpisow { get; private set; }
    private readonly List<string> _wpisy = new List<string>();
    private const int maksWpisow = 3;
    private bool[] _odwiedzone =  new bool[4];

    public DziennikWyprawy(){
        LiczbaOdwiedzonych = 0;
        LiczbaWpisow = 0;
        Odwiedz(1);
    }
    public void Odwiedz(int numer){
        if(numer < 1 || numer >4 || _odwiedzone[numer-1]){
            return;
        }else{
            _odwiedzone[numer-1] = true;
            LiczbaOdwiedzonych++;
        }
    }

    public bool? CzyOdwiedzono(int numer){
        if(numer < 1 || numer > 4){
            return null;
        }else{
            return _odwiedzone[numer-1];
        }
    }

    public void DodajWpis(string wpis){
        if(string.IsNullOrWhiteSpace(wpis)){
            return;
        }

        string oczyszczonyWpis = wpis!.Trim();
        if(_wpisy.Count >= maksWpisow){
            _wpisy.RemoveAt(0);
        }
        _wpisy.Add(oczyszczonyWpis);
        LiczbaWpisow++;
    }

    public string PobierzWpis(int index){
        if(index < 0 || index >= _wpisy.Count){
            return "";
        }

        return _wpisy[index];
    }

    public void Reset(){
        for(int i = 0; i < _odwiedzone.Length; i++){
            _odwiedzone[i] = false;
        }
        LiczbaOdwiedzonych = 0;
        Odwiedz(1);
        LiczbaWpisow = 0;
        _wpisy.Clear();
    }
}

class ProgramTestowy
{
    static void Main()
    {
        var dziennik = new DziennikWyprawy();

        // 1. Stan początkowy po konstruktorze
        Sprawdz(dziennik.LiczbaOdwiedzonych == 1, "Start: pokój 1 odwiedzony (liczba = 1)");
        Sprawdz(dziennik.LiczbaWpisow == 0, "Start: brak wpisów");
        Sprawdz(dziennik.CzyOdwiedzono(1) == true, "Start: pokój 1 -> true");
        Sprawdz(dziennik.CzyOdwiedzono(2) == false, "Start: pokój 2 -> false");
        Sprawdz(dziennik.CzyOdwiedzono(99) == null, "Start: zły numer pokoju -> null");

        // 2. Odwiedzanie pokoi (w tym ponowne i poza zakresem)
        dziennik.Odwiedz(2);
        dziennik.Odwiedz(2); // powtórne wejście nie powinno zwiększyć licznika
        dziennik.Odwiedz(0); // poza zakresem
        dziennik.Odwiedz(5); // poza zakresem
        Sprawdz(dziennik.LiczbaOdwiedzonych == 2, "Odwiedz: poprawne liczenie unikalnych pokoi");
        Sprawdz(dziennik.CzyOdwiedzono(2) == true, "Odwiedz: pokój 2 oznaczony");

        // 3. Dodawanie wpisów (null, puste, spacje, Trim, limit 3)
        dziennik.DodajWpis(null!);
        dziennik.DodajWpis("");
        dziennik.DodajWpis("    ");
        Sprawdz(dziennik.LiczbaWpisow == 0, "DodajWpis: ignoruje null, pusty i spacje");

        dziennik.DodajWpis("  Wpis 1  ");
        dziennik.DodajWpis("Wpis 2");
        dziennik.DodajWpis("Wpis 3");
        dziennik.DodajWpis("Wpis 4"); // usuwa "Wpis 1"

        Sprawdz(dziennik.LiczbaWpisow == 4, "DodajWpis: licznik wszystkich dodanych wpisów");
        Sprawdz(dziennik.PobierzWpis(0) == "Wpis 2", "PobierzWpis(0): najstarszy z zachowanych");
        Sprawdz(dziennik.PobierzWpis(1) == "Wpis 3", "PobierzWpis(1): środkowy");
        Sprawdz(dziennik.PobierzWpis(2) == "Wpis 4", "PobierzWpis(2): najnowszy po Trim");
        Sprawdz(dziennik.PobierzWpis(3) == "", "PobierzWpis(3): poza zakresem -> pusty napis");
        Sprawdz(dziennik.PobierzWpis(-1) == "", "PobierzWpis(-1): ujemny indeks -> pusty napis");

        // 4. Reset
        dziennik.Reset();
        Sprawdz(dziennik.LiczbaOdwiedzonych == 1, "Reset: tylko pokój 1 odwiedzony");
        Sprawdz(dziennik.CzyOdwiedzono(2) == false, "Reset: pokój 2 znowu nieodwiedzony");
        Sprawdz(dziennik.LiczbaWpisow == 0, "Reset: LiczbaWpisow == 0");
        Sprawdz(dziennik.PobierzWpis(0) == "", "Reset: dziennik pusty");

        Console.WriteLine("Koniec testów.");
    }

    static void Sprawdz(bool warunek, string nazwaTestu)
    {
        Console.WriteLine(warunek ? $"[OK]   {nazwaTestu}" : $"[BŁĄD] {nazwaTestu}");
    }
}