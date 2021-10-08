using System;

namespace komisi_plus_gajipokok_pegawai_polymorphism
{
    public class KomisiPegawai : object
    {
        public string NamaDepan { get; }
        public string NamaBelakang { get; }
        public string NomerKTP { get; }
        private decimal pendapatanKotor;
        private decimal tarifKomisi;

        public KomisiPegawai(string namaDepan, string namaBelakang, string nomerKTP, decimal pendapatanKotor, decimal tarifKomisi)
        {
            NamaDepan = namaDepan;
            NamaBelakang = namaBelakang;
            NomerKTP = nomerKTP;
            PendapatanKotor = pendapatanKotor;
            TarifKomisi = tarifKomisi;
        }
        public decimal PendapatanKotor
        {
            get
            {
                return pendapatanKotor;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                        value, $"{nameof(PendapatanKotor)} must be >=0");
                }
                pendapatanKotor = value;
            }
        }
        public decimal TarifKomisi
        {
            get
            {
                return tarifKomisi;
            }
            set
            {
                if (value <= 0 || value >= 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                        value, $"{nameof(TarifKomisi)} must be >0 and <1");
                }
                tarifKomisi = value;
            }
        }
        public decimal Pendapatan() => tarifKomisi * pendapatanKotor;
        public override string ToString() =>
                $"Gaji Pegawai = {NamaDepan}{NamaBelakang}\n" +
                $"Nomer KTP = {NomerKTP}\n" +
                $"Pendapatan Kotor = {pendapatanKotor:C}\n" +
                $"Tingkat Gaji = {tarifKomisi:F2}";
    }
    public class KomisiPlusGajiPokokPegawai : object
    {
        public string NamaDepan { get; }
        public string NamaBelakang { get; }
        public string NomerKTP { get; }
        private decimal pendapatanKotor;
        private decimal tarifKomisi;
        private decimal gajiPokok;

        public KomisiPlusGajiPokokPegawai(string namaDepan, string namaBelakang, string nomerKTP, decimal pendapatanKotor, decimal tarifKomisi, decimal gajiPokok)
        {
            NamaDepan = namaDepan;
            NamaBelakang = namaBelakang;
            NomerKTP = nomerKTP;
            PendapatanKotor = pendapatanKotor;
            TarifKomisi = tarifKomisi;
            GajiPokok = gajiPokok;
        }
        public decimal PendapatanKotor
        {
            get
            {
                return pendapatanKotor;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(PendapatanKotor)} must be >=0");
                }
                pendapatanKotor = value;
            }
        }
        public decimal TarifKomisi
        {
            get
            {
                return tarifKomisi;
            }
            set
            {
                if (value <= 0 || value >= 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(TarifKomisi)} must be >0 and <1");
                }
                tarifKomisi = value;
            }
        }
        public decimal GajiPokok
        {
            get
            {
                return gajiPokok;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(GajiPokok)} must be >=0");
                }
                gajiPokok = value;
            }
        }

        public decimal Pendapatan() => gajiPokok + (tarifKomisi * pendapatanKotor);
        public override string ToString() =>
             $"Gaji Pegawai = {NamaDepan}{NamaBelakang}\n" +
             $"Nomer KTP = {NomerKTP}\n" +
             $"Pendapatan Kotor = {pendapatanKotor:C}\n" +
             $"Tarif Komisi = {tarifKomisi:F2}\n" +
             $"Gaji Pokok = {gajiPokok:C}\n";
    }
    class polymhorphismtest
    {
        static void Main()
        {
            var komisiPegawai = new KomisiPegawai("Sue", "Jones", "222-22-222", 10000.00M, .06M);
            var komisiPlusGajiPokokPegawai = new KomisiPlusGajiPokokPegawai("Bob", "Lewis", "333-33-333", 5000.00M, .04M, 300.00M);
            Console.WriteLine("Komisi Pegawai\n");
            Console.WriteLine(komisiPegawai.ToString());
            Console.WriteLine($"Pendapatan = {komisiPegawai.Pendapatan():C}");
            Console.WriteLine("Komisi Plus Gaji Pokok Pegawai dengan referensi kelas turunan ke objek kelas turunan\n");
            Console.WriteLine(komisiPlusGajiPokokPegawai.ToString());
            Console.WriteLine($"Pendapatan = {komisiPlusGajiPokokPegawai.Pendapatan():C}");

            KomisiPlusGajiPokokPegawai komisiPegawai2 = komisiPlusGajiPokokPegawai;
            Console.WriteLine("Komisi Plus Gaji Pokok Pegawai dengan referensi kelas dasar ke objek kelas turunan\n");
            Console.WriteLine(komisiPegawai2.ToString());
            Console.WriteLine($"Pendapatan = {komisiPlusGajiPokokPegawai.Pendapatan():C}");
            Console.ReadLine();
        }
    }
}
