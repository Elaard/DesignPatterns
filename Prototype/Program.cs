using System;
using System.Collections.Generic;

namespace Prototype
{
    internal class Program
    {
        //The Prototype design pattern specifies the kind of objects to create using a prototypical instance, and create new objects by copying this prototype.
        static void Main(string[] args)
        {
            ColorManager colormanager = new ColorManager();
            // Initialize with standard colors
            colormanager["red"] = new Color(255, 0, 0);
            colormanager["green"] = new Color(0, 255, 0);
            colormanager["blue"] = new Color(0, 0, 255);
            // User adds personalized colors
            colormanager["angry"] = new Color(255, 54, 0);
            colormanager["peace"] = new Color(128, 211, 128);
            colormanager["flame"] = new Color(211, 34, 20);
            // User clones selected colors
            Color color1 = colormanager["red"].Clone() as Color;
            Color color2 = colormanager["peace"].Clone() as Color;
            Color color3 = colormanager["flame"].Clone() as Color;
            // Wait for user
            Console.ReadKey();
        }
    }
    // Prototype abstract class -> declares an interface for cloning itself
    public abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }

    // ConcretePrototype -> implements an operation for cloning itself
    public class Color: ColorPrototype
    {
        int red;
        int green;
        int blue;

        public Color(int red, int green, int blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        public override ColorPrototype Clone()
        {
            Console.WriteLine(
               "Cloning color RGB: {0,3},{1,3},{2,3}",
               red, green, blue);
            return this.MemberwiseClone() as ColorPrototype;
        }

    }

    // Prototype manager (Client) -> creates a new object by asking a prototype to clone itself
    public class ColorManager
    {
        private Dictionary<string, ColorPrototype> colors =
        new Dictionary<string, ColorPrototype>();
        // Indexer
        public ColorPrototype this[string key]
        {
            get { return colors[key]; }
            set { colors.Add(key, value); }
        }
    }

}
