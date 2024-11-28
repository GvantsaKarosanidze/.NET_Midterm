namespace Calculator
{
    class Calculator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Calculator App");
            while (true)
            {
                Console.WriteLine("First Number:");
                double first = getDouble();
                Console.WriteLine("Second Number:");
                double second = getDouble();
                Console.WriteLine("Operation (+ - * /):");
                char op = getOperation();
                Operation operation = null;
                switch (op)
                {
                    case '+':
                        operation = new Addition(first, second);
                        break;
                    case '-':
                        operation = new Substraction(first, second);
                        break;
                    case '*':
                        operation = new Multiplication(first, second);
                        break;
                    case '/':
                        if (second == 0)
                        {
                            Console.WriteLine("Dividing by 0 is not allowed");
                        }
                        else
                            operation = new Division(first, second);
                        break;
                }
                
                if (operation != null) 
                    Console.WriteLine(first + " " + op + " " + second + " = " + operation.Calculate());
                

                if (!Again())
                    break;
            }
            Console.WriteLine("Bye ^_^");
        }

        private static bool Again()
        {
            Console.WriteLine("Press enter to quit or type something to continue");
            return Console.ReadLine().Length > 0;
        }

        private static char getOperation()
        {
            string op;
            while (true)
            {
                op = Console.ReadLine();
                if (op.Length == 1 && ("+-*/".Contains(op[0])))
                    return op[0];
                Console.WriteLine("Illegal input! Please, enter one of this: + - * / ");
            }
        }

        private static double getDouble()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double n))
                {
                    return n;
                }
                else
                {
                    Console.WriteLine("Illegal input! Please, enter decimal.");
                }
            }
        }
    }
}
