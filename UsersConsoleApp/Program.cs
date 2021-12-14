using System;

namespace UsersConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            MenuApp();
        }

        static void MenuApp()
        {
            Console.WriteLine("1. Add User");

            Console.WriteLine("2. Edit User");

            Console.WriteLine("3.Delete User");

            Console.WriteLine("4. Show user info");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    AddUserFun();
                    break;


                case 2:
                    Console.WriteLine("Please Enter File Name");
                    EditUser(Console.ReadLine());
                    break;


                case 3:
                    Console.WriteLine("Please Enter File Name");
                    string userAnswer = Console.ReadLine();
                    DeleteUser(userAnswer);
                    break;


                case 4:
                    Console.WriteLine("Please Enter File Name");
                    GetDataFromUserFile(Console.ReadLine());
                    break;

                default:
                    MenuApp();
                    break;

            }
        }


        static void AddUserFun()
        {
            Console.WriteLine("Enter name:");
            string nameUser = Console.ReadLine();

            Console.WriteLine("Enter Last name:");
            string nameLastUser = Console.ReadLine();

            Console.WriteLine("Enter year of birth");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Email");
            string emailUser = Console.ReadLine();

            User userInput = new User(nameUser, nameLastUser, year, emailUser);
            Console.WriteLine(userInput.Fname);
            GetObjAndAddToFile(userInput);
        }

        static void GetObjAndAddToFile(User userOne)
        {
            FileStream fileStream = new FileStream(@$"C:\Users\edent\OneDrive\שולחן העבודה\טק קריירה\C#\שיעורי בית\משימת סופש 09.12 פיצול\files\{userOne.Fname}.txt", FileMode.Append);
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.WriteLine($"{userOne.Fname} {userOne.LName} {userOne.YearOfBirth} {userOne.Email}");
            }

            FileStream fileStreamTwo = new FileStream(@$"C:\Users\edent\OneDrive\שולחן העבודה\טק קריירה\C#\שיעורי בית\משימת סופש 09.12 פיצול\files\listAll.txt", FileMode.Append);
            using (StreamWriter writer = new StreamWriter(fileStreamTwo))
            {
                writer.WriteLine($"{userOne.Fname} {userOne.LName} {userOne.YearOfBirth} {userOne.Email}");
            }
        }

        static void EditUser(string userName)
        {
            string[] arrayOfStrings;

            FileStream fileStreamObject = new FileStream($@"C:\Users\edent\OneDrive\שולחן העבודה\טק קריירה\C#\שיעורי בית\משימת סופש 09.12 פיצול\files\{userName}.txt", FileMode.Open);
            using (StreamReader readFromUserFile = new StreamReader(fileStreamObject))
            {
                arrayOfStrings = readFromUserFile.ReadLine().Split(" ");
            }

            FileStream userFile = new FileStream($@"C:\Users\edent\OneDrive\שולחן העבודה\טק קריירה\C#\שיעורי בית\משימת סופש 09.12 פיצול\files\{userName}.txt", FileMode.Create);
            using (StreamWriter writeToUserFile = new StreamWriter(userFile))
            {
                Console.WriteLine("Please Select The Options");
                Console.WriteLine("1. Edit firstName");
                Console.WriteLine("2. Edit lastName");
                Console.WriteLine("3. Edit yearOfBirth");
                Console.WriteLine("4. Edit email");
                int selectedOption = int.Parse(Console.ReadLine());
                switch (selectedOption)
                {
                    case 1:
                        Console.WriteLine("Enter firstName");
                        Update(0, writeToUserFile, arrayOfStrings);
                        break;
                    case 2:
                        Console.WriteLine("Enter lastName");
                        Update(1, writeToUserFile, arrayOfStrings);
                        break;
                    case 3:
                        Console.WriteLine("Enter yearOfBirth");
                        Update(2, writeToUserFile, arrayOfStrings);
                        break;
                    case 4:
                        Console.WriteLine("Enter Email");
                        Update(3, writeToUserFile, arrayOfStrings);
                        break;
                    default:
                        EditUser(userName);
                        break;
                }
            }
        }

         static void Update(int v, StreamWriter writeToUserFile, string[] arrayOfStrings)
        {
            throw new NotImplementedException();
        }

        static void DeleteUser(string fileName) => File.Delete(fileName);


        static void GetDataFromUserFile(string fileName)
        {
            FileStream fileStream = new FileStream(@$"C:\Users\edent\OneDrive\שולחן העבודה\טק קריירה\C#\שיעורי בית\משימת סופש 09.12 פיצול\files\{fileName}.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }


    }



}