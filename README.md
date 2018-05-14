## Aplikacka 'BazaDanych GUI wykonana' na potrzeby zajęć 
**Wzorce Projektowe - Uniwersytet Śląski 2018**

Aplikacja została napisana w języku C# przy pomocy Visual Studio 2017 Community.
Wykorzystując dodatek MySQL Connector Net 6.10.6, potrafi połączyć się z jakąkolwiek bazą danych MySQL, pobrać z niej tablice i rekordy; dodawać, edytować i usuwać rekordy
* Żeby opcje w aplikacji działały poprawnie, pierwsza kolumna w tabeli musi być zawsze unikalna (Aplikacja traktuje pierwszą kolumnę jako identyfikator)

# Działanie aplikacji:
* Klikając przycisk połącz, aplikacja wprowadza dane połączenia do obiektu DBConnector, który używany jest potem do wykonywania różnych czynności na danej bazie. Następnie otwiera połączenie z bazą, pobiera z niej nazwy wszystkich obecnych tabel i przypisuje je do ComboBox'a. Jeśli są jakieś tabele, do ComboBox'a jako wartość akutalnie wybrana, zostaje przypisana pierwsza alfabetycznie tabela oraz zostają pobrane i wyświetlone w listview wszystkie jej rekordy.
* Zmieniając aktualnie wybraną tabele, aplikacja czyści obiekt listview i ponownie pobiera wszystkie rekordy do niego.
* Przyciski odpowiadające za edycje i usuwanie są dostępne tylko jeśli wybierzemy jakiś rekord z tabeli w obiekcie listview, natomiast opcja dodawania jest aktywna tylko wtedy jeśli są jakieś tabele w bazie danych.
* Wybierając opce Dodaj albo Edytuj, otwierane jest nowe okienko w którym po kolei podajemy wszystkie wartości (przy edycji jest pokazana wpisana stara wartość). Po wszystkim wykonane zostaje zapytanie do bazy dodające nowy rekord lub modyfikujące już istniejący oraz zostaje odświeżona tabela listview.
* Opcja usuwania działa na wielu rekordach jednoczeście. Wysyła zapytanie do bazy mające usunąć rekord, identyfikując go po pierwszej kolumnie.

# TODO:

* Walidacja wprowadzanych danych
* Sortowanie
* Cofanie operacji przy użyciu wzorca memento