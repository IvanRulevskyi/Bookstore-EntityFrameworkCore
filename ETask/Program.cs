using ClassLibrary.Services;


MenuBookStore menuBookStore = new MenuBookStore{};


    while (true)
    {
        Console.WriteLine("Вас приветсвует: Книжный магазин");
        Console.WriteLine();
        Console.WriteLine("Нажмите 1: Для Входа в учетную запись");
        Console.WriteLine("Нажмите 2: Для создании учетной записи");
        Console.WriteLine("Нажмите 0: Для Выхода с программы");
        Console.WriteLine();
        Console.Write("Сделайте выбор: ");
        int.TryParse(Console.ReadLine(), out int choice);
        if (choice == 0)
        {
            break;
        }
        if (choice == 1)
        {
            menuBookStore.AdminLogin();
        }
        if (choice == 2)
        {
            menuBookStore.RegisterUser();
        }

    }