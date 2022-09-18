Projekto tikslas – sukurti automobilio detalių parduotuvės administravimo sistemą, bei pritaikant tos sistemos funkcijas, internetinę detalių parduotuvę. 
Veikimo principas – sukurtą svetainę sudarys dvi dalys: administravimo sistema (Markių, modelių, detalių, naudotojų pridėjimas, redagavimas, šalinimas) ir internetinė parduotuvė, kuria naudosis klientai.

Klientas norėdamas naudotis šia platforma, turės prisiregistruoti prie svetainės ir galės pildyti savo krepšelį norimomis detalėmis. Užpildžius krepšelį, jis galės pasirinkti mokėjimo būdą, bei pristatymo specifikacijas(LP EXPRESS, Omniva, kurjeriu iki namų). Mokėjimo patvirtinimui bus naudojama Paysera API.  Administratorius turi patvirtinti klientų krepšelius, bei sutikrinti pristatymo specifikacijas. Taip pat administratorius gali redaguoti, pridėti, bei šalinti modelius, markes ir detalių asortimentą.

Funkciniai reikalavimai

Neregistruotas naudotojas (Svečias) galės:
1. Peržiūrėti prekių pasirinkimą;
2. Peržiūrėti konkrečios prekės informaciją;
2. Prisiregistruoti arba prisijungti.

Registruotas naudotojas (Klientas) galės:
1. Peržiūrėti prekių pasirinkimą;
2. Peržiūrėti konkrečios prekės informaciją;
3. Pridėti prekę į krepšelį;
4. Sumokėti už krepšelį;
5. Penkių žvaigždučių skalėje pateikti prekės rekomendaciją kitiems;
6. Palikti atsiliepimą (Tik nusipirkus prekę);
5. Atsijungti.

Sistemos administratorius galės:
1. Pridėti, redaguoti, šalinti: markes, modelius, detales, naudotojus;
2. Atsijungti;

Sistemos architektūra:
Front-End – naudojant Angular
Back-End – naudojant C# .net 6. Duomenų bazė – Microsoft sql server.

Reikalavimai:

Bent 3 taikomosios srities objektai tarpusavyje susieti prasmingu ir hierarchiniu ryšiu:

Markė ← Modelis ← Detalė

Bent 5 sąsajos (API) metodai. (Markės CRUD, Modelio CRUD, Detalės CRUD, User CRUD?) ir 1 metodas grąžinantis sąrašą.

Duomenų bazė – Microsoft sql server.

