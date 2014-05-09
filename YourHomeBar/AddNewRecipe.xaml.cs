using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.IO;
using Windows.ApplicationModel;
using System.Runtime.InteropServices.WindowsRuntime;
using YourHomeBar.Common;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SQLite;
using System.Collections.ObjectModel;

// The Item Detail Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234232

namespace YourHomeBar
{
    /// <summary>
    /// A page that displays details for a single item within a group while allowing gestures to
    /// flip through other items belonging to the same group.
    /// </summary>
    public sealed partial class AddNewRecipe : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        public static int AmountOfSelectedIngredients = 0;
        public static int AmountOfIngredients = 0;
        public ComboBox ComboBoxIngredients = new ComboBox();
        public ComboBox ComboBoxParts = new ComboBox();
        
        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        public AddNewRecipe()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;

            StackIngredients.Children.Add(ComboBoxIngredients);
            StackIngredientsPart.Children.Add(ComboBoxParts);

            AmountOfIngredients++;

            BuildMainAlcoholComboBox();
            BuildGlassTypeComboBox();
            BuildIngedientsComboBox(ref ComboBoxIngredients);
            BuildPartsComboBox(ref ComboBoxParts);
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {

            object navigationParameter;
            if (e.PageState != null && e.PageState.ContainsKey("SelectedItem"))
            {
                navigationParameter = e.PageState["SelectedItem"];
            }

            // TODO: Assign a bindable group to this.DefaultViewModel["Group"]
            // TODO: Assign a collection of bindable items to this.DefaultViewModel["Items"]
            // TODO: Assign the selected item to this.flipView.SelectedItem
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void AddIngredient_Button_Click(object sender, RoutedEventArgs e)
        {

            if (StackIngredients.Children.Count < 10)
            {

                ComboBox newComboBox = new ComboBox();
                BuildIngedientsComboBox(ref newComboBox);
                StackIngredients.Children.Add(newComboBox);

                //StackIngredientsPart.Children.Add(ComboBoxParts);

                AmountOfIngredients++;

            }

        }

        private void RemoveIngredient_Button_Click(object sender, RoutedEventArgs e)
        {
            if (StackIngredients.Children.Count > 0)
            {
                StackIngredients.Children.RemoveAt(StackIngredients.Children.Count);
                StackIngredientsPart.Children.RemoveAt(StackIngredientsPart.Children.Count);

                AmountOfIngredients--;
            }
        }

        private void TempIngrediantChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TempGlassChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TempAlcoholChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddUserPicture_Button_Click(object sender, RoutedEventArgs e)
        {
            UserSubmittedPictures.UserChoosePicture();
        }

        private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {

            // Check Add recipe is completely filled in
            if (ComboBoxAlcohol.SelectedItem != null && ComboBoxGlass.SelectedItem != null && ComboBoxIngredients.SelectedItem != null && AmountOfIngredients != 0)
            {
                /*
                MySQLRecipe SQLConnection = new MySQLRecipe();

                MySQLRecipe NewRecipe = new MySQLRecipe
                {
                    CategoryType = ComboBoxAlcohol.SelectedItem.ToString(),
                    GlassType = ComboBoxAlcohol.SelectedItem.ToString()
                };
                */

                status.Text = "sumbitted correctly";

                //SQLConnection.CreateTable();
                //SQLConnection.InsertRecipe(NewRecipe);

                Frame.Navigate(typeof(GroupedItemsPage));

            } 

        }

        public static void ChangeUserSubmittedPicture()
        {
            
        }

        public void UpdatePicture()
        {
            //Image img = new Image();
            //img.Source = "Assets/DarkGray.png";
            //UserPicture.Source = picture;
        }

        private void BuildMainAlcoholComboBox()
        {

            //string recipeDetailsXMLPath = Path.Combine(Package.Current.InstalledLocation.Path, "DataModel/RecipeDetails.xml");
            //XDocument loadedData = XDocument.Load(recipeDetailsXMLPath);

            //var mainAlcoholList = from query in loadedData.Descendants("mainalcohol")
            //select new MainAlcoholList
            //{
            //    MainAlcohol = (string)query.Element("mainalcoholname")
            //};

            //var sortedMainAlcoholList =
            //    from mainAlcohol in mainAlcoholList
            //    orderby mainAlcohol.MainAlcohol ascending
            //    select mainAlcohol;

            //foreach (var mainAlcohol in sortedMainAlcoholList)
            //{
            //    ComboBoxIngredients.Items.Add(mainAlcohol.MainAlcohol);
            //}

        }

        private void BuildGlassTypeComboBox()
        {

            //string recipeDetailsXMLPath = Path.Combine(Package.Current.InstalledLocation.Path, "DataModel/RecipeDetails.xml");
            //XDocument loadedData = XDocument.Load(recipeDetailsXMLPath);

            //var glassTypeList = from query in loadedData.Descendants("glasstype")
            //select new GlassTypeList
            //{
            //    GlassType = (string)query.Element("glasstypename")
            //};

            //var sortedGlassTypeList =
            //    from glassType in glassTypeList
            //    orderby glassType.GlassType ascending
            //    select glassType;

            //foreach (var glasstype in sortedGlassTypeList)
            //{
            //    ComboBoxIngredients.Items.Add(glasstype.GlassType);
            //}

        }

        private void BuildIngedientsComboBox(ref ComboBox tempComboBax)
        {

            //string recipeDetailsXMLPath = Path.Combine(Package.Current.InstalledLocation.Path, "DataModel/RecipeDetails.xml");
            //XDocument loadedData = XDocument.Load(recipeDetailsXMLPath);

            //var ingredientList = from query in loadedData.Descendants("ingredients")
            //select new IngredientList
            //{
            //    Ingredient = (string)query.Element("ingredientname")
            //};

            //var sortedIngredientList =
            //    from ingredient in ingredientList
            //    orderby ingredient.Ingredient ascending
            //    select ingredient;

            //foreach (var ingredient in sortedIngredientList)
            //{
            //    ComboBoxIngredients.Items.Add(ingredient.Ingredient);
            //}
                     
        }

        private void BuildPartsComboBox(ref ComboBox tempComboBax)
        {

            //string recipeDetailsXMLPath = Path.Combine(Package.Current.InstalledLocation.Path, "DataModel/RecipeDetails.xml");
            //XDocument loadedData = XDocument.Load(recipeDetailsXMLPath);

            //var partList = from query in loadedData.Descendants("parts")
            //               select new PartList
            //               {
            //                   Part = (string)query.Element("partname")
            //               };

            //var sortedPartlist = 
            //    from part in partList
            //    orderby part.Part ascending
            //    select part;

            //foreach (var part in sortedPartlist)
            //{
            //    tempComboBax.Items.Add(part.Part);
            //}

        }

        //public async void AddingNewIngredient(String NewIngredient)
        //{

        //}

    }
    
}
