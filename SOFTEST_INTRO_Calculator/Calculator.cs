namespace SOFTEST_INTRO_Calculator
{
    public class Calculator
    {
        public double Add(double a, double b)
        {
            if (IsBinaryNumber(a) && IsBinaryNumber(b))
            {
                string combined = ((long)a).ToString() + ((long)b).ToString();
                return Convert.ToInt64(combined, 2);
            }

            return a + b;
        }

        private static bool IsBinaryNumber(double value)
        {
            if (value < 0 || value % 1 != 0)
                return false;

            string text = ((long)value).ToString();

            foreach (char digit in text)
            {
                if (digit != '0' && digit != '1')
                    return false;
            }

            return true;
        }
        public double Subtract(double a, double b) => a - b;
        public double Multiply(double a, double b) => a * b;

        // Starter version: complete the zero-divisor rule in section 5.
        public double Divide(double a, double b)
        {
            if (b == 0)
                throw new ArgumentException();

            return a / b;
        }

        public double DoOperation(double a, double b, string op)
        {
            return op switch
            {
                "a" => Add(a, b),
                "s" => Subtract(a, b),
                "m" => Multiply(a, b),
                "d" => Divide(a, b),
                _ => throw new ArgumentException("Unknown operation.")
            };
        }

        public long Factorial(int n)
        {
            if (n < 0 || n > 20)
                throw new ArgumentOutOfRangeException(nameof(n));

            long result = 1;

            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }

        public double TriangleArea(double height, double width)
        {
            if (height < 0)
                throw new ArgumentOutOfRangeException(nameof(height));

            if (width < 0)
                throw new ArgumentOutOfRangeException(nameof(width));

            return 0.5 * height * width;
        }

        public double CircleArea(double radius)
        {
            if (radius < 0)
                throw new ArgumentOutOfRangeException(nameof(radius));

            return Math.PI * radius * radius;
        }

        public long UnknownFunctionA(int n, int r)
        {
            ValidateNAndR(n, r);

            return Factorial(n) / Factorial(n - r);
        }

        public long UnknownFunctionB(int n, int r)
        {
            ValidateNAndR(n, r);

            return Factorial(n) /
                   (Factorial(r) * Factorial(n - r));
        }

        private static void ValidateNAndR(int n, int r)
        {
            if (n < 0 || n > 20 || r < 0 || r > n)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public double MTBF(double operatingTime, double numberOfFailures)
        {
            if (operatingTime <= 0)
                throw new ArgumentOutOfRangeException(nameof(operatingTime));

            if (numberOfFailures <= 0)
                throw new ArgumentOutOfRangeException(nameof(numberOfFailures));

            return operatingTime / numberOfFailures;
        }

        public double Availability(double mtbf, double mttr)
        {
            if (mtbf < 0)
                throw new ArgumentOutOfRangeException(nameof(mtbf));

            if (mttr < 0)
                throw new ArgumentOutOfRangeException(nameof(mttr));

            if (mtbf + mttr <= 0)
                throw new ArgumentException("MTBF + MTTR must be greater than zero.");

            return mtbf / (mtbf + mttr);
        }

        public double BasicMusaFailureIntensity(
            double initialFailureIntensity,
            double expectedTotalFailures,
            double executionTime)
        {
            if (initialFailureIntensity <= 0)
                throw new ArgumentOutOfRangeException(nameof(initialFailureIntensity));

            if (expectedTotalFailures <= 0)
                throw new ArgumentOutOfRangeException(nameof(expectedTotalFailures));

            if (executionTime < 0)
                throw new ArgumentOutOfRangeException(nameof(executionTime));

            return initialFailureIntensity *
                   Math.Exp(
                       -initialFailureIntensity * executionTime /
                       expectedTotalFailures);
        }

        public double BasicMusaCumulativeFailures(
            double initialFailureIntensity,
            double expectedTotalFailures,
            double executionTime)
        {
            if (initialFailureIntensity <= 0)
                throw new ArgumentOutOfRangeException(nameof(initialFailureIntensity));

            if (expectedTotalFailures <= 0)
                throw new ArgumentOutOfRangeException(nameof(expectedTotalFailures));

            if (executionTime < 0)
                throw new ArgumentOutOfRangeException(nameof(executionTime));

            return expectedTotalFailures *
                   (1 - Math.Exp(
                       -initialFailureIntensity * executionTime /
                       expectedTotalFailures));
        }

        public double GenMagicNum(
            int choice, string path, IFileReader fileReader)
        {
            ArgumentNullException.ThrowIfNull(fileReader);

            if (choice < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(choice));
            }

            string[] magicStrings = fileReader.Read(path);

            if (choice >= magicStrings.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(choice));
            }

            double magicNumber = double.Parse(magicStrings[choice]);

            return 2 * Math.Abs(magicNumber);
        }
    }
}
