using ClassLibrary.Data;
using ClassLibrary.models;
using Microsoft.EntityFrameworkCore;
namespace ClassLibrary.data;

public class BookRepository
{

    public void AddBook(string title, string publisher, int pages, int year, decimal costPrice , decimal sellingPrice, int genreId, int authorId)
    {
        using (ApplicationContext context = new ApplicationContext())
        {
            Book book = new()
            {
                Title = title,
                Publisher = publisher,
                Pages = pages,
                Year = year,
                CostPrice = costPrice,
                SellingPrice = sellingPrice,
                GenreId = genreId,
                AuthorId = authorId
            };

            context.Books.Add(book);
            context.SaveChanges();
        }
    }

    public void DeleteBook(string bookName)
    {
        using (ApplicationContext context = new ApplicationContext())
        {
            Book bookToDelete = context.Books.FirstOrDefault(b => b.Title == bookName);
            if (bookToDelete is not null)
            {
                context.Books.Remove(bookToDelete);
                context.SaveChanges();
                Console.WriteLine();
                Console.WriteLine($"Книга {bookToDelete} успешно удалена!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Такой книги не существует");
            }
        }
    }

    public void UpdateBook(string bookName)
    {
        using (ApplicationContext context = new ApplicationContext())
        {
            Book bookToUpdate = context.Books.FirstOrDefault(b => b.Title == bookName);
            if (bookToUpdate is not null)
            {
                Console.WriteLine();
                Console.WriteLine("Нажмите 1: для изменения Названия книги");
                Console.WriteLine("Нажмите 2: для изменения Издателя книги");
                Console.WriteLine("Нажмите 3: для изменения Количества страниц книги");
                Console.WriteLine("Нажмите 4: для изменения Года выпуска");
                Console.WriteLine("Нажмите 5: для изменения Базовой цены");
                Console.WriteLine("Нажмите 6: для изменения Продажной цены");
                Console.WriteLine("Нажмите 7: для изменения Автора");
                Console.WriteLine("Нажмите 8: для изменения Жанра");
                Console.WriteLine("Нажмите 9: для запуска Ценовой акции");

                int.TryParse(Console.ReadLine(), out int choiceUpdate);
                if (choiceUpdate == 1)
                {
                    Console.Write("Введите новое название книги: ");
                    string newTitleBook = Console.ReadLine().ToLower();
                    bookToUpdate.Title = newTitleBook;
                    context.Update(bookToUpdate);
                    context.SaveChanges();
                    Console.WriteLine();
                    Console.WriteLine("Изменения успешно сохранены!");
                }
                if (choiceUpdate == 2)
                {
                    Console.Write("Введите новое издательство: ");
                    string newPublisherBook = Console.ReadLine().ToLower();
                    bookToUpdate.Publisher = newPublisherBook;
                    context.Update(bookToUpdate);
                    context.SaveChanges();
                    Console.WriteLine();
                    Console.WriteLine("Изменения успешно сохранены!");

                }
                if (choiceUpdate == 3)
                {
                    Console.Write("Введите новое количество страниц: ");
                    int.TryParse(Console.ReadLine(), out int newPages);
                    bookToUpdate.Pages = newPages;
                    context.Update(bookToUpdate);
                    context.SaveChanges();
                    Console.WriteLine();
                    Console.WriteLine("Изменения успешно сохранены!");
                }
                if (choiceUpdate == 4)
                {
                    Console.Write("Введите новый год написания книги: ");
                    int.TryParse(Console.ReadLine(), out int newYear);
                    bookToUpdate.Year = newYear;
                    context.Update(bookToUpdate);
                    context.SaveChanges();
                    Console.WriteLine();
                    Console.WriteLine("Изменения успешно сохранены!");
                }
                if (choiceUpdate == 5)
                {
                    Console.Write("Введите новую базовую цену: ");
                    decimal.TryParse(Console.ReadLine(), out decimal newCostPrice);
                    bookToUpdate.CostPrice = newCostPrice;
                    context.Update(bookToUpdate);
                    context.SaveChanges();
                    Console.WriteLine();
                    Console.WriteLine("Изменения успешно сохранены!");
                }
                if (choiceUpdate == 6)
                {
                    Console.Write("Введите новую цену для продажи: ");
                    decimal.TryParse(Console.ReadLine(), out decimal newSellingPrice);
                    bookToUpdate.SellingPrice = newSellingPrice;
                    context.Update(bookToUpdate);
                    context.SaveChanges();
                    Console.WriteLine();
                    Console.WriteLine("Изменения успешно сохранены!");
                }
                if (choiceUpdate == 7)
                {
                    Console.Write("Введите нового автора: ");
                    string newAuthorBook = Console.ReadLine().ToLower();
                    Author authorUpdate = context.Authors.FirstOrDefault(a => a.Name == newAuthorBook);
                    if (authorUpdate is not null)
                    {
                        bookToUpdate.AuthorId = authorUpdate.Id;
                        context.Update(bookToUpdate);
                        context.SaveChanges();
                         Console.WriteLine();
                        Console.WriteLine("Изменения успешно сохранены!");
                    }
                    else
                    {
                        int authorId;
                        var newAuthor = new Author { Name = newAuthorBook };
                        context.Authors.Add(newAuthor);
                        context.SaveChanges();
                        authorId = newAuthor.Id;
                        context.SaveChanges();

                        bookToUpdate.AuthorId = authorId;
                        context.Update(bookToUpdate);
                        context.SaveChanges();
                        Console.WriteLine();
                        Console.WriteLine("Изменения успешно сохранены!");
                    }
                }
                if (choiceUpdate == 8)
                {
                    Console.Write("Введите новый жанр: ");
                    string newGenreBook = Console.ReadLine().ToLower();
                    Genre genreUpdate = context.Genres.FirstOrDefault(g => g.Name == newGenreBook);
                    if (genreUpdate is not null)
                    {
                        bookToUpdate.GenreId = genreUpdate.Id;
                         context.Update(bookToUpdate);
                        context.SaveChanges();
                        Console.WriteLine();
                        Console.WriteLine("Изменения успешно сохранены!");
                    }
                    else
                    {
                        int genreId;
                        var newGenre = new Genre { Name = newGenreBook };
                        context.Genres.Add(newGenre);
                        context.SaveChanges();
                        genreId = newGenre.Id;
                        context.SaveChanges();

                        bookToUpdate.GenreId = genreId;
                        context.Update(bookToUpdate);
                        context.SaveChanges();
                        Console.WriteLine();
                        Console.WriteLine("Изменения успешно сохранены!");
                    }
                }
                if (choiceUpdate == 9)
                {
                    Console.Write("Введите процент скидки на книгу: ");
                    int.TryParse(Console.ReadLine(), out int saleValue);
                    bookToUpdate.DiscountPercentage = saleValue;

                    Console.Write("Введите Год начала акции: ");
                    int.TryParse(Console.ReadLine(), out int yearStartSale);
                    Console.Write("Введите Месяц начала акции: ");
                    int.TryParse(Console.ReadLine(), out int monthStartSale);
                    Console.Write("Введите День начала акции: ");
                    int.TryParse(Console.ReadLine(), out int dayStartSale);

                    Console.Write("Введите Год окончания акции: ");
                    int.TryParse(Console.ReadLine(), out int yearEndSale);
                    Console.Write("Введите Месяц окончания акции: ");
                    int.TryParse(Console.ReadLine(), out int monthEndSale);
                    Console.Write("Введите День окончания акции: ");
                    int.TryParse(Console.ReadLine(), out int dayEndSale);

                    bookToUpdate.PromotionStartDate = new DateTime(yearStartSale, monthStartSale, dayStartSale);
                    bookToUpdate.PromotionEndDate = new DateTime(yearEndSale, monthEndSale, dayEndSale);

                    context.Update(bookToUpdate);
                    context.SaveChanges();
                    Console.WriteLine();
                    Console.WriteLine("Изменения успешно сохранены!");

                }
            }     
                
        }
    }

