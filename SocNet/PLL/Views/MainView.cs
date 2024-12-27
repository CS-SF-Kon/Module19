namespace SocNet.PLL.Views;

/// <summary>
/// Оформлюшка для приветственного "окна"
/// </summary>
public class MainView
{
    public void Show()
    {
        Console.WriteLine("Welcome to FB vol.2!");
        Console.WriteLine("Sign in (1):");
        Console.WriteLine("Sign up (2):");

        switch (Console.ReadLine())
        {
            case "1":
                {
                    Program.authenticationView.Show();
                    break;
                }
            case "2":
                {
                    Program.registrationView.Show();
                    break;
                }
        }
    }
}
