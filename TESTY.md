# Próby odbiorowe

Każdą próbę zaczynamy od start. Po sekwencji wpisujemy status. Komendy z tabeli wpisujemy osobno, każdą zatwierdzając Enterem. Oczekiwania odnoszą się do limitu 10.

| Nr | Próba i komendy po start | Oczekiwane | Otrzymane / osoba |
|---|---|---|---|
| 1 | mapa, pomoc, opis, status | 4 pokoje, 1 znacznik przy recepcji; energia 10 | Działa bez błędów |
| 2 | lewo, gora, pusty Enter | Pokój 1, energia 10 | wiadomosc nieznane brak ruchu: Poprawne działanie |
| 3 | prawo | Pokój 2, energia 9 | Poprawne działanie |
| 4 | prawo, prawo, prawo, prawo | Pokój 4, energia 7; ostatni ruch odrzucony | Poprawne działanie |
| 5 | karta, karta | Karta True, energia 9 | Poprawne zabranie karty i wiadomość o braku karty do zabrania |
| 6 | bezpiecznik | Bezpiecznik False, energia 10 | Poprawne działanie |
| 7 | prawo, prawo, napraw | Pokój 3, energia 8, zasilanie False | Poprawne działanie |
| 8 | karta, prawo, prawo, prawo, wyjdz | Brak zasilania; pokój 4, energia 6, koniec False | Poprawne działanie |
| 9 | prawo, bezpiecznik, prawo, napraw, prawo, wyjdz | Brak karty; pokój 4, energia 5, koniec False | Poprawne działanie |
| 10 | karta, prawo, bezpiecznik, prawo, napraw, lewo, bezpiecznik | Energia 4, zasilanie True, bezpiecznik False; nie odradza się | Poprawne działanie |
| 11 | Znajdźcie drogę zwycięską i zapiszcie ją poniżej | Jedna wygrana, bez jednoczesnej przegranej | karta, prawo, bezpiecznik, prawo, napraw, prawo, wyjdz |
| 12 | Pięć razy para prawo, lewo | Pokój 1, energia 0, koniec True, wygrana False | Poprawne działanie |
| 13 | Po próbie 12: prawo, karta, status | Stan nie zmienia się; informacje nadal działają | Poprawne działanie |
| 14 | Po końcu gry: start, status | Pokój 1, energia 10, wszystkie flagi False | Poprawne działanie |
| 15 | Wpisz spacje + PRAWO + spacje | Pokój 2, energia 9; wielkość liter i skrajne spacje nie przeszkadzają | Poprawne działanie |
| 16 | koniec | Aplikacja wraca do terminala | Poprawne działanie |
| ID | Próba — każda komenda osobno | Oczekiwanie |
|---|---|---|
| T2.1 | start, odkrycia, mapa, status | Odkryty tylko pokój 1; 1/4; energia 10; jeden znacznik bieżącej pozycji. | Poprawne działanie
| T2.2 | start, prawo, lewo, prawo, odkrycia, status | Odkryte 1 i 2; 2/4; pokój 2; energia 7. Powroty nie zwiększają liczby różnych pokojów. | Poprawne działanie
| T2.3 | start, prawo, prawo, prawo, odkrycia | 4/4; energia 7. Nazwy i znaczniki zgadzają się z pozycją. | Poprawne działanie
| T2.4 | start, lewo, gora, pusty Enter, odkrycia | 1/4; pokój 1; energia 10. | Poprawne działanie
| T2.5 | start, prawo, odkrycia, mapa, opis, status, odkrycia | Nadal 2/4 i energia 9; żadna informacja nie odkrywa nowego pokoju. | Poprawne działanie
| T2.6 | Po T2.3: start, odkrycia | Ponownie tylko pokój 1; energia 10. | Poprawne działanie
| T2.7 | start; pięć razy para prawo, lewo; prawo, odkrycia, status | Przegrana; pokój 1; energia 0; 2/4. Ruch po końcu nie działa, odczyt działa. | Poprawne działanie
| T2.8 | start, karta, prawo, bezpiecznik, prawo, napraw, prawo, wyjdz, odkrycia | Wygrana; energia 3; 4/4; odkrycia nie zmieniają wyniku. | Poprawne działanie
| T2.9 | Osobny test funkcji: nazwy dla 0 i 5; zliczenie pustej bool[] | Nieznane pomieszczenie dla obu numerów; wynik zliczenia 0; bez odwołania poza tablicę. | Poprawne działanie
| T2.10 | start, polecenie ODKRYCIA ze skrajnymi spacjami | Ten sam odczyt co odkrycia; energia 10. | Poprawne działanie

- Dodatkowo wykonajcie całe dotychczasowe TESTY.md. Nie zastępujcie tych prób tylko nowymi przypadkami.

## Nasza droga zwycięska

…

## Znaleziony błąd

- Wersja/commit: brak
- Kroki od startu: 
- Oczekiwane: spełnione
- Rzeczywiste: spełnione 
- Poprawka i ponowna próba: brak
