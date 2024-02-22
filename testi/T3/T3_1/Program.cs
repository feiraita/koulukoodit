// See https://aka.ms/new-console-template for more information
using T3_1;

Moikkaaja moi1 = new Moikkaaja();
Moikkaaja moi2 = new Moikkaaja();
Moikkaaja moi_en = new Moikkaaja();
Moikkaaja moi_fi = new Moikkaaja();
Moikkaaja moi3 = new Moikkaaja();

moi1.AsetaMoi("Moikka");
moi1.Moikkaa();

moi2.Moikkaa("MOI");

moi_en.ValitseKieli("en");
moi_en.Moikkaa();

moi_fi.ValitseKieli("fi");
moi_fi.Moikkaa();

moi3.Moikkaa("Heippa");