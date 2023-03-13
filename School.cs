namespace Database
{
    internal class School : OperationClass, ISchool
    {
        /// <summary>
        /// Inicializace zaměstnanců do seznamu
        /// </summary>
        protected List<Employee> employees;



        /// <summary>
        /// Konstruktor školy, kde je definován seznam zaměstnanců 
        /// </summary>
        public School()
        {
            employees = new List<Employee>();
        }

        /// <summary>
        /// Vytvoří zamšstnance a přiřadí mu ID
        /// </summary>
        public void CreateHuman()
        {

            //Zadání jména a příjmení do pole
            var name = InsertFirstAndLastName();

            //Console.Write("Zadejte datum narození ve tvaru   =>  14.10.1982  : ");
            //DateTime birthday = DateBirth();            
            //Console.Write("Zadejte mzdu: ");
            //int salary = Number();
            Training training = new Training();
            training.NewTrainig();


            Employee e = new Employee(firstName: name[0], lastName: name[1], birthday: DateTime.Today, salary: 10000, trainingHuman: training);
            AddHuman(e);
            Console.WriteLine("Zaměstnance {0} přidán pod ID: {1}", name[0] + " " + name[1], e.ShowId());
        }

        /// <summary>
        /// Pomocná metoda k přidání zaměstnanace
        /// </summary>
        /// <param name="employee"></param>
        private void AddHuman(Employee employee)
        {
            employees.Add(employee);
        }
        /// <summary>
        /// Přidání kreditů dané osobě
        /// </summary>
        /// <param name="id"></param>
        protected void AddCreditsToEmploee(int id)
        {




            Console.WriteLine("Zadej počet kreditů: ");
            int count = int.Parse(Console.ReadLine());

            //Nalezení osoby podle Id přes LINQ dotaz
            var a = employees.FirstOrDefault(x => x.ShowId() == id);



            if (a != null)
            {
                List<Employee> employee = new List<Employee> { a };
                Employee e = employee[0];
                e.GetCredits(count);
                Console.WriteLine("{0} kreditů připsáno na účet", count);
            }
            else
            {
                Console.WriteLine("Nikdo s tímto id nenalezen...");
            }




        }

        /// <summary>
        /// Smaže zaměstnance dle ID
        /// </summary>
        /// <param name="id"></param>
        public void DeleteHuman(int id)
        {
            var a = employees.Where(x => x.ShowId() == id).ToList();
            if (a != null)
            {
                for (int i = 0; i < a.Count; i++)
                {
                    employees.RemoveAt(i);
                    Console.WriteLine("Osoba s ID: {0} smazána", id);

                }
            }
        }
        /// <summary>
        /// Vypíše zaměstnance podle jeho ID
        /// </summary>
        /// <param name="id"></param>
        public void ShowHuman(int id)
        {
            var a = employees.Where(x => x.ShowId() == id).ToList();
            if (a != null) foreach (var item in a) Console.WriteLine(item);
            else Console.WriteLine("Nikdo s Id:  {0} nenalezen", id);
            Console.WriteLine();

        }
        /// <summary>
        /// Upraví zaměstnance dle zadaného ID
        /// </summary>
        /// <param name="id"></param>
        public void UpdateHuman(int id)
        {





            Console.WriteLine("Upravuji...");
        }
        /// <summary>
        /// Vložení jména a příjmení do pole
        /// </summary>
        /// <returns>vrátí pole se jménem a příjmením</returns>
        public string[] InsertFirstAndLastName()
        {
            //Pole zadaných parametrů
            string[] fullName = new string[] { AddFirstName(), AddLastNAme() };
            return fullName;
        }
        /// <summary>
        /// Zadání data narození
        /// </summary>
        /// <returns></returns>
        public DateTime DateBirth()
        {
            DateTime birthday;
            while (!DateTime.TryParse(Console.ReadLine(), out birthday))
                Console.WriteLine("Zadejte prosím datum narození ve správném formátu => 14.10.1982");
            return birthday;
        }

        ///// <summary>
        ///// Vrátí číslo, když ho správně zadám
        ///// </summary>
        ///// <returns></returns>
        public override int Number()
        {
            int num;
            while (!int.TryParse(Console.ReadLine(), out num)) Console.WriteLine("Zadejte numerickou hodnotu prosím");
            return num;
        }

        /// <summary>
        ///Zvětší první písmeno ve jméně a ověření zadání
        /// </summary>
        /// <returns></returns>
        private string AddFirstName()
        {
            Console.Write("Zadejte jméno: ");
            string firstName = Console.ReadLine();
            while (string.IsNullOrEmpty(firstName))
            {
                Console.WriteLine("Zadej prosím jméno");
                firstName = Console.ReadLine();
            }
            firstName = firstName.Substring(0, 1).ToUpper() + firstName.Substring(1).Trim();
            return firstName;
        }
        /// <summary>
        ///Zvětší první písmeno v příjmení a ověření zadání
        /// </summary>
        /// <returns></returns>
        private string AddLastNAme()
        {
            Console.Write("Zadejte příjmení: ");
            string lastName = Console.ReadLine();
            while (string.IsNullOrEmpty(lastName))
            {
                Console.WriteLine("Zadej prosím příjmení");
                lastName = Console.ReadLine();
            }
            lastName = lastName.Substring(0, 1).ToUpper() + lastName.Substring(1).Trim();
            return lastName;
        }

        public void ShowCredits(int id)
        {
            List<Employee> emp = new List<Employee>();
            var findEmployee = FindPerson(id);


            //Vybere zaměstnance podle zadaného id
            // var idEmployee = employees.FirstOrDefault(x => x.ShowId() == id);
            if (findEmployee == null) Console.WriteLine("Žádný zaměstnanec s id {0} neexistuje", id);


            if (findEmployee != null)
            {
                emp.Add(findEmployee);
                var a = emp.Select(x => x.credits).ToArray();
                //Daný zaměstnanec s id
                Employee employee = emp[0];
                //Vybere kredity a datum
                var all = a[0].Select(x => x.ToValueTuple());
                //Vypíše seznam, kdy byly přidány kredity
                foreach (var item in all)
                {
                    Console.WriteLine(item.Item1 + " ------ " +
                                      item.Item2.ToString("{0}:dd.MM.yyyy     {1}: HH:mm"), "Datum", "čas");
                }
            }
        }


        //Nelezne osobu podle id, může být i null
        private Employee FindPerson(int id)
        {
            var idEmployee = employees.FirstOrDefault(x => x.ShowId() == id);
            return idEmployee;
        }

    }
}
