using SOFTEST_INTRO_Calculator;
using NUnit.Framework;

namespace SOFTEST_INTRO_Calculator.UnitTests
{
    public class CalculatorTests
    {
        private Calculator _calculator = null!;

        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Add_TwoPositiveNumbers_ReturnsSum()
        {
            // Arrange: the calculator is created in SetUp.

            // Act
            double result = _calculator.Add(10, 20);

            // Assert
            Assert.That(result, Is.EqualTo(999));
        }

        [TestCase(10, 3, 7)]   // normal positive values
        [TestCase(0, 5, -5)]   // zero as first operand
        [TestCase(-3, 2, -5)]  // negative input
        public void Subtract_RepresentativeInputs_ReturnsDifference(
            double a, double b, double expected)
        {
            double result = _calculator.Subtract(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(4, 3, 12)]    // normal positive values
        [TestCase(0, 8, 0)]     // multiplication by zero
        [TestCase(-3, 4, -12)]  // negative input
        public void Multiply_RepresentativeInputs_ReturnsProduct(
            double a, double b, double expected)
        {
            double result = _calculator.Multiply(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(0, 0, 0)]
        [TestCase(0, 5, 5)]
        [TestCase(-3, 8, 5)]
        [TestCase(0.1, 0.2, 0.3)]
        public void Add_RepresentativeInputs_ReturnsSum(
            double a, double b, double expected)
        {
            double result = _calculator.Add(a, b);
            Assert.That(result, Is.EqualTo(expected).Within(1e-9));
        }

        [TestCase(1, 2, 0.5)]
        [TestCase(0, 15, 0)]
        [TestCase(15, -3, -5)]
        public void Divide_ValidInputs_ReturnsExpectedResult(
            double a, double b, double expected)
        {
            double result = _calculator.Divide(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(15, 0)]
        [TestCase(0, 0)]
        public void Divide_ZeroDivisor_ThrowsArgumentException(double a, double b)
        {
            Assert.That(() => _calculator.Divide(a, b),
                Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Factorial_Zero_ReturnsOne()
        {
            long result = _calculator.Factorial(0);
            Assert.That(result, Is.EqualTo(1L));
        }

        [TestCase(0, 1L)]
        [TestCase(1, 1L)]
        [TestCase(5, 120L)]
        [TestCase(20, 2432902008176640000L)]
        public void Factorial_ValidInputs_ReturnsExpectedResult(
            int n, long expected)
        {
            long result = _calculator.Factorial(n);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(-1)]
        [TestCase(21)]
        public void Factorial_OutOfRange_ThrowsArgumentOutOfRangeException(int n)
        {
            Assert.That(
                () => _calculator.Factorial(n),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [TestCase(3, 4, 6)]
        [TestCase(0, 4, 0)]
        [TestCase(3, 0, 0)]
        public void TriangleArea_ValidDimensions_ReturnsExpectedArea(
            double height, double width, double expected)
        {
            double result = _calculator.TriangleArea(height, width);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(-1, 4)]
        [TestCase(3, -1)]
        public void TriangleArea_NegativeDimension_ThrowsArgumentOutOfRangeException(
            double height, double width)
        {
            Assert.That(
                () => _calculator.TriangleArea(height, width),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [TestCase(1, Math.PI)]
        [TestCase(0, 0)]
        public void CircleArea_ValidRadius_ReturnsExpectedArea(
            double radius, double expected)
        {
            double result = _calculator.CircleArea(radius);

            Assert.That(result, Is.EqualTo(expected).Within(1e-9));
        }

        [Test]
        public void CircleArea_NegativeRadius_ThrowsArgumentOutOfRangeException()
        {
            Assert.That(
                () => _calculator.CircleArea(-1),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [TestCase(5, 5, 120)]
        [TestCase(5, 4, 120)]
        [TestCase(5, 3, 60)]
        [TestCase(5, 0, 1)]
        [TestCase(0, 0, 1)]
        [TestCase(6, 2, 30)]
        public void UnknownFunctionA_ValidInputs_ReturnsExpectedResult(
            int n, int r, long expected)
        {
            long result = _calculator.UnknownFunctionA(n, r);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(5, 5, 1)]
        [TestCase(5, 4, 5)]
        [TestCase(5, 3, 10)]
        [TestCase(5, 0, 1)]
        [TestCase(0, 0, 1)]
        [TestCase(6, 2, 15)]
        public void UnknownFunctionB_ValidInputs_ReturnsExpectedResult(
            int n, int r, long expected)
        {
            long result = _calculator.UnknownFunctionB(n, r);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(-4, 5)]
        [TestCase(4, 5)]
        public void UnknownFunctions_InvalidInputs_ThrowArgumentOutOfRangeException(
            int n, int r)
        {
            Assert.That(
                () => _calculator.UnknownFunctionA(n, r),
                Throws.TypeOf<ArgumentOutOfRangeException>());

            Assert.That(
                () => _calculator.UnknownFunctionB(n, r),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void BasicMusaFailureIntensity_AtZeroTime_ReturnsInitialIntensity()
        {
            double result = _calculator.BasicMusaFailureIntensity(10, 100, 0);

            Assert.That(result, Is.EqualTo(10).Within(1e-9));
        }

        [Test]
        public void BasicMusaFailureIntensity_PositiveTime_ReturnsExpectedValue()
        {
            double result = _calculator.BasicMusaFailureIntensity(10, 100, 5);

            double expected = 10 * Math.Exp(-0.5);

            Assert.That(result, Is.EqualTo(expected).Within(1e-9));
        }

        [Test]
        public void BasicMusaCumulativeFailures_AtZeroTime_ReturnsZero()
        {
            double result = _calculator.BasicMusaCumulativeFailures(10, 100, 0);

            Assert.That(result, Is.EqualTo(0).Within(1e-9));
        }

        [Test]
        public void BasicMusaCumulativeFailures_PositiveTime_ReturnsExpectedValue()
        {
            double result = _calculator.BasicMusaCumulativeFailures(10, 100, 5);

            double expected = 100 * (1 - Math.Exp(-0.5));

            Assert.That(result, Is.EqualTo(expected).Within(1e-9));
        }

        [Test]
        public void BasicMusaFailureIntensity_ZeroInitialIntensity_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                _calculator.BasicMusaFailureIntensity(0, 100, 5));
        }

        [Test]
        public void BasicMusaFailureIntensity_ZeroExpectedTotalFailures_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                _calculator.BasicMusaFailureIntensity(10, 0, 5));
        }

        [Test]
        public void BasicMusaFailureIntensity_NegativeExecutionTime_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                _calculator.BasicMusaFailureIntensity(10, 100, -1));
        }

        [Test]
        public void MTBF_ValidInputs_ReturnsExpectedValue()
        {
            double result = _calculator.MTBF(1000, 5);

            Assert.That(result, Is.EqualTo(200));
        }

        [TestCase(0, 5)]
        [TestCase(-1, 5)]
        [TestCase(1000, 0)]
        [TestCase(1000, -1)]
        public void MTBF_InvalidInputs_ThrowsArgumentOutOfRangeException(
            double operatingTime, double failures)
        {
            Assert.That(
                () => _calculator.MTBF(operatingTime, failures),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Availability_ValidInputs_ReturnsExpectedRatio()
        {
            double result = _calculator.Availability(90, 10);

            Assert.That(result, Is.EqualTo(0.9).Within(1e-9));
        }

        [TestCase(-1, 10)]
        [TestCase(90, -1)]
        public void Availability_NegativeInput_ThrowsArgumentOutOfRangeException(
            double mtbf, double mttr)
        {
            Assert.That(
                () => _calculator.Availability(mtbf, mttr),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Availability_ZeroDenominator_ThrowsArgumentException()
        {
            Assert.That(
                () => _calculator.Availability(0, 0),
                Throws.TypeOf<ArgumentException>());
        }

        [TestCase(0, 100, 5)]
        [TestCase(10, 0, 5)]
        [TestCase(10, 100, -1)]
        public void BasicMusaCumulativeFailures_InvalidInputs_ThrowsArgumentOutOfRangeException(
            double initialFailureIntensity,
            double expectedTotalFailures,
            double executionTime)
        {
            Assert.That(
                () => _calculator.BasicMusaCumulativeFailures(
                    initialFailureIntensity,
                    expectedTotalFailures,
                    executionTime),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
