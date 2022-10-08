using System;

namespace FirstLab
{
    public class DataEventArgs<T> : EventArgs
    {
        public  T MyData { get; set; }
    }
}