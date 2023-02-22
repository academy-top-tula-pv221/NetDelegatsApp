namespace NetDelegatsApp
{
    delegate T BinOperation<T, U>(U a, U b);

    delegate void Message();
    public class User
    {
        public string Name { get; set; }
        public int Age { set; get; }

        public int Mult(int a, int b)
        {
            Console.WriteLine($"Mult {a * b}");
            return a * b;
        }
        public void PrintName()
        {
            Console.WriteLine(Name);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ////Message message = SendText;
            //Message? message = new Message(SendText);
            ////message();
            //User user = new User() { Name = "Bob" };
            //message += user.PrintName;
            //message += SendText;
            ////message();

            //message -= user.PrintName;
            //message?.Invoke();


            BinOperation<int, int> binOperation = Add;
            //Console.WriteLine(binOperation(10, 20));
            binOperation += new User().Mult;
            Console.WriteLine(binOperation(10, 20));

            Console.WriteLine(BinCalc(30, 40, new User().Mult));

            var oper = CreateOperation('*');
        }

        static void SendText()
        {
            Console.WriteLine("Text"); ;
        }

        static int Add(int n, int m)
        {
            Console.WriteLine($"Add {n + m}");
            return n + m;
        }

        static int BinCalc(int a, int b, BinOperation<int, int> operation)
        {
            return operation.Invoke(a, b);
        }

        static BinOperation<int, int>? CreateOperation(char sign)
        {
            return sign switch
            {
                '*' => new User().Mult,
                '+' => Add,
                _ => null
            };
        }
    }
}