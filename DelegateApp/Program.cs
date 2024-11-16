namespace DelegateApp
{
    public class Program
    {

        static void Main(string[] args)
        {

        }

        #region SquareTask
        delegate void Square(int x);

        public static void SquareCalc()
        {
            // Kvadratın sahəsini və perimetrini qaytaran methodlar yazın. Bunu delegate istifadə edərək edin.
            // Delegate çağıldığı təqdirdə ekrana həm perimetr, həm də sahə çıxmalıdır.
            Square square = new Square(Area);
            square += Perimetr;

            square(5);
        }

        public static void Area(int x)
        {
            Console.WriteLine(x * x);
        }

        public static void Perimetr(int x)
        {
            Console.WriteLine(4 * x);
        }
        #endregion
        #region BankQueue
        // Bir bank növbəsini simulyasiya edin. Stack və ya Queue istifadə edərək,
        // müştəriləri növbəyə əlavə edin və onların növbədən çıxmasını təmin edin.
        // Proqram aşağıdakı funksionallığa malik olmalıdır:

        // - Müştəri növbəyə əlavə olunur.
        // - Növbədə ilk müştəri çağırılır və növbədən çıxarılır.
        // - Növbədəki müştərilərin siyahısı göstərilir.
        public static void BankQueue()
        {
            Queue<string> bankQueue = new Queue<string>();

            int input = 0;

            do
            {
                Console.WriteLine("Əməliyyatı seçin: ");
                Console.WriteLine("1. Müştəri növbəyə əlavə olunur.");
                Console.WriteLine("2. Növbədə ilk müştəri çağırılır və növbədən çıxarılır.");
                Console.WriteLine("3. Növbədəki müştərilərin siyahısı göstərilir.");

                input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Console.WriteLine("Adınızı qeyd edin: ");
                        string newName = Console.ReadLine().Trim();
                        bankQueue.Enqueue(newName);
                        break;
                    case 2:
                        string deletedName = bankQueue.Dequeue();
                        Console.WriteLine($"{deletedName} çağırıldı.");
                        break;
                    case 3:
                        if (bankQueue.Count > 0)
                        {
                            foreach (var item in bankQueue)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Novbede adam yoxdu");
                        }
                        break;
                    default:
                        break;
                }
            } while (input != 0);
        }
        #endregion
        #region OperationDelegate

        delegate int OperationDelegate(int x, int y);
        public static void OperationDelegateMethod()
        {
            /*
             Proqram yazın ki, iki ədəd alsın və istifadəçiyə bu ədədlər üzərində hansı əməliyyatı etmək istədiyini soruşsun (Toplama, Çıxma, Vurma, Bölmə).
             Hər bir əməliyyat üçün fərqli metod yaradın. Delegate yaradın və istifadəçinin seçiminə görə uyğun metodu çağırın.

                2.1 Bir delegate yaradın: OperationDelegate(int a, int b)
                2.2 Addition, Subtraction, Multiplication, Division metodlarını yaradın.
                2.3 İstifadəçinin seçiminə görə uyğun metodu çağırmaq üçün delegate istifadə edin.
                2.4 Nəticəni ekrana çıxarın.
             */

            Console.WriteLine("Seçim edin: ");
            Console.WriteLine("1. Toplama");
            Console.WriteLine("2. Çıxma");
            Console.WriteLine("3. Vurma");
            Console.WriteLine("4. Bölmə");

            int input = int.Parse(Console.ReadLine());

            Console.WriteLine("First input: ");
            int firstInput = int.Parse(Console.ReadLine());
            Console.WriteLine("Second input: ");
            int secondInput = int.Parse(Console.ReadLine());

            OperationDelegate operationDel = input switch
            {
                1 => (x, y) => x + y,
                2 => (x, y) => x - y,
                3 => (x, y) => x * y,
                4 => (x, y) => y != 0 ? x / y : throw new DivideByZeroException(),
                _ => throw new InvalidOperationException()
            };

            Console.WriteLine($"Netice: {operationDel(firstInput, secondInput)}");
        }
        #endregion

        #region GradeCalculation
        public delegate double GradeCalculationDelegate(List<Student> students);
        public static void GradeCalculation()
        {
            /*
             3. Bir şagird siyahısındakı şagirdlərin ballarını müxtəlif üsullarla (ortalama, maksimum, minimum) hesablamaq üçün bir proqram yazın.

                3.1 Student sinfi yaradın: Name, Grade xüsusiyyətlərini daxil edin.
                3.2 Delegate yaradın: GradeCalculationDelegate(List<Student> students)
                3.3 3 metod yaradın:
                - CalculateAverage - Ortalamanı qaytarır.
                - CalculateMax - Maksimum balı qaytarır.
                - CalculateMin - Minimum balı qaytarır.
                3.4 İstifadəçiyə hansı hesablama üsulunu seçmək istədiyini soruşun. Seçimə əsasən delegat vasitəsilə metodu çağırın.
             */
            List<Student> students = new List<Student>()
            {
                new Student{Name="Firdovsi", Grade=90},
                new Student {Name="Salam", Grade=85},
                new Student{ Name="Sagol", Grade=70}
            };


            Console.WriteLine("Secim edin: ");
            Console.WriteLine("1. Average: ");
            Console.WriteLine("2. Max: ");
            Console.WriteLine("3. Min: ");

            int input = int.Parse(Console.ReadLine());

            GradeCalculationDelegate gradeCalculation = input switch
            {
                1 => (students) => students.Average(n => n.Grade),
                2 => (students) => students.Max(n => n.Grade),
                3 => (students) => students.Min(n => n.Grade),
                _ => throw new InvalidOperationException()
            };

            Console.WriteLine($"Netice: {gradeCalculation(students)}");
        }
        #endregion
    }

    public class Student
    {
        public string Name { get; set; }
        public int Grade { get; set; }
    }
}
