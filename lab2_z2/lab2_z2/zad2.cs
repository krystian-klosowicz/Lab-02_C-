using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_z2
{

     class Osoba
    {
        private string imie; // field
        private string nazwisko; // field
        private string pesel; // field
        private int wiek; // field
        public string Imie   // property
        {
            get { return imie; }
            set { imie = value; }
        }

        public string Nazwisko   // property
        {
            get { return nazwisko; }
            set { nazwisko = value; }
        }


        public string Pesel   // property
        {
            get { return pesel; }
            set { pesel = value; }
        }

        public int Wiek   // property
        {
            get { return wiek; }
            set { wiek = value; }
        }

        public int getAge()

        {
            DateTime now = DateTime.Now ; 
            string currentYear = now.Year.ToString();
            int current_year = Int32.Parse(currentYear);
            var year = (Int32.Parse(Pesel[0].ToString()) * 10) + Int32.Parse(Pesel[1].ToString()) + (Int32.Parse(Pesel[2].ToString()) / 2 + 1) % 5 * 100 + 1800;

            return current_year - year;

        }

        public String getGender()
        {
            //10 cyfra jesli parzysta to kobieta jesli nie to men
            if (Int32.Parse(Pesel.Substring(9, 1)) % 2 == 0)
            {
                return "women";
            }
            else
            {
                return "men";
            }
        }
        public void GetEducationInfo()
        {
            System.Console.WriteLine("Student");
        }

        public String GetFullName()
        {
            return imie + " " + nazwisko;
        }

        public Boolean CanGoHomeAlone()
        {
            if (getAge() >= 12) return true;
            return false;
        }
    }

    class Uczen : Osoba
    {
        String szkoła;
        public string Szkoła   // property
        {
            get { return szkoła; }
            set { szkoła = value; }
        }


        public void ChangeSchool(String name)
        {
            Szkoła = name;
        }

        public void Info()
        {
            Console.WriteLine("Nie moze sam wracac ponizej 12 lat chyba ze ma pozwolenie");
        }
    }

    class Nauczyciel : Uczen
    {
        private String tytulnaukowy;
        private List<Uczen> PodwladniUczniowe = new List<Uczen>();
        public string TytułNaukowy
        {
            get { return tytulnaukowy;}
            set { tytulnaukowy = value;}
        }

        public void dodaj(Uczen uczen)
        {
            PodwladniUczniowe.Add(uczen);
        }

        public void WhichStudentCanGoHomeAlone(DateTime dateToCheck)
        {
            foreach (Uczen uczen in PodwladniUczniowe)
            {
                if(uczen.CanGoHomeAlone())
                {
                    Console.WriteLine(uczen.GetFullName());
                }
            }
        }


    }



    public class zad2

    {
        static void Main(string[] args)
        {
            Osoba o = new Osoba();
            o.Imie = "ala";
            o.Nazwisko = "mak";
            o.Pesel = "9703150851";
            o.Wiek = 22;
            Console.WriteLine(o.Imie+" " +o.Nazwisko+" "+o.Pesel+" "+o.Wiek);
            Console.WriteLine(o.getAge());
            Console.WriteLine(o.getGender());
            o.GetEducationInfo();
            o.CanGoHomeAlone();
            Uczen u1 = new Uczen();
            u1.Imie = "Karol";
            u1.Nazwisko = "dads";
            u1.Pesel = "99051600000";
            u1.Wiek = 15;
            u1.Szkoła = "szkola";
            Nauczyciel n1 = new Nauczyciel();
            n1.dodaj(u1);
            //
            Console.WriteLine(u1.getAge());
            //ii tu wyrzuca jakis blad
            //n1.CanGoHomeAlone();
            
 
            
 

        }
    }




}
