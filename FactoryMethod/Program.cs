using System;
using System.Collections.Generic;

namespace FactoryMethod
{
    internal class Program
    {
        //The Factory Method design pattern defines an interface for creating an object,
        //but let subclasses decide which class to instantiate.
        //This pattern lets a class defer instantiation to subclasses.

        static void Main(string[] args)
        {
            Document[] documents = new Document[2];

            documents[0] = new Resume();
            documents[1] = new Report();
            // Display document pages
            foreach (Document document in documents)
            {
                Console.WriteLine("\n" + document.GetType().Name + "--");
                foreach (Page page in document.Pages)
                {
                    Console.WriteLine(" " + page.GetType().Name);
                }
            }
            // Wait for user
            Console.ReadKey();
        }
    }
    // abstract Product -> defines the interface of objects the factory method creates
    abstract class Page { }
    // ConcreteProduct  
    class SkillsPage : Page { }
    // ConcreteProduct  
    class EducationPage : Page { }
    // ConcreteProduct  
    class ExperiencePage : Page { }
    // ConcreteProduct  
    class IntroductionPage : Page { }
    // ConcreteProduct  
    class ResultsPage : Page { }
    // ConcreteProduct  
    class ConclusionPage : Page {}
    // ConcreteProduct  
    class BibliographyPage : Page { }
    // ConcreteProduct  
    class SummaryPage : Page { }
    // Creator 
    abstract class Document
    {
        private List<Page> _pages = new List<Page>();

        public Document()
        {
            this.CreatePages();
        }

        public List<Page> Pages {
            get { return _pages;  }
        }

        public abstract void CreatePages();
    }
    // ConcreteCreator  
    class Resume : Document
    {
        public override void CreatePages()
        {
            Pages.Add(new SkillsPage());
            Pages.Add(new EducationPage());
            Pages.Add(new ExperiencePage());
        }
    }
    // ConcreteCreator  
    class Report : Document
    {
        // Factory Method implementation
        public override void CreatePages()
        {
            Pages.Add(new IntroductionPage());
            Pages.Add(new ResultsPage());
            Pages.Add(new ConclusionPage());
            Pages.Add(new SummaryPage());
            Pages.Add(new BibliographyPage());
        }
    }

}
