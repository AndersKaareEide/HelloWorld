namespace HelloWorld
{

    public interface ICalculator
    {
        int Add(int num1, int num2);
        int Mul(int num1, int num2);
    }

    public class Calculator : ICalculator
    {
        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        public int Mul(int num1, int num2)
        {
            return num1 * num2;
        }
    }
}