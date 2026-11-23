# 🎬 Film Arşivim – Sinema Koltuk Yazılım

C# Windows Forms ve SQL Server ile geliştirilmiş, kişisel film arşivi uygulaması.
Filmlerinizi kategori ve YouTube linkiyle kaydedebilir, listeden seçtiğiniz filmi uygulama içinde izleyebilirsiniz.

> Bu proje, **"25 Derste 25 Uygulama"** serisi kapsamında geliştirilmiştir.

![Ekran Görüntüsü](screenshot.png)

## ✨ Özellikler

- 📝 **Film ekleme:** Film adı, kategori ve link bilgisiyle yeni film kaydı
- 📋 **Film listesi:** Kayıtlı filmlerin DataGridView üzerinde listelenmesi
- ▶️ **Uygulama içinde izleme:** Listede filme çift tıklayınca video, sağdaki ekranda açılır
- 🖥️ **Tam ekran:** Seçili film ayrı bir formda, kenarlıksız tam ekran olarak açılır
- 🎨 **Renk değiştir:** Her tıklamada 10 renk arasından rastgele arka plan rengi (aynı renk arka arkaya gelmez)
- ℹ️ **Hakkımızda** ve 🚪 **Çıkış** butonları

## 🛠️ Kullanılan Teknolojiler

| Teknoloji | Açıklama |
|---|---|
| C# / .NET Framework | Windows Forms masaüstü uygulaması |
| SQL Server Express | Film verilerinin saklanması |
| ADO.NET (`SqlConnection`, `SqlCommand`, `SqlDataAdapter`) | Veritabanı işlemleri |
| Microsoft Edge WebView2 | YouTube videolarının uygulama içinde oynatılması |

> **Neden WebView2?** Klasik `WebBrowser` kontrolü Internet Explorer motorunu kullanır ve YouTube artık IE'yi desteklemez. Bu yüzden Chromium tabanlı **WebView2** kullanılmıştır.

## 🗄️ Veritabanı

`FilmArsiv` adında bir veritabanı oluşturup aşağıdaki tabloyu ekleyin:

```sql
CREATE DATABASE FilmArsiv;
GO

USE FilmArsiv;
GO

CREATE TABLE TblFilmler (
    ID        INT IDENTITY(1,1) PRIMARY KEY,
    AD        NVARCHAR(100),
    KATEGORI  NVARCHAR(50),
    LINK      NVARCHAR(250),
    DURUM     BIT
);
```



## 📖 Kullanım

1. Sol taraftaki **Yeni Film** alanına film adı, kategori ve YouTube linkini yazıp **Kaydet**'e basın.
2. **Film Listesi**'nde izlemek istediğiniz filme **çift tıklayın**; film sağdaki **Ekran** alanında açılır.
3. **Tam Ekran** butonuyla filmi ayrı bir pencerede tam ekran izleyin, **Kapat** ile geri dönün.
4. **Renk Değiştir** ile uygulamanın arka plan rengini değiştirin.

## 📂 Proje Yapısı

```
FilmArsivim/
├── Form1.cs        # Ana form: film ekleme, listeleme, oynatma, renk değiştirme
├── Form2.cs        # Tam ekran oynatma formu
├── Program.cs      # Uygulama giriş noktası
└── README.md
```



⭐ Projeyi beğendiyseniz yıldız vermeyi unutmayın!
<img width="1894" height="1008" alt="Ekran görüntüsü 2026-11-23 193300" src="https://github.com/user-attachments/assets/c51c2626-b31a-46ac-bec9-73c7f669a10b" />
<img width="1903" height="988" alt="Ekran görüntüsü 2026-11-23 193310" src="https://github.com/user-attachments/assets/0fdb6d3a-6124-405a-add8-4aa8b98a06dd" />
<img width="1899" height="1023" alt="Ekran görüntüsü 2026-11-23 193627" src="https://github.com/user-attachments/assets/f931b05a-0c93-429f-a907-119fe3d8a6c9" />
<img width="1911" height="1004" alt="Ekran görüntüsü 2026-11-23 193822" src="https://github.com/user-attachments/assets/079ccfb6-e57c-4309-b983-16a728aa7733" />



