using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DZ_15_10
{
    public class Student
    {
        public int id;
        public string firstName;
        public string lastName;
        public int birthYear;
        public string exam;
        public int score;
        public Student(int id, string allInfo)
        {
            this.id = id;
            InsertAllInfo(allInfo);
        }
        public Student(int id, string FirstName, string LastName, int BirthYear, string Exam, int Score)
        {
            this.id = id;
            this.firstName = FirstName;
            this.lastName = LastName;
            this.birthYear = BirthYear;
            this.exam = Exam;
            this.score = Score;
        }
        private void InsertAllInfo(string allInfo)
        {
            string[] allInfoMass = allInfo.Split('#');
            firstName = allInfoMass[0];
            lastName = allInfoMass[1];
            if (!int.TryParse(allInfoMass[2], out birthYear))
            {
                Console.WriteLine("Error");
            }
            exam = allInfoMass[3];
            if (!int.TryParse(allInfoMass[4], out score))
            {
                Console.WriteLine("Error");
            }
        }
    }
    public class FileWorker
    {
        public void AddStudentInfoToFile(string allInfoAboutStudent)
        {
            string text = File.ReadAllText(@".\students.txt");
            text += "\n" + allInfoAboutStudent;
            File.WriteAllText(@".\students.txt", text);
        }
        public void DeleteStudentInfoFromFile(int id)
        {
            string[] text = File.ReadAllLines(@".\students.txt");
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (i + 1 == id)
                {
                    continue;
                }
                result += text[i] + "/n";
            }
            File.WriteAllText(@".\students.txt", result);
        }
        public string[] getAllStudents()
        {
            File.WriteAllText(@".\students.txt", "Ахметов#Ильдар#2004#Информатика#85\nБогомолов#Никита#2004#Информатика#90\nГалимова#Элина#2004#Информатика#88\nГильфанова#Аделина#2004#Информатика#83\nГоловина#Мария#2004#Английский#91\nМухетдинов#Ильназ#2003#Информатика#100\nСагдуллин#Амир#2004#Информатика#85\nМошкина#Мария#2004#Информатика#88\nХузина#Карина#2004#Английский#80\nХамидуллина#Диана#2004#Английский#87");
            string[] mass = File.ReadAllLines(@".\students.txt");
            return mass;
        }
    }
    public class Check{
        public bool UserInutWithCheckInteger(out int userNumber)
        {
            Console.WriteLine("Введите число:");
            while (!int.TryParse(Console.ReadLine(), out userNumber))
            {
                Console.WriteLine("Ошибка, введите число");
            }
            return true;
        }
    }
    public class Villager
    {
        public string name;
        public string numberOfpasport;
        public string problem;
        public int scandalousness;
        public bool isSmart;

        public Villager(string name, string numberOfpasport, string problem, int scandalousness, bool isSmart)
        {
            this.name = name;
            this.numberOfpasport = numberOfpasport;
            this.problem = problem;
            this.scandalousness = scandalousness;
            this.isSmart = isSmart;
        }

    }
    public class Window
    {
        Check check = new Check();
        public string problem;
        public List<Villager> notSortedQueueVilagers = new List<Villager>();
        public Queue<Villager> queueVilagers;
        public void PrintAllVillagers()
        {
            for (int i = 0; i < notSortedQueueVilagers.Count; i++)
            {
                Console.WriteLine(i + ": " + notSortedQueueVilagers[i].name);
            }
        }
        public void SortVillagers()
        {
            Console.WriteLine("Окно " + problem);
            PrintAllVillagers();
            for (int i = 0; i < notSortedQueueVilagers.Count; i++)
            {
                if (notSortedQueueVilagers[i].scandalousness >= 5)
                {
                    int userChoose;
                    bool flag = false;
                    Console.WriteLine(notSortedQueueVilagers[i].name + " очень наглый/ая. Скольких он обгонит?");
                    check.UserInutWithCheckInteger(out userChoose);
                    if (i - userChoose > 0)
                    {
                        Villager rotate = notSortedQueueVilagers[i - userChoose];
                        notSortedQueueVilagers[i - userChoose] = notSortedQueueVilagers[i];
                        notSortedQueueVilagers[i] = rotate;
                    }
                }
            }
            queueVilagers = new Queue<Villager>(notSortedQueueVilagers);
        }
        public void WorkWithVillager()
        {
            while (queueVilagers.Count > 0)
            {
                Villager villager = queueVilagers.Dequeue();
                Console.WriteLine("Обработка жителя:");
                Console.WriteLine(villager.numberOfpasport + ": " + villager.name);
            }
        }
    }
    public class Zina
    {
        Window[] allWindows;
        public Stack<Villager> stackVilagers = new Stack<Villager>();
        public void InsertAllStack()
        {
            stackVilagers.Push(new Villager("МашаМ", "1", "Подключение", 10, false));
            stackVilagers.Push(new Villager("Элина", "2", "Другое", 2, true));
            stackVilagers.Push(new Villager("МашаГ", "3", "Оплата", 3, true));
            stackVilagers.Push(new Villager("Аделя", "4", "Оплата", 7, false));
            stackVilagers.Push(new Villager("Ляйсан", "5", "Другое", 1, true));
            stackVilagers.Push(new Villager("Алия", "6", "Подключение", 9, false));
            stackVilagers.Push(new Villager("Карина", "7", "Оплата", 5, false));
            stackVilagers.Push(new Villager("Диана", "8", "Другое", 5, false));
            stackVilagers.Push(new Villager("Юля", "9", "Подключение", 6, false));
            stackVilagers.Push(new Villager("Алина", "10", "Оплата", 0, false));

        }
        public Zina(Window[] allWindows)
        {
            this.allWindows = allWindows;
            InsertAllStack();
        }
        public void Distribution()
        {
            while (stackVilagers.Count > 0)
            {
                Villager villager = stackVilagers.Pop();
                if (villager.isSmart)
                {
                    for (int i = 0; i < allWindows.Length; i++)
                    {
                        if (villager.problem == allWindows[i].problem)
                        {
                            allWindows[i].notSortedQueueVilagers.Add(villager);
                        }
                    }
                }
                else
                {
                    Random random = new Random();
                    int villageChoose = random.Next(0, allWindows.Length);
                    allWindows[villageChoose].notSortedQueueVilagers.Add(villager);
                }

            }
        }
    }
    class Ex1
    {
        private Dictionary<int, Student> students = new Dictionary<int, Student>();
        private FileWorker fileWorker = new FileWorker();
        private void AddStudentToTheFileAndDictionary(string FirstName, string LastName, int BirthYear, string Exam, int Score)
        {
            string allInfo = FirstName + "#" + LastName + "#" + BirthYear + "#" + Exam + "#" + Score;
            fileWorker.AddStudentInfoToFile(allInfo);
            students.Add(students.Count, new Student(students.Count, FirstName, LastName, BirthYear, Exam, Score));
        }
        private void SortedStudent()
        {
            for (int i = 0; i < students.Count; i++)
            {
                Student rotate;
                for (int j = 0; j < students.Count; j++)
                {
                    if (students[i].score < students[j].score)
                    {
                        rotate = students[i];
                        students[i] = students[j];
                        students[j] = rotate;
                    }
                }
            }
        }
        private void PrintAllStudents()
        {
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(i + ". " + students[i].firstName + " " + students[i].lastName);
            }
        }
        private void AddStudent()
        {
            Console.WriteLine("Введите фамилию:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Введите имя:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Введите год:");
            int year;
            while (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.WriteLine("Некорректный ввод\nВведите год");
            }
            Console.WriteLine("Введите экзамен:");
            string exams = Console.ReadLine();
            Console.WriteLine("Введите баллы:");
            int score;
            while (!int.TryParse(Console.ReadLine(), out score))
            {
                Console.WriteLine("Некорректный ввод\nВведите год");
            }
            AddStudentToTheFileAndDictionary(firstName, lastName, year, exams, score);
        }
        private void RemoveStudent()
        {
            Console.WriteLine("Введите id студента, которого хотите удалить: ");
            int ID;
            while (!int.TryParse(Console.ReadLine(), out ID) && ID >= students.Count && ID < 0)
            {
                Console.WriteLine("Некорректный ввод\nВведите число");
            }
            fileWorker.DeleteStudentInfoFromFile(ID);
            students.Remove(ID);
        }
        public void Run()
        {
            Console.WriteLine("Задача 1");
            string[] allInfoMass = fileWorker.getAllStudents();
            for (int i = 0; i < allInfoMass.Length; i++)
            {
                Student student = new Student(i, allInfoMass[i]);
                students.Add(i, student);
            }
            string userChoice = "";
            while (!userChoice.Equals("Выход"))
            {
                Console.WriteLine("Список студентов:");
                PrintAllStudents();
                Console.WriteLine("\n\nВведите команду:\n1. Новый студент\n2. Удалить\n3. Сортировать\n4. Выход");
                userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "Новый студент":
                        AddStudent();
                        break;
                    case "Удалить":
                        RemoveStudent();
                        break;
                    case "Сортировать":
                        SortedStudent();
                        PrintAllStudents();
                        break;
                    case "Выход":
                        break;
                    default:
                        Console.WriteLine("Ошибка, введите корректное значение.");
                        break;
                }
            }
        }
    }
    class Ex2
    {
        private static string Games(int[] masOf1KLAn, int[] masOf2KLAn)
        {
            string fraza1 = "Drinks All Round! Free Beers on Bjorg!";
            string fraza2 = "Ой, Бьорг -пончик! Ни для кого пива!";
            int count1 = 0;
            int count2 = 0;
            foreach (int n in masOf1KLAn)
            {
                if (n == 5)
                {
                    count1 += 1;
                }
            }
            foreach (int n in masOf2KLAn)
            {
                if (n == 5)
                {
                    count2 += 1;
                }
            }
            return count1 == count2 ? fraza1 : fraza2;
        }
        public void Run()
        {
            Console.WriteLine("\nЗадание 2 Пятерки");
            Console.WriteLine("Введите количество элементов массива:");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите числа для 1 массива:");
            int[] masOf1KLAn = new int[N];
            for (int i = 0; i < masOf1KLAn.Length; i++)
            {
                masOf1KLAn[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Введите числа для 2 массива:");
            int[] masOf2KLAn = new int[N];
            for (int i = 0; i < masOf2KLAn.Length; i++)
            {
                masOf2KLAn[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine(Games(masOf1KLAn, masOf2KLAn));
        }

    }
    class Ex3
    {
        string[] problems = { "Подключение", "Оплата", "Другое" };
        Window[] allWindows = new Window[3];
        public void Run()
        {
            Console.WriteLine("Задание 3");
            for (int i = 0; i < 3; i++)
            {
                allWindows[i] = new Window();
                allWindows[i].problem = problems[i];
            }
            Zina zina = new Zina(allWindows);
            zina.Distribution();
            for (int i = 0; i < allWindows.Length; i++)
            {
                allWindows[i].SortVillagers();
                allWindows[i].WorkWithVillager();
            }
        }
    }
    class Ex4
    {
        public void Run()
        {
            Console.WriteLine("Задание 4 Обход графа в ширину");
            Random rand = new Random();
            Queue<int> NumbOfVersh = new Queue<int>();
            Console.Write("Введите количество вершин: ");
            int KolishVersh = int.Parse(Console.ReadLine()) - 1;
            if (KolishVersh >= 3)
            {
                bool[] UsedVersh = new bool[KolishVersh + 1];
                int[][] SmezhVersh = new int[KolishVersh + 1][];

                for (int i = 0; i < KolishVersh + 1; i++)
                {
                    SmezhVersh[i] = new int[KolishVersh + 1];
                    Console.Write($"\n{i + 1} вершина - [");
                    for (int j = 0; j < KolishVersh + 1; j++)
                    {
                        SmezhVersh[i][j] = rand.Next(0, 2);
                    }
                    SmezhVersh[i][i] = 0;
                    foreach (var item in SmezhVersh[i])
                    {
                        Console.Write($" {item}");
                    }
                    Console.Write("]\n");
                }
                UsedVersh[KolishVersh] = true;//информация о том, посещали мы вершину или нет 
                NumbOfVersh.Enqueue(KolishVersh);
                Console.WriteLine("Начинаем обход с {0} вершины", KolishVersh + 1);
                while (NumbOfVersh.Count != 0)
                {
                    KolishVersh = NumbOfVersh.Peek();
                    NumbOfVersh.Dequeue();
                    Console.WriteLine("Перешли к узлу {0}", KolishVersh + 1);

                    for (int i = 0; i < SmezhVersh.Length; i++)
                    {
                        if (Convert.ToBoolean(SmezhVersh[KolishVersh][i]))
                        {
                            int v = i;
                            if (!UsedVersh[v])
                            {
                                UsedVersh[v] = true;
                                NumbOfVersh.Enqueue(v);
                                Console.WriteLine("Добавили в очередь узел {0}", v + 1);
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Количество вершин некорректно");
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Ex1 ex1 = new Ex1();
            ex1.Run();
            Ex2 ex2 = new Ex2();
            ex2.Run();
            Ex3 ex3 = new Ex3();
            ex3.Run();
            Ex4 ex4 = new Ex4();
            ex4.Run();
        }
    }
}  
