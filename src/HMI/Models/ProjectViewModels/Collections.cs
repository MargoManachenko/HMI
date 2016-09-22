using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMI.Models.ProjectViewModels
{
    // Коллекции, ограничивающие ввод пользователя
    public static class Collections
    {
        public static IEnumerable<string> Cities = new string[5] { "Харьков", "Киев", "Одесса", "Днепропетровск", "Львов" };

        // Цена шторы зависит от материала. В словаре хранится название материала и его цена за квадратный метр
        public static IDictionary<string, decimal> MaterialsWithPrice = new Dictionary<string, decimal>() {};

        public static IEnumerable<string> Colors = new string[3] { "Бежевый", "Золотистый", "Синий" };

        static Collections()
        {
            MaterialsWithPrice.Add("Бархат", 10m);
            MaterialsWithPrice.Add("Сукно", 20m);
            MaterialsWithPrice.Add("Шерсть", 30m);
        }
    }
}
