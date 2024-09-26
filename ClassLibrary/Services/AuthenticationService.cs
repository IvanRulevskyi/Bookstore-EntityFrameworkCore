using ClassLibrary.Data;
using ClassLibrary.models;

namespace ClassLibrary.Services;

public class AuthenticationService
{
    public void AddUser(string loginUser, string passwordUser)
    {
        using (ApplicationContext context = new ApplicationContext())
        {
            if (context.Logins.Any(u =>u.LoginUser == loginUser) == false)
            {
                Login login = new()
                {
                    LoginUser = loginUser,
                    PasswordUser = passwordUser
                };

                context.Add(login);
                context.SaveChanges();
                Console.WriteLine("Вы успешно зарегестрировались в Книжном магазине!");
            }
            else
            {
                Console.WriteLine("Пользователь с таким именем существует!");
            }
        }
    }

    public bool ValidatePassword(string loginUser, string passwordUser)
    {
        using (ApplicationContext context = new ApplicationContext())
        {
            return context.Logins
                .Any(t => t.LoginUser == loginUser && t.PasswordUser == passwordUser);
        }
    }
}
