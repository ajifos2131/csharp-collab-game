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