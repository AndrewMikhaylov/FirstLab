using System;
namespace FirstLab
{
    public class Check
    {
        static void Main(string[] args)
        {
            MyList<int> newList = new MyList<int>();
            newList.DataAdded += newList.EventHadler;
            newList.Add(2);
            newList.Add(4);
            newList.Add(5);
            newList.Add(6);
            newList.Add(16);
            newList.Remove(5);
            DoubleNode<int> current = newList.Find(2);
            DoubleNode<int> newNod = newList.Find(16);
            newList.AddBefore(44, current);
            
            foreach (var item in newList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(newList.Count);
            Console.WriteLine(newList.Contains(5));
            newList.Clear();
            Console.WriteLine(newList.Count);
        }
    }
}