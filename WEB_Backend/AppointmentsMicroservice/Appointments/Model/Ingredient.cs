using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointments.Model
{
    public class Ingredient
    {
        public int IngredientId{ get; set; }
        public string IngredientCode{ get; set; }
        public string IngredientName { get; set; }

        public Ingredient() { }
    }
}
