using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection8523
{
    class Program
    {
        static void Main(string[] args)
        {
            SurucuBase surucu1 = new Surucu()
            {
                Isim="Çağıl"
            };
            Araba araba = new Araba(surucu1);
            araba.Sur();

            SurucuBase surucu2 = new Surucu() 
            { 
                Isim="Simge"
            };
            Araba simgeninArabası = new Araba(surucu2);
            simgeninArabası.Sur();

            SurucuBase surucu3 = new Surucu { Isim = "Muhittin" };
            Araba araba1  = new Araba(surucu3);
            araba1.Sur(surucu3.Isim);
            
            Console.ReadLine();
        }
    }
    class Araba
    {
        private readonly SurucuBase _surucu;
        
        public Araba(SurucuBase surucu)
        {
            _surucu = surucu;
        }
        public void Sur()
        {
            Console.WriteLine("Araba: " + _surucu.Isim + " tarafından sürülüyor...");
        }
        public void Sur(string surucu)
        {
            Console.WriteLine("Araba: " + surucu + " tarafından 30 Nisan'da sürülüyor...");
        }
    }
    abstract class SurucuBase // ISurucuBase
    {
        public string Isim { get; set; }
    }
    class Surucu : SurucuBase
    {
        
    }
}
