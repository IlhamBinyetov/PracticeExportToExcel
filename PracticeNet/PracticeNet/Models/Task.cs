using System;
using static PracticeNet.Models.Task;

namespace PracticeNet.Models
{
    public class Task
    {
        public delegate void MyDelegate(string msg);

        




        static void MethodA(string message)
        {
            Console.WriteLine(message);
        }

        MyDelegate myDelegate = new MyDelegate(MethodA);

        
    }
}
