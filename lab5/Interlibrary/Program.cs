using System;
using System.Collections.Generic;

namespace Interlibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Receiver receiver = new Receiver(true, true, true);

            LibraryHandler children_lib_handler = new ChildrenLibraryHandler();
            LibraryHandler nation_lib_handler = new NationalUkraineLibraryHandler();
            LibraryHandler science_lib_handler = new ScientificAndTechnologicalLibraryHandler();

            children_lib_handler.Successor = nation_lib_handler;
            nation_lib_handler.Successor = science_lib_handler;;

            children_lib_handler.Handle(receiver, "Nightwork");
            children_lib_handler.Handle(receiver, "Harry Potter");
            children_lib_handler.Handle(receiver, "A Brief History of Time");

            // Console.Read();
        }
    }
    class Book 
    {
        public string name;
        public string author;
        public Book(string bookname, string bookauthor)
        {
            this.name = bookname;
            this.author = bookauthor;
        }
    }

    class Receiver
    {
        public bool NationalUkraineLibrary { get; set; }
        // перевод через PayPal
        public bool ScientificAndTechnologicalLibrary { get; set; }
        public bool ChildrenLibrary { get; set;}
        public Receiver(bool nationalukraine, bool scientifictechnological, bool children)
        {
            NationalUkraineLibrary = nationalukraine;
            ScientificAndTechnologicalLibrary = scientifictechnological;
            ChildrenLibrary = children;
        }
    }
    abstract class LibraryHandler
    {
        public LibraryHandler Successor { get; set; }
        public abstract void Handle(Receiver receiver, string bookname);
    }

    class ChildrenLibraryHandler : LibraryHandler
    {
        List<Book> _books = new List<Book>()
        {
            new Book("Polianna", "Eleonor Porter"),
            new Book("The Children of Captain Grant", "Jules Verne"),
            new Book("Peter Pan", "James Barrie"),
            new Book("Harry Potter", "Joanne Rowling"),
        };
        public override void Handle(Receiver receiver, string bookname)
        {
            Console.WriteLine("Searching your book in National Library of Ukraine for Children...");
            Book bk = this._books.Find(p => p.name == bookname);
            if (receiver.ChildrenLibrary == true && bk != null)
            {
                Console.WriteLine("\nYour book found in National Library of Ukraine for Children!");
                Console.Write("Name: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(bk.name);
                Console.ResetColor();
                Console.Write("Author: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(bk.author);
                Console.ResetColor();
                Console.WriteLine("----------------");
            }
            else if (Successor != null)
            {
                Successor.Handle(receiver, bookname);
            }
        }
    }

    class NationalUkraineLibraryHandler : LibraryHandler
    {
        List<Book> _books = new List<Book>()
        {
            new Book("To Kill a Mockingbird", "Harper Lee"),
            new Book("The Shining", "Stephen King"),
            new Book("The Night in Lisbon", "Erich Maria Remarque"),
            new Book("Nightwork", "Irwin Shaw"),
        };
        public override void Handle(Receiver receiver, string bookname)
        {
            Console.WriteLine("Searching your book in National Ukraine Library...");
            Book bk = this._books.Find(p => p.name == bookname);
            if (receiver.NationalUkraineLibrary == true && bk != null)
            {
                Console.WriteLine("\nYour book found in National Ukraine Library!");
                Console.Write("Name: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(bk.name);
                Console.ResetColor();
                Console.Write("Author: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(bk.author);
                Console.ResetColor();
                Console.WriteLine("----------------");
            }
            else if (Successor != null)
            {
                Successor.Handle(receiver, bookname);
            }
        }
    }
    class ScientificAndTechnologicalLibraryHandler : LibraryHandler
    {
        List<Book> _books = new List<Book>()
        {
            new Book("Surely You're Joking, Mr. Feynman!", "Richard Feynman"),
            new Book("A Brief History of Time", "Stephen Hawking"),
            new Book("Cosmos", "Carl Sagan"),
            new Book("The Selfish Gene", "Richard Dawkins"),
        };
        public override void Handle(Receiver receiver, string bookname)
        {
            Console.WriteLine("Searching your book in Scientific and Technological Library...");
            Book bk = this._books.Find(p => p.name == bookname);
            if (receiver.ScientificAndTechnologicalLibrary == true && bk != null)
            {
                Console.WriteLine("\nYour book had found in Scientific and Technological Library!");
                Console.Write("Name: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(bk.name);
                Console.ResetColor();
                Console.Write("Author: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(bk.author);
                Console.ResetColor();
                Console.WriteLine("----------------");
            }
            else if (Successor != null)
            {
                Successor.Handle(receiver, bookname);
            }
        }
    }
}