    public void SearchfForABook(string searchBook)
    {
        using (ApplicationContext context = new ApplicationContext())
        {
            if (context.Books.Any(b => b.Title == searchBook) == true)
            {
                var BookInfo = context.Books
                    .Include(b =>b.Author)
                    .Include(b => b.Genre)
                    .Where(b => b.Title == searchBook)
                    .Select(b => new
                    {
                        b.Title,
                        b.Publisher,
                        b.Pages,
                        b.Year,
                        Genre = b.Genre.Name,
                        Author = b.Author.Name

                    }).ToList();

                foreach (var item in BookInfo)
                {
                    Console.WriteLine($"Название книги: {item.Title}");
                    Console.WriteLine($"Автор книги: {item.Author}");
                    Console.WriteLine($"Жанр книги: {item.Genre}");
                    Console.WriteLine($"Издательство книги: {item.Publisher}");
                    Console.WriteLine($"Год выпуска книги: {item.Year}");
                    Console.WriteLine($"Количество страниц в книге: {item.Pages}");
                }

            }
            else
            {
                Console.WriteLine("Ошибка! Такой книги нет в нашем магазине!");
            }
        }
    }
    public void SearchByAuthor(string authorName)
    {
        using (ApplicationContext context = new ApplicationContext())
        {
            if (context.Authors.Any(a => a.Name == authorName) == true)
            {
                var booksAuthor = context.Authors
                    .Where(a => a.Name == authorName)
                    .SelectMany(a => a.Books.Select(b => new
                    {
                        b.Title,
                        b.Publisher,
                        b.Pages,
                        b.Year,
                        Genre = b.Genre.Name,
                        Author = b.Author.Name
                    })).ToList();
                if (booksAuthor.Any())
                {
                    foreach (var book in booksAuthor)
                    {
                        Console.WriteLine($"Название книги: {book.Title}");
                        Console.WriteLine($"Автор книги: {book.Author}");
                        Console.WriteLine($"Жанр книги: {book.Genre}");
                        Console.WriteLine($"Издательство книги: {book.Publisher}");
                        Console.WriteLine($"Год выпуска книги: {book.Year}");
                        Console.WriteLine($"Количество страниц в книге: {book.Pages}");
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("Ошибка! Такого автора нет в нашем магазине!");
            }
        }
    }

    public void SearchByGenre(string genreName)
    {
        using (ApplicationContext context = new ApplicationContext())
        {
            if (context.Genres.Any(g => g.Name == genreName) == true)
            {
                var booksGenre = context.Genres
                    .SelectMany(g => g.Books.Select(b => new
                    {
                        b.Title,
                        b.Publisher,
                        b.Pages,
                        b.Year,
                        Genre = b.Genre.Name,
                        Author = b.Author.Name
                    })).ToList();

                if (booksGenre.Any())
                {
                    foreach (var book in booksGenre)
                    {
                        Console.WriteLine($"Название книги: {book.Title}");
                        Console.WriteLine($"Автор книги: {book.Author}");
                        Console.WriteLine($"Жанр книги: {book.Genre}");
                        Console.WriteLine($"Издательство книги: {book.Publisher}");
                        Console.WriteLine($"Год выпуска книги: {book.Year}");
                        Console.WriteLine($"Количество страниц в книге: {book.Pages}");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка! У нас нет книг этого автора");
                }
            }
        }
    }

    public void NewItems()
    {
        using (ApplicationContext context = new ApplicationContext())
        {
            var newItems = context.Books
                .OrderByDescending(b => b.Id)
                .Take(3)
                .Select(b => new
                {
                    b.Title,
                    b.Publisher,
                    b.Pages,
                    b.Year,
                    Genre = b.Genre.Name,
                    Author = b.Author.Name
                });
            foreach (var book in newItems)
            {
                Console.WriteLine($"Название книги: {book.Title}");
                Console.WriteLine($"Автор книги: {book.Author}");
                Console.WriteLine($"Жанр книги: {book.Genre}");
                Console.WriteLine($"Издательство книги: {book.Publisher}");
                Console.WriteLine($"Год выпуска книги: {book.Year}");
                Console.WriteLine($"Количество страниц в книге: {book.Pages}");
                Console.WriteLine();
            }
        }
    }

    public void BuyingABook(string buyingBook, string login)
    {
        using (ApplicationContext context = new ApplicationContext())
        {
            Console.Write("Введите количество штук для покупки: ");
            int.TryParse(Console.ReadLine(), out int countBook);
            var bookCountInBookStore = context.Books.Count(b => b.Title == buyingBook);

            var priceBook = context.Books
                .Where(b => b.Title == buyingBook)
                .Select(b => b.SellingPrice)
                .FirstOrDefault();

            var userSale = context.Logins
                .Where(l => l.LoginUser == login)
                .FirstOrDefault();
            
            var genreName = context.Books
                .Where(b => b.Title == buyingBook)
                .Select(b => b.Genre.Name)
                .FirstOrDefault();

            var AuthorName = context.Books
                .Where(b => b.Title == buyingBook)
                .Select(b => b.Author.Name)
                .FirstOrDefault();


            
            if (bookCountInBookStore < countBook)
            {
                Console.WriteLine("Вы заказываете больше чем есть на остатке книг");
                Console.WriteLine($"Книг на остатке - {bookCountInBookStore}");

            }
            if(bookCountInBookStore >= countBook)
            {
                Sale sale = new()
                {
                    Title = buyingBook,
                    Quantity = countBook,
                    UnitPrice = priceBook,
                    TotalPrice = priceBook * countBook,
                    SaleDate = DateTime.Now,
                    UserId = userSale.Id,
                    Genre = genreName,
                    Author = AuthorName
                };
                context.Sales.Add(sale);
                context.SaveChanges();

                var booksToDelete = context.Books
                    .Where(b => b.Title == buyingBook)
                    .Take(countBook)
                    .ToList();
                context.Books.RemoveRange(booksToDelete);
                context.SaveChanges();
                Console.WriteLine($"Вы успешно купили книгу: {buyingBook}");
                Console.WriteLine($"Количество штук: {countBook}");
            }
        }
    }

    public void PopularBooks()
    {
        using (ApplicationContext context = new ApplicationContext())
        {
            Console.WriteLine("Введите по чем вывести по популярности");
            Console.WriteLine("Нажмите 1: по названи книги");
            Console.WriteLine("Нажмите 2: по автору");
            Console.WriteLine("Нажмите 3: по жанру");
            Console.WriteLine();
            Console.Write("Сделайте выбор: ");
            int.TryParse(Console.ReadLine(), out int choice);
            if (choice == 1)
            {
                var popularBooks = context.Sales
                    .GroupBy(s => s.Title)
                    .Select(g => new 
                    {
                        Title = g.Key,
                        Count = g.Sum(s => s.Quantity)
                    })
                    .OrderByDescending(b => b.Count)
                    .ToList(); 

                foreach (var book in popularBooks)
                {
                    Console.WriteLine($"Название: {book.Title}, Количество продаж: {book.Count}");
                }

            }
            if (choice == 2)
            {
                var popularAuthors = context.Sales
                    .GroupBy(s => s.Author)
                    .Select(g => new 
                    {
                        Author = g.Key,
                        Count = g.Sum(s => s.Quantity)
                    })
                    .OrderByDescending(b => b.Count)
                    .ToList(); 


                foreach (var author in popularAuthors)
                {
                    Console.WriteLine($"Автор: {author.Author}, Количество продаж: {author.Count}");
                }

                
            }
            if (choice == 3)
            {
                var popularGenres = context.Sales
                    .GroupBy(s => s.Genre)
                    .Select(g => new 
                    {
                        Genre = g.Key,
                        Count = g.Sum(s => s.Quantity)
                    })
                    .OrderByDescending(b => b.Count)
                    .ToList(); 

                foreach (var genre in popularGenres)
                {
                    Console.WriteLine($"Жанр: {genre.Genre}, Количество продаж: {genre.Count}");
                }

            }
        }
    }
}