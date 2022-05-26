using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    internal class PriceList
    {
        public abstract class Device
        {
            public abstract string Name { get; set; }
            public abstract string Description { get; set; }
            public virtual string Type { get; set; }
            public abstract int Quantity { get; set; }
            public abstract float Price { get; set; }

            public Device(string N) { }
            public Device(string N, string D, string T, int Q, float P)
            {
                Name = N;
                Description = D;
                Type = T;
                Quantity = Q;
                Price = P;
            }
            public virtual void Print()
            {
                for (int i = 0; i < Quantity; i++)
                {

                    Console.WriteLine($"Назва носiя: {Name} \nВиробник:" +
                        $" { Description} \nМодель: { Type} \nКiлькiсть: {Quantity} \nВартiсть: {Price}");
                }
            }
            public virtual void Loading()
            {
                FileStream file = new FileStream("d:\\test.txt", FileMode.Open, FileAccess.Read);
            }
            public virtual void Save()
            {
                File.WriteAllText("D:\\new_file.txt", "Носiї інформацiї");
            }


            public class Flash : Device
            {
                public int Memory { get; set; }
                public double Speed { get; set; }
                public Flash(string v) : base("Флeш-накопичувач") { }
                public Flash(string N, string D, string T, int Q, float P, int M, double S) : base(N, D, T, Q, P)
                {
                    Memory = M;
                    Speed = S;
                }

                public override string Name { get; set; }
                public override string Description { get; set; }
                public override int Quantity { get; set; }
                public override float Price { get; set; }

                public override sealed void Print()
                {
                    base.Print();
                    Console.WriteLine($"Пам'ять: {Memory}\nШвидкiсть: {Speed}");
                }

                public override sealed void Loading()
                {
                    base.Loading();
                }

                public override sealed void Save()
                {
                    base.Save();                   
                }
            }
            public class DVD : Device
            {
                public int Speed_write { get; set; }
                public int Speed_read { get; set; }
                public DVD(string v) : base("DVD дiск") { }
                public DVD(string N, string D, string T, int Q, float P, int W, int R) : base(N, D, T, Q, P)
                {
                    Speed_write = W;    
                    Speed_read = R;                    
                }

                public override string Name { get; set; }
                public override string Description { get; set; }
                public override int Quantity { get; set; }
                public override float Price { get; set; }

                public override sealed void Print()
                {
                    base.Print();
                    Console.WriteLine($"Швидкiсть запису: {Speed_write}\nШвидкiсть читання: {Speed_read}");
                }

                public override sealed void Loading()
                {
                    base.Loading();
                }

                public override sealed void Save()
                {
                    base.Save();
                }
            }
            public class HDD : Device
            {
                public int Size { get; set; }
                public int Speed { get; set; }
                public HDD(string v) : base("HDD") { }
                public HDD(string N, string D, string T, int Q, float P, int S, int Sp) : base(N, D, T, Q, P)
                {
                    Size = S;
                    Speed = Sp;
                }

                public override string Name { get; set; }
                public override string Description { get; set; }
                public override int Quantity { get; set; }
                public override float Price { get; set; }

                public override sealed void Print()
                {
                    base.Print();
                    Console.WriteLine($"Розмiр: {Size}\nШвидкiсть: {Speed}");
                }

                public override sealed void Loading()
                {
                    base.Loading();
                }

                public override sealed void Save()
                {
                    base.Save();
                }
            }

            class List : IList
            {
                private object[] _contents = new object[10];
                private int _count;

                public List()
                {
                    _count = 0;
                }

                public int Add(object value)
                {
                    if (_count < _contents.Length)
                    {
                        _contents[_count] = value;
                        _count++;

                        return (_count - 1);
                    }

                    return -1;
                }

                public void Clear()
                {
                    _count = 0;
                }

                public bool Contains(object value)
                {
                    for (int i = 0; i < Count; i++)
                    {
                        if (_contents[i] == value)
                        {
                            return true;
                        }
                    }
                    return false;
                }

                public int IndexOf(object value)
                {
                    for (int i = 0; i < Count; i++)
                    {
                        if (_contents[i] == value)
                        {
                            return i;
                        }
                    }
                    return -1;
                }

                public void Insert(int index, object value)
                {
                    if ((_count + 1 <= _contents.Length) && (index < Count) && (index >= 0))
                    {
                        _count++;

                        for (int i = Count - 1; i > index; i--)
                        {
                            _contents[i] = _contents[i - 1];
                        }
                        _contents[index] = value;
                    }
                }

                public bool IsFixedSize
                {
                    get
                    {
                        return true;
                    }
                }

                public bool IsReadOnly
                {
                    get
                    {
                        return false;
                    }
                }

                public void Remove(object value)
                {
                    RemoveAt(IndexOf(value));
                }

                public void RemoveAt(int index)
                {
                    if ((index >= 0) && (index < Count))
                    {
                        for (int i = index; i < Count - 1; i++)
                        {
                            _contents[i] = _contents[i + 1];
                        }
                        _count--;
                    }
                }

                public object this[int index]
                {
                    get
                    {
                        return _contents[index];
                    }
                    set
                    {
                        _contents[index] = value;
                    }
                }

               
                public void CopyTo(Array array, int index)
                {
                    for (int i = 0; i < Count; i++)
                    {
                        array.SetValue(_contents[i], index++);
                    }
                }

                public int Count
                {
                    get
                    {
                        return _count;
                    }
                }

                public bool IsSynchronized
                {
                    get
                    {
                        return false;
                    }
                }                
                public object SyncRoot
                {
                    get
                    {
                        return this;
                    }
                }
               
                public IEnumerator GetEnumerator()
                {                    
                    throw new NotImplementedException("The method or operation is not implemented.");
                }

                public void PrintList()
                {
                   
                    Console.Write("List contents:");
                    for (int i = 0; i < Count; i++)
                    {
                        Console.Write($" {_contents[i]}");
                    }
                    Console.WriteLine();
                }
            }

            private static void DrawMenu(string[] items, int row, int col, int index)
            {
                Console.SetCursorPosition(col, row);
                for (int i = 0; i < items.Length; i++)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(items[i]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }


            static void Main(string[] args)
            {
                List<Device> devices = new List<Device>();
                var list = new List();
                devices.Add(new HDD("HDD", "ADATA", "DashDrive Durable", 2, 1629, 1, 5));
                devices.Add(new Flash("Флeш-накопичувач", "Kingston", "DataTraveler ", 20, 252, 64, 3.0));
                devices.Add(new DVD("DVD-дiск", "Verbatim", "43552", 10, 437, 16, 16));
                Console.WriteLine("Прайс - лист");
                Console.WriteLine("1.Друк прайс-листа" + "\n2.Видалення носiя" + "\n3.Додавання носiя" + "\n4.Змiна параметрiв" + "\n5.Пошук" + "\n6.Вихiд");
                Console.WriteLine("Зробить свiй вибiр");

                int number = Convert.ToInt32(Console.ReadLine());
                switch (number)
                {
                    case 1:
                        Console.WriteLine("Обрано друк прайс-листа\n");                        
                        foreach (var device in devices)
                        {
                            Console.WriteLine(device.Name + " " + device.Description + " " + device.Type + device.Quantity);
                        }
                        return;
                    case 2:
                        Console.WriteLine("Обрано видалення носiя\n");                        
                        devices.RemoveRange(2, 1);                       
                        foreach (var device in devices)
                        {
                            Console.WriteLine(device.Name + " " + device.Description + " " + device.Type + device.Quantity);
                        }
                        return;
                    case 3:
                        Console.WriteLine("Обрано додавання носiя\n");
                        devices.Add(new DVD("DVD-дiск", "Verbatim", "43552", 8, 602, 16, 32));
                        foreach (var device in devices)
                        {
                            Console.WriteLine(device.Name + " " + device.Description + " " + device.Type + device.Quantity);
                        }
                        return;
                    case 4:
                        Console.WriteLine("Обрано змiна параметрiв\n");
                        devices[0].Name = "DVD-дiск";
                        foreach (var device in devices)
                        {
                            Console.WriteLine(device.Name + " " + device.Description + " " + device.Type + device.Quantity);
                        }
                        return;
                    case 5:
                        Console.WriteLine("Обрано пошук\n");                        
                        Console.WriteLine(devices.Contains(devices[1]));
                        return;

                    default:
                        Console.WriteLine("Обрано вихiд\n");
                        break;
                }               

                //var list = new List();
                //list.Add(new HDD("HDD", "ADATA", "DashDrive Durable", 2, 1629, 1, 5));
                //list.Add(new Flash("Флeш-накопичувач", "Kingston", "DataTraveler ", 20, 252, 64, 3.0));
                //list.Add(new DVD("DVD-дiск", "Verbatim", "43552", 10, 437, 16, 16));
                //list.PrintList();
                //Flash f = new Flash("Флeш-накопичувач", "Kingston", "DataTraveler ", 20, 252, 64, 3.0);
                //f.Print();
                //f.Save();
                //f.Loading();
                //Console.WriteLine();

                //Device d = new DVD("DVD-дiск", "Verbatim", "43552", 10, 437, 16, 16);
                //d.Print();
                //d.Save();
                //d.Loading();
                //Console.WriteLine();

                //Device dv = new HDD("HDD", "ADATA", "DashDrive Durable", 2, 1629, 1, 5);
                //dv.Print();
                //dv.Save();
                //dv.Loading();
                //Console.WriteLine();
            }
        }
    }
}
