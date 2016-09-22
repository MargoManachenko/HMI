using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HMI.Models.ProjectViewModels
{
    public class Curtain
    {
        public int Id { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public string Color { get; set; }

        public string Material { get; set; }

        [Range(0, 50)]
        public int Quantity { get; set; }

    }
}
