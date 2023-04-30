using System;

namespace AbstractFactory
{
    internal class Program
    {
        //The Abstract Factory design pattern provides an interface for
        //creating families of related or dependent objects without specifying their concrete classes.
        static void Main(string[] args)
        {
            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);

            world.RunFoodChain();

            Console.ReadKey();
        }
    }
    // Use the Abstract Factory when your code needs to work with various families of related products,
    // but you don’t want it to depend on the concrete classes of those products—they might be unknown beforehand
    // or you simply want to allow for future extensibility
    // Abstract factory
    abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }
    // Concrete factory -> implements the operations to create concrete product objects
    class AfricaFactory : ContinentFactory
    {
        public override Carnivore CreateCarnivore()
        {
            return new Lion();
           
        }

        public override Herbivore CreateHerbivore()
        {
            return new Wildebeest();
        }
    }
    // Concrete factory -> implements the operations to create concrete product objects
    class AmericaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }
    // AbstractProduct
    abstract class Herbivore
    {

    }
    // AbstractProduct
    abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }
    // Product
    class Wildebeest : Herbivore
    {
    }
    // Product
    class Bison : Herbivore
    {
    }
    // Product
    class Lion : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            Console.WriteLine(this.GetType().Name +
              " eats " + h.GetType().Name);
        }
    }

    class Wolf : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            Console.WriteLine(this.GetType().Name +
              " eats " + h.GetType().Name);
        }
    }

    //Client class -> uses interfaces declared by AbstractFactory and AbstractProduct classes
    class AnimalWorld
    {
        private Herbivore _herbivore;
        private Carnivore _carnivore;
        // Constructor
        public AnimalWorld(ContinentFactory factory)
        {
            _carnivore = factory.CreateCarnivore();
            _herbivore = factory.CreateHerbivore();
        }
        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
        }
    }

}
