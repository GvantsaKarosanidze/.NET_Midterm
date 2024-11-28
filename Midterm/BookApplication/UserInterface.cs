namespace BookApplication
{
    class UserInterface
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is BookManager Application");

            // create log file
            String path = "C:\\Users\\Greench\\Desktop";
            DirectoryInfo parent = new DirectoryInfo(path);
            DirectoryInfo child = parent.CreateSubdirectory("BookApplicationLogs");
            DirectoryInfo folderByDate = child.CreateSubdirectory(DateTime.Now.ToString("dd-MM-yyyy-HH.mm.ss"));
            FileInfo newFile = new FileInfo(Path.Combine(folderByDate.FullName, "log.txt"));
            if (!newFile.Exists)
            {
                using (StreamWriter sw = newFile.CreateText())
                {
                    sw.WriteLine(DateTime.Now.ToString() + " Log file created");
                }
            }

            BookManager bookManager = new BookManager();

            while (true)
            {
                Console.WriteLine("Type appropriate number or something else to quit");
                Console.WriteLine("1. Add book");
                Console.WriteLine("2. Display all books");
                Console.WriteLine("3. Search book by title");
                Console.WriteLine("4. Search book by author");
                Console.WriteLine("5. Search book by year of publication");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Title:");
                        string title = Console.ReadLine();
                        Console.WriteLine("Author:");
                        string author = Console.ReadLine();
                        Console.WriteLine("Year of publication:");
                        string year = Console.ReadLine();
                        try
                        {
                            bookManager.AddBook(new Book(title, author, year));
                            CreateLog(newFile, "Add book: Title " + title + "; Author: " + author + "; Year of publication: " + year);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            CreateLog(newFile, ex.ToString());
                        }
                        break;
                    case "2":
                        bookManager.DisplayAllBooks();
                        CreateLog(newFile, "Display all books");
                        break;
                    case "3":
                        Console.WriteLine("Title:");
                        string searchTitle = Console.ReadLine();
                        DisplayList(bookManager.SearchBookByTitle(searchTitle));
                        CreateLog(newFile, "Search book by title: " + searchTitle);
                        break;
                    case "4":
                        Console.WriteLine("Author:");
                        string searchAuthor = Console.ReadLine();
                        DisplayList(bookManager.SearchBookByAuthor(searchAuthor));
                        CreateLog(newFile, "Search book by author: " + searchAuthor);
                        break;
                    case "5":
                        Console.WriteLine("Year of publication:");
                        string searchYear = Console.ReadLine();
                        DisplayList(bookManager.SearchBookByYear(searchYear));
                        CreateLog(newFile, "Search book by year of publication: " + searchYear);
                        break;
                    default:
                        CreateLog(newFile, "Quit");
                        return;
                }
            }
        }

        static void CreateLog(FileInfo newFile, string log)
        {
            using (StreamWriter sw = newFile.AppendText())
            {
                sw.WriteLine(DateTime.Now.ToString() + " " + log);
            }
        }

        static void DisplayList(List<Book> list)
        {
            if (list.Count == 0)
                Console.WriteLine("Nothing found");
            else
                list.ForEach(book => Console.WriteLine(book));
        }
    }
}
