using System;

namespace Tumakov12
{
    internal class Ratio
    {
        #region Fields
        private int _Numerator;
        private int _Denominator;
        #endregion

        #region Properties
        public int Numerator
        {
            get { return _Numerator; }
            set { _Numerator = value; }
        }
        public int Denominator
        {
            get { return _Denominator; }
            set { _Denominator = value; }
        }
        #endregion

        #region Constructor
        public Ratio(int num, int denom)
        {
            if (denom == 0)
            {
                throw new Exception("! Деление на ноль !");
            }
            if (denom < 0)
            {
                num = -num;
                denom = -denom;
            }

            _Numerator = num;
            _Denominator = denom;

            NormRatio();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Оператор сложения
        /// </summary>
        /// <returns>Число типа Ratio</returns>
        public static Ratio operator +(Ratio rat1, Ratio rat2)
        {
            return new Ratio(rat1.Numerator * rat2.Denominator + rat2.Numerator * rat1.Denominator, rat2.Denominator * rat1.Denominator);
        }

        /// <summary>
        /// Оператор вычитания
        /// </summary>
        /// <returns>Число типа Ratio</returns>
        public static Ratio operator -(Ratio rat1, Ratio rat2)
        {
            return new Ratio(rat1.Numerator * rat2.Denominator - rat2.Numerator * rat1.Denominator, rat2.Denominator * rat1.Denominator);
        }

        /// <summary>
        /// Оператор умножения
        /// </summary>
        /// <returns>Число типа Ratio</returns>
        public static Ratio operator *(Ratio rat1, Ratio rat2)
        {
            return new Ratio(rat1.Numerator * rat2.Numerator, rat1.Denominator * rat2.Denominator);
        }

        /// <summary>
        /// Оператор деления
        /// </summary>
        /// <returns>Число типа Ratio</returns>
        public static Ratio operator /(Ratio rat1, Ratio rat2)
        {
            return new Ratio(rat1.Numerator * rat2.Denominator, rat1.Denominator * rat2.Numerator);
        }

        /// <summary>
        /// Оператор нахождения остатка
        /// </summary>
        /// <returns>Число типа Ratio</returns>
        public static Ratio operator %(Ratio rat1, Ratio rat2)
        {
            Ratio ans = new Ratio(1, 1);
            ans = rat1 / rat2 * rat2;

            return rat1 - ans;
        }

        /// <summary>
        /// Операторпроверки на равенство
        /// </summary>
        /// <returns>Булево значение</returns>
        public static bool operator ==(Ratio rat1, Ratio rat2)
        {
            return rat1.Equals(rat2);
        }

        /// <summary>
        /// Оператор проверки на неравенство
        /// </summary>
        /// <returns>Булево значение</returns>
        public static bool operator !=(Ratio rat1, Ratio rat2)
        {
            return !rat1.Equals(rat2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Ratio)
            {
                Ratio ratio = (Ratio)obj;
                return Numerator == ratio.Numerator && Denominator == ratio.Denominator;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (Numerator, Denominator).GetHashCode();
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        /// <summary>
        /// Оператор сравнения
        /// </summary>
        /// <returns>Булево значение</returns>
        public static bool operator >=(Ratio rat1, Ratio rat2)
        {
            return (rat1.Numerator / rat1.Denominator) >= (rat2.Numerator / rat2.Denominator);
        }

        /// <summary>
        /// Оператор сравнения
        /// </summary>
        /// <returns>Булево значение</returns>
        public static bool operator <=(Ratio rat1, Ratio rat2)
        {
            return (rat1.Numerator / rat1.Denominator) <= (rat2.Numerator / rat2.Denominator);
        }

        /// <summary>
        /// Оператор сравнения
        /// </summary>
        /// <returns>Булево значение</returns>
        public static bool operator <(Ratio rat1, Ratio rat2)
        {
            return (rat1.Numerator / rat1.Denominator) < (rat2.Numerator / rat2.Denominator);
        }

        /// <summary>
        /// Оператор сравнения
        /// </summary>
        /// <returns>Булево значение</returns>
        public static bool operator >(Ratio rat1, Ratio rat2)
        {
            return (rat1.Numerator / rat1.Denominator) > (rat2.Numerator / rat2.Denominator);
        }

        /// <summary>
        /// Оператор инкремента
        /// </summary>
        /// <returns>Число типа Ratio</returns>
        public static Ratio operator ++(Ratio rat)
        {
            return rat + new Ratio(1, 1);
        }

        /// <summary>
        /// Оператор декремента
        /// </summary>
        /// <returns>Число типа Ratio</returns>
        public static Ratio operator --(Ratio rat)
        {
            return rat - new Ratio(1, 1);
        }

        /// <summary>
        /// Метод переводит число из Ratio в int
        /// </summary>
        /// <returns>Число типа int</returns>
        public int ToInt()
        {
            return Numerator / Denominator;
        }

        /// <summary>
        /// Метод переводит число из Ratio в float
        /// </summary>
        /// <returns>Число типа float</returns>
        public float ToFloat()
        {
            return (float)Numerator / Denominator;
        }

        /// <summary>
        /// Метод переводит число из int в Ratio
        /// </summary>
        /// <returns>Число типа Ratio</returns>
        public Ratio ToRatio(int number)
        {
            return new Ratio(number, 1);
        }

        /// <summary>
        /// Метод переводит число из float в Ratio
        /// </summary>
        /// <returns>Число типа Ratio</returns>
        public Ratio ToRatio(float number)
        {
            int countZeroes = 0;
            if (number < 0)
            {
                number = -number;
            }

            while (number != (int)number)
            {
                countZeroes++;
                number *= 10;
            }

            return new Ratio((int)number, (int)Math.Pow(10, countZeroes));
        }

        /// <summary>
        /// Метод сокращения дроби
        /// </summary>
        private void NormRatio()
        {
            int a = Math.Abs(Numerator);
            int b = Math.Abs(Denominator);

            while (b > 0)
            {
                int dop = b;
                b = a % b;
                a = dop;
            }

            Numerator /= a;
            Denominator /= a;
        }
        #endregion
    }
}