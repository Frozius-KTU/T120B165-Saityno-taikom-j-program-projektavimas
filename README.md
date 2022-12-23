
**Kauno technologijos universitetas**

Informatikos fakultetas

**Saityno taikomųjų programų projektavimas**

**Inžinerinis projektas**

|||
| :- | :- |
|<p>**Autoriaus vardas ir pavadė** </p><p>Darmiras Burokas IFF-9/6</p>|(signature) (date)|
|||
|<p>**Pareigų sutrumpinimas, vardas ir pavardė**</p><p>dėst.val. Baltulionis Simonas</p>|(signature) (date)|
|doc. prakt. TAMOŠIŪNAS Petras||
Ataskaita

**Turinys**

[1.	Sistemos paskirtis	3](#_Toc122625863)

[2.	Funkciniai reikalavimai	4](#_Toc122625864)

[3.	Sistemos architektūra	5](#_Toc122625865)

[4.	Naudotojo sąsajos projektas	5](#_Toc122625866)

[5.	API specifikacija	5](#_Toc122625867)

[6.	Išvados	5](#_Toc122625868)





1. **Projekto tikslas**

Projekto tikslas – sukurti automobilio detalių parduotuvės administravimo sistemą, bei pritaikant tos sistemos funkcijas, internetinę detalių parduotuvę. Veikimo principas – sistemos naudotojai (klientai) galės sukurti tam tikram automobiliui prekes, jas redaguoti. Administratorius galės sukurti automobilių markes, bei jų modelius. Pagrindiniame puslapyje yra visas prekių sąrašas, kurį filtruoti pagal modelius. 

Klientas norėdamas naudotis šia platforma, turės prisiregistruoti prie svetainės ir galės pildyti savo krepšelį norimomis detalėmis. Užpildžius krepšelį, jis galės pasirinkti mokėjimo būdą, bei pristatymo specifikacijas(LP EXPRESS, Omniva, kurjeriu iki namų). Mokėjimo patvirtinimui bus naudojama Paysera API. Administratorius turi patvirtinti klientų krepšelius, bei sutikrinti pristatymo specifikacijas. Ši paskutinė dalis nebuvo realizuota.

1. **Funkciniai reikalavimai**

Neregistruotas naudotojas (Svečias) galės:

- Vartotojo registracija;
- Vartotoj prisijungimas;
- Peržiūrėti automobilio prekių sąrašą;
- Peržiūrėti konkrečios prekės informaciją;

Registruotas naudotojas (Vartotojas) galės:

- Atsijungti;
- Peržiūrėti automobilio prekių sąrašą;
- Peržiūrėti konkrečios prekės informaciją;
- Pridėti automobilio detalę į prekybą, ją redaguoti.

Sistemos administratorius galėas:

- Atsijungti;
- Pridėti, redaguoti, šalinti: markes, modelius, detales; 



1. **Sistemos architektūra**


*pav. 1. Sistemos architektūra.*

1. **Naudotojo sąsajos projektas**



1. **API specifikacija**

1. **CarBrand**


|**API metodas**|**(GET) Gauti markę**|
| :- | :- |
|**Atsako kodai**|**200 Success**|
|**Užklausos pavyzdys**|**https://localhost:7178/api/carBrand**|
|**Atsakymo pavyzdys**||

|<p>[</p><p>`  `{</p><p>`    `"id": "220d0ee7-ead3-4562-abd7-14cb9be625ef",</p><p>`    `"name": "Seat"</p><p>`  `},</p><p>`  `{</p><p>`    `"id": "b4ad4adf-5cf9-41ee-b841-cd87046bd18b",</p><p>`    `"name": "Mitsubishi"</p><p>`  `}</p><p>]</p>|
| - |

|||
| :- | :- |


|**API metodas**|**(POST) Sukurti markę**|
| :- | :- |
|**Atsako kodai**|**201 Created, 400 Bad Request, 401 Unauthorized**|
|**Užklausos pavyzdys**|**https://localhost:7178/api/carBrand**|
|**Atsakymo pavyzdys**||

|<p>{</p><p>`  `"id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",</p><p>`  `"name": "string"</p><p>}</p>|
| - |

|||
| :- | :- |


|**API metodas**|**(GET) Gauti markę pagal markės ID**|
| :- | :- |
|**Atsako kodai**|**200 OK, 404 Not Found**|
|**Užklausos pavyzdys**|**https://localhost:7178/api/carBrand/{carBrandId}**|
|**Atsakymo pavyzdys**||

|<p>{</p><p>`  `"id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",</p><p>`  `"name": "string"</p><p>}</p>|
| - |

|||
| :- | :- |


|**API metodas**|**(DELETE) Ištrinti markę pagal markės ID**|
| :- | :- |
|**Atsako kodai**|**204 No Content, 404 Not Found, 401 Unauthorized**|
|**Užklausos pavyzdys**|**https://localhost:7178/api/carBrand/{carBrandId}**|
|**Atsakymo pavyzdys**||

||
| - |

|||
| :- | :- |



|**API metodas**|**(PUT) Redaguoti markę pagal markės ID**|
| :- | :- |
|**Atsako kodai**|**204 No Content, 404 Not Found, 401 Unauthorized, 400 Bad Request**|
|**Užklausos pavyzdys**|**https://localhost:7178/api/carBrand/{carBrandId}**|
|**Atsakymo pavyzdys**||

||
| - |

|||
| :- | :- |


|**API metodas**|**(GET) Gauti modelius pagal markės ID**|
| :- | :- |
|**Atsako kodai**|**200 Success, 404 Not Found**|
|**Užklausos pavyzdys**|<p>[**https://localhost:7178/api/carBrand/**](https://localhost:7178/api/carBrand/)</p><p>**{carBrandId}/carModel**</p>|
|**Atsakymo pavyzdys**||

|<p>[</p><p>`  `{</p><p>`    `"id": "520ff37d-f9e4-452f-b5d4-420c9d22c2bc",</p><p>`    `"carBrand": {</p><p>`      `"id": "13d359a9-f546-4e71-b1f0-a0be36661f51",</p><p>`      `"name": "BMW"</p><p>`    `},</p><p>`    `"name": "E39"</p><p>`  `},</p><p>]</p>|
| - |

|||
| :- | :- |


|**API metodas**|**(GET) Gauti detales pagal modelio ir markės ID**|
| :- | :- |
|**Atsako kodai**|**200 Success, 404 Not Found**|
|**Užklausos pavyzdys**|<p>[**https://localhost:7178/api/carBrand/{carBrandId}**](https://localhost:7178/api/carBrand/%7bcarBrandId%7d)</p><p>**/carModel/{carModel{Id}/carPart**</p>|
|**Atsakymo pavyzdys**||

|<p>[</p><p>`  `{</p><p>`    `"id": "e4d2f6d4-b8d5-4c3d-8e78-2c6a99f7bc1a",</p><p>`    `"name": "Angelo Akys",</p><p>`    `"description": "Angel Eyes CCFL skritas e46 modeliui, tinka visiems kėbulams. Tik reflektorinėm farom.",</p><p>`    `"qty": 5,</p><p>`    `"photoUrl": "https://xenon.lt/bnuotraukos/ccfl-angel-eyes-kit-1.jpg",</p><p>`    `"carModel": {</p><p>`      `"id": "e7d17079-276d-4a74-b34a-b5baa2150484",</p><p>`      `"carBrand": {</p><p>`        `"id": "13d359a9-f546-4e71-b1f0-a0be36661f51",</p><p>`        `"name": "BMW"</p><p>`      `},</p><p>`      `"name": "E46"</p><p>`    `}</p><p>`  `}</p><p>]</p>|
| - |

|||
| :- | - |



|**API metodas**|**(GET) Gauti detales pagal markės ID**|
| :- | :- |
|**Atsako kodai**|**200 Success, 404 Not Found**|
|**Užklausos pavyzdys**|<p>[**https://localhost:7178/api/carBrand/{carBrandId}**](https://localhost:7178/api/carBrand/%7bcarBrandId%7d)</p><p>**/carPart**</p>|
|**Atsakymo pavyzdys**||

|<p>[</p><p>`  `{</p><p>`    `"id": "e4d2f6d4-b8d5-4c3d-8e78-2c6a99f7bc1a",</p><p>`    `"name": "Angelo Akys",</p><p>`    `"description": "Angel Eyes CCFL skritas e46 modeliui, tinka visiems kėbulams. Tik reflektorinėm farom.",</p><p>`    `"qty": 5,</p><p>`    `"photoUrl": "https://xenon.lt/bnuotraukos/ccfl-angel-eyes-kit-1.jpg",</p><p>`    `"carModel": {</p><p>`      `"id": "e7d17079-276d-4a74-b34a-b5baa2150484",</p><p>`      `"carBrand": {</p><p>`        `"id": "13d359a9-f546-4e71-b1f0-a0be36661f51",</p><p>`        `"name": "BMW"</p><p>`      `},</p><p>`      `"name": "E46"</p><p>`    `}</p><p>`  `}</p><p>]</p>|
| - |

|||
| :- | - |

1. **CarModel**

|**API metodas**|**(GET) Gauti modelius**|
| :- | :- |
|**Atsako kodai**|**200 Success**|
|**Užklausos pavyzdys**|**https://localhost:7178/api/carModel**|
|**Atsakymo pavyzdys**||

|<p>{</p><p>`  `"id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",</p><p>`  `"carBrand": {</p><p>`    `"id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",</p><p>`    `"name": "string"</p><p>`  `},</p><p>`  `"name": "string"</p><p>}</p>|
| - |

|||
| :- | - |


|**API metodas**|**(POST) Sukurti modelį**|
| :- | :- |
|**Atsako kodai**|**201 Created, 400 Bad Request, 401 Unauthorized**|
|**Užklausos pavyzdys**|**https://localhost:7178/api/carModel**|
|**Atsakymo pavyzdys**||

|<p>{</p><p>`  `"id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",</p><p>`  `"carBrand": {</p><p>`    `"id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",</p><p>`    `"name": "string"</p><p>`  `},</p><p>`  `"name": "string"</p><p>}</p>|
| - |

|||
| :- | - |



|**API metodas**|**(GET) Gauti modelį pagal ID**|
| :- | :- |
|**Atsako kodai**|**200 Success, 404 Not Found**|
|**Užklausos pavyzdys**|**https://localhost:7178/api/carModel/{carModelId}**|
|**Atsakymo pavyzdys**||

|<p>{</p><p>`  `"id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",</p><p>`  `"carBrand": {</p><p>`    `"id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",</p><p>`    `"name": "string"</p><p>`  `},</p><p>`  `"name": "string"</p><p>}</p>|
| - |

|||
| :- | - |


|**API metodas**|**(DELETE) Ištrinti modelį pagal ID**|
| :- | :- |
|**Atsako kodai**|**204 No Content, 404 Not Found, 401 Unauthorized**|
|**Užklausos pavyzdys**|**https://localhost:7178/api/carModel/{carModelId}**|
|**Atsakymo pavyzdys**||

|<p></p><p></p>|
| - |

|||
| :- | - |
**  

|**API metodas**|**(PUT) Redaguoti modelį pagal ID**|
| :- | :- |
|**Atsako kodai**|**204 No Content, 404 Not Found, 400 Bad Request, 401 Unauthorized**|
|**Užklausos pavyzdys**|**https://localhost:7178/api/carModel/{carModelId}**|
|**Atsakymo pavyzdys**||

|<p></p><p></p>|
| - |

|||
| :- | - |


|**API metodas**|**(GET) Gauti detales pagal modelio ID**|
| :- | :- |
|**Atsako kodai**|**200 Success, 404 Not Found**|
|**Užklausos pavyzdys**|<p>[**https://localhost:7178/api//carModel/{carModel{Id}/**](https://localhost:7178/api//carModel/%7bcarModel%7bId%7d/)</p><p>**carPart**</p>|
|**Atsakymo pavyzdys**||

|<p>[</p><p>`  `{</p><p>`    `"id": "e4d2f6d4-b8d5-4c3d-8e78-2c6a99f7bc1a",</p><p>`    `"name": "Angelo Akys",</p><p>`    `"description": "Angel Eyes CCFL skritas e46 modeliui, tinka visiems kėbulams. Tik reflektorinėm farom.",</p><p>`    `"qty": 5,</p><p>`    `"photoUrl": "https://xenon.lt/bnuotraukos/ccfl-angel-eyes-kit-1.jpg",</p><p>`    `"carModel": {</p><p>`      `"id": "e7d17079-276d-4a74-b34a-b5baa2150484",</p><p>`      `"carBrand": {</p><p>`        `"id": "13d359a9-f546-4e71-b1f0-a0be36661f51",</p><p>`        `"name": "BMW"</p><p>`      `},</p><p>`      `"name": "E46"</p><p>`    `}</p><p>`  `}</p><p>]</p>|
| - |

|||
| :- | - |
1. **CarPart**

|**API metodas**|**(GET) Gauti detales pagal ID**|
| :- | :- |
|**Atsako kodai**|**200 Success**|
|**Užklausos pavyzdys**|[**https://localhost:7178/api/](https://localhost:7178/api/)**carPart**|
|**Atsakymo pavyzdys**||

|<p>[</p><p>`  `{</p><p>`    `"id": "e4d2f6d4-b8d5-4c3d-8e78-2c6a99f7bc1a",</p><p>`    `"name": "Angelo Akys",</p><p>`    `"description": "Angel Eyes CCFL skritas e46 modeliui, tinka visiems kėbulams. Tik reflektorinėm farom.",</p><p>`    `"qty": 5,</p><p>`    `"photoUrl": "https://xenon.lt/bnuotraukos/ccfl-angel-eyes-kit-1.jpg",</p><p>`    `"carModel": {</p><p>`      `"id": "e7d17079-276d-4a74-b34a-b5baa2150484",</p><p>`      `"carBrand": {</p><p>`        `"id": "13d359a9-f546-4e71-b1f0-a0be36661f51",</p><p>`        `"name": "BMW"</p><p>`      `},</p><p>`      `"name": "E46"</p><p>`    `}</p><p>`  `}</p><p>]</p>|
| - |

|||
| :- | - |


|**API metodas**|**(POST) Sukurti detalę**|
| :- | :- |
|**Atsako kodai**|**201 Created, 400 Bad Request, 401 Unauthorized**|
|**Užklausos pavyzdys**|[**https://localhost:7178/api/](https://localhost:7178/api/)**carPart**|
|**Atsakymo pavyzdys**||

|<p>[</p><p>`  `{</p><p>`    `"id": "e4d2f6d4-b8d5-4c3d-8e78-2c6a99f7bc1a",</p><p>`    `"name": "Angelo Akys",</p><p>`    `"description": "Angel Eyes CCFL skritas e46 modeliui, tinka visiems kėbulams. Tik reflektorinėm farom.",</p><p>`    `"qty": 5,</p><p>`    `"photoUrl": "https://xenon.lt/bnuotraukos/ccfl-angel-eyes-kit-1.jpg",</p><p>`    `"carModel": {</p><p>`      `"id": "e7d17079-276d-4a74-b34a-b5baa2150484",</p><p>`      `"carBrand": {</p><p>`        `"id": "13d359a9-f546-4e71-b1f0-a0be36661f51",</p><p>`        `"name": "BMW"</p><p>`      `},</p><p>`      `"name": "E46"</p><p>`    `}</p><p>`  `}</p><p>]</p>|
| - |

|||
| :- | - |



|**API metodas**|**(POST) Gauti detalę pagal ID**|
| :- | :- |
|**Atsako kodai**|**200 Success** |
|**Užklausos pavyzdys**|[**https://localhost:7178/api/](https://localhost:7178/api/)**carPart/{carPartID}**|
|**Atsakymo pavyzdys**||

|<p>[</p><p>`  `{</p><p>`    `"id": "e4d2f6d4-b8d5-4c3d-8e78-2c6a99f7bc1a",</p><p>`    `"name": "Angelo Akys",</p><p>`    `"description": "Angel Eyes CCFL skritas e46 modeliui, tinka visiems kėbulams. Tik reflektorinėm farom.",</p><p>`    `"qty": 5,</p><p>`    `"photoUrl": "https://xenon.lt/bnuotraukos/ccfl-angel-eyes-kit-1.jpg",</p><p>`    `"carModel": {</p><p>`      `"id": "e7d17079-276d-4a74-b34a-b5baa2150484",</p><p>`      `"carBrand": {</p><p>`        `"id": "13d359a9-f546-4e71-b1f0-a0be36661f51",</p><p>`        `"name": "BMW"</p><p>`      `},</p><p>`      `"name": "E46"</p><p>`    `}</p><p>`  `}</p><p>]</p>|
| - |

|||
| :- | - |


|**API metodas**|**(Delete) Ištrinti detalę pagal ID**|
| :- | :- |
|**Atsako kodai**|**204 No content, 404 Not Found, 401 Unauthorized**|
|**Užklausos pavyzdys**|[**https://localhost:7178/api/](https://localhost:7178/api/)**carPart/{carPartID}**|
|**Atsakymo pavyzdys**||

||
| - |

|||
| :- | - |


|**API metodas**|**(Put) Redaguoti detalę pagal ID**|
| :- | :- |
|**Atsako kodai**|<p>**204 No content, 404 Not Found, 400 Bad Request,**</p><p>**401 Unauthorized**</p>|
|**Užklausos pavyzdys**|[**https://localhost:7178/api/](https://localhost:7178/api/)**carPart/{carPartID}**|
|**Atsakymo pavyzdys**||

||
| - |

|||
| :- | - |



1. **Auth**

|**API metodas**|**(GET) Gauti detales pagal userID**|
| :- | :- |
|**Atsako kodai**|**200 Success** |
|**Užklausos pavyzdys**|[**https://localhost:7178/api/](https://localhost:7178/api/)**users/{userID}/carParts**|
|**Atsakymo pavyzdys**||

|<p>{</p><p>`  `"id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",</p><p>`  `"name": "string",</p><p>`  `"description": "string",</p><p>`  `"qty": 0,</p><p>`  `"photoUrl": "string",</p><p>`  `"carModel": {</p><p>`    `"id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",</p><p>`    `"carBrand": {</p><p>`      `"id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",</p><p>`      `"name": "string"</p><p>`    `},</p><p>`    `"name": "string"</p><p>`  `}</p><p>}</p><p></p>|
| - |

|||
| :- | - |


|**API metodas**|**(POST) Registracija, grąžina vartotoją**|
| :- | :- |
|**Atsako kodai**|**200 Success , 400 Bad Request**|
|**Užklausos pavyzdys**|[**https://localhost:7178/api/](https://localhost:7178/api/)**register**|
|**Atsakymo pavyzdys**||

|<p>**{**</p><p>`  `**"userName": "string",**</p><p>`  `**"email": "string",**</p><p>`  `**"password": "string"**</p><p>**}**</p><p></p>|
| - |

|||
| :- | - |


|**API metodas**|**(POST) Prisijungimas, grąžina žetoną**|
| :- | :- |
|**Atsako kodai**|**200 Success, 400 Bad Request**|
|**Užklausos pavyzdys**|[**https://localhost:7178/api/](https://localhost:7178/api/)**login**|
|**Atsakymo pavyzdys**|<p>"accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwO</p><p>i8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9u</p><p>YW1lIjoiYWRtaW5hcyIsImp0aSI6IjZhZWZmOTAyLTZkOTUtNGVmNS1hYmI0LTQ3MWE3</p><p>ODQzZjZhNiIsInN1YiI6Im</p><p>FjMDk4NWQzLWQzNTktNDNkNS1hZTQ2LTUyYzNkZTNiZDY5OSIsImh0dHA6L</p><p>y9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXM</p><p>vcm9sZSI6WyJBZG1pbiIsIlNob3BVc2VyIl0sImV4cCI6MTY3MtgwMTgxMCwiaXNzIj</p><p>oiRGFtaXJhcyIsImF1ZCI6IlRyd</p><p>XN0ZWRDbGllbnQifQ.jpD7hviefU9XDDiI8HM98iEReeKTF5y1tK5VCTw\_23c"</p>|



|**API metodas**|**(GET) grąžina prisijungusį vartotoją.**|
| :- | :- |
|**Atsako kodai**|**200 Success** |
|**Užklausos pavyzdys**|[**https://localhost:7178/api/](https://localhost:7178/api/)**register**|
|**Atsakymo pavyzdys**||

|<p>{</p><p>`  `"additionalInfo": null,</p><p>`  `"id": "ac0985d3-d359-43d5-ae46-52c3de3bd699",</p><p>`  `"userName": "adminas",</p><p>`  `"normalizedUserName": "ADMINAS",</p><p>`  `"email": "adminas@pastas.com",</p><p>`  `"normalizedEmail": "ADMINAS@PASTAS.COM",</p><p>`  `"emailConfirmed": false,</p><p>`  `"passwordHash": "AQAAAAEAACcQAAAAEEhFIoCco8j/xUQy+3xZSOSuvEoJVbPXGBXWTF/+bLr+YRi6y/RhozB1h4Hm0Kgqqg==",</p><p>`  `"securityStamp": "JIEOLM3TMA4RCFFCYN4JVUVPUZFSPVAZ",</p><p>`  `"concurrencyStamp": "f398a272-9cd3-4cd4-9668-733566ec449a",</p><p>`  `"phoneNumber": null,</p><p>`  `"phoneNumberConfirmed": false,</p><p>`  `"twoFactorEnabled": false,</p><p>`  `"lockoutEnd": null,</p><p>`  `"lockoutEnabled": true,</p><p>`  `"accessFailedCount": 0</p><p>}</p><p></p><p></p>|
| - |

|||
| :- | - |

1. **Sistemos Prezentacija**

**Pagrindinis langas. Svečias mato visas galimas pirkti prekes, bei jų filtravimą. Svečias gali peržiūrėti konkrečios prekės informaciją.**


**Toliau svečias gali pasirinti prisijungti ar registruotis**


**Prisijungus administratoriui atsiranda dešinėje navigacija, kuri rodo visų markių, modelių ir detalių sąrašus.** 

**Kiekvienas administracinis sąrašas gali tam tikrą objektą sukurti, naikinti, redaguoti.**



**Toliau šoninėje navigacijos dalyje matome „Your car parts“, kur rodo kiekvienas to vartotojo sukurtas detales, jis tas detales gali redaguoti ir sukurti.**

**Bei paspaudus „Sign out“ vartotojas atjungiamas, bei atveriamas pagrindinis langas.**

1. **Išvados**
**
`	`Atliktas darbas, pritaikant Front – Angular, Back - .net 6 technologijas. Realizuota authorizacija ir autentifikacija, sukurti visi reikalaujami API metodai. Projekto repozitorija:

https://github.com/Frozius-KTU/T120B165-Saityno-taikom-j-program-projektavimas

