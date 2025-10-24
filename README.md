# Production Planner

Sebuah aplikasi web berbasis ASP.NET Core MVC dengan dukungan database (MySQL) untuk merencanakan produksi mobil per hari (Senin–Minggu). Aplikasi ini menyimpan data ke database dan menampilkan hasil perataan produksi.

## 🚀 Fitur
- Input jumlah produksi per hari (Senin–Minggu)
- Penanganan hari libur (nilai = 0)
- Hitung total dan rata-rata produksi
- Perataan hasil produksi dengan menjaga total tetap sama
- Simpan hasil ke database (Entity Framework Core + MySQL)
- Tampilkan seluruh data yang tersimpan dalam daftar

## 🧱 Teknologi
- ASP.NET Core MVC
- Entity Framework Core
- MySQL (Pomelo Provider)
- C#
- SQL (untuk operasi database)

## ⚙️ Instalasi & Setup

### 1. Prasyarat
Pastikan sudah menginstal:
- .NET SDK 6.0+
- MySQL (melalui XAMPP atau standalone)

### 2. Clone Repository
```bash
git clone https://github.com/tumbur1999/Production-Planner.git
cd Production-Planner
```

### 3. Konfigurasi Koneksi Database
Edit file `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=ProductionPlannerDB;user=root;password=;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### 4. Install Dependencies
```bash
dotnet add package Pomelo.EntityFrameworkCore.MySql
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet tool install --global dotnet-ef
```

### 5. Migrasi Database
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 6. Jalankan Aplikasi
```bash
dotnet run
```
Akses di browser: `https://localhost:5001`

---

## 📁 Struktur Proyek
```
/Controllers
  PlanningController.cs
/Data
  AppDbContext.cs
/Models
  Planning.cs
/Views
  /Planning
    Index.cshtml     ← Form input
    Result.cshtml    ← Tabel hasil perataan
    List.cshtml      ← Daftar semua rencana
appsettings.json
Program.cs
Migrations/
```

---

## 📊 Contoh Data Uji
| No | Input Produksi (Sen–Min) | Hasil Perataan | Total |
|----|---------------------------|----------------|--------|
| 1 | 4,5,1,7,6,4,0 | 4,5,4,5,5,4,0 | 27 |
| 2 | 6,0,4,6,5,0,0 | 6,0,5,6,5,0,0 | 22 |
| 3 | 5,5,5,5,5,5,5 | 5,5,5,5,5,5,5 | 35 |
| 4 | 4,4,4,4,4,0,0 | 4,4,4,4,4,0,0 | 20 |
| 5 | 8,6,4,3,5,0,0 | 7,6,5,4,4,0,0 | 26 |
| 6 | 3,2,6,5,4,0,0 | 3,3,5,5,4,0,0 | 20 |
| 7 | 7,7,0,7,5,0,0 | 7,7,0,7,5,0,0 | 26 |
| 8 | 10,8,9,7,6,5,0 | 9,8,9,8,7,6,0 | 45 |
| 9 | 5,0,0,6,0,5,6 | 5,0,0,6,0,5,6 | 22 |
| 10 | 2,3,1,4,2,3,0 | 2,3,2,3,2,3,0 | 15 |

---

## 🧠 Tips
- Gunakan angka 0 untuk hari libur agar tidak dihitung dalam rata-rata.
- Pastikan `dotnet-ef` sudah diinstal agar migrasi database bisa dijalankan.
- Pastikan folder `Migrations/` ikut di-push ke GitHub agar tim lain bisa langsung `update database` tanpa konflik.

---

## 🤝 Kontribusi
Pull request dipersilakan. Untuk perubahan besar, silakan buka issue terlebih dahulu untuk diskusi.

---

## 🪪 Lisensi
Hak Cipta © 2025. Silakan tambahkan lisensi (mis. MIT atau Apache 2.0) jika diperlukan.
