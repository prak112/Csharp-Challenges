namespace FibonacciNumbers
{
    public class FibbonaciNumbers
    {
        public static void Main(string[] args)
        {
            // LOGIC - fibonacci numbers
            // sum of first two real numbers results in 3rd number amd so on..
            // n = (n-2)th element + (n-1)th element
            // - iterate until user input (totalNumbers) == count of fibonacci series numbers
            
            // initialize list with base elements
            List<long> fibonacciSeries = new List<long> { 0, 1 };

            // subtract user input totalNumbers from listed numbers count
            Console.WriteLine("\n---Welcome to Fibonacci series---\nEnter Fibonacci series length (works till 92) : ");
            int totalNumbers = int.Parse(Console.ReadLine());

            // iterate loop times = totalNumbers
            for (int i = fibonacciSeries.Count; i <= totalNumbers; i++)         // start from base count, i.e., 2 elements
            {
                // second last number 
                long previous2 = fibonacciSeries[i - 2];
                // last number
                long previous1 = fibonacciSeries[i - 1];
                // sum of last 2 numbers
                long nextFib =  previous1 + previous2;
                // add to series
                fibonacciSeries.Add(nextFib);
            }                
        
            // display fibonacciSeries
            Console.WriteLine($"Fibonacci series of {totalNumbers} :");
            foreach (long item in fibonacciSeries)
            {
                Console.WriteLine(item);
            }
        }
    }
}