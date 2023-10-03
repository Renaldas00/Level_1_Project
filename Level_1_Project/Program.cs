using System;
using System.Collections.Generic;
using System.Linq;

namespace Project
{
    class Program
    {
        static Dictionary<string, string> userDatabase = new Dictionary<string, string>();
        static Dictionary<string, int> userScores = new Dictionary<string, int>();
        static string currentUser = null;
        public static List<Question> questions = new List<Question>();
        static int sessionQuestionCount = 5;
        public static List<Category> categories = new List<Category>
        {
            new Category("Matematika", new List<Question>
            {
                new Question("2 + 2?", new List<string> { "4", "5", "6" }, 0),
                new Question("10 * 5?", new List<string> { "50", "25", "15" }, 0),
                new Question("Kas yra 5 kart 7?", new List<string> { "35", "42", "12" }, 0),
                new Question("Kiek yra 8 dalyba iš 2?", new List<string> { "4", "6", "10" }, 0),
                new Question("Koks yra kvadratinės šaknies iš 144 rezultatas?", new List<string> { "12", "10", "14" }, 0)
            }),
            new Category("Istorija", new List<Question>
            {
                new Question("Kas buvo pirmasis prezidentas JAV?", new List<string> { "George Washington", "Thomas Jefferson", "John Adams" }, 0),
                new Question("Kur vyko Pirmasis pasaulinis karas?", new List<string> { "Europa", "Azija", "Afrika" }, 0),
            }),
            new Category("C# Programavimas", new List<Question>
            {
                new Question("Kas yra C# programavimo kalbos pagrindinė savybė?", new List<string> { "Objektinė programavimo kalba", "Funkcinė programavimo kalba", "Procedūrinė programavimo kalba" }, 0),
                new Question("Kas yra C# klasės ir objektai?", new List<string> { "Klasės yra šablonai, o objektai yra jų egzemplioriai", "Tai yra kintamieji", "Tai yra funkcijos" }, 0),
                new Question("Kas yra .NET framework?", new List<string> { ".NET framework yra programinė platforma, skirta kurti Windows aplikacijas", ".NET framework yra operacinė sistema", ".NET framework yra C# programavimo kalba" }, 0),
                new Question("Kas yra C# sintaksės pagrindas?", new List<string> { "Raktažodžiai, operatoriai ir kintamieji", "Kintamieji ir funkcijos", "Klasės ir objektai" }, 0),
                new Question("Ką reiškia C# programos kompiliavimas?", new List<string> { "Tai procesas, kuriuo C# programa verčiama į mašinos kodą", "Tai procesas, kuriuo programa testuojama", "Tai procesas, kuriuo programa vykdoma" }, 0),
            }),
        };

        static void Main()
        {
            while (true)
            {
                if (currentUser == null)
                {
                    Console.WriteLine("Welcome! To log in, you need to enter your first name and last name.");
                    Console.Write("Enter your first name: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Enter your last name: ");
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
                        Console.WriteLine($"Successfully logged in.\nUser Display Name: {currentUser}");
                    }
                    else
                    {
                        RegisterUser(firstName, lastName);
                        currentUser = userDatabase[userKey];
                        userScores[userKey] = 0;
                        Console.WriteLine($"Congratulations, you've logged in and created a new account, {currentUser}!");
                    }
                }
                else
                {
                    ShowMenu();
                }

                Console.WriteLine("Press Enter to continue...");
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
                    Console.WriteLine($"Hello, {currentUser}!");
                    Console.WriteLine("Choose an action:");
                    Console.WriteLine("1. Game Rules");
                    Console.WriteLine("2. Start Game");
                    Console.WriteLine("3. Results");
                    Console.WriteLine("4. Logout");
                    Console.WriteLine("5. Exit");
                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {

                        case "1":
                            ShowGameRules();
                            break;
                        case "2":
                            StartGame();
                            break;
                        case "3":
                            ShowResultsOrParticipants();
                            break;
                        case "4":
                            currentUser = null;
                            Console.WriteLine("You have logged out. Please log in again.");
                            return;
                        case "5":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
            }
        }

