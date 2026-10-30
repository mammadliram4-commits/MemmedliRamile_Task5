
using System;
using System.IO;
/*
class Program
{
    static void Main()
    {
        string fayl = "qeydler.txt";

        while (true)
        {
            Console.WriteLine("\n1. Yeni qeyd");
            Console.WriteLine("2. Butun qeydler");
            Console.WriteLine("3. Qeyd axtar");
            Console.WriteLine("4. Butun qeydleri sil");
            Console.WriteLine("5. Cixis");

            Console.Write("Seciminizi daxil edin: ");
            string secim = Console.ReadLine();

            try
            {
                if (secim == "1")
                {
                    Console.Write("Qeydi yazin: ");
                    string qeyd = Console.ReadLine();

                    using (StreamWriter sw = new StreamWriter(fayl, true))
                    {
                        sw.WriteLine(DateTime.Now + " - " + qeyd);
                    }

                    Console.WriteLine("Qeyd elave edildi.");
                }
                else if (secim == "2")
                {
                    if (File.Exists(fayl))
                    {
                        string[] qeydlər = File.ReadAllLines(fayl);

                        foreach (string q in qeydlər)
                        {
                            Console.WriteLine(q);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hele qeyd yoxdur.");
                    }
                }
                else if (secim == "3")
                {
                    Console.Write("Axtarilan sozu daxil edin: ");
                    string soz = Console.ReadLine();

                    if (File.Exists(fayl))
                    {
                        string[] qeydlər = File.ReadAllLines(fayl);
                        bool tapildi = false;

                        foreach (string q in qeydlər)
                        {
                            if (q.IndexOf(soz, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                Console.WriteLine(q);
                                tapildi = true;
                            }
                        }

                        if (!tapildi)
                            Console.WriteLine("Qeyd tapilmadi.");
                    }
                    else
                    {
                        Console.WriteLine("Fayl movcud deyil.");
                    }
                }
                else if (secim == "4")
                {
                    Console.Write("Butun qeydləri silmek isteyirsiniz? (y/n): ");
                    string cavab = Console.ReadLine();

                    if (cavab == "y" || cavab == "Y")
                    {
                        File.WriteAllText(fayl, "");
                        Console.WriteLine("Butun qeydlər silindi.");
                    }
                }
                else if (secim == "5")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Yanlis secim!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Xeta: " + ex.Message);
            }
        }
    }
}
*/









/*
  
using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Mənbə qovluğunun yolunu daxil edin: ");
            string menbe = Console.ReadLine();

            Console.Write("Təyinat qovluğunun yolunu daxil edin: ");
            string teyinat = Console.ReadLine();

            if (!Directory.Exists(menbe))
            {
                Console.WriteLine("Mənbə qovluğu movcud deyil!");
                return;
            }

            if (!Directory.Exists(teyinat))
            {
                Directory.CreateDirectory(teyinat);
            }

            string[] fayllar = Directory.GetFiles(menbe, "*.txt");

            int say = 0;
            long umumiOlcu = 0;

            foreach (string fayl in fayllar)
            {
                FileInfo melumat = new FileInfo(fayl);

                string tarix = DateTime.Now.ToString("yyyy-MM-dd");
                string yeniAd = tarix + "_" + melumat.Name;

                string yeniYol = Path.Combine(teyinat, yeniAd);

                File.Copy(fayl, yeniYol, true);

                FileInfo yeniMelumat = new FileInfo(yeniYol);

                umumiOlcu += yeniMelumat.Length;
                say++;
            }

            Console.WriteLine("Kopyalanan fayllarin sayi: " + say);
            Console.WriteLine("Umumi olcu: " + umumiOlcu + " bayt");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Xeta: " + ex.Message);
        }
    }
}
*/





