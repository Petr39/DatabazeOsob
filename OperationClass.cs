using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    abstract class OperationClass
    {


       //Třída určena pro různé operace

        /// <summary>
        /// Zadání čísla s ověřením, že je to číslo
        /// </summary>
        /// <returns></returns>
        public virtual int Number()
        {
            int num;
            while (!int.TryParse(Console.ReadLine(), out num)) Console.WriteLine("Zadej prosím číslo"); 
            return num;
        }
    }
}
