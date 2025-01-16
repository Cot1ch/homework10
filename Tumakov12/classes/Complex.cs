using System;

namespace Tumakov12
{
    internal class Complex
    {

        private double _Real;
        private double _Imaginary;

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

        public Complex(double real, double imaginary)
        {
            _Real = real;
            _Imaginary = imaginary;
        }


        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
        }
        public static Complex operator -(Complex c1, Complex c2)
        {
            return new Complex(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
        }
        public static Complex operator *(Complex c1, Complex c2)
        {
            return new Complex(c1.Real * c2.Real - c1.Imaginary * c2.Imaginary,
                c1.Imaginary * c2.Real + c2.Imaginary * c1.Real);
        }
        public static Complex operator /(Complex c1, Complex c2)
        {
            if (c2._Real == 0 || c2.Imaginary == 0)
            {
                throw new Exception("! Деление на ноль !");
            }
            return new Complex((c1.Real * c2.Real + c1.Imaginary * c2.Imaginary) / (c2.Real * c2.Real + c2.Imaginary * c2.Imaginary), (c1.Imaginary * c2.Real - c1.Real * c2.Imaginary) / (c2.Real * c2.Real + c2.Imaginary * c2.Imaginary));
        }
        public static bool operator ==(Complex c1, Complex c2)
        {
            return c1.Equals(c2);
        }
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
    }
}