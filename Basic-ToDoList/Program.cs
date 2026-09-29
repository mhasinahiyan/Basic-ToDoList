using System;
using System.Windows.Forms;

namespace MyTodoApp   // ← match your namespace
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ToDoList());   // ← ToDoList, not Form1
        }
    }
}