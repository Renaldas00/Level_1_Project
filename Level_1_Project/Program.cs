//using System;
//using System.Collections.Generic;

//namespace Project
//{
//    class LogIn
//    {
//        static Dictionary<string, string> userDatabase = new Dictionary<string, string>();
//        static string currentUser = null;

//        static void Main()
//        {
//            while (true)
//            {
//                if (currentUser == null)
//                {
//                    Console.WriteLine("Sveiki! Siekiant prisijungti reikės įvesti vardą ir pavardę.");
//                    Console.Write("Įveskite pavardę: ");
//                    string firstName = Console.ReadLine();
//                    Console.Write("Įveskite vardą: ");
//                    string lastName = Console.ReadLine();

//                    string userKey = GetUserKey(firstName, lastName);

//                    if (userDatabase.ContainsKey(userKey))
//                    {
//                        currentUser = userDatabase[userKey];
//                        Console.WriteLine($"Jūs esate prisijungęs, {currentUser}.");
//                    }
//                    else
//                    {
//                        RegisterUser(firstName, lastName);
//                        currentUser = userDatabase[userKey];
//                        Console.WriteLine($"Sveikiname prisijungus ir susikūrus naują paskyrą, {currentUser}!");
//                    }
//                }

//                ShowMenu();

//                // Po meniu atvaizdavimo leidžiame vartotojui atsijungti ir paprašome prisijungti iš naujo.
//                currentUser = null;
//                Console.WriteLine("Atsijungėte. Prašome prisijungti iš naujo.");
//            }
//        }

//        static void ShowMenu()
//        {
//            while (true)
//            {
//                Console.Clear();
//                if (currentUser != null)
//                {
//                    Console.WriteLine($"Sveiki, {currentUser}!");
//                }
//                Console.WriteLine("Pasirinkite meniu punktą:");
//                Console.WriteLine("1. Profilis");
//                Console.WriteLine("2. Nustatymai");
//                Console.WriteLine("3. Atsijungti");
//                Console.Write("Įveskite pasirinkimą: ");
//                string choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case "1":
//                        Console.WriteLine("Profilio rodymas");
//                        Console.ReadLine();
//                        break;
//                    case "2":
//                        Console.WriteLine("Nustatymų langas");
//                        Console.ReadLine();
//                        break;
//                    case "3":
//                        // Atsijungti ir išeiti iš meniu.
//                        return;
//                    default:
//                        Console.WriteLine("Neteisingas pasirinkimas.");
//                        break;
//                }
//            }
//        }

//        static string GetUserKey(string firstName, string lastName)
//        {
//            return $"{firstName.ToLower()}_{lastName.ToLower()}";
//        }

//        static void RegisterUser(string firstName, string lastName)
//        {
//            string userKey = GetUserKey(firstName, lastName);
//            userDatabase[userKey] = $"{firstName} {lastName}";
//        }
//    }
//}

//using System;
//using System.Collections.Generic;

//class Program
//{
//    static void Main(string[] args)
//    {
//        Dictionary<string, string> vartotojai = new Dictionary<string, string>();
//        string CurrentUser = null;

//        while (true)
//        {
//            Console.Clear();
//            Console.WriteLine("Sveiki atvykę!");

//            if (!string.IsNullOrEmpty(CurrentUser))
//            {
//                Console.WriteLine($"Prisijungęs vartotojas: {CurrentUser}");
//                Console.WriteLine("Pasirinkite veiksmą:");
//                Console.WriteLine("1. Atsijungti");
//                Console.WriteLine("2. Kažkokia kita veiksmo opcija"); // Čia galite pridėti kitas veiksmo opcijas
//            }
//            else
//            {
//                Console.WriteLine("Įveskite savo vardą ir pavardę:");

//                Console.Write("Vardas: ");
//                string vardas = Console.ReadLine();
//                Console.Write("Pavardė: ");
//                string pavardė = Console.ReadLine();

