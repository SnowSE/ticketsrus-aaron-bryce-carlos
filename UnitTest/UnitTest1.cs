namespace UnitTest;

public class UnitTest1
{
    [Fact]
    public void canMultiplyNumbers()
    {
        int num1 = 2;
        int num2 = 3;
        int result = (num1 * num2);

        Assert.Equal(7, result);
    }
}
