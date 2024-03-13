using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTicket;

public class UnitTest
{
    [Fact]
    public void canMultiplyNumbers()
    {
        int num1 = 2;
        int num2 = 3;
        int result = (num1 * num2);

        Assert.Equal(6, result);
    }
}
