using System;

namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    // defines an Instance operation that lets clients access its unique instance. Instance is a class operation
    // can be use as database connection if u want to have only one
    class Singleton
    {
        static Singleton instance;
        private Singleton()
        {
            
        }
        
        public static Singleton GetInstance ()
        {
            if(instance == null)
            {
                instance = new Singleton();
            }

            return instance;
        }
    }
}
