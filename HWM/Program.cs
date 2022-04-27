using System;

namespace HWM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dataUser = userEnter();

            Console.WriteLine("Информация о пользователе");
            Console.WriteLine($"* Имя - {dataUser.FirstName}\n* Фамилия - {dataUser.LastName} \n* Возраст - {dataUser.Age}  ");
            Console.Write("* Кличка домнего животного - ");

            foreach (var namepet in dataUser.Pet)
            {
                Console.Write($"{namepet} ");
            }

            Console.Write("\n* Любимые цвета - ");

            foreach (var favcolor in dataUser.FavoritColor)
            {
                Console.Write($"{favcolor} ");
            }
        }

        static (string FirstName, string LastName, int Age, string[] Pet, string[] FavoritColor) userEnter()
        {
            (string FirstName, string LastName, int age, string[] pet, string[] favoritColor) User;

            Console.WriteLine("Ведите своё имя:");
            User.FirstName = Console.ReadLine();
            //*****************************************************************//
            
            Console.WriteLine("Введите свою фамилию:");
            User.LastName = Console.ReadLine();
            //*****************************************************************//

            string age;
            int intage;

            do
            {
                Console.WriteLine("Введите своё возраст:");
                age = Console.ReadLine();
            }
            while (ChekAge(age, out intage));

            User.age = intage;
            //****************************************************************//

            Console.WriteLine("Есть ли у вас домашнее животное да или нет");
            string dataPet = Console.ReadLine();

            switch (dataPet)
            {
                case "да":

                    Console.WriteLine("Введите количество домашних животных");
                    int numberPets = Convert.ToInt32(Console.ReadLine());
                    User.pet = new string[numberPets];
                    for (int i = 0; i < User.pet.Length; i++)
                    {
                        Console.WriteLine("Введите имя одного животоного");
                        User.pet[i] = Console.ReadLine();
                    }
                    break;

                default:
                    User.pet = new string[] { "У пользователя нет домашних животных:" };
                    break;
            }
            //****************************************************************//

            Console.WriteLine("Напишите количество любимых цветов от 1 до 5:");
            int favColor = Convert.ToInt32(Console.ReadLine());
            User.favoritColor = new string[favColor];
            for (int i = 0; i < User.favoritColor.Length; i++)
            {
                Console.WriteLine("Ввседите один из любимых цветов");
                User.favoritColor[i] = Console.ReadLine();
            }

            static bool ChekAge(string number, out int corrnumber)
            {
                if (int.TryParse(number, out int intnum))
                {
                    if (intnum > 0)
                    {
                        corrnumber = intnum;
                        return false;

                    }
                }
                {
                    corrnumber = 0;
                    return true;
                }
            }


            return User;
        }
    }
}