//                string pilnasVardas = $"{vardas} {pavardė}";

//                if (vartotojai.ContainsKey(pilnasVardas))
//                {
//                    CurrentUser = pilnasVardas;
//                    Console.WriteLine($"Sveikiname, {pilnasVardas}, jūs sėkmingai prisijungėte!");
//                }
//                else
//                {
//                    vartotojai[pilnasVardas] = pilnasVardas;
//                    CurrentUser = pilnasVardas;
//                    Console.WriteLine($"Sveikiname, {pilnasVardas}, jūs sėkmingai sukūrėte naują paskyrą!");
//                }
//            }

//            string pasirinkimas = Console.ReadLine();

//            if (!string.IsNullOrEmpty(CurrentUser))
//            {
//                switch (pasirinkimas)
//                {
//                    case "1":
//                        CurrentUser = null;
//                        Console.WriteLine("Jūs atsijungėte. Norėdami prisijungti iš naujo, įveskite vardą ir pavardę.");
//                        break;
//                    case "2":
//                        // Čia galite pridėti kitą veiksmo logiką
//                        Console.WriteLine("Pasirinkote kažkokią kita veiksmo opciją.");
//                        break;
//                    default:
//                        Console.WriteLine("Netinkamas pasirinkimas. Pasirinkite iš pateiktų opcijų.");
//                        break;
//                }
//            }

//            Console.WriteLine("Spauskite Enter tęsti...");
//            Console.ReadLine();
//        }
//    }
//}


using System;
using System.Collections.Generic;

namespace Project
{
    class Program
    {
        static Dictionary<string, string> userDatabase = new Dictionary<string, string>();
        static string currentUser = null;

        static void Main(string[] args)
        {
            while (true)
            {
                if (currentUser == null)
                {
                    Console.WriteLine("Sveiki! Siekiant prisijungti reikės įvesti vardą ir pavardę.");
                    Console.Write("Įveskite pavardę: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Įveskite vardą: ");
                    string lastName = Console.ReadLine();

                    string userKey = GetUserKey(firstName, lastName);

                    if (userDatabase.ContainsKey(userKey))
                    {
                        currentUser = userDatabase[userKey];
                        Console.WriteLine($"Jūs esate prisijungęs, {currentUser}.");
                    }
                    else
                    {
                        RegisterUser(firstName, lastName);
                        currentUser = userDatabase[userKey];
                        Console.WriteLine($"Sveikiname prisijungus ir susikūrus naują paskyrą, {currentUser}!");
                    }
                }
                else
                {
                    ShowMenu();
                }

                Console.WriteLine("Spauskite Enter tęsti...");
                Console.ReadLine();
            }
        }

        static void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                if (currentUser != null)
                {
                    Console.WriteLine($"Sveiki, {currentUser}!");
                    Console.WriteLine("Pasirinkite veiksmą:");
                    Console.WriteLine("1. Profilis");
                    Console.WriteLine("2. Nustatymai");
                    Console.WriteLine("3. Atsijungti");
                    Console.Write("Įveskite pasirinkimą: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("Profilio rodymas");
                            Console.ReadLine();
                            break;
                        case "2":
                            Console.WriteLine("Nustatymų langas");
                            Console.ReadLine();
                            break;
                        case "3":
                            // Atsijungti ir išeiti iš meniu.
                            currentUser = null;
                            Console.WriteLine("Atsijungėte. Prašome prisijungti iš naujo.");
                            return;
                        default:
                            Console.WriteLine("Neteisingas pasirinkimas.");
                            break;
                    }
                }
            }
        }

        static string GetUserKey(string firstName, string lastName)
        {
            return $"{firstName.ToLower()}_{lastName.ToLower()}";
        }

        static void RegisterUser(string firstName, string lastName)
        {
            string userKey = GetUserKey(firstName, lastName);
            userDatabase[userKey] = $"{firstName} {lastName}";
        }
    }
}
