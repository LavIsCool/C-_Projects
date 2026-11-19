using System;

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
            age = this.year - birthday.GetYear();
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
    public class Cycle
    {
        private double x;
        private double y;
        private double radius;
        private double pi = Math.PI;

        public Cycle(double x, double y, double radius)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }
        public double GetX() { return this.x; }
        public double GetY() { return this.y; }
        public double GetRadius() { return this.radius; }
        public void SetX(double x) { this.x = x; }
        public void SetY(double y) { this.y = y; }
        public void SetRadius(double radius) { this.radius = radius; }
        public double CalcSurface() { return this.pi * this.radius * this.radius; }
        public double CalcPerimeter() { return 2 * this.pi * this.radius; }
        public bool Inside(double x, double y) { return (x - this.x) * (x - this.x) - (y - this.y) * (y - this.y) < this.radius * this.radius; }
        public double CalcArc(double angel) { return CalcPerimeter() * (angel/360); }
        public override string ToString() { return $"({this.x},{this.y}), radius = {this.radius}"; }
    }
    public class Polynom
    {
        private double a;
        private double b;
        public Polynom(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        public double GetA() { return this.a; }
        public double GetB() { return this.b; }
        public void SetA(double a) { this.a = a; }
        public void SetB(double b) { this.b = b; }
        public double Result(double x) { return this.a * x + this.b; }
        public double ConnectX() { return -this.b / this.a; }
        public double ConnectY() { return this.b; }
        public Polynom Add(Polynom P) { return new Polynom(P.GetA() + this.a, P.GetB() + this.b); }
        public bool OnPolynom(double x, double y) { return Result(x) == y; }
        public override string ToString() { return $"{this.a}x + {this.b}"; }
    }
    public class Rectangle
    {
        private double x;
        private double y;
        private double width;
        private double length;
        public Rectangle(double length, double width, double x, double y)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.length = length;
        }
        public double GetLength() { return this.length; }
        public double GetWidth()  { return this.width;  }
        public double GetPointX() { return this.x; }
        public double GetPointY() { return this.y; }
        public void SetLength(double length) { this.length = length; }
        public void SetWidth(double width) { this.width = width; }
        public void SetPointX(double x) { this.x = x; }
        public void SetPointY(double y) { this.y = y; }
        public double CalcArea() { return this.length * this.width; }
        public double CalcPerimeter() { return 2 * (this.length + this.width); }
        public bool IsInside(double x, double y) { return (x - this.x <= this.length && x - this.x >= 0) && (y - this.y <= this.width && y - this.y >= 0); }
        public override string ToString() { return $"Rectangle({this.length}X{this.width}) in Point ({this.x}, {this.y})"; }
    }
    public class Account
    {
        private int accountNum;
        private string ownerName = "";
        private double balance;
        public Account(int accountNum, string ownerName, double balance)
        {
            this.accountNum = accountNum;
            this.ownerName = ownerName;
            this.balance = balance;
        }
        public void Deposit(double amount) { this.balance += amount; }
        public void Withdraw(double amount) { this.balance -= amount; }
        public int GetAccountNum() { return accountNum; }
        public string GetOwnerName() { return ownerName; }
        public double GetBalance() { return balance; }
        public override string ToString() { return $"Num: {this.accountNum}, Name: {this.ownerName}, Balance: {this.balance}"; }
    }
    public class Bucket
    {
        private int capacity;
        private double water = 0;
        public Bucket(int capacity) { this.capacity = capacity; }
        public void Empty() { this.water = 0; }
        public bool IsEmpty() { return this.capacity == 0; }
        public void Fill(double amountToFill) { this.water += amountToFill; if (this.water > (double)this.capacity) this.water = (double)this.capacity; }
        public int GetCapacity() { return this.capacity; }
        public double GetCurrentAmount() { return water; }
        public void PourInto(Bucket bucketInto)
        {
            int inCpacity = bucketInto.GetCapacity();
            double inWater = bucketInto.GetCurrentAmount();
            double inEmpty = (double)inCpacity - inWater;
            if (inEmpty == 0) return;
            if (inEmpty >= this.water)
            {
                bucketInto.Fill(this.water);
                this.Empty();
                return;
            }
            bucketInto.Fill(this.water);
            this.water -= inEmpty;
        }
        public override string ToString() { return $"The capacity: {this.capacity}\nThe current amount of water: {this.water}"; }
    }
    public class Rational
    {
        private int x;
        private int y;
        public Rational(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int GetNumerator() { return x; }
        public int GetDenom() { return y; }
        public bool IsEqual(Rational num) { return (double)this.x / (double)this.y == (double)num.GetNumerator() / (double)num.GetDenom(); }
        public Rational Multiply(Rational num) { return new Rational(this.x * num.GetNumerator(), this.y * num.GetDenom()); }
        public Rational Divide(Rational num) { if (num.GetNumerator() == 0) return null; return new Rational(this.x * num.GetDenom(), this.y * num.GetNumerator()); }
        public override string ToString() { return $"{this.x}/{this.y}"; }
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
                    case  "1": Console.WriteLine("Ex 01: \n"); TestPoint(); break;
                    case  "2": Console.WriteLine("Ex 02: \n"); TestArray(); break;
                    case  "3": Console.WriteLine("Ex 03: \n"); TestDate() ; break;
                    case  "4": Console.WriteLine("Ex 04: \n"); TestCycle(); break;
                    case  "5": Console.WriteLine("Ex 05: \n"); TestPolynom(); break;
                    case  "6": Console.WriteLine("Ex 06: \n"); TestRect(); break;
                    case  "7": Console.WriteLine("Ex 07: \n"); TestRect2(); break;
                    case  "8": Console.WriteLine("Ex 08: \n"); TestAccount(); break;
                    case  "9": Console.WriteLine("Ex 09: \n"); TestAccount2(); break;
                    case "10": Console.WriteLine("Ex 10: \n"); TestBucket(); break;
                    case "11": Console.WriteLine("Ex 11: \n"); TestRational(); break;
                    case  "_": Console.WriteLine("bye"); break;
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
            Date date1 = new Date(20, 10, 1935);
            Date date2 = new Date(21, 8, 1995);
            Console.WriteLine($"Date 1 = {date1.ToString()}\nDate 2 = {date2.ToString()}");
            date1.SetDay(15);
            date2.SetYear(1997);
            Console.WriteLine($"Date 1 = {date1.ToString()}\nDate 2 = {date2.ToString()}");
            Date birth = new Date(5, 11, 1997);
            Date current = new Date(18, 11, 2026);
            Console.WriteLine($"Birthday = {birth.ToString()}\nCurrent Date = {current.ToString()}\nAge = {current.CalcAge(birth)}");
            Date d1 = new Date(17, 6, 1979);
            Date d2 = new Date(2, 4, 1981);
            if (d1.After(d2)) Console.WriteLine("d1 is After d2");
            else Console.WriteLine("d2 is After d1");
            Date[] arrDate = new Date[10];
            Console.WriteLine("Enter 10 dates: ");
            for (int i = 0; i < arrDate.Length; i++)
            {
                Console.Write("day => ");
                int day = int.Parse(Console.ReadLine());
                Console.Write("month => ");
                int month = int.Parse(Console.ReadLine());
                Console.Write("year => ");
                int year = int.Parse(Console.ReadLine());
                arrDate[i] = new Date(day, month, year);
                Console.WriteLine();
            }
            Date comp = new Date(1, 1, 2000);
            int count = comp.CheckYear(arrDate);
            Console.WriteLine($"{count} dates are in the year 2000");
        }
        static void TestCycle()
        {
            Cycle a = new Cycle(3, 8.25, 2.5);
            Cycle b = new Cycle(1, 2.3, 5);
            Console.WriteLine($"a = {a.ToString()}\nSa = {a.CalcSurface()}");
            Console.WriteLine($"b = {b.ToString()}\nPb = {b.CalcPerimeter()}");
            a.SetRadius(6.45);
            Console.WriteLine($"a = {a.ToString()}");
            b.SetX(4.3); b.SetY(1.5);
            Console.WriteLine($"b = {b.ToString()}");
            Console.Write("Enter a point:\nx => ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("y => ");
            double y = double.Parse(Console.ReadLine());
            bool inA = a.Inside(x, y);
            bool inB = b.Inside(x, y);
            if (inA && inB) Console.WriteLine("The point is inside both circles");
            else if (inA) Console.WriteLine("The point is inside circle a");
            else if (inB) Console.WriteLine("The point is inside circle b");
            else Console.WriteLine("The point is outside both circles");
            if (a.CalcArc(35) > b.CalcArc(35)) Console.WriteLine($"a has a bigger Arc of {a.CalcArc(35)}");
            else if (a.CalcArc(35) < b.CalcArc(35)) Console.WriteLine($"a has a bigger Arc of {b.CalcArc(35)}");
            else Console.WriteLine($"Both Arcs are equal {b.CalcArc(35)}");
        }
        static void TestPolynom()
        {
            Polynom f = new Polynom(3, 4);
            Polynom g = new Polynom(7.5, 9);
            Console.WriteLine($"f(x) = {f.ToString()}\ng(x) = {g.ToString()}");
            Console.WriteLine($"f(3) = {f.Result(3)}");
            Console.WriteLine($"g(1.25) = {g.Result(1.25)}");
            Console.WriteLine($"({f.ConnectX()}, 0)");
            Console.WriteLine($"(0, {g.ConnectY()})");
            Console.Write("Enter a point:\nx => ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("y => ");
            double y = double.Parse(Console.ReadLine());
            bool Onf = f.OnPolynom(x, y);
            bool Ong = g.OnPolynom(x, y);
            if (Onf && Ong) Console.WriteLine("The point is on both functions");
            else if (Onf) Console.WriteLine("The point is on function f");
            else if (Ong) Console.WriteLine("The point is on function g");
            else Console.WriteLine("The point is not on either function");

        }
        static void TestRect()
        {
            Rectangle a = new Rectangle(3, 5, 9, 1.5);
            Rectangle b = new Rectangle(9, 6, 3, 4.5);
            Console.WriteLine($"a = {a.ToString()}\nSa = {a.CalcArea()}");
            Console.WriteLine($"b = {b.ToString()}\nPb = {b.CalcPerimeter()}");
            a.SetPointX(1); a.SetPointY(2);
            Console.WriteLine($"a = {a.ToString()}");
            b.SetLength(2); b.SetWidth(3);
            Console.WriteLine($"b = {b.ToString()}");
            Console.Write("Enter a point:\nx => ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("y => ");
            double y = double.Parse(Console.ReadLine());
            bool inA = a.IsInside(x, y);
            bool inB = b.IsInside(x, y);
            if (inA && inB) Console.WriteLine("The point is inside both rectangles");
            else if (inA) Console.WriteLine("The point is inside rectangle a");
            else if (inB) Console.WriteLine("The point is inside rectangle b");
            else Console.WriteLine("The point is outside both rectangles");
        }
        static void TestRect2()
        {
            Rectangle[] arrRect = new Rectangle[10];
            Console.WriteLine("Enter 10 Rectangles: ");
            for (int i = 0; i < arrRect.Length; i++)
            {
                Console.Write("length => ");
                double length = double.Parse(Console.ReadLine());
                Console.Write("width => ");
                double width = double.Parse(Console.ReadLine());
                Console.Write("x => ");
                double X = double.Parse(Console.ReadLine());
                Console.Write("y => ");
                double Y = double.Parse(Console.ReadLine());
                arrRect[i] = new Rectangle(length, width, X, Y);
                Console.WriteLine();
            }
            Console.Write("Enter point:\nx => ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("y => ");
            double y = double.Parse(Console.ReadLine());
            Rectangle smol = arrRect[0];
            double smolSize = smol.CalcArea();
            bool found = false;
            for (int i = 1; i < arrRect.Length; i++)
            {
                if (arrRect[i].IsInside(x, y)) 
                {
                    found = true; 
                    if (arrRect[i].CalcArea() < smolSize) { smol = arrRect[i]; smolSize = smol.CalcArea(); }
                } 
            }
            if (!found) Console.WriteLine("The point is not in any rectangle");
            else Console.WriteLine(smol.ToString());
        }
        static void TestAccount()
        {
            Console.Write("Enter your name to create a new account:\n=> ");
            string name = Console.ReadLine();
            Account user = new Account(123, name, 100);
            Console.Write("Enter amount to deposit:\n=> ");
            double money = int.Parse(Console.ReadLine());
            user.Deposit(money);
            Console.WriteLine(user.ToString());
        }
        static void TestAccount2()
        {
            Account[] arr = new Account[20];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("Enter your name to create a new account:\n=> ");
                string name = Console.ReadLine();
                Console.Write("Enter starting amount:\n=> ");
                double money = int.Parse(Console.ReadLine());
                arr[i] = new Account(i, name, money);
                Console.WriteLine();
            }
            Console.Write("Enter account number:\n=> ");
            int num = int.Parse(Console.ReadLine());
            Console.Write("Enter your name:\n=> ");
            string user = Console.ReadLine();
            if (arr[num].GetOwnerName() != user) Console.WriteLine("Error *Wrong name or account number*");
            else
            {
                Console.Write("Enter amout to withdraw:\n=> ");
                double amount = int.Parse(Console.ReadLine());
                if (arr[num].GetBalance() >= amount)
                {
                    arr[num].Withdraw(amount);
                    Console.WriteLine($"New balance: {arr[num].GetBalance()}");
                }
                else Console.WriteLine("Error *You are too poor to withdraw this amount*");
            }
        }
        static void TestBucket() 
        {
            Console.Write("Enter sub task number: \n=> ");
            string task = Console.ReadLine();
            Console.WriteLine();
            switch (task)
            {
                case "1": Console.WriteLine("Sub 01: \n"); task101(); break;
                case "2": Console.WriteLine("Sub 02: \n"); task102(); break;
                case "3": Console.WriteLine("Sub 03: \n"); task103(); break;
                default: Console.WriteLine("Enter valid number"); break;
            }
        }
        static void task101()
        {
            int capacity = 10;
            Bucket[] arr = new Bucket[6];
            double water = (double)capacity;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Bucket(capacity);
                arr[i].Fill(Math.Pow(2, -i) *water);
                Console.WriteLine($"[{i}]:\n{arr[i].ToString()}");
            }
        }
        static void task102()
        {
            Console.Write("Enter number of buckets:\n=> ");
            int n = int.Parse(Console.ReadLine());
            Bucket[] arr = new Bucket[n];
            Random rnd = new Random();
            double max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Bucket(20);
                double water = rnd.NextDouble() * 20;
                arr[i].Fill(water);
                if (water > max) max = water;
                Console.WriteLine($"[{i}]:\n{arr[i].ToString()}");
            }
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].Empty();
                arr[i].Fill(max);
                Console.WriteLine($"[{i}]:\n{arr[i].ToString()}");
            }
        }
        static void task103()
        {
            Console.Write("Enter number of buckets:\n=> ");
            int n = int.Parse(Console.ReadLine());
            Bucket[] arr = new Bucket[n];
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                int capacity = rnd.Next(11);
                arr[i] = new Bucket(capacity);
                double water = rnd.NextDouble() * capacity;
                arr[i].Fill(water);
                Console.WriteLine($"[{i}]:\n{arr[i].ToString()}");
            }
            Bucket[] newArr = new Bucket[n];
            newArr = arr;
            for (int i = 0;i < newArr.Length - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < newArr.Length - 1 - i; j++)
                {
                    double water0 = newArr[j].GetCurrentAmount();
                    double water1 = newArr[j+1].GetCurrentAmount();
                    if (water0 > water1)
                    {
                        swapped = true;
                        Bucket temp = newArr[j];
                        newArr[j] = newArr[j+1];
                        newArr[j+1] = temp;
                    }
                }
                if (!swapped) break;
            }
            Console.WriteLine("\nSorted:\n");
            for (int i = 0; i < newArr.Length; i++)
            {
                Console.WriteLine($"[{i}]:\n{newArr[i].ToString()}");
            }
        }
        static void TestRational()
        {
            Console.Write("Enter numerator:\n=> ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Enter denominator:\n=> ");
            int y = int.Parse(Console.ReadLine());
            Rational a = new Rational(x, y);
            Console.Write("\nEnter numerator:\n=> ");
            x = int.Parse(Console.ReadLine());
            Console.Write("Enter denominator:\n=> ");
            y = int.Parse(Console.ReadLine());
            Rational b = new Rational(x, y);
            Console.WriteLine($"a = {a.ToString()}, b = {b.ToString()}");
            a = low(a); b = low(b);
            Console.WriteLine($"a = {a.ToString()}, b = {b.ToString()}");
            Console.WriteLine($"a + b = {add(a, b).ToString()}");
            Console.WriteLine($"a - b = {add(a, b, '-').ToString()}");
            Console.WriteLine($"a / b = {low(a.Divide(b))}");
            Console.WriteLine($"a * b = {low(a.Multiply(b))}");
            Rational Thirty = new Rational(15, 30);
            Rational half = new Rational(1, 2);
            if (Thirty.IsEqual(half)) Console.WriteLine($"{Thirty.ToString()} is equal to {half.ToString()}");
            else Console.WriteLine($"{Thirty.ToString()} is not equal to {half.ToString()}");
        }
        static Rational add(Rational a, Rational b, char sign = '+')
        {
            if (sign == '-') b = b.Multiply(new Rational(-1,1));
            return low(new Rational(a.GetNumerator()*b.GetDenom()+a.GetDenom()*b.GetNumerator(), a.GetDenom()*b.GetDenom()));
        }
        static Rational low(Rational num)
        {
            int x = num.GetNumerator();
            int y = num.GetDenom();
            int a = Math.Abs(x);
            int b = Math.Abs(y);
            while (b != 0)
            {
                int remainder = a % b;
                a = b;
                b = remainder;
            }
            return new Rational(x/a, y/a);
        }
    }
}