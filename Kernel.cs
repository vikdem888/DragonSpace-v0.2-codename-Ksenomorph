using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Sys = Cosmos.System;
using System.Threading.Tasks;
using System.Diagnostics;
using Cosmos.System.Graphics;
using Cosmos.Common;
using System.Drawing;
using Cosmos.Core.IOGroup;
using Point = System.Drawing.Point;

namespace CSharpKernel1
{
    public class Kernel : Sys.Kernel
    {
        Canvas canvas;
        protected override void BeforeRun()
        {
            Console.WriteLine("Loading DragonSpace");
            Console.Clear();
            Console.WriteLine("Welcome to DragonSpace! Type \"help\" for the list of commands");
        }

        protected override void Run()
        {
            Console.Write("DragonSpace> ");
            string command = Console.ReadLine();
            switch (command) {
                case "off":
                    Console.WriteLine("Shutting down DragonSpace");
                    Cosmos.System.Power.Shutdown();
                    break;
                case "reboot":
                    Console.Clear();
                    Console.WriteLine("Reboot DragonSpace");
                    Cosmos.System.Power.Reboot();
                    break;
                case "crash":
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Clear();
                    Console.WriteLine("A critical error occurred and DragonSpace shut down to prevent further errors.");
                    Console.WriteLine("Error: CMD_CRASH");
                    Console.WriteLine("");
                    Console.WriteLine("If you see this error for the first time, just restart your computer. ");
                    Console.WriteLine("If not, restore the system via the installer, ");
                    Console.WriteLine("or check if all the files are exists via the command: checksys /a");
                    Console.WriteLine("");
                    Console.WriteLine("Technical information:");
                    Console.WriteLine("0x000000001 (0x00000032, 0x0000043, 0x0000007x)");
                    Console.WriteLine("Press any key to reboot");
                    Console.ReadKey();
                    Cosmos.System.Power.Reboot();
                    break;
                case "help":
                    Console.WriteLine("help - list of commands");
                    Console.WriteLine("crash - crashes the system");
                    Console.WriteLine("off - shutdown your pc");
                    Console.WriteLine("reboot - reboot your system");
                    Console.WriteLine("dsver - about your system");
                    Console.WriteLine("cls - clear console");
                    Console.WriteLine("dat - date and time");
                    Console.WriteLine("gui - GUI test (alpha)");
                    Console.WriteLine("calc - calc");
                    break;
                case "dsver":
                    Console.WriteLine("DragonSpace v0.2 closed alpha, codename: Ksenomorph");
                    break;
                case "cls":
                    Console.Clear();
                    break;
                case "dat":
                    Console.WriteLine(DateTime.Now);
                    break;
                case "gui":
                    Console.WriteLine("Select yout mode:");
                    Console.WriteLine("Width: ");
                    int a = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Height: ");
                    int b = Convert.ToInt32(Console.ReadLine());

                        canvas = FullScreenCanvas.GetFullScreenCanvas();
                        canvas.Mode = new Mode(a, b, ColorDepth.ColorDepth32);
                        canvas.Clear(Color.DarkCyan);

                        Console.ReadKey();

                        Stop();
                    break;
                case "calc":
                    Console.WriteLine("First Number: ");
                    int c1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Operator(/, *, +, -): ");
                    char b1 = Convert.ToChar(Console.ReadLine());
                    Console.WriteLine("Second number: ");
                    int c2 = Convert.ToInt32(Console.ReadLine());
                    switch (b1)
                    {
                        case '/':
                            if (c2 == 0)
                            {
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Clear();
                                Console.WriteLine("A critical error occurred and DragonSpace shut down to prevent further errors.");
                                Console.WriteLine("Error: KMODE_EXCEPTION_NOT_HANDLED (calc)");
                                Console.WriteLine("");
                                Console.WriteLine("If you see this error for the first time, DO NOT DIVIDE BY ZERO MAN.");
                                Console.WriteLine("If you didn't divide by zero, restore the system via the installer,");
                                Console.WriteLine("or check if all the files are exists via the command: checksys /a");
                                Console.WriteLine("");
                                Console.WriteLine("Technical information:");
                                Console.WriteLine("0x000000RE0 (0x00000052, 0x0000012, 0x000000K2)");
                                Console.WriteLine("Press any key to reboot");
                                Console.ReadKey();
                                Cosmos.System.Power.Reboot();
                            } else
                            {
                                int divide = c1 / c2;
                                Console.WriteLine(c1 + " / " + c2 + " = " + divide);
                            }
                                break;
                        case '+':
                            int plus = c1 + c2;
                            Console.WriteLine(c1 + " + " + c2 + " = " + plus);
                            break;
                        case '-':
                            int minus = c1 - c2;
                            Console.WriteLine(c1 + " - " + c2 + " = " + minus);
                            break;
                        case '*':
                            int umnoz = c1 * c2;
                            Console.WriteLine(c1 + " * " + c2 + " = " + umnoz);
                            break;
                    } 
                    break;
                default:
                    Console.WriteLine("The field is empty, or this command does not exist. Type \"help\" for the list of commands");
                    break;
            }
        }
    }
}