using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    internal class Training
    {
        private string _nameTraining;


        public Training() { }

        public string NewTrainig()
        {
            Console.WriteLine("Zadejte školení");
            _nameTraining = Console.ReadLine();
            return _nameTraining;
        }


        /// <summary>
        /// Přepsání metody do stringu
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _nameTraining;
        }
    }
}
