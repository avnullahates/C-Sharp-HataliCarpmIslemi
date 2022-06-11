using System;

namespace OdevHataliCarpmaIslemi
{
    class Program
    {
        static void Main(string[] args)
        {
            GirisMesaj();

            int sayi1 = Sayi1Al();

            int sayi2 = Sayi2Al();

            HataliIslemiYapVeYazdir(sayi1, sayi2);

            CikisMesaji();

            TestVerileri();

        }


        private static void GirisMesaj()
        {
            Console.WriteLine("Hosgeldiniz. Bu uygulamada hatali carpim islemi nasil yapilir onu ogrencez. Sadece yondendirmelere gore sayilari giriniz. Biz sonuclari size yondendirecegiz.");
        }

        private static int Sayi1Al()
        {
            Console.Write("Lutfen 1. Sayiyi giriniz: ");
            int birinciSayi = int.Parse(Console.ReadLine());
            return birinciSayi;
        }

        private static int Sayi2Al()
        {
            Console.Write("Lutfen 2. Sayiyi giriniz(1-99): ");
            int ikiciSayi = int.Parse(Console.ReadLine());

            while (ikiciSayi > 99 && ikiciSayi > -99)
            {
                Console.WriteLine("Ikinci sayi 2 basamakli olmalidir");
                ikiciSayi = Convert.ToInt32(Console.ReadLine());
            }
            return ikiciSayi;

        }

        public static void HataliIslemiYapVeYazdir(int birinciSayi, int ikinciSayi)
        {

            string sayi1 = birinciSayi.ToString();
            string toplamBasamak = (birinciSayi * ikinciSayi).ToString();  //Dizinin boyutunu ogrenmek icin basamak degerini ogrenizyoruz.

            string sayi2 = ikinciSayi.ToString();     //Buralarda yapilan kod satirlarinda ikinci sayini basamak degerlerine ayirmak icin char degerlerine dondurdum
            int basamak = sayi2.Length;               //
            char birlerBasamak = sayi2[basamak - 1];  //
            char onlarBasamak = sayi2[basamak - 2];   //


            int birlerSayi = birlerBasamak - '0';    //char  degerini tekrar int degere cevirdim
            int onlarSayi = onlarBasamak - '0';      //


            int carpim1 = birinciSayi * Convert.ToInt32(birlerSayi);  //2. sayiyinin birler basamagini 1. sayi ile carpip bir degere atadim
            int carpim2 = birinciSayi * Convert.ToInt32(onlarSayi); //2. sayiyinin onlar basamagini 1. sayi ile carpip bir degere atadim


            int[] dizi = new int[toplamBasamak.Length - 1]; //Hatali toplam icin diziye tanimalanacak olan sayiyin boyotunu ogrenmek icin toplam basamak degerinden 1 dusuyoruz

            for (int i = 0; i < toplamBasamak.Length - 1; i++)
            {
                int sonuc = 0;
                int toplam1, toplam2 = 1;

                toplam1 = carpim1 % 10;  // Hatali toplam icin her bir  basamagi toplamak icin mod degerlerini aliyoruz  
                carpim1 = carpim1 / 10;   //
                                          //
                toplam2 = carpim2 % 10;  //
                carpim2 = carpim2 / 10;   //

                sonuc = toplam1 + toplam2;  // her basamagin toplamini burada kontrol etemek icin sonuc degerine atiyoruz

                if (sonuc > 9)  //Hatali toplama icin sayi 9 dan buyuk ise sadece sadece birler basamagini aliyoruz.
                    sonuc = sonuc % 10;

                dizi[i] = sonuc; //Cikan her sonucu bir dizi icerisine aktariyoruz
            }

            Array.Reverse(dizi);

            Console.Write("SONUC: ");

            foreach (int sayi in dizi)
            {
                Console.Write(sayi);
            }
            Console.WriteLine();
        }

        private static void CikisMesaji()
        {
            Console.WriteLine("Sonucunuz ekrana yazilmistir umarim uygulamamizdan memnun kalmissinizdir. Iyi gunler dileriz.");
            Console.WriteLine("Cikmak icin herhangi bir tusa basiniz.");
            Console.ReadLine();
        }


        private static void TestVerileri()
        {
            Console.WriteLine("1. Test Sonuclari: ");
            Console.WriteLine("Lutfen 1. Sayiyi giriniz: 211\nLutfen 2. Sayiyi giriniz(1-99): 33\nSONUC: 266");

            Console.WriteLine("2. Test Sonuclari: ");
            Console.WriteLine("Lutfen 1. Sayiyi giriniz: 947\nLutfen 2.Sayiyi giriniz(1 - 99): 23\nSONUC: 3635");

            Console.WriteLine("3. Test Sonuclari: ");
            Console.WriteLine("Lutfen 1. Sayiyi giriniz: 1056\nLutfen 2. Sayiyi giriniz(1-99): 45\nSONUC: 9404");

        }



    }
}
