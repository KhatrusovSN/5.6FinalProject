using System;

namespace _5._3FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintUser(EnterUser());
        }

        static (string Name, string LastName, int Age, bool HavePets, int NumPets, string[] NamePets, int NumColors, string[] NameColors) EnterUser()
        {
            (string Name, string LastName, int Age, bool HavePets, int NumPets, string[] NamePets, int NumColors, string[] NameColors) User;

            Console.WriteLine("Введите имя: ");
            User.Name = EnterAndCheckString();

            Console.WriteLine("Введите фамилию: ");
            User.LastName = EnterAndCheckString();

            Console.WriteLine("Введите ваш возвраст:");
            User.Age = EnterAndCheckValue();

            Console.WriteLine("Есть ли у вас домашние питомцы?(ответ - Да/Нет)");
            switch (Console.ReadLine())
            {
                case "да":
                case "Да":
                    User.HavePets = true;
                    break;
                default:
                    User.HavePets = false;
                    break;
            }

            if (User.HavePets)
            {
                Console.WriteLine("Введите кол-во питомцев:");
                User.NumPets = EnterAndCheckValue();
                User.NamePets = EnterPetsName(User.NumPets);
            }
            else
            {
                User.NumPets = 0;
                User.NamePets = new string[0];
            }

            Console.WriteLine("Введите кол-во любимых цветов:");
            User.NumColors = EnterAndCheckValue();
            User.NameColors = EnterColorsName(User.NumColors);

            return User;
        }
        static string[] EnterPetsName(int NumPets)
        {
            Console.WriteLine("Введите клички ваших питомцев:");
            string[] namePets = new string[NumPets];
            for (int i = 0; i < namePets.Length; i++)
            {
                namePets[i] = EnterAndCheckString();
            }
            return namePets;
        }
        static string[] EnterColorsName(int NumColors)
        {
            Console.WriteLine("Введите ваши любимые цвета: ");
            string[] nameColors = new string[NumColors];
            for (int i = 0; i < nameColors.Length; i++)
            {
                nameColors[i] = EnterAndCheckString();
            }
            return nameColors;
        }
        static int EnterAndCheckValue()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result) ^ result < 0)
            {
                Console.WriteLine("Ошибка ввода! Введите число:");
            }
            return result;
        }
        static string EnterAndCheckString()
        {
            string result = Console.ReadLine();
            while (int.TryParse(result, out int intResult) || intResult != 0)
            {
                Console.WriteLine("Ошибка ввода! Повторите попытку:");
                result = Console.ReadLine();
            }
            return result;
        }
        static void PrintUser((string Name, string LastName, int Age, bool HavePets, int NumPets, string[] NamePets, int NumColors, string[] NameColors)tuple)
        {
            Console.WriteLine("\nДанные из кортежа:");
            Console.WriteLine("Имя: " + tuple.Name + " \nФамилия: " + tuple.LastName + " \nВозвраст: " + tuple.Age);

            if (tuple.HavePets)
            {
                Console.WriteLine("Есть домашние животные, их у вас " + tuple.NumPets + " кличка(и): ");
                foreach (var NamePets in tuple.NamePets)
                {
                    Console.Write(NamePets + " ");
                }
            }
            else
                Console.WriteLine("Питомцев нет");

            Console.WriteLine("Кол-во любимых цветов: " + tuple.NumColors);
            foreach (var colors in tuple.NameColors)
            {
                Console.Write(colors + " ");
            }
        }
    }
}

        