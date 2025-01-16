using System;

namespace Tumakov12
{
    internal class Complex
    {
        #region Fields
        private double _Real;
        private double _Imaginary;
        #endregion

        #region Properties
        public double Real
        {
            get { return _Real; }
            set { _Real = value; }
        }
        public double Imaginary
        {
            get { return _Imaginary; }
            set { _Imaginary = value; }
        }
        #endregion

        #region Constructor
        public Complex(double real, double imaginary)
        {
            _Real = real;
            _Imaginary = imaginary;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Оператор сложения
        /// </summary>
        /// <returns>Число типа Complex</returns>
        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
        }

        /// <summary>
        /// Оператор вычитания
        /// </summary>
        /// <returns>Число типа Complex</returns>
        public static Complex operator -(Complex c1, Complex c2)
        {
            return new Complex(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
        }

        /// <summary>
        /// Оператор умножения
        /// </summary>
        /// <returns>Число типа Complex</returns>
        public static Complex operator *(Complex c1, Complex c2)
        {
            return new Complex(c1.Real * c2.Real - c1.Imaginary * c2.Imaginary,
                c1.Imaginary * c2.Real + c2.Imaginary * c1.Real);
        }

        /// <summary>
        /// Оператор деления
        /// </summary>
        /// <returns>Число типа Complex</returns>
        public static Complex operator /(Complex c1, Complex c2)
        {
            if (c2._Real == 0 && c2.Imaginary == 0)
            {
                throw new Exception("! Деление на ноль !");
            }
            return new Complex((c1.Real * c2.Real + c1.Imaginary * c2.Imaginary) / (c2.Real * c2.Real + c2.Imaginary * c2.Imaginary), (c1.Imaginary * c2.Real - c1.Real * c2.Imaginary) / (c2.Real * c2.Real + c2.Imaginary * c2.Imaginary));
        }

        /// <summary>
        /// Оператор сравнения
        /// </summary>
        /// <returns>Булево значение</returns>
        public static bool operator ==(Complex c1, Complex c2)
        {
            return c1.Equals(c2);
        }

        /// <summary>
        /// Оператор сравнения
        /// </summary>
        /// <returns>Булево значение</returns>
        public static bool operator !=(Complex c1, Complex c2)
        {
            return !c1.Equals(c2);
        }
        public override bool Equals(object obj)
        {
            if (obj is Complex)
            {
                Complex comp = (Complex)obj;
                return comp.Real == Real && comp.Imaginary == Imaginary;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return (Real, Imaginary).GetHashCode();
        }
        public override string ToString()
        {
            string symb = Imaginary < 0 ? String.Empty : "+";
            return Real + symb + Imaginary + "i";
        }
        #endregion
    }
}