using System;
using System.Security.Cryptography.X509Certificates;

namespace Classes
{
    public class Point
    {
        private double x;
        private double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public double GetX() { return x; }
        public double GetY() { return y; }
        public void SetX(double x) { this.x = x; }
        public void SetY(double y) { this.y = y; }
        public override string ToString() { return string.Format("({0},{1})",this.x,this.y); }
    }
    public class AutoArray 
    {
        private int[] arr;
        private int size;
        public AutoArray(int n, int size) 
        {
            Random rnd = new Random();
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(1,n+1);
            }
            this.arr = arr;
            this.size = size;
        }
        public void SetElement(int index, int value)
        {
            this.arr[index] = value;
        }
        public int SumArray()
        {
            int sum = 0;
            for (int i = 0; i < this.size; i++)
            {
                sum += this.arr[i];
            }
            return sum;
        }
        public double Average()
        {
            double sum = (double)SumArray();
            return sum/(double)this.size;
        }
        public int CountAbove(int x)
        {
            int count = 0;
            for (int i = 0; i < this.size; i++)
            {
                if (this.arr[i] > x) count++;
            }
            return count;
        }
        public bool Contains(int x)
        {
            for (int i = 0; i < this.size; i++)
            {
                if (this.arr[i] == x) return true;
            } return false;
        }
        public void Sort(char sign)
        {
            bool swapped = false;
            for (int i = 0; i < this.size - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < this.size - 1 - i; j++)
                {
                    bool res = false;
                    if (sign == '+') res = this.arr[j] > this.arr[j + 1];
                    if (sign == '-') res = this.arr[j] < this.arr[j + 1];
                    if (res)
                    {
                        int temp = this.arr[j];
                        this.arr[j] = this.arr[j + 1];
                        this.arr[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
            }
        }
        public bool ArrayIsEqual(AutoArray a1)
        {
            for (int i = 0; i < this.size; i++)
            {
                if (this.arr[i] != a1.arr[i]) return false;
            }
            return true;   
        }
        public override string ToString()
        {
            string str = "[";
            for (int i = 0; i < this.size -1 ; i++) { str += this.arr[i] + ", "; }
            str += this.arr[this.size-1] + "]";
            return str;
        }
    } 
    public class Date
    {
        private int day;
        private int month;
        private int year;
        public Date(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }
        public int GetDay() { return day; }
        public int GetMonth() { return month; }
        public int GetYear() { return year; }
        public void SetDay(int day) { this.day = day;}
        public void SetMonth(int month) { this.month = month; }
        public void SetYear(int year) { this.year = year;}
        public int CalcAge(Date birthday)
        {
            int age;
            age = birthday.GetYear() - this.year;
            if (birthday.GetMonth() > this.month) { age--; }
            else if (birthday.GetMonth() == this.month && birthday.GetDay() > this.day) { age--; }
            return age;
        }
        public bool After(Date compDate)
        {
            if (compDate.GetYear() != this.year) return false;
            if (compDate.GetMonth() != this.month) return false;
            if (compDate.GetDay() != this.day) return false;
            return true;
        }
        public int CheckYear(Date[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].GetYear() == this.year) count++;
            }
            return count;
        }
        public override string ToString()
        {
            return $"{this.day}/{this.month}/{this.year}";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lavi Presenting: ");
            string task = "";
            do {
                Console.Write("---\nEnter task number (1 - 11) or (_) to exit: \n=> ");
                task = Console.ReadLine();
                Console.WriteLine("---");
                switch (task) 
                {
                    case "1": Console.WriteLine("Ex 01: \n"); TestPoint(); break;
                    case "2": Console.WriteLine("Ex 02: \n"); TestArray(); break;
                    case "3": Console.WriteLine("Ex 03: \n"); TestDate() ; break;
                    case "_": Console.WriteLine("bye"); break;
                    default: Console.WriteLine("Enter valid number"); break;
                }
            } while (task != "_");
        }

        static void TestPoint()
        {
            Point p1 = new Point(43, 7);
            Point p2 = new Point(5, 5);
            Console.WriteLine("{0}, {1}", p1.ToString(), p2.ToString());
            double temp = p1.GetX();
            p1.SetX(p2.GetX());
            p2.SetX(temp);
            Console.WriteLine("{0}, {1}", p1.ToString(), p2.ToString());
        }
        static void TestArray()
        {
            AutoArray a = new AutoArray(20, 10);
            AutoArray b = new AutoArray(20, 10);
            Console.WriteLine($"a = {a.ToString()}\nb = {b.ToString()}");
            Console.WriteLine($"a - sum = {a.SumArray()}, avreage = {a.Average()}\nb - sum = {b.SumArray()}, avreage = {b.Average()}");
            Console.WriteLine($"{a.CountAbove(13)} items are above 13 in array a");
            if (b.Contains(9)) { Console.WriteLine("Array b does contain 9!"); } else { Console.WriteLine("Array b does not contain 9!"); }
            if (a.ArrayIsEqual(b)) { Console.WriteLine("The arrays are equal!"); } else { Console.WriteLine("The arrays are not equal!"); }
            a.Sort('+'); Console.WriteLine($"a = {a.ToString()}");
            b.Sort('-'); Console.WriteLine($"b = {b.ToString()}");
        }
        static void TestDate()
        {
            Date d1 = new Date(20, 10, 1935);
            Date d2 = new Date(21, 8, 1995);
            Console.WriteLine($"Date 1 = {d1.ToString()}\nDate 2 = {d2.ToString()}");
        }
    }
}