using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp_LINQ_App
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Comp_model> compModels = new List<Comp_model>()
            {
                new Comp_model(){ Code=01, Name="LENOVO", TypeProc="INTEL",HzProc=2.3,V_OZU=32,V_SSD=512, V_UHD=6,Cost=70000,Count=5},
                new Comp_model(){ Code=02, Name="LENOVO", TypeProc="INTEL CORE i3",HzProc=2.3,V_OZU=32,V_SSD=512, V_UHD=6,Cost=75000,Count=8},
                new Comp_model(){ Code=03, Name="LENOVO", TypeProc="INTEL CORE i5",HzProc=2.3,V_OZU=32,V_SSD=512, V_UHD=6,Cost=100000,Count=15},
                new Comp_model(){ Code=04, Name="ASUS", TypeProc="AMD EPYC",HzProc=2.3,V_OZU=16,V_SSD=256, V_UHD=6,Cost=63000,Count=31},
                new Comp_model(){ Code=05, Name="ASUS", TypeProc="AMD EPYC",HzProc=2.3,V_OZU=64,V_SSD=512, V_UHD=6,Cost=115000,Count=9},
                new Comp_model(){ Code=06, Name="ASUS", TypeProc="AMD Ryzen",HzProc=2.3,V_OZU=32,V_SSD=512, V_UHD=6,Cost=93000,Count=20},
            };

            // LINQ реализован через синтаксис на основе метода расширений

            Console.WriteLine("Введите тип процессора");
            string Proc = Console.ReadLine();
            List<Comp_model> compModelsPr = compModels.Where(x => x.TypeProc == Proc).ToList();
            Print(compModelsPr);

            Console.WriteLine("Введите требуемый объем ОЗУ");
            int vOZU = Convert.ToInt32(Console.ReadLine());
            List<Comp_model> compModelsvOZU = compModels.Where(x => x.V_OZU >= vOZU).ToList();
            Print(compModelsvOZU);

            Console.WriteLine("Сортировка по стоимости");
            Console.ReadKey();

            List<Comp_model> compModelsSort = compModels.OrderBy(x => x.Cost).ToList();
            Print(compModelsSort);

            Console.WriteLine("Группировка по типу");
            Console.ReadKey();

            IEnumerable<IGrouping<string, Comp_model>> compModelsGr = compModels.GroupBy(x => x.TypeProc);
            foreach (IGrouping<string, Comp_model> catalog in compModelsGr)
            {
                Console.WriteLine(catalog.Key);
                Console.WriteLine();
                foreach (Comp_model m in catalog)
                {
                    Console.WriteLine($"Код {m.Code:D2}; {m.Name}; {m.TypeProc}; объем диска {m.V_SSD} Гб; объем видеокарты {m.V_UHD} Гб. Стоимость {m.Cost}; наличие {m.Count}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Поиск по стоимости MAX и MIN");
            Console.ReadKey();

            Comp_model compModelsMod1 = compModels.OrderByDescending(x => x.Cost).FirstOrDefault();
            Console.WriteLine($"Код {compModelsMod1.Code:D2}; {compModelsMod1.Name}. Стоимость MAX {compModelsMod1.Cost}; наличие {compModelsMod1.Count}");

            Comp_model compModelsMod2 = compModels.OrderBy(x => x.Cost).FirstOrDefault();
            Console.WriteLine($"Код {compModelsMod2.Code:D2}; {compModelsMod2.Name}. Стоимость MIN {compModelsMod2.Cost}; наличие {compModelsMod2.Count}");

            Console.WriteLine();
            Console.WriteLine("Проверка условия на наличие моделей требуемого количества");
            Console.ReadKey();

            if (compModels.Any(c => c.Count > 30))
            {
                Console.WriteLine("Поиск. Условие по необходимому количеству выполнено");
            }
            else
            {
                Console.WriteLine("Поиск. Условие по необходимому количеству не выполнено");
            }

            //или коротко Console.WriteLine(compModels.Any(c => c.Count > 30));

            Console.ReadKey();

        }
        static void Print(List<Comp_model> compModels)
        {
            foreach (Comp_model c in compModels)
            {
                Console.WriteLine($"Код {c.Code:D2}; {c.Name}; {c.TypeProc}; {c.HzProc} Hz; объем ОЗУ {c.V_OZU} Гб. Стоимость {c.Cost}; наличие {c.Count}");
            }
            Console.WriteLine();
        }
    }
}
