namespace MISA.Web062023.Demo
{
    public class Calculator
    {   
        /// <summary>
        /// Hàm cộng 2 số nguyên
        /// </summary>
        /// <param name="x">Toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <returns>Tổng 2 số nguyên</returns>
        /// Created by: nshung (13/08/2023)
        public long Add(int x, int y)
        {
            return x + (long)y;
        }

        /// <summary>
        /// Hàm trừ 2 số nguyên
        /// </summary>
        /// <param name="x">Toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <returns>Hiệu 2 số nguyên</returns>
        /// Created by: nshung (13/08/2023)
        public long Sub(int x, int y)
        {
            return x - (long)y;
        }

        /// <summary>
        /// Hàm nhân 2 số nguyên
        /// </summary>
        /// <param name="x">Toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <returns>Tích 2 số nguyên</returns>
        /// Created by: nshung (13/08/2023)
        public long Mul(int x, int y)
        {
           return x * (long)y;
        }

        /// <summary>
        /// Hàm chia 2 số nguyên
        /// </summary>
        /// <param name="x">Toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <returns>Thương 2 số nguyên</returns>
        /// Created by: nshung (13/08/2023)
        public double Div(int x, int y)
        {
           if(y== 0)
            {
                throw new Exception("Không thể chia cho 0");
            }
            return x / (double)y;

        }

        /// <summary>
        /// Hàm tính tổng khi truyền vào chuỗi
        /// </summary>
        /// <param input>Dữ liệu vào</param>
        /// <returns>kết quả tính toán</returns>
        /// Created by: nshung (13/08/2023)
        public int Add(string input)
        {
            // chuỗi rỗng trả về 0
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            // Chuỗi cách nhau dấu ','
            string[] numbers = input.Split(',');

            int sum = 0;
            string negativeNumbers = "";

            foreach (string number in numbers)
            {
                int parsedNumber = int.Parse(number.Trim());
                if (parsedNumber < 0)
                {
                    if (!string.IsNullOrEmpty(negativeNumbers))
                    {
                        negativeNumbers += ", ";
                    }
                    negativeNumbers += parsedNumber.ToString();
                }
                else
                {
                    sum += parsedNumber;
                }
            }

            // Có số âm thì thông báo lỗi
            if (!string.IsNullOrEmpty(negativeNumbers))
            {
                throw new Exception("Không chấp nhận toán tử âm: -2,-3");
            }

            return sum;
        }

    }
}
