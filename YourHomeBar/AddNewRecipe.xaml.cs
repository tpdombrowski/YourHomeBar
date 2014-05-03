using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                        
            ComboBoxIngredients.Items.Add("Vodka");
            ComboBoxIngredients.Items.Add("Whiskey");
            ComboBoxIngredients.Items.Add("Rum");
        
            ComboBoxParts.Items.Add("1/2 Ounces");
            ComboBoxParts.Items.Add("1 Ounces");
            ComboBoxParts.Items.Add("1-1/2 Ounces");
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
                StackIngredients.Children.Add(ComboBoxIngredients);
                StackIngredientsPart.Children.Add(ComboBoxParts);

                AmountOfIngredients++;
            }
        }

        private void RemoveIngredient_Button_Click(object sender, RoutedEventArgs e)
        {
            if (StackIngredients.Children.Count>0)
            {
                StackIngredients.Children.RemoveAt(StackIngredients.Children.Count - 1);
                StackIngredientsPart.Children.RemoveAt(StackIngredientsPart.Children.Count - 1);

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

        private void AddPicture_Button_Click(object sender, RoutedEventArgs e)
        {

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
            } 
        }

    }
    
}
