using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Presistance.Models
{
    public class CategorySeed
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string IconSvg { get; set; } = default!;
    }
}
