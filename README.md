# Interpreter własnego języka opartego na hieroglifach egipskich

**Autorzy:**
- Bartłomiej Łaciak, email: blaciak@student.agh.edu.pl
- Kamil Bernacik, email: kbernacik@student.agh.edu.pl

**Główne cele i założenia projektu:**
- opis własnego języka opartego na hieroglifach o nazwie **Isis** (od imienia egipskiej bogini Izydy)
- stworzenie interpretera z interfejsem graficznym, uruchamiającego programy napisane w języku Isis
- wpisywanie hieroglifów z autorskiej klawiatury z poziomu interfejsu graficznego
- system liczbowy oparty na egipskim systemie liczbowym [Wikipedia][1]
- składnia języka oparta jest głównie na okrojonej wersji C
- implementacja interpretera w **C#** używając frameworku **WinForms** z platformy **.NET**
- używany generator parserów: **ANTLR** w wersji **4.10.1**

[1]: https://pl.wikipedia.org/wiki/Egipski_system_liczbowy "Egipski system liczbowy"

**Gramatyka**

Pliki gramatyk znajdują się w katalogu /IsisPapyrus/Grammar

**Schemat struktury programu**

![plot](./Images/prog_struct.png)
