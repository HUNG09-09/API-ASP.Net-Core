using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web062023.Demo.UnitTests
{
    [TestFixture]
    public class CalculatorTests
    {
        /// <summary>
        /// Hàm test cộng thành công 2 số nguyên
        /// </summary>
        /// Create by :nshung(13/08/2023)
        [TestCase(1,2,3)]
        [TestCase(2,3,5)]
        [TestCase(1,-7,6)]
        [TestCase(int.MaxValue,int.MaxValue, int.MaxValue * (long)2)]


        public void Add_ValidInput_SumTwoNumber(int x, int y, long expectedResult)
        {
            //Arrange
          

            //Act
            var actualResult = new Calculator().Add(x, y);

            //Assert
            Assert.That(expectedResult, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// Hàm test trừ thành công 2 số nguyên
        /// </summary>
        /// Create by :nshung(13/08/2023)
        [TestCase(1, 2, -1)]
        [TestCase(2, 3, -1)]
        [TestCase(-1, 7, -8)]
        [TestCase(int.MaxValue, int.MinValue, int.MaxValue * (long)2 + 1)]

        public void Sub_ValidInput_SumTwoNumber(int x, int y, long expectedResult)
        {
            //Arrange


            //Act
            var actualResult = new Calculator().Sub(x, y);

            //Assert
            Assert.That(expectedResult, Is.EqualTo(expectedResult));
        }


        /// <summary>
        /// Hàm test chia thành công 2 số nguyên
        /// </summary>
        /// Create by :nshung(13/08/2023)
        [Test]        
        public void Div_ZeroInput_ThrowExeption()
        {
            //Arrange
            var  x = 1;
            var  y = 0;
            var expectedMessage = "Không thể chia cho 0";

            var exception = Assert.Throws<Exception>(() => new Calculator().Div(x, y));

            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
           
        }

        /// <summary>
        /// Hàm test chia thành công 2 số nguyên
        /// </summary>
        /// Create by :nshung(13/08/2023)
        [TestCase(1, 2, 0.5f)]
        [TestCase(1, 3, 1/(double)3)]
        [TestCase(int.MaxValue, 3, int.MaxValue/(double)3)]

        public void Div_ValidInput_Success(int x, int y, double expectedResult)
        {
            //Act
            var actualResult = new Calculator().Div(x, y);

            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// Hàm test nhân thành công 2 số nguyên
        /// </summary>
        /// Create by :nshung(13/08/2023)
        [TestCase(1, 2, 2)]
        [TestCase(2, 3, 6)]
        [TestCase(-1, 7, -7)]
        [TestCase(int.MaxValue, int.MinValue, int.MaxValue * (long)int.MinValue)]


        public void Mul_ValidInput_SumTwoNumber(int x, int y, long expectedResult)
        {
            //Arrange


            //Act
            var actualResult = new Calculator().Mul(x, y);

            //Assert
            Assert.That(expectedResult, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// Hàm test tổng chuỗi
        /// </summary>
        /// Create by :nshung(13/08/2023)
        /// 

        // Chuỗi rỗng trả về 0
        [Test]
        public void Add_EmptyString_ReturnsZero()
        {
            // Arrange
            string input = "";

            // Act
            var actualResult = new Calculator().Add(input);

            // Assert
            Assert.That(actualResult, Is.EqualTo(0));
        }

        // Chuỗi 1 trả về 1, chuỗi 2 trả về 2........
        [TestCase("1", 1)]
        [TestCase("2", 2)]
        [TestCase("10", 10)]
        [TestCase("100", 100)]
        public void Add_SingleNumber_ReturnsNumber(string input, int expectedResult)
        {
            // Act
            var actualResult = new Calculator().Add(input);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        // Chuỗi "1,2,3" trả về 6, chuỗi "1, 2, 3" trả về 6
        [TestCase("1,2,3", 6)]
        [TestCase("10,20,30", 60)]
        [TestCase("1, 2, 3", 6)]
        public void Add_MultipleNumbers_ReturnsSum(string input, int expectedResult)
        {
            // Act
            var actualResult = new Calculator().Add(input);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        // Thông báo lỗi khi từng toán tử âm
        [Test]
        public void Add_NegativeNumbers_ThrowsException()
        {
            // Arrange
            string input = "1,-2,-3";
            string expectedMessage = "Không chấp nhận toán tử âm: -2, -3";

            // Act 
            var exception = Assert.Throws<Exception>(() => new Calculator().Add(input));

            //Assert
            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
        }
    }
}
