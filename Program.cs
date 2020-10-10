using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l_3
{
    class Person

    {
        public static int id = 0; //создайте в классе статистическое поле, хранящее количество созданных объектов
        public string name;
        public string surname;
        public string patronymic;
        public string address;
        public int telephone;
        public int[] marks;
        public int age;
        public Person()//конструктор по умолчанию
        {
            id++;
            name = "Lysova";
            surname = "Anastasia";
            patronymic = "Nikolaevna";
            address = "Belarus, Minsk";
            telephone = 25896547;
            age = 18;
        }
        public Person(int a)//конструктор с параметром
        {
            id++;
        }
        static Person()//статический конструктор, без параметров 
        //Статические конструкторы обычно используются для инициализации статических данных, либо же выполняют действия, которые требуется выполнить только один раз
        {
            Console.WriteLine("Программа запущена!");
        }
         class Read
    {
        //ПОЛЕ ТОЛЬКО ДЛЯ ЧТЕНИЯ
        public readonly double K = 23;
        public Read(double _k)
        {
            K = _k; //поле для чтения 
            }
    }
        public Person(Person a)//конструктор копирования
        {
            id++;
            name = a.name;
        }
        public override string ToString()//переопределён метод ToString
        //заменяю базовое поведение метода на свою реализацию
        {
            string h = (base.ToString() + " ");
            return h;
        }
        public override bool Equals(object obj)//переопределён метод Equals(определяет, равен ли указанный объект текущему объекту)
        {
            bool h = base.Equals(obj);
            return h;
        }
        public override int GetHashCode()//переопределён метод GetHashCode (если он равен, то объекты в c# равны)
        {
            return base.GetHashCode();
        }
        public void GetInfo()
        {
            Console.WriteLine($"имеют удовлетворительные отметки ИМЯ:{name} Адрес:{address}");
        }
        public void Info4()
        {
            Console.WriteLine($"Имеют неудовлетворительную отметку ИМЯ:{name} Адрес:{address}");
        }
        public void InfoS()
        {
            Console.WriteLine($"Сумма баллов выше заданной ИМЯ:{name} Адрес:{address}");
        }
        static int getid()//статический метод
        {
            return id;
        }
        public static void GetClassInfo() 
        {
            Console.WriteLine("Elements count is: " + Person.getid());
        }
    }
    public partial class Human
    {
        private int telephone;
        public int Telephone { get; set; } //автоматические свойства
        public void Move()
        {
            Console.WriteLine("I am moving");
        }
        public override string ToString()//переопределён метод ToString
        {
            string h = (base.ToString() + $"private int age = {telephone}\n" +
            "public int Age{get;set;}");
            return h;
        }
    }
    ///частичные методы
    ///То есть мы можем иметь несколько файлов с определением одного и того же класса,
    ///и при компиляции все эти определения будут скомпилированы в одно.
    public partial class Prog
    // частичный: мы можем иметь несколько файлов с определением одного и того же класса, и при компиляции все эти определения будут скомпилированы в одно
    {
        partial void DoSomethingElse();
        public void DoSomething()
        {
            Console.WriteLine("Start");
            DoSomethingElse();
            Console.WriteLine("Finish");
        }
    }
    class RefExample
    //при передаче параметров по ссылке перед параметрами используется модификатор ref
    {
        static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
        public static void SwapExample()
        {
            int i = 1, j = 2;
            Swap(ref i, ref j);
            Console.WriteLine($"{i} {j}"); // Outputs "2 1"
        }
    }

    class OutExample //результат возвращается не через оператор return, а через выходной параметр 
    //чтобы сделать параметр выходным, перед ним ставится модификатор out
    {
        static void Sum(int x, int y, out int a)
        {
            a = x + y;
        }
    }

    public partial class Prog
    // частичный: мы можем иметь несколько файлов с определением одного и того же класса, и при компиляции все эти определения будут скомпилированы в одно
    {
        partial void DoSomethingElse()
        {
            Console.WriteLine("I am reading a book");
        }
    }

    public class Counter////закрытый конструктор, запрещает автоматическое создание кострукторов без параметров
    {
        private Counter() { }
        public static int currentCount;
        public static int IncrementCount()
        {
            return ++currentCount;
        }
    }
    class People
    {
        private string name;
        public string Name //В блоке get мы возвращаем значение поля, а в блоке set устанавливаем.
        {
            get
            {
                return name;
            }
            protected set //ограничивается уровень доступа для метода set, тогда как метод get остается общедоступным
            //protected - модификатор доступа (такой член класса доступен из любого места в текущем классе или в производных классах)
            {
                name = value;
            }
        }
    }
    class MathLib////поле-константа
    {
        public const int ID = 25;
    }
    public class Program
    {
        static void Main(string[] args)
        { 
            Person Nastya = new Person();////конструктор
            Nastya.name = "Anastasia";
            Nastya.surname = "Lysova";
            Nastya.patronymic = "Nikolaevna";
            Nastya.telephone = 25896547;
            int sum = 0;
            Nastya.marks = new int[] { 5, 8, 6, 9, 2 };
            int Min = Nastya.marks.Min();
            int Max = Nastya.marks.Max();
            Console.WriteLine("Nastya имеет " + "min отметку " + Min + " " + " max отметку " + Max);
            for (int i = 0; i < Nastya.marks.Length; i++)
            {
                if (Nastya.marks[i] < 4) Nastya.Info4();
                sum = sum + Nastya.marks[i];
            }
            Console.WriteLine(sum);
            if (sum > 53) Nastya.InfoS();
            Counter.currentCount = 100;////вызов закрытого конструктора
            Counter.IncrementCount();
            Console.WriteLine("New count:", Counter.currentCount);
            var User = new { name = "fbgb", telephone = 858483 };///анонимный тип
            Console.WriteLine(User.name);
            Person Elena = new Person();////конструктор
            int Sum = 0;
            Elena.name = "Elena";
            Elena.surname = "Ivanova";
            Elena.telephone = 258421;
            Elena.marks = new int[] { 5, 6, 7, 8, 9, 8 };
            for (int j = 0; j < Elena.marks.Length; j++)
            {
                if (Elena.marks[j] < 4) Elena.Info4();
                Sum = Sum + Elena.marks[j];
            }
            Console.WriteLine(sum);
            if (Sum > 3) Elena.InfoS(); //СУММА БАЛЛОВ ВЫШЕ ЗАДАННОЙ
            Elena.address = "Belarus, Brest";
            Person.GetClassInfo();
            Console.ReadKey();
        }
    }
}
