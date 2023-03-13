using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{

    /// <summary>
    /// Rozhranní předepisuje metody pro manipulaci s daty
    /// </summary>
    internal interface ISchool
    {
        void CreateHuman();
        void ShowHuman(int id);
        void UpdateHuman(int id);
        void DeleteHuman(int id);      
        string[] InsertFirstAndLastName();

    }
}
