using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocNet.PLL.Views;

internal class MainView
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
