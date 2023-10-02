using System;
using System.Collections.Generic;

namespace Project
{
    class Program
    {
        static Dictionary<string, string> userDatabase = new Dictionary<string, string>();
        static string currentUser = null;
        public static List<Klausimas> questions = new List<Klausimas>();
        static int sessionQuestionCount = 5;
        public static List<Kategorija> categories = new List<Kategorija>
{
    new Kategorija("Matematika", new List<Klausimas>
    {
        new Klausimas("2 + 2?", new List<string> { "4", "5", "6" }, 0),
        new Klausimas("10 * 5?", new List<string> { "50", "25", "15" }, 0),
        new Klausimas("Kas yra 5 kart 7?", new List<string> { "35", "42", "12" }, 1),
        new Klausimas("Kiek yra 8 dalyba iš 2?", new List<string> { "4", "6", "10" }, 0),
        new Klausimas("Koks yra kvadratinės šaknies iš 144 rezultatas?", new List<string> { "12", "10", "14" }, 0)
    }),
    new Kategorija("Istorija", new List<Klausimas>
    {
        new Klausimas("Kas buvo pirmasis prezidentas JAV?", new List<string> { "George Washington", "Thomas Jefferson", "John Adams" }, 0),
        new Klausimas("Kur vyko Pirmasis pasaulinis karas?", new List<string> { "Europa", "Azija", "Afrika" }, 0),
    }),
    new Kategorija("C# Programavimas", new List<Klausimas>
    {
        new Klausimas("Kas yra C# programavimo kalbos pagrindinė savybė?", new List<string> { "Objektinė programavimo kalba", "Funkcinė programavimo kalba", "Procedūrinė programavimo kalba" }, 0),
        new Klausimas("Kas yra C# klasės ir objektai?", new List<string> { "Klasės yra šablonai, o objektai yra jų egzemplioriai", "Tai yra kintamieji", "Tai yra funkcijos" }, 0),
        new Klausimas("Kas yra .NET framework?", new List<string> { ".NET framework yra programinė platforma, skirta kurti Windows aplikacijas", ".NET framework yra operacinė sistema", ".NET framework yra C# programavimo kalba" }, 0),
        new Klausimas("Kas yra C# sintaksės pagrindas?", new List<string> { "Raktažodžiai, operatoriai ir kintamieji", "Kintamieji ir funkcijos", "Klasės ir objektai" }, 0),
        new Klausimas("Ką reiškia C# programos kompiliavimas?", new List<string> { "Tai procesas, kuriuo C# programa verčiama į mašinos kodą", "Tai procesas, kuriuo programa testuojama", "Tai procesas, kuriuo programa vykdoma" }, 0),
    }),
};
        static void Main()
        {
            while (true)
            {
                if (currentUser == null)
                {
                    Console.WriteLine("Sveiki! Siekiant prisijungti reikės įvesti vardą ir pavardę.");
                    Console.Write("Įveskite vardą: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Įveskite pavardę: ");
                    string lastName = Console.ReadLine();

                    string userKey = GetUserKey(firstName, lastName);
                    static string GetUserKey(string firstName, string lastName)
                    {
                        return $"{firstName.ToLower()}_{lastName.ToLower()}";
                    }

                    static void RegisterUser(string firstName, string lastName)
                    {
                        string userKey = GetUserKey(firstName, lastName);
                        userDatabase[userKey] = $"{firstName} {lastName}";
                    }

                    if (userDatabase.ContainsKey(userKey))
                    {
                        currentUser = userDatabase[userKey];
                        Console.WriteLine($"Vartotojas: {currentUser}.");
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
                    Console.WriteLine("3. Žaidimo taisyklės");
                    Console.WriteLine("4. Pradėti žaidimą");
                    Console.WriteLine("5. Rezultatai");
                    Console.WriteLine("6. Atsijungti");
                    Console.WriteLine("7. Uždaryti programą");
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
                            ShowGameRules();
                            break;
                        case "4":
                            StartGame();
                            break;
                        case "5":
                            ShowResultsOrParticipants();
                            break;
                        case "6":
                            currentUser = null;
                            Console.WriteLine("Atsijungėte. Prašome prisijungti iš naujo.");
                            return;
                        case "7":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Neteisingas pasirinkimas.");
                            break;
                    }
                }
            }
        }

