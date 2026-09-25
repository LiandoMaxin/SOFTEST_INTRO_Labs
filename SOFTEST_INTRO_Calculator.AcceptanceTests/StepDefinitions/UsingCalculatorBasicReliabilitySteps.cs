using Reqnroll;
using SOFTEST_INTRO_Calculator.AcceptanceTests.Support;

namespace SOFTEST_INTRO_Calculator.AcceptanceTests.StepDefinitions;

[Binding]
public sealed class UsingCalculatorBasicReliabilitySteps
{
    private readonly CalculatorContext _context;
    private readonly BasicMusaContext _musa;

    public UsingCalculatorBasicReliabilitySteps(
        CalculatorContext context,
        BasicMusaContext musa)
    {
        _context = context;
        _musa = musa;
    }

    [Given("the initial failure intensity is {double}")]
    public void GivenTheInitialFailureIntensityIs(double value)
    {
        _musa.InitialFailureIntensity = value;
    }

    [Given("the expected total number of failures is {double}")]
    public void GivenTheExpectedTotalNumberOfFailuresIs(double value)
    {
        _musa.ExpectedTotalFailures = value;
    }

    [Given("the accumulated execution time is {double} hours")]
    public void GivenTheAccumulatedExecutionTimeIs(double value)
    {
        _musa.ExecutionTime = value;
    }

    [When("I calculate the current failure intensity")]
    public void WhenICalculateTheCurrentFailureIntensity()
    {
        _context.Result =
            _context.Calculator.BasicMusaFailureIntensity(
                _musa.InitialFailureIntensity,
                _musa.ExpectedTotalFailures,
                _musa.ExecutionTime);
    }

    [When("I calculate the expected cumulative failures")]
    public void WhenICalculateTheExpectedCumulativeFailures()
    {
        _context.Result =
            _context.Calculator.BasicMusaCumulativeFailures(
                _musa.InitialFailureIntensity,
                _musa.ExpectedTotalFailures,
                _musa.ExecutionTime);
    }
}