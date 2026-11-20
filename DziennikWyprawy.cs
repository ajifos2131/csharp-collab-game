using Sysytem;

class DziennikWyprawy{
    int LiczbaOdwiedzonych { get; }
    int LiczbaWpisow { get; private set; }
    public DziennikWyprawy(){
        LiczbaOdwiedzonych = 0;
        LiczbaWpisow = 0;
    }
    void Odwiedz(int numer){
        if(numer < 1 || numer >4){
            return;
        }else{
            
        }
    }
}