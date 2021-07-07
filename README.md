# Bootcamp-BitirmeProjesi


### İki Tip Kullanıcımız Var

### 1. Admin/Yönetici
- Daire bilgilerini girebilir.
- İkamet eden kullanıcı bilgilerini girer.
- Daire başına ödenmesi gereken aidat ve fatura bilgilerini girer(Aylık olarak). Toplu veya tek tek atama yapılabilir.
- Gelen ödeme bilgilerini görür.
- Gelen mesajları görür.
- Aylık olarak borç-alacak listesini görür.
- Kişileri listeler, düzenler, siler.
- Daire/konut bilgilerini listeler, düzenler siler.

### 2.Kullanıcı
- Kendisine atanan fatura ve aidat bilgilerini görür.
- Kredi kartı ile ödeme yapabilir.
- Yöneticiye mesaj gönderebilir.

#### Daire/Konut bilgilerinde
- Hangi blokda
- Durumu (Dolu-boş)
- Tipi (2+1 vb.)
- Bulunduğu kat
- Daire numarası
- Daire sahibi veya kiracı
#### Kullanıcı bilgilerinde
- Ad-soyad
- TCNo
- E-Mail
- Telefon
- Araç bilgisi(varsa plaka no)

## Kullanılan Teknolojiler
1. Web projesi için .Net 5 MVC
2. Sistemin yönetimi/database için MS SQL Server
3. Kredi kartı servisi için mongodb(verilerin tutulması için), .Net WebApi(Servis için).
