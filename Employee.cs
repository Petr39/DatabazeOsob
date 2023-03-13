using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    internal class Employee : Human
    {
        /// <summary>
        /// Id je statické, aby bylo jedinečné, začíná se od 10000
        /// </summary>
        private static int Id=10000;
        private  int Credits=0;
        
        //Definice kreditů s daty
        public List<Tuple<int, DateTime>> credits = new List<Tuple<int, DateTime>>();
       

        
        /// <summary>
        /// Toto Id je určeno jen ke čtení
        /// </summary>
        readonly int _Id;
        /// <summary>
        /// Mzda v korunách za měsíc
        /// </summary>
        private int Salary { get;set; }

        private Training TrainingHuman { get; set; }

        /// <summary>
        /// Konstruktor zaměstnance
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="birthday"></param>
        /// <param name="salary"></param>
        public Employee(string firstName, string lastName, DateTime birthday, int salary, Training trainingHuman) : base(firstName, lastName, birthday)
        {
            Salary = salary;
            _Id = Id;
            TrainingHuman = trainingHuman;
            Id++;            
        }
        /// <summary>
        /// Zadání kreditů s datem do seznamu
        /// </summary>
        /// <param name="credit"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public void  GetCredits(int credit)
        {
             Credits += credit;
             DateTime date = DateOfAddCredit();
             credits.Add(new Tuple<int, DateTime>(credit,date));
           
        }
        //Přepsání dat do čitelné podoby v konzoli
        public override string ToString()
        {
            return string.Format("ID: " + _Id + "\nJméno a příjmení: " + FullName + " \nVěk: " + ShowAge() + " \nMzda: " + Salary+"\nŠkolení: "+TrainingHuman+"\nKredity: "+Credits);
        }
        /// <summary>
        /// Ukáže Id osoby
        /// </summary>
        /// <returns></returns>
       public int ShowId()
        {
            return _Id;
        }
        /// <summary>
        /// Vypočítá věk osoby
        /// </summary>
        /// <returns></returns>
        public double ShowAge()
        {
           TimeSpan year=DateTime.Today-Birthday;
           return Age = Math.Floor(year.Days/365.255);
        }
        /// <summary>
        /// Datum uložení nějakých dat, zatím slouží k vlastnosti Credits
        /// </summary>
        /// <returns></returns>
        public DateTime DateOfAddCredit()
        {
            DateTime date=DateTime.Today;
            return date;
        }
    }

    //Rozšiřující třída
    public static class ExtensionClass
    {
        /// <summary>
        /// Metoda pro výpis seznamů
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="text"></param>
        public static void ShowAllUniversal<T>(this IEnumerable<T> a, string text=" ")
        {
            //Nadpis výpisu, není povinný
            Console.WriteLine(text);
            foreach (T item in a)
            {
                Console.WriteLine(item);
            }
        }
    }
}