/*
 
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Mətn faylinin yolunu daxil edin: ");
            string fayl = Console.ReadLine();

            if (!File.Exists(fayl))
            {
                Console.WriteLine("Fayl movcud deyil!");
                return;
            }

            string metn = File.ReadAllText(fayl);

            string[] setirler = File.ReadAllLines(fayl);

            string[] sozler = Regex.Split(metn, @"[^\p{L}\p{N}]+")
                .Where(s => s != "")
                .ToArray();

            int setirSayi = setirler.Length;
            int sozSayi = sozler.Length;
            int simvolSayi = metn.Length;

            string enUzunSoz = "";

            foreach (string soz in sozler)
            {
                if (soz.Length > enUzunSoz.Length)
                {
                    enUzunSoz = soz;
                }
            }

            Dictionary<string, int> tekrarlanan =
                new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (string soz in sozler)
            {
                if (tekrarlanan.ContainsKey(soz))
                {
                    tekrarlanan[soz]++;
                }
                else
                {
                    tekrarlanan.Add(soz, 1);
                }
            }

            var ilkUc = tekrarlanan
                .OrderByDescending(x => x.Value)
                .Take(3);

            using (StreamWriter sw = new StreamWriter("hesabat.txt"))
            {
                sw.WriteLine("METN ANALIZI");
                sw.WriteLine("-------------------");
                sw.WriteLine("Setir sayi: " + setirSayi);
                sw.WriteLine("Soz sayi: " + sozSayi);
                sw.WriteLine("Simvol sayi: " + simvolSayi);
                sw.WriteLine("En uzun soz: " + enUzunSoz);

                sw.WriteLine("\nEn cox tekrarlanan 3 soz:");

                foreach (var soz in ilkUc)
                {
                    sw.WriteLine(soz.Key + " - " + soz.Value + " defe");
                }
            }

            Console.WriteLine("Analiz tamamlandi!");
            Console.WriteLine("Neticeler hesabat.txt faylina yazildi.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Xeta: " + ex.Message);
        }
    }
}
*/




/*
 *
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string fayl = "telebeler.txt";

        while (true)
        {
            Console.WriteLine("\n1. Telebe elave et");
            Console.WriteLine("2. Hamisini goster");
            Console.WriteLine("3. Ada gore axtar");
            Console.WriteLine("4. Cixis");

            Console.Write("Seciminizi daxil edin: ");
            string secim = Console.ReadLine();

            try
            {
                if (secim == "1")
                {
                    Console.Write("Telebenin ID-si: ");
                    string id = Console.ReadLine();

                    Console.Write("Telebenin adi: ");
                    string ad = Console.ReadLine();

                    Console.Write("Telebenin yasi: ");
                    int yas = int.Parse(Console.ReadLine());

                    using (StreamWriter sw = new StreamWriter(fayl, true))
                    {
                        sw.WriteLine(id + ";" + ad + ";" + yas);
                    }

                    Console.WriteLine("Telebe elave edildi.");
                }
                else if (secim == "2")
                {
                    if (File.Exists(fayl))
                    {
                        string[] telebeler = File.ReadAllLines(fayl);

                        foreach (string telebe in telebeler)
                        {
                            string[] melumat = telebe.Split(';');

                            Console.WriteLine("ID: " + melumat[0]);
                            Console.WriteLine("Ad: " + melumat[1]);
                            Console.WriteLine("Yas: " + melumat[2]);
                            Console.WriteLine("----------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Telebe siyahisi bosdur.");
                    }
                }
                else if (secim == "3")
                {
                    Console.Write("Axtarilan adi daxil edin: ");
                    string axtarilanAd = Console.ReadLine();

                    bool tapildi = false;

                    if (File.Exists(fayl))
                    {
                        string[] telebeler = File.ReadAllLines(fayl);

                        foreach (string telebe in telebeler)
                        {
                            string[] melumat = telebe.Split(';');

                            if (melumat.Length >= 3 &&
                                melumat[1].Equals(axtarilanAd,
                                StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine("ID: " + melumat[0]);
                                Console.WriteLine("Ad: " + melumat[1]);
                                Console.WriteLine("Yas: " + melumat[2]);

                                tapildi = true;
                            }
                        }
                    }

                    if (!tapildi)
                    {
                        Console.WriteLine("Telebe tapilmadi.");
                    }
                }
                else if (secim == "4")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Yanlis secim!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Xeta: " + ex.Message);
            }
        }
    }
}
*/




 
