using SocNet.BLL.Exceptions;
using SocNet.BLL.Models;
using SocNet.BLL.Services;
using SocNet.PLL.Helpers;

namespace SocNet;

internal class Program
{
    public static UserService userService = new UserService();
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to FB vol.2!");

        while (true)
        {
            Console.WriteLine("Sign in (1):");
            Console.WriteLine("Sign up (2):");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        var authenticationData = new UserAuthenticationData();

                        Console.Write("Your email: ");
                        authenticationData.Email = Console.ReadLine();
                        Console.WriteLine();

                        Console.Write("Your password: ");
                        authenticationData.Password = Console.ReadLine();

                        try
                        {
                            User user = userService.Authenticate(authenticationData);
                            //Console.ForegroundColor = ConsoleColor.Green;
                            //Console.WriteLine($"Success! Welcome to FB vol.2, {user.FirstName}");
                            //Console.ForegroundColor = ConsoleColor.White; // теперь такая конструкция лишняя, она заменена на новую здесь и далее
                            SuccessMessage.Show($"Success! Welcome to FB vol.2, {user.FirstName}");

                            while (true)
                            {
                                Console.WriteLine("Profile (1)");
                                Console.WriteLine("Edit profile (2)");
                                Console.WriteLine("Add a friends (3)");
                                Console.WriteLine("Message (4)");
                                Console.WriteLine("Logout (5)");

                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("My profile");
                                            Console.WriteLine($"My ID: {user.Id}");
                                            Console.WriteLine($"My name: {user.FirstName}");
                                            Console.WriteLine($"My surname: {user.LastName}");
                                            Console.WriteLine($"My Email: {user.Email}");
                                            Console.WriteLine($"My photo link: {user.Photo}");
                                            Console.WriteLine($"My favorite movie: {user.FavoriteMovie}");
                                            Console.WriteLine($"My favorite book: {user.FavoriteBook}");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            break;
                                        }
                                    case "2":
                                        {
                                            Console.Write("New name: ");
                                            user.FirstName = Console.ReadLine();

                                            Console.Write("New surname: ");
                                            user.LastName = Console.ReadLine();

                                            Console.Write("New photo link: ");
                                            user.Photo = Console.ReadLine();

                                            Console.Write("New favorite movie: ");
                                            user.FavoriteMovie = Console.ReadLine();

                                            Console.Write("New favorite book: ");
                                            user.FavoriteBook = Console.ReadLine();

                                            userService.Update(user);

                                            SuccessMessage.Show("Profile were successfully updated");
                                            break;
                                        }
                                }
                            }
                        }
                        catch (WrongPasswordException)
                        {
                            AlertMessage.Show("Wrong password!");
                        }
                        catch (UserNotFoundException)
                        {
                            AlertMessage.Show("User not found!");
                        }
                        break;
                    }
                case "2":
                    {
                        var userRegistrationData = new UserRegistrationData();

                        Console.Write("Enter your name:");
                        userRegistrationData.FirstName = Console.ReadLine();

                        Console.Write("Enter your surname:");
                        userRegistrationData.LastName = Console.ReadLine();

                        Console.Write("Enter your password:");
                        userRegistrationData.Password = Console.ReadLine();

                        Console.Write("Enter your email:");
                        userRegistrationData.Email = Console.ReadLine();

                        try
                        {
                            userService.Register(userRegistrationData);
                            SuccessMessage.Show("Success! Now you can sign in");
                        }
                        catch (ArgumentNullException)
                        {
                            AlertMessage.Show("Some fields were filled incorrectly");
                        }
                        catch (Exception ex)
                        {
                            AlertMessage.Show($"Something went wrong - {ex}");
                        }
                        break;
                    }
            }
        }
    }
}
