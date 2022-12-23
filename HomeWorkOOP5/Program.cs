namespace HomeWorkOOP5
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
            
            Reader reader = new("Аноним");
            Storage storage = new();

            Console.WriteLine("Здравствуйте, Как Вас зовут?: ");
            reader.SetName();

            while (isProgramOn)
            {
                Console.Clear();
                Console.WriteLine($"Что Вас интересует, {reader.Name}? ");
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
                        storage.AddBook();
                        break;
                    case CommandShowAllBooks:
                        storage.ShowAll();
                        break;
                    case CommandDeleteBook:
                        storage.Remove();
                        break;
                    case CommandShowBooksByParametr:
                        storage.ShowByParametrs();
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
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Genre { get; private set; }
        public int Year { get; private set; }
        public string Author { get; private set; }

        public Books(int id, string title, string author, string genre, int year)
        {
            Id = id;
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;
        }
    }

    class Storage
    {
        private int _lastId = 1;
        private string _title = "1";
        private string _author = "2";
        private string _genre = "3";
        private string _year = "4";

        private List<Books> _books  = new();

        public Storage()
        {
            _books.Add(new Books(1, "На Западном фронте без перемен", "Эрих Мария Ремарк", "Роман", 1929));
        }

        private void ShowByTitle(string? userInput)
        {
            foreach (Books book in _books)
            {
                if (userInput == book.Title)
                {
                    Console.WriteLine($"Id: {book.Id}, Название: {book.Title}, Автор: {book.Author}, Жанр: {book.Genre}, Год: {book.Year}");
                }
            }

            Console.ReadKey();
        }

        private void ShowByAuthor(string? userInput)
        {
            foreach (Books book in _books)
            {
                if (userInput == book.Author)
                {
                    Console.WriteLine($"Id: {book.Id}, Название: {book.Title}, Автор: {book.Author}, Жанр: {book.Genre}, Год: {book.Year}");
                }
            }

            Console.ReadKey();
        }

        private void ShowByGenre(string? userInput)
        {
            foreach (Books book in _books)
            {
                if (userInput == book.Genre)
                {
                    Console.WriteLine($"Id: {book.Id}, Название: {book.Title}, Автор: {book.Author}, Жанр: {book.Genre}, Год: {book.Year}");
                }
            }

            Console.ReadKey();
        }

        private void ShowByYear(string? userInput)
        {
            bool isNumber = int.TryParse(userInput, out int userInputNumberForSearch);

            if (isNumber)
            {
                foreach (Books book in _books)
                {
                    if (userInputNumberForSearch == book.Year)
                    {
                        Console.WriteLine($"Id: {book.Id}, Название: {book.Title}, Автор: {book.Author}, Жанр: {book.Genre}, Год: {book.Year}");
                    }
                }

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ошибка, нужно ввести число.");
            }
        }

        private bool TryGetBook(out Books? books)
        {
            books = null;

            Console.WriteLine("Введите id книги: ");

            if (int.TryParse(Console.ReadLine(), out int number))
            {
                for (int i = 0; i < _books.Count; i++)
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

            }

            return false;
        }

        public void AddBook()
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

            bool isNumber = int.TryParse(Console.ReadLine(), out int number);

            if (isNumber)
            {
                year = number;
                _books.Add(new Books(id, title, author, genre, year));
            }
            else
            {
                Console.WriteLine("Нужно ввести число.");
                Console.ReadKey();
            }
        }

        public void ShowAll()
        {
            Console.Clear();
            Console.WriteLine("Книги: ");

            for (int i = 0; i < _books.Count; i++)
            {
                Console.WriteLine($"Id: {_books[i].Id}, Название: {_books[i].Title}, Автор: {_books[i].Author}, Жанр: {_books[i].Genre}, Год: {_books[i].Year}");
            }

            Console.ReadKey();
        }

        public void Remove()
        {
            if(TryGetBook(out Books? book))
            {
                _books.Remove(book);
                Console.WriteLine("Книга удалена");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ошибка");
            }
        }

        public void ShowByParametrs()
        {
            Console.WriteLine($"Выберите параметр: \n{_title}Название\n{_author}Автор\n{_genre}Жанр\n{_year}Год");

            string? userInput = Console.ReadLine();
   
            Console.WriteLine("Введите значение: ");

            string? userInputForSearch = Console.ReadLine();

            if (userInput == _title)
            {
                ShowByTitle(userInputForSearch);
            }
            else if(userInput == _author)
            {
                ShowByAuthor(userInputForSearch);
            }
            else if (userInput == _genre)
            {
                ShowByGenre(userInputForSearch);
            }
            else if (userInput == _year)
            {
                ShowByYear(userInputForSearch);
            }
        }
    }

    class Reader
    {
        public string Name { get; private set; } 
        
        public Reader(string name)
        {
            Name = name;
        }

        public void SetName()
        {
            Name = Console.ReadLine();
        }
    }
}