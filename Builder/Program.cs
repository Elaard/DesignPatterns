using System;
using System.Collections.Generic;

namespace Builder
{
    internal class Program
    {
        //The Builder design pattern separates the construction of a complex object from its
        //representation so that the same construction process can create different representations
        static void Main(string[] args)
        {
            VehicleBuilder builder;

            Shop shop = new Shop();

            builder = new ScooterBuilder();

            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new MotorCycleBuilder(); 
            shop.Construct(builder);
            builder.Vehicle.Show();


            Console.ReadKey();

        }
    }

    //Director -> constructs an object using the Builder interface
    //can exist many directors for example director which creates car without doors
    class Shop
    {
        public void Construct(VehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.BuildFrame();
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuildWheels();
            vehicleBuilder.BuildDoors();
        }
    }

    //Builder -> specifies an abstract interface for creating parts of a Product object
    abstract class VehicleBuilder
    {
        protected Vehicle vehicle;
        public Vehicle Vehicle
        {
            get { return vehicle; }
        }

        public abstract void BuildFrame();
        public abstract void BuildEngine();
        public abstract void BuildWheels();
        public abstract void BuildDoors();
    }
    //ConcreteBuilder
    class MotorCycleBuilder : VehicleBuilder
    {
        public MotorCycleBuilder()
        {
            vehicle = new Vehicle("MotorCycle");
        }
        public override void BuildFrame()
        {
            vehicle["frame"] = "MotorCycle Frame";
        }
        public override void BuildEngine()
        {
            vehicle["engine"] = "500 cc";
        }
        public override void BuildWheels()
        {
            vehicle["wheels"] = "2";
        }
        public override void BuildDoors()
        {
            vehicle["doors"] = "0";
        }
    }
    //ConcreteBuilder
    class CarBuilder : VehicleBuilder
    {
        public CarBuilder()
        {
            vehicle = new Vehicle("Car");
        }
        public override void BuildFrame()
        {
            vehicle["frame"] = "Car Frame";
        }
        public override void BuildEngine()
        {
            vehicle["engine"] = "2500 cc";
        }
        public override void BuildWheels()
        {
            vehicle["wheels"] = "4";
        }
        public override void BuildDoors()
        {
            vehicle["doors"] = "4";
        }
    }
    //ConcreteBuilder
    class ScooterBuilder : VehicleBuilder
    {
        public ScooterBuilder()
        {
            vehicle = new Vehicle("Scooter");
        }
        public override void BuildFrame()
        {
            vehicle["frame"] = "Scooter Frame";
        }
        public override void BuildEngine()
        {
            vehicle["engine"] = "50 cc";
        }
        public override void BuildWheels()
        {
            vehicle["wheels"] = "2";
        }
        public override void BuildDoors()
        {
            vehicle["doors"] = "0";
        }
    }

    //Product -> complex object under construction
    class Vehicle
    {
        private string _vehicleType;
        private Dictionary<string, string> _parts =
          new Dictionary<string, string>();
        // Constructor
        public Vehicle(string vehicleType)
        {
            this._vehicleType = vehicleType;
        }
        // Indexer
        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }
        public void Show()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Vehicle Type: {0}", _vehicleType);
            Console.WriteLine(" Frame : {0}", _parts["frame"]);
            Console.WriteLine(" Engine : {0}", _parts["engine"]);
            Console.WriteLine(" #Wheels: {0}", _parts["wheels"]);
            Console.WriteLine(" #Doors : {0}", _parts["doors"]);
        }
    }
}
