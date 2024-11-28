namespace Calculator
{
    public abstract class Operation
    {
        public double firstNum { get; set; }
        public double secondNum { get; set; }

        public Operation(double firstNum, double secondNum)
        {
            this.firstNum = firstNum;
            this.secondNum = secondNum;
        }

        public abstract double Calculate();
    }

    public class Addition : Operation
    {
        public Addition(double firstNum, double secondNum) : base(firstNum, secondNum)
        {
        }

        public override double Calculate()
        {
            return firstNum + secondNum;
        }
    }

    public class Substraction : Operation
    {
        public Substraction(double firstNum, double secondNum) : base(firstNum, secondNum)
        {
        }

        public override double Calculate()
        {
            return firstNum - secondNum;
        }
    }

    public class Multiplication : Operation
    {
        public Multiplication(double firstNum, double secondNum) : base(firstNum, secondNum)
        {
        }

        public override double Calculate()
        {
            return (firstNum * secondNum);
        }
    }

    public class Division : Operation
    {
        public Division(double firstNum, double secondNum) : base(firstNum, secondNum)
        {
        }

        public override double Calculate()
        {
            return firstNum / secondNum;
        }
    }
}