        static void ShowGameRules()
        {
            Console.Clear();
            Console.WriteLine("Game Rules:");
            Console.WriteLine("Welcome to the quiz game.");
            Console.WriteLine("Select a category and answer the questions.");
            Console.WriteLine("Write the answer using the option number.");
            Console.WriteLine("To go back, enter 'q'.");
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
            Console.WriteLine("Choose a category:");
            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {categories[i].Name}");
            }

            Console.Write("Enter the category number: ");
            if (int.TryParse(Console.ReadLine(), out int categoryChoice) && categoryChoice >= 1 && categoryChoice <= categories.Count)
            {
                StartCategoryGame(categories[categoryChoice - 1]);
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        static void StartCategoryGame(Category category)
        {
            Console.Clear();
            Console.WriteLine($"You've started a game in the category: {category.Name}");

            int correctAnswers = 0;

            category.ResetNextQuestionIndex();

            for (int i = 0; i < sessionQuestionCount; i++)
            {
                if (i > 0)
                {
                    Console.WriteLine($"Question {i}/{sessionQuestionCount}");
                }

                Question question = category.GetNextQuestion();

                if (question == null)
                {
                    Console.WriteLine("No more questions in this category.");
                    break;
                }

                Console.WriteLine(question.Text);

                for (int j = 0; j < question.Response.Count; j++)
                {
                    Console.WriteLine($"{j + 1}. {question.Response[j]}");
                }

                Console.Write("Choose an answer (enter the option number): ");
                if (int.TryParse(Console.ReadLine(), out int answerChoice) && answerChoice >= 1 && answerChoice <= question.Response.Count)
                {
                    if (question.ResponseCheck(answerChoice - 1))
                    {
                        Console.WriteLine("Correct answer! +1 point.");
                        correctAnswers++;
                    }
                    else
                    {
                        Console.WriteLine("Wrong answer.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }

            string userKey = GetUserKey(currentUser.Split(' ')[0], currentUser.Split(' ')[1]);
            static string GetUserKey(string firstName, string lastName)
            {
                return $"{firstName.ToLower()}_{lastName.ToLower()}";
            }

            userScores[userKey] += correctAnswers;

            Console.WriteLine($"End of the game. You scored {correctAnswers}/{sessionQuestionCount} points.");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
        static void ShowResultsOrParticipants()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose what you want to view:");
                Console.WriteLine("1. Results");
                Console.WriteLine("2. Participants");
                Console.WriteLine("3. Back");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowResults();
                        break;
                    case "2":
                        ShowAllParticipants();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void ShowAllParticipants()
        {
            Console.Clear();
            Console.WriteLine("Participants:");

            foreach (var user in userDatabase)
            {
                string userName = user.Value;
                Console.WriteLine(userName);
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }


        static void ShowResults()
        {
            Console.Clear();
            Console.WriteLine("Results:");

            var sortedResults = userScores
                .OrderByDescending(pair => pair.Value)
                .ToList();

            Console.WriteLine("Top 10 Players:");
            for (int i = 0; i < sortedResults.Count && i < 10; i++)
            {
                string userName = userDatabase[sortedResults[i].Key];
                int userScore = sortedResults[i].Value;
                string rankIndicator = GetRankIndicator(i);

                Console.WriteLine($"{i + 1}. {rankIndicator} {userName}: {userScore} points");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
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



    class Category
    {
        public string Name { get; }
        public List<Question> questions = new List<Question>();
        private int nextQuestionIndex = 0;

        public Category(string name, List<Question> questions)
        {
            Name = name;
            this.questions = questions;
        }

        public Question GetNextQuestion()
        {
            if (nextQuestionIndex < questions.Count)
            {
                return questions[nextQuestionIndex++];
            }
            return null;
        }
        public void ResetNextQuestionIndex()
        {
            nextQuestionIndex = 0;
        }
    }

    class Question
    {
        public string Text { get; }
        public List<string> Response { get; }
        public int CorrectResponse { get; }

        public Question(string text, List<string> response, int correctResponse)
        {
            Text = text;
            Response = response;
            CorrectResponse = correctResponse;
        }

        public bool ResponseCheck(int choice)
        {
            return choice == CorrectResponse;
        }
    }
}
