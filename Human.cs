using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    abstract class Human 
    {
        /// <summary>
        /// Jméno osoby
        /// </summary>
        protected string FirstName { get; set; }
        /// <summary>
        /// Příjmení osoby
        /// </summary>
        protected string LastName { get; set; }
        /// <summary>
        /// Narození dle vzoru 16.11.1988
        /// </summary>
        protected DateTime Birthday { get; set; }
        /// <summary>
        /// Věk osoby
        /// </summary>
        protected double Age;


        /// <summary>
        /// Celé jméno a příjmení osoby
        /// </summary>
        public string FullName => FirstName + " " + LastName;

        /// <summary>
        /// Základní konstruktor člověka
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="birthday"></param>
        public Human(string firstName, string lastName, DateTime birthday)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;          
        }
    }
}
