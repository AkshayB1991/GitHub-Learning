using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntitiesVO
{
    public class FruitsVO
    {
        public int FruitID { get; set; }

        public string FruitName { get; set; }

        public bool IsSelected { get; set; }
    }
}
