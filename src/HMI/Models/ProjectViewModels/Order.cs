using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMI.Models.ProjectViewModels
{
    public class Order
    {
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public DateTime DateOfStart { get; set; }

        public DateTime DateOfFinish { get; set; }

        public decimal Price { get; set; }

        // 0 - заявка подана, 1 - в процессе выполнения, 2 - завершено, 3 - удалено
        public int State { get; set; }

        public virtual Curtain Curtain { get; set; }

        // Высчитывает цену шторы. Берет цену материала за метр квадратный,
        // умножает на площадь шторы и на количество штор
        public static decimal GetPrice(Curtain curtain)
        {
            double square = curtain.Width * curtain.Height;
            return (decimal)(Collections.MaterialsWithPrice[curtain.Material] * (decimal)square * curtain.Quantity);
        }
    }
}
