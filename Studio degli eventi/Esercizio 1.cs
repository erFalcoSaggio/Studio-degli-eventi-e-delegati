namespace Studio_degli_eventi
{
    delegate void BellHandler();
    internal class Program
    {
        static event BellHandler BellRang; //evento BellRang con delegato BellHandler
        static void Main(string[] args)
        {
            BellRang += OnBellRang; //aggancio all'evento BellRang il metodo OnBellRang
            int n;
            Console.WriteLine("Hello, World!");
            do
            {
                Console.WriteLine("Press 1");
            } while (!int.TryParse(Console.ReadLine(), out n) || n != 1);
            //il campanello viene suonato, quindi chiamo BellPressed();
            BellPressed();
        }
        static void BellPressed()
        {
            Console.WriteLine("Bell pressed..");
            BellRang?.Invoke(); //invoco l'evento >> essendo agganciato a OnBellRang, chiamerà quel metodo
        }
        static void OnBellRang()
        {
            Console.WriteLine("Bell rang!");
        }
    }
}