        static void ShowGameRules()
        {
            Console.Clear();
            Console.WriteLine("Žaidimo taisyklės:");
            Console.WriteLine("Sveikiname prisijungus prie proto mūšio programos.");
            Console.WriteLine("Pasirinkite kategoriją ir atsakykite į klausimus.");
            Console.WriteLine("Atsakymą į klausimą parašykite naudodami varianto numerį.");
            Console.WriteLine("Norėdami grįžti atgal, įveskite 'q'.");
            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "q")
                {
                    return;
                }
            }
        }

        static void StartGame()
        {
            Console.Clear();
            Console.WriteLine("Pasirinkite kategoriją:");
            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {categories[i].Pavadinimas}");
            }

            Console.Write("Įveskite kategorijos numerį: ");
            if (int.TryParse(Console.ReadLine(), out int categoryChoice) && categoryChoice >= 1 && categoryChoice <= categories.Count)
            {
                StartCategoryGame(categories[categoryChoice - 1]);
            }
            else
            {
                Console.WriteLine("Neteisingas pasirinkimas.");
            }
        }

        static void StartCategoryGame(Kategorija category)
        {
            Console.Clear();
            Console.WriteLine($"Pradėjote žaisti kategorijoje: {category.Pavadinimas}");

            int correctAnswers = 0;

            for (int i = 0; i < sessionQuestionCount; i++)
            {
                if (i > 0)
                {
                    Console.WriteLine($"Klausimas {i}/{sessionQuestionCount}");
                }

                Klausimas question = category.GetNextQuestion();

                if (question == null)
                {
                    Console.WriteLine("Nėra daugiau klausimų šioje kategorijoje.");
                    break;
                }

                Console.WriteLine(question.Tekstas);

                for (int j = 0; j < question.Atasakymai.Count; j++)
                {
                    Console.WriteLine($"{j + 1}. {question.Atasakymai[j]}");
                }

                Console.Write("Pasirinkite atsakymą (įveskite varianto numerį): ");
                if (int.TryParse(Console.ReadLine(), out int answerChoice) && answerChoice >= 1 && answerChoice <= question.Atasakymai.Count)
                {
                    if (question.PatikrintiAtsakyma(answerChoice - 1))
                    {
                        Console.WriteLine("Teisingas atsakymas! +1 taškas.");
                        correctAnswers++;
                    }
                    else
                    {
                        Console.WriteLine("Neteisingas atsakymas.");
                    }
                }
                else
                {
                    Console.WriteLine("Neteisingas pasirinkimas.");
                }
            }

            Console.WriteLine($"Žaidimo pabaiga. Surinkote {correctAnswers}/{sessionQuestionCount} taškų.");

            Console.WriteLine("Norėdami grįžti atgal, įveskite 'q'.");
            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "q")
                {
                    return;
                }
            }
        }
        static void ShowResultsOrParticipants()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Pasirinkite, ką norite peržiūrėti:");
                Console.WriteLine("1. Rezultatai");
                Console.WriteLine("2. Dalyviai");
                Console.WriteLine("3. Grįžti atgal");
                Console.Write("Įveskite pasirinkimą: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowResults();
                        break;
                    case "2":
                        ShowParticipants();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Neteisingas pasirinkimas.");
                        break;
                }
            }

        }

        static void ShowResults()
        {
            Console.Clear();
            Console.WriteLine("Rezultatai:");

            var sortedResults = userDatabase
                .Select(user => new
                {
                    UserName = user.Value,
                    TotalScore = GetTotalScoreForUser(user.Key)
                })
                .OrderByDescending(result => result.TotalScore)
                .ToList();

            Console.WriteLine("TOP 10 dalyviai:");
            for (int i = 0; i < sortedResults.Count && i < 10; i++)
            {
                string userName = sortedResults[i].UserName;
                string rankIndicator = GetRankIndicator(i);

                Console.WriteLine($"{i + 1}. {rankIndicator} {userName}: {sortedResults[i].TotalScore} taškai");
            }

            Console.WriteLine("Norėdami grįžti atgal, įveskite 'q'.");
            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "q")
                {
                    return;
                }
            }
        }

        static void ShowParticipants()
        {
            Console.Clear();
            Console.WriteLine("Dalyviai:");

            foreach (var user in userDatabase)
            {
                Console.WriteLine(user.Value);
            }

            Console.WriteLine("Norėdami grįžti atgal, įveskite 'q'.");
            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "q")
                {
                    return;
                }
            }
        }

        static int GetTotalScoreForUser(string userKey)
        {
            int totalScore = 0;
            foreach (var category in categories)
            {
                int correctAnswersInCategory = 0;
                foreach (var question in category.klausimai)
                {
                    if (question.PatikrintiAtsakyma(question.TeisingasAtsakymas))
                    {
                        correctAnswersInCategory++;
                    }
                }
                totalScore += correctAnswersInCategory;
            }
            return totalScore;
        }

        static string GetRankIndicator(int rank)
        {
            if (rank < 3)
            {
                return new string('*', rank + 1);
            }
            return string.Empty;
        }
    }

    class Kategorija
    {
        public string Pavadinimas { get; }
        public List<Klausimas> klausimai = new List<Klausimas>();
        private int nextQuestionIndex = 0;

        public Kategorija(string pavadinimas, List<Klausimas> klausimai)
        {
            Pavadinimas = pavadinimas;
            this.klausimai = klausimai;
        }

        public Klausimas GetNextQuestion()
        {
            if (nextQuestionIndex < klausimai.Count)
            {
                return klausimai[nextQuestionIndex++];
            }
            return null;
        }
    }
    class Klausimas
    {
        public string Tekstas { get; }
        public List<string> Atasakymai { get; }
        public int TeisingasAtsakymas { get; }

        public Klausimas(string tekstas, List<string> atasakymai, int teisingasAtsakymas)
        {
            Tekstas = tekstas;
            Atasakymai = atasakymai;
            TeisingasAtsakymas = teisingasAtsakymas;
        }

        public bool PatikrintiAtsakyma(int pasirinkimas)
        {
            return pasirinkimas == TeisingasAtsakymas;
        }
    }
}

