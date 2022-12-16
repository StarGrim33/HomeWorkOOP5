﻿namespace HomeWorkOOP5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddBook = "1";
            const string CommandShowAllBooks = "2";
            const string CommandDeleteBook = "3";
            const string CommandShowBooksByParametr = "4";
            const string CommandExit = "5";

            bool isProgramOn = true;

            Reader reader = new("Влад");
            Storage storage = new();

            while (isProgramOn)
            {
                Console.Clear();
                Console.WriteLine($"Меню: ");
                Console.WriteLine($"{CommandAddBook}-Добавить книгу");
                Console.WriteLine($"{CommandShowAllBooks}-Показать книги");
                Console.WriteLine($"{CommandDeleteBook}-Удалить книгу");
                Console.WriteLine($"{CommandShowBooksByParametr}-Показать книги по параметру");
                Console.WriteLine($"{CommandExit}-Выйти из программы");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddBook:
                        reader.AddBook(storage);
                        break;
                    case CommandShowAllBooks:
                        storage.ShowAllBooks();
                        break;
                    case CommandDeleteBook:
                        storage.RemoveBook();
                        break;
                    case CommandShowBooksByParametr:

                        break;
                    case CommandExit:
                        isProgramOn = false;
                        break;
                }
            }
        }
    }

    class Books
    {
        public Books(int id, string title, string author, string genre, int year)
        {
            Id = id;
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Genre { get; private set; }
        public int Year { get; private set; }
        public string Author { get; private set; }
    }

    class Storage
    {
        public List<Books> _books { get; private set; } = new List<Books> { new Books(1, "На Западном фронте без перемен", "Эрих Мария Ремарк", "Роман", 1929) };

        public void ShowAllBooks()
        {
            Console.Clear();
            Console.WriteLine("Книги: ");

            for (int i = 0; i < _books.Count; i++)
            {
                Console.WriteLine($"Id: {_books[i].Id}, Название: {_books[i].Title}, Автор: {_books[i].Author}, Жанр: {_books[i].Genre}, Год: {_books[i].Year}");
            }

            Console.ReadKey();
        }

        public bool TryGetBook(out Books? books)
        {
            books = null;

            Console.WriteLine("Введите id книги: ");

            if (int.TryParse(Console.ReadLine(), out int number))
            {
                for(int i = 0; i < _books.Count; i++)
                {
                    if (_books[i].Id == number)
                    {
                        books = _books[i];
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Книга не найдена");
                        return false;
                    }
                }
                return false;
            }
            else
            {
                books = null;
                Console.WriteLine("Ошибка");
                return false;
            }
        }
        
        public void RemoveBook()
        {
            if(TryGetBook(out Books? books))
            {
                _books.Remove(books);
                Console.WriteLine("Книга удалена");
            }
            else
            {
                Console.WriteLine("Ошибка");
            }
        }

        public void 
    }

    class Reader
    {
        public Reader(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        private int _lastId = 1;

        public void AddBook(Storage storage)
        {
            int id = ++_lastId;
            string? title;
            string? author;
            string? genre;
            int year;

            Console.WriteLine("Введите название книги: ");
            title = Console.ReadLine();
            Console.WriteLine("Введите автора: ");
            author = Console.ReadLine();
            Console.WriteLine("Введите жанр: ");
            genre = Console.ReadLine();
            Console.WriteLine("Введите год выхода книги: ");
            year = Convert.ToInt32(Console.ReadLine());

            storage._books.Add(new Books(id, title, author, genre, year));
        }
    }
}