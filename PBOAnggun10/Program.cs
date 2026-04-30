using System;
using System.Collections.Generic;

public class Kendaraan
{
    public string nama;
    public int kecepatan;

    public Kendaraan(string nama, int kecepatan)
    {
        this.nama = nama;
        this.kecepatan = kecepatan;
    }

    public virtual void Bergerak()
    {
        Console.WriteLine($"{nama} sedang bergerak dengan kecepatan {kecepatan} km/jam");
    }

    public void InfoKendaraan()
    {
        Console.WriteLine($"Nama: {nama}, Kecepatan: {kecepatan} km/jam");
    }
}

public class Darat : Kendaraan
{
    public int jumlahRoda;

    public Darat(string nama, int kecepatan, int jumlahRoda)
        : base(nama, kecepatan)
    {
        this.jumlahRoda = jumlahRoda;
    }

    public void HitungRoda()
    {
        Console.WriteLine($"Jumlah roda: {jumlahRoda}");
    }

    public override void Bergerak()
    {
        Console.WriteLine($"{nama} berjalan di darat dengan {jumlahRoda} roda");
    }
}

public class Air : Kendaraan
{
    public string jenisAir;

    public Air(string nama, int kecepatan, string jenisAir)
        : base(nama, kecepatan)
    {
        this.jenisAir = jenisAir;
    }

    public void CekKondisiAir()
    {
        Console.WriteLine($"Berada di air {jenisAir}");
    }

    public override void Bergerak()
    {
        Console.WriteLine($"{nama} bergerak di air ({jenisAir})");
    }
}

public class Mobil : Darat
{
    public Mobil(string nama, int kecepatan, int jumlahRoda)
        : base(nama, kecepatan, jumlahRoda) { }

    public void Klakson()
    {
        Console.WriteLine("Tin Tin!");
    }

    public override void Bergerak()
    {
        Console.WriteLine("Mobil melaju di jalan raya");
    }
}

public class Motor : Darat
{
    public Motor(string nama, int kecepatan, int jumlahRoda)
        : base(nama, kecepatan, jumlahRoda) { }

    public void GasPol()
    {
        Console.WriteLine("Ngeeeeng!");
    }

    public override void Bergerak()
    {
        Console.WriteLine("Motor melaju dengan cepat");
    }
}

public class Kapal : Air
{
    public Kapal(string nama, int kecepatan, string jenisAir)
        : base(nama, kecepatan, jenisAir) { }

    public void Berlayar()
    {
        Console.WriteLine("Kapal sedang berlayar");
    }

    public override void Bergerak()
    {
        Console.WriteLine("Kapal berlayar di laut");
    }
}

public class Perahu : Air
{
    public Perahu(string nama, int kecepatan, string jenisAir)
        : base(nama, kecepatan, jenisAir) { }

    public void Dayung()
    {
        Console.WriteLine("Perahu didayung");
    }

    public override void Bergerak()
    {
        Console.WriteLine("Perahu bergerak dengan dayung");
    }
}

public class Garasi
{
    private List<Kendaraan> daftarKendaraan = new List<Kendaraan>();

    public void TambahKendaraan(Kendaraan kendaraan)
    {
        daftarKendaraan.Add(kendaraan);
    }

    public void DaftarKendaraan()
    {
        foreach (var k in daftarKendaraan)
        {
            k.InfoKendaraan();
        }
    }
}

class Program
{
    static void Main()
    {
       // a. Buat objek garasi
        Garasi garasi = new Garasi();

        // b. Buat beberapa objek kendaraan
        Mobil mobil = new Mobil("Avanza", 120, 4);
        Motor motor = new Motor("Vario", 100, 2);
        Kapal kapal = new Kapal("Titanic", 50, "laut");
        Perahu perahu = new Perahu("Sampan", 20, "sungai");

        // c. Tambahkan ke garasi
        garasi.TambahKendaraan(mobil);
        garasi.TambahKendaraan(motor);
        garasi.TambahKendaraan(kapal);
        garasi.TambahKendaraan(perahu);

        // d. Tampilkan semua data
        Console.WriteLine("=== DAFTAR KENDARAAN ===");
        garasi.DaftarKendaraan();

        // e. Demonstrasikan polymorphism
        Console.WriteLine("\n=== POLYMORPHISM ===");
        Kendaraan k1 = mobil;
        Kendaraan k2 = kapal;

        Console.Write($"{mobil.nama} -> ");
        k1.Bergerak();

        Console.Write($"{kapal.nama} -> ");
        k2.Bergerak();

        // f. Panggil method khusus
        Console.WriteLine("\n=== METHOD KHUSUS ===");

        Console.WriteLine("\n-- Kendaraan Darat --");
        Console.Write($"{mobil.nama} (Klakson): ");
        mobil.Klakson();

        Console.Write($"{motor.nama} (GasPol): ");
        motor.GasPol();

        Console.Write($"{mobil.nama} (Jumlah Roda): ");
        mobil.HitungRoda();

        Console.Write($"{motor.nama} (Jumlah Roda): ");
        motor.HitungRoda();

        Console.WriteLine("\n-- Kendaraan Air --");
        Console.Write($"{kapal.nama} (Berlayar): ");
        kapal.Berlayar();

        Console.Write($"{perahu.nama} (Dayung): ");
        perahu.Dayung();

        Console.Write($"{kapal.nama} (Kondisi Air): ");
        kapal.CekKondisiAir();

        Console.Write($"{perahu.nama} (Kondisi Air): ");
        perahu.CekKondisiAir();
    }
}