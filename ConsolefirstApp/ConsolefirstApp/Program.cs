using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolefirstApp
{
    internal class Program
    {
        static void calculatior()
        {

            Console.WriteLine("Enter your first Number ");
            int n1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Second number ");
            int n2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Opertion + , - , *,/ ,%");
            string op = Console.ReadLine();

            if (op == "+")
            {
                int output = Addtwonum((int)n1, (int)n2);
                Console.WriteLine($"SUM of Entered Numbers are {output}");
                Console.ReadLine();
            }
            else if (op == "-")
            {
                int output = subtracttwonumbers((int)n1, (int)n2);
                Console.WriteLine($"subtraction of Entered Numbers are {output}");
                Console.ReadLine();
            }
            else if (op == "*")
            {
                int output = multiplicaton((int)n1, (int)n2);
                Console.WriteLine($"Multiplication of Entered Numbers are {output}");
                Console.ReadLine();
            }
            else if (op == "/")
            {
                int output = Division((int)n1, (int)n2);
                Console.WriteLine($"Division of Entered Numbers are {output}");
                Console.ReadLine();
            }
            else if (op == "%")
            {
                int output = Reminder((int)n1, (int)n2);
                Console.WriteLine($"Reminder of Entered Numbers are {output}");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("you Entered Invalid value");
                Console.ReadLine();
            }
            calculatior();
        }
        static int Addtwonum(int n, int m)
        {
            return n + m;
        }
        static int subtracttwonumbers(int n, int m)
        {
            return n - m;
        }
        static int multiplicaton(int n, int m)
        {

            return n * m;
        }
        static int Division(int n, int m)
        {

            return n / m;
        }
        static int Reminder(int n, int m)
        {

            return n % m;
        }
        static void firstmethod()
        {
            Console.WriteLine(" Udit Dhiman ");
            Console.ReadLine();
        }
        static int sumtwonum(int n, int m)
        {
            return n + m;
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter your Name  ");
            //string name = Console.ReadLine();
            //Console.WriteLine("My name is {0}", name);
            //Console.ReadLine();

            //simple print statement 

            //Console.WriteLine("Udit Dhiman");
            //Console.ReadLine();

            //arithmetic operation with user input

            //Console.WriteLine("Enter First Number ");
            //int num1 = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter Second Number ");
            //int num2 = int.Parse(Console.ReadLine());
            //int sum = num1 + num2;
            //Console.WriteLine("Addition result is {0}", sum);
            //Console.ReadLine();

            //simple if else statement 

            //int a = 2;
            //if (a > 2)
            //{
            //    Console.WriteLine("A is greater than b ");
            //    Console.ReadLine();
            //}
            //else if (a == 2)
            //{

            //    Console.WriteLine("a is equal to 2");
            //    Console.ReadLine();
            //}
            //else {
            //    Console.WriteLine("A is less than 2");
            //    Console.ReadLine();
            //}

            //if else if else sttatement with user input 

            //Console.WriteLine("Enter your Number for cheack greater than 100 or equal or less than 100");
            //int num = int.Parse(Console.ReadLine());

            //if (num > 100)
            //{
            //    Console.WriteLine("number is greater than 100");
            //    Console.ReadLine();
            //}
            //else if (num ==0)
            //{
            //    Console.WriteLine("number is equal to 100");
            //    Console.ReadLine();
            //}
            //else {
            //    Console.WriteLine("number is less than 100");
            //    Console.ReadLine();
            //}

            //Console.WriteLine("List of cases are ");
            //Console.WriteLine("Ringing");
            //Console.WriteLine("calling");
            //Console.WriteLine("busy");
            //Console.WriteLine("switchedoff");
            //Console.WriteLine("blocked");


            //swith statement with user input 

            //string userinput = Console.ReadLine();

            //switch (userinput.ToLower())
            //{
            //    case "ringing":
            //        Console.WriteLine("Phone ringing");
            //        Console.ReadLine();
            //        break;
            //    case "calling":
            //        Console.WriteLine("Phone calling");
            //        Console.ReadLine();
            //        break;
            //    case "busy":
            //        Console.WriteLine("Dial nuber has been busy");
            //        Console.ReadLine();
            //        break;
            //    case "switchedoff":
            //        Console.WriteLine("Dial Nuber has been curently switch off");
            //        Console.ReadLine();
            //        break;
            //    case "blocked":
            //        Console.WriteLine("your are blocked user");
            //        Console.ReadLine();
            //        break;

            //    default:
            //        Console.WriteLine("Input not recognized.");
            //        break;
            //}

            //simple while loop 

            //int i = 1;
            //while (i < 6) {
            //    Console.WriteLine("while loop working {0}", i);
            //    i++;
            //    if (i == 6)
            //    {
            //        Console.ReadLine();

            //    }
            //}
            //while lop with user input 

            //Console.WriteLine("enter a number between 0 to 100 while you print the number");
            //int inputnumber = int.Parse(Console.ReadLine());
            //int i = 1;
            //if (inputnumber <= 100) { 

            //    while(i<= inputnumber)
            //    {
            //        Console.WriteLine(i);
            //        i++;
            //        if(i == inputnumber)
            //        {
            //            Console.WriteLine(i);
            //            Console.ReadLine();
            //        }
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("please write a number between 1 to 100");
            //}

            //print uisng for loop 

            //int forarg = 25;
            //Console.WriteLine("for loop print statement ");
            //for (int i = 1; i <=forarg; i++)
            //{

            //    Console.WriteLine("no is {0} ", i );
            //    if(i == forarg)
            //    {
            //        Console.ReadLine();
            //    }

            //}

            //for each loop 
            //Console.WriteLine("using for each loop ");
            //string[] names = { "Udit", "amar", "vinay ", "rahul", "sachin" };
            //foreach (string name in names)
            //{
            //    Console.WriteLine($"MY NAME IS {name}");
            //    if (name == names[names.Length - 1])
            //    {
            //        Console.ReadLine();
            //    }
            //    }
            //firstmethod();

            //Console.WriteLine("Enter your first Number ");
            //int n = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter your Second number ");
            //int m = int.Parse(Console.ReadLine());
            //int sumnum = sumtwonum((int)n, m);
            //if (sumnum > 100)
            //{
            //    Console.WriteLine("entered number sum greater than 100");
            //    Console.ReadLine();
            //}
            //else if (sumnum == 100)
            //{
            //    Console.WriteLine("sum of two numbers equal to 100");
            //    Console.ReadLine();
            //}

            //else
            //{
            //    Console.WriteLine("entered number sum less than 100 ");
            //    Console.ReadLine();
            //}


            //calculatior application 
            //Console.WriteLine("calculatior application ");
            //int i = 0;
            //do
            //{

            //    Console.WriteLine("Enter 1 for start calculator and 0 for close");
            //    int calinput = int.Parse(Console.ReadLine());
            //    calculatior();
            //    Console.WriteLine("if you want to close then press 5  else  press any number not 5");
            //     i = int.Parse(Console.ReadLine());

            //}
            //while (i != 5);

            //Array with user input 
            Console.WriteLine("Creatinf a Array using user input");
            Console.WriteLine("Enter the length of array");
            int n = int.Parse(Console.ReadLine());
            int[] num = new int[n];
            for (int z = 0; z < n; z++)
            {
                Console.WriteLine($"enter the {z + 1} number");
                num[z] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Elemets of array Entered by You");
            foreach (int z in num)
            {
                Console.WriteLine(z);
            }
            Console.ReadLine();



        }


    }
}
