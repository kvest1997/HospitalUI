namespace HospitalUIConsole
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Test ts = new Test();
            
            ts.Inizilizate();
        }
    }

    public class Test
    {
        private Book[] _Books;

        public void Inizilizate()
        {
            _Books = Enumerable.Range(1, 10)
                .Select(i => new Book
                {
                    Category = $"{i}"
                })
                .ToArray();
        }
    }

    public class Book 
    {
        public virtual string Category { get; set; }
    }
}
