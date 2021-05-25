using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Баскетбол
{
    public class Сборные
    {
        public string Страна;
        public string СтранаЧФ;
        public int ИндексРезультатов;
        public int[] ЗаброшенныеМячи;
        public int[] ПропущенныеМячи;
        public int[] РазницаЗабИПроп;
        public int Результат;
        public int ЛучшаяРазница;
        public int СуммаПроп;
        public int МестоГруппа;
        public int РезультатЧФ;
        public int МестоИтог;


        public static int СравнитьСБ(Сборные а, Сборные б)
        {
            if (а.Результат > б.Результат) // по очкам
                return -1;
            else if (а.Результат < б.Результат)
                return 1;
            else if (а.ЛучшаяРазница > б.ЛучшаяРазница) // по лучшей разнице пропущенных и заброшенных мячей
                return -1;
            else if (а.ЛучшаяРазница < б.ЛучшаяРазница)
                return 1;
            else if (а.СуммаПроп < б.СуммаПроп) // по наименьшему количеству пропущенных мячей
                return -1;
            else if (а.СуммаПроп > б.СуммаПроп)
                return 1;
            else if (а.ЗаброшенныеМячи[б.ИндексРезультатов] > б.ЗаброшенныеМячи[а.ИндексРезультатов]) // по результатам игр между собой
                return -1;
            else if (а.ЗаброшенныеМячи[б.ИндексРезультатов] < б.ЗаброшенныеМячи[а.ИндексРезультатов])
                return 1;
            else
                return 0;
        }
    }
}
