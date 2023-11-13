namespace FactorialProcessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FactorialProcessor processor = new FactorialProcessor();
           
            try
            {
                processor.Go(5, true);
                Console.WriteLine();

                processor.Go(5, false);
                Console.WriteLine();

                processor.Go(10, true);
                Console.WriteLine();

                processor.Go(10, false);
                Console.WriteLine();

                processor.Go(15, true);
                Console.WriteLine();

                processor.Go(15, false);
                Console.WriteLine();

                // The code line to check try-catch block
                processor.Go(16, false);
            }
            catch (ArgumentException ex) 
            {
                Console.WriteLine($"Incorrect parameter provided, out of scope (1<=X<=15): {ex.Message}"); 
            }
        }
    }
}