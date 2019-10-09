using System;

namespace mindBox_app
{
    public class figure
    { 
        int num;// кол-во углов
        double p;//периметр
        double r;//радиус вписанной окр.
        string type;//тип фигуры
        double[] sides;//массив значений сторон фигуры
        public double P
        {
            get
            {
                return p;
            }
        }
        public double R
        {
            get { return r; }
            set { if (value > 0) r = value; else throw new Exception("Ошибка!"); } //проверка на отрицательное значение радиуса
        }
        public double [] Sides
        {
            get { return sides; }
            set
            {
                bool ok = true;
                foreach (double item in value)//проверка на отрицательное значение сторон
                    if (item < 0)
                        ok = false;
                if (ok == true)
                    sides = value;
                else
                    throw new Exception("Ошибка!");
            }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public int Corners
        {
            get { return num; }
            set { if (value >= 0||value!=1||value!=2) num = value; else throw new Exception("Ошибка!"); } //проверка на отрицательное кол-во углов и пр.
        }
        public figure()
        {
            
        }
        public figure(double r)
        {
            Corners = 0;
            Type = "КРУГ";
            R = r;
            Sides = null;
        }
        public figure(int corners_num)
        {
            Corners = corners_num;
        }
        public figure(double r, double[] sides)
        {
            Corners = sides.Length;
            R = r;
            Sides = sides;
        }
        public figure(double r, string type, double[] sides)
        {
            Corners = sides.Length;
            Type = type;
            R = r;
            Sides = sides;
        }
        public double GetS()
        {
            if (num == 0) return 3.14 * r * r;//площадь, если круг
            foreach (double item in sides)
                p += item;//подсчет периметра
            if (num == 3) return Math.Sqrt(p / 2 * (p / 2 - sides[0]) * (p / 2 - sides[1]) * (p / 2 - sides[2]));//площадь если треугольник
            return (p*r)/2;//площадь любого другого многоугольника
        }
        public bool IsRight()
        {
            if (num == 3)
            {
                Array.Sort(sides);
                double a2 = sides[0] * sides[0];
                double b2 = sides[1] * sides[1];
                double c2 = sides[2] * sides[2];
                if (a2 + b2 == c2)//прямоугольный ли треугольник??
                    return true;
                else
                    return false;
            }
            else
                throw new Exception("Не треугольник!");
        }
    }
}
