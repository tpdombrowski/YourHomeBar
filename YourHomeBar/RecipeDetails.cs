using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourHomeBar
{

    class RecipeDetails
    {

        public ObservableCollection<string> MainAlcohol { get; set; }
        public ObservableCollection<string> GlassType { get; set; }
        public ObservableCollection<string> Ingredient { get; set; }
        public ObservableCollection<string> Part { get; set; }

    }

    public class MainAlcoholList
    {
        public ObservableCollection<string> MainAlcohol { get; set; }
    }

    public class GlassTypeList
    {
        public ObservableCollection<string> GlassType { get; set; }
    }

    public class IngredientList
    {
        public ObservableCollection<string> Ingredient { get; set; }
    }

    public class PartList
    {
        public ObservableCollection<string> Part { get; set; }
    }
}
