using ClassLibrary.models;
using ClassLibrary.Data;
using ClassLibrary.data;

namespace ClassLibrary.Services;

public class MenuBookStore
{
    public void RegisterUser()
    {
        Console.Write("Введите логин: ");
        string? login = Console.ReadLine().ToLower();
        Console.Write("Введите пароль: ");
        string? password = Console.ReadLine().ToLower();

        if (login == "admin" && password == "admin")
        {
            Console.WriteLine();
            Console.WriteLine("Логин и Пароль уже существует !!!");
        }
        else
        {
            AuthenticationService authenticationService = new AuthenticationService{};
            authenticationService.AddUser(login, password);
        }
    }



    public void AdminLogin()
    {
        Console.Write("Введите логин: ");
        string? login = Console.ReadLine();
        Console.Write("Введите пароль: ");
        string? password = Console.ReadLine();  
        AuthenticationService authenticationService = new AuthenticationService{};
        while (true)
        {
            //For Admin
            if (login == "admin" && password == "admin")
            {
                Console.WriteLine("Вы успешно вошли в учетную запись АДМИНИСТРАТОРА!");
                Console.WriteLine();
                Console.WriteLine("Нажмите 1: для добавления книги");
                Console.WriteLine("Нажмите 2: для удаления книги книги");
                Console.WriteLine("Нажмите 3: для редактирования книги");
                Console.WriteLine("Нажмите 0: выхода в предыдущее меню");
                Console.WriteLine();
                Console.Write("Сделайте выбор: ");
                int.TryParse(Console.ReadLine(), out int newChoice);

                if (newChoice == 0)
                {
                    break;
                }
                if (newChoice == 1)
                {
                    BookRepository bookRepository = new BookRepository();
                    using (var context = new ApplicationContext())
                    {
                        //add Genre
                        Console.Write("Введите жанр книги: ");
                        string GenreName = Console.ReadLine().ToLower();

                        var existingGenre = context.Genres
                            .FirstOrDefault(g => g.Name == GenreName);

                        int genreId;

                        if (existingGenre != null)
                        {
                                genreId = existingGenre.Id;
                        }
                        else
                        {
                            var newGenre = new Genre { Name = GenreName };
                            context.Genres.Add(newGenre);
                            context.SaveChanges();
                            genreId = newGenre.Id;
                        }
                        context.SaveChanges();

                        //add Author
                        Console.Write("Введите Имя автора: ");
                        string authorName = Console.ReadLine().ToLower();

                        var existingAuthor = context.Authors
                            .FirstOrDefault(a => a.Name == authorName);

                        int authorId;

                        if (existingAuthor != null)
                        {
                                authorId = existingAuthor.Id;
                        }
                        else
                        {
                            var newAuthor = new Author { Name = authorName };
                            context.Authors.Add(newAuthor);
                            context.SaveChanges();
                            authorId = newAuthor.Id;
                        }
                        context.SaveChanges();

                        Console.Write("Введите название книги: ");
                        string bookName = Console.ReadLine().ToLower();
                        Console.Write("Введите издательсво книги: ");
                        string publisherName = Console.ReadLine().ToLower();
                        Console.Write("Введите количество страниц в книге: ");
                        int.TryParse(Console.ReadLine(), out int pages);
                        Console.Write("Введите год издательства книги: ");
                        int.TryParse(Console.ReadLine(), out int year);
                        Console.Write("Введите себестоимость книги: ");
                        decimal.TryParse(Console.ReadLine(), out decimal costPrice);
                        Console.Write("Введите продажную цену книги: ");
                        decimal.TryParse(Console.ReadLine(), out decimal sellingPrice);

                        bookRepository.AddBook(bookName, publisherName, pages, year, costPrice, sellingPrice, genreId, authorId);
                        Console.WriteLine();
                        Console.WriteLine($"Книга {bookName} успешно добавлена!");
                        Console.WriteLine();
                    }
                }
                if (newChoice == 2)
                {
                    // Delete Book
                    BookRepository bookRepository = new BookRepository();
                    using (ApplicationContext context = new ApplicationContext())
                    {
                        Console.Write("Введите название книги для удаления: ");
                        string deleteBook = Console.ReadLine().ToLower();
                        bookRepository.DeleteBook(deleteBook);
                    }
                }
                if (newChoice == 3)
                {
                    //Update book
                    Console.Write("Введите название книги для поиска : ");
                    string UpdateBook = Console.ReadLine().ToLower();
                    BookRepository bookRepository = new BookRepository();
                    bookRepository.UpdateBook(UpdateBook);
                }
            }
            //For User
            if (authenticationService.ValidatePassword(login, password) == true)
            {
                Console.WriteLine("Вы успешно вошли в учетную запись ПОЛЬЗОВАТЕЛЯ!");
                Console.WriteLine();
                Console.WriteLine("Нажмите 1: для поиска книги по названию");
                Console.WriteLine("Нажмите 2: для поиска книг по автору");
                Console.WriteLine("Нажмите 3: для поиска книг по жанру");
                Console.WriteLine("Нажмите 4: для просмотра новинок");
                Console.WriteLine("Нажмите 5: для покупки книги");
                Console.WriteLine("Нажмите 6: для просмотра популярности книг");
                Console.WriteLine("Нажмите 0: выхода в предыдущее меню");
                Console.WriteLine();
                Console.Write("Сделайте выбор: ");
                int.TryParse(Console.ReadLine(), out int newChoice);
                if (newChoice == 0)
                {
                    break;
                }
                if (newChoice == 1)
                {
                    //Search Book
                    Console.Write("Введите название книги: ");
                    string searchBook = Console.ReadLine();
                    BookRepository bookRepository = new BookRepository();
                    bookRepository.SearchfForABook(searchBook);
                }
                if (newChoice == 2)
                {
                    //Search by author
                    Console.Write("Введите имя автора: ");
                    string searchByAuthor = Console.ReadLine();
                    BookRepository bookRepository = new BookRepository();
                    bookRepository.SearchByAuthor(searchByAuthor);
                }
                if (newChoice == 3)
                {
                    //Search by genre
                    Console.Write("Введите жанр книги: ");
                    string searchByGenre = Console.ReadLine();
                    BookRepository bookRepository = new BookRepository();
                    bookRepository.SearchByGenre(searchByGenre);
                }
                if (newChoice == 4)
                {
                    //New items
                    BookRepository bookRepository = new BookRepository();
                    Console.WriteLine("Топ 3 новых поступления");
                    Console.WriteLine();
                    bookRepository.NewItems();
                }
                if (newChoice == 5)
                {
                    //buying a book
                    Console.Write("Введите название книги для покупки: ");
                    string buyingBook = Console.ReadLine();
                    BookRepository bookRepository = new BookRepository();
                    bookRepository.BuyingABook(buyingBook, login);
                }
                if (newChoice == 6)
                {
                    // popular books
                    BookRepository bookRepository = new BookRepository();
                    bookRepository.PopularBooks();


                }
            }
            else
            {
                Console.WriteLine("Пользователь не найден! Для начала надо ЗАРЕГЕСТРИРОВАТЬСЯ!");
                Console.WriteLine();
                return;
            }
        }
    }
}
