namespace Database
{
    internal class Application  : School
    {
     
        /// <summary>
        /// Delegát pro metodu čísla
        /// </summary>
        /// <returns></returns>
        delegate int DelegateHandle();    
        /// <summary>
        /// Nastavení pro Menu funkci, jestli má pokračovat
        /// </summary>
        bool theEnd = false; 
        /// <summary>
        /// Uživatelský vstup
        /// </summary>
        public void Run()
        {
            //Cyklus, dokud není zmáčknuté číslo 5
            while (!theEnd)
            {
                Choice();
            }
        }
        /// <summary>
        /// Volby z menu, kde si uživatel vybere
        /// </summary>
        void Choice()
        {
            DelegateHandle del = new DelegateHandle(Number);
            Menu();
            Console.ForegroundColor = ConsoleColor.Green;      
            switch (del())
            {
                case 1:
                    Console.WriteLine("Vytvořením se vygeneruje jedinečné ID ");
                    CreateHuman();
                    break;
                case 2:
                    Console.Write("Zadej id k vypsání osoby: ");                  
                    ShowHuman(del());
                    break;
                case 3:
                    Console.Write("Zadej id k úpravě osoby: ");
                    UpdateHuman(del());
                    break;
                case 4:
                    Console.Write("Zadej id ke smazání osoby: ");
                    DeleteHuman(del());
                    break; 
                case 5:
                    Console.Write("Zadej id osoby pro přidání kredit: ");
                    AddCreditsToEmploee(del());
                    break;
                    case 6:
                    Console.Write("Zadej id osoby pro výpis kreditů: ");
                    ShowCredits(del());
                    break;
                    case 7:
                 
                    break;
                    case 8:
                    Console.WriteLine("Děkujeme za použití aplikace, stiskněte Enter");
                    theEnd = true;
                    break;
                default:
                    Console.WriteLine("Pod tímto číslem neexistuje volba");
                    break;
            }
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
        }
        /// <summary>
        /// Menu volby
        /// </summary>
        void Menu()
        {            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t-------Menu------");
            Console.WriteLine("\t1 - Přidat osobu");
            Console.WriteLine("\t2 - Vypsat osobu");
            Console.WriteLine("\t3 - Upravit osobu");
            Console.WriteLine("\t4 - Smazat osobu");
            Console.WriteLine("\t5 - Přidat kredity");
            Console.WriteLine("\t6 - Ukáže kredity");
            Console.WriteLine("\t7 - ");
            Console.WriteLine("\t8 - Konec ");
            Console.ResetColor();
        }
       ///<summary>
       ///Zadání čísla
       ///</summary>
       ///<returns>Celé číslo</returns>
        public override int Number()
        {
            int num;
            while (!int.TryParse(Console.ReadLine(), out num)) Console.WriteLine("Zadej prosím číslo");
            return num;
        }   
    }
}
