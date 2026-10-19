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
| 9 | prawo, bezpiecznik, prawo, napraw, prawo, wyjdz | Brak karty; pokój 4, energia 5, koniec False | Poprawne diałanie |
| 10 | karta, prawo, bezpiecznik, prawo, napraw, lewo, bezpiecznik | Energia 4, zasilanie True, bezpiecznik False; nie odradza się | Poprawne diałanie |
| 11 | Znajdźcie drogę zwycięską i zapiszcie ją poniżej | Jedna wygrana, bez jednoczesnej przegranej | karta, prawo, bezpiecznik, prawo, napraw, prawo, wyjdz |
| 12 | Pięć razy para prawo, lewo | Pokój 1, energia 0, koniec True, wygrana False | Poprawne diałanie |
| 13 | Po próbie 12: prawo, karta, status | Stan nie zmienia się; informacje nadal działają | Poprawne diałanie |
| 14 | Po końcu gry: start, status | Pokój 1, energia 10, wszystkie flagi False | Poprawne diałanie |
| 15 | Wpisz spacje + PRAWO + spacje | Pokój 2, energia 9; wielkość liter i skrajne spacje nie przeszkadzają | Poprawne diałanie |
| 16 | koniec | Aplikacja wraca do terminala | Poprawne diałanie |

## Nasza droga zwycięska

…

## Znaleziony błąd

- Wersja/commit: brak
- Kroki od startu: 
- Oczekiwane: …
- Rzeczywiste: …
- Poprawka i ponowna próba: …
