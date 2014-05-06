using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourHomeBar
{
    public class RecipeDetails
    {
        public ObservableCollection<string> MainAlcohol { get; set; }
        public ObservableCollection<string> GlassType { get; set; }
        public ObservableCollection<string> Part { get; set; }
        public ObservableCollection<string> Ingredient { get; set; }
    }
}
