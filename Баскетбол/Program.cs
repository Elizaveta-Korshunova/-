 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Баскетбол
{
    static class Program
    {
        
        public static int КолСборных = 12;
        public static Сборные [] Группа1;
        public static Сборные [] Группа2;
        public static Сборные[] Четвертьфинал;
        public static Сборные[] Полуфинал;
        public static Сборные[] Финал;
        public static Сборные[] Итог;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
