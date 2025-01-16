using System;

namespace Tumakov12
{
    internal class Ratio
    {
        private int _Numerator;
        private int _Denominator;

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

        public static Ratio operator +(Ratio rat1, Ratio rat2)
        {
            return new Ratio(rat1.Numerator * rat2.Denominator + rat2.Numerator * rat1.Denominator, rat2.Denominator * rat1.Denominator);
        }
        public static Ratio operator -(Ratio rat1, Ratio rat2)
        {
            return new Ratio(rat1.Numerator * rat2.Denominator - rat2.Numerator * rat1.Denominator, rat2.Denominator * rat1.Denominator);
        }

        public static Ratio operator *(Ratio rat1, Ratio rat2)
        {
            return new Ratio(rat1.Numerator * rat2.Numerator, rat1.Denominator * rat2.Denominator);
        }
        public static Ratio operator /(Ratio rat1, Ratio rat2)
        {
            return new Ratio(rat1.Numerator * rat2.Denominator, rat1.Denominator * rat2.Numerator);
        }
        public static Ratio operator %(Ratio rat1, Ratio rat2)
        {
            Ratio ans = new Ratio(1, 1);
            ans = rat1 / rat2 * rat2;

            return rat1 - ans;
        }
        public static bool operator ==(Ratio rat1, Ratio rat2)
        {
            return rat1.Equals(rat2);
        }
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
        public static bool operator >=(Ratio rat1, Ratio rat2)
        {
            return (rat1.Numerator / rat1.Denominator) >= (rat2.Numerator / rat2.Denominator);
        }
        public static bool operator <=(Ratio rat1, Ratio rat2)
        {
            return (rat1.Numerator / rat1.Denominator) <= (rat2.Numerator / rat2.Denominator);
        }
        public static bool operator <(Ratio rat1, Ratio rat2)
        {
            return (rat1.Numerator / rat1.Denominator) < (rat2.Numerator / rat2.Denominator);
        }
        public static bool operator >(Ratio rat1, Ratio rat2)
        {
            return (rat1.Numerator / rat1.Denominator) > (rat2.Numerator / rat2.Denominator);
        }
        public static Ratio operator ++(Ratio rat)
        {
            return rat + new Ratio(1, 1);
        }
        public static Ratio operator --(Ratio rat)
        {
            return rat - new Ratio(1, 1);
        }
        public int ToInt()
        {
            return Numerator / Denominator;
        }
        public float ToFloat()
        {
            return (float)Numerator / Denominator;
        }
        public Ratio ToRatio(int number)
        {
            return new Ratio(number, 1);
        }
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
    }
}