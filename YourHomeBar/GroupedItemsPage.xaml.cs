using YourHomeBar.Common;
using YourHomeBar.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Windows.Data.Xml.Dom;
using Windows.ApplicationModel;
using System.Xml.Linq;

// The Grouped Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234231

namespace YourHomeBar
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class GroupedItemsPage : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public ObservableCollection<string> MainAlcoholList = new ObservableCollection<string>();
        public ObservableCollection<string> GlassTypeList = new ObservableCollection<string>();
        public ObservableCollection<string> PartList = new ObservableCollection<string>();
        public ObservableCollection<string> IngredientList = new ObservableCollection<string>();

        private int NumberOfIngredients = 0;

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        public GroupedItemsPage()
        {
            //SetupComboBox();

            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;

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
        private async void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            var sampleDataGroups = await SampleDataSource.GetGroupsAsync();
            this.DefaultViewModel["Groups"] = sampleDataGroups;
        }

        /// <summary>
        /// Invoked when a group header is clicked.
        /// </summary>
        /// <param name="sender">The Button used as a group header for the selected group.</param>
        /// <param name="e">Event data that describes how the click was initiated.</param>
        void Header_Click(object sender, RoutedEventArgs e)
        {
            // Determine what group the Button instance represents
            var group = (sender as FrameworkElement).DataContext;

            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
            this.Frame.Navigate(typeof(GroupDetailPage), ((SampleDataGroup)group).UniqueId);
        }

        /// <summary>
        /// Invoked when an item within a group is clicked.
        /// </summary>
        /// <param name="sender">The GridView (or ListView when the application is snapped)
        /// displaying the item clicked.</param>
        /// <param name="e">Event data that describes the item clicked.</param>
        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
            var itemId = ((SampleDataItem)e.ClickedItem).UniqueId;
            this.Frame.Navigate(typeof(ItemDetailPage), itemId);
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

        private void SetupComboBox()
        {
            string usersXMLPath = Path.Combine(Package.Current.InstalledLocation.Path, "DataModel/RecipeDetails.xml");
            XDocument LoadedData = XDocument.Load(usersXMLPath);

            var data = from query in LoadedData.Descendants("Users")
                       select new RecipeDetails
                       {
                           MainAlcohol = (string)query.Element("MainAlcohol"),
                           GlassType = (string)query.Element("GlassType"),
                           Part = (string)query.Element("Part"),
                           Ingredient = (string)query.Element("Ingredient")
                       };

            for (int i = 0; i < 3; i++)
                MainAlcoholList.Add(data.ElementAt(i).MainAlcohol);
            
            for (int i = 0; i < 3; i++)
                GlassTypeList.Add(data.ElementAt(i).GlassType);
                        
            for (int i = 0; i < 3; i++)
                PartList.Add(data.ElementAt(i).Part);
                        
            for (int i = 0; i < 3; i++)
                IngredientList.Add(data.ElementAt(i).Ingredient);
        
        }

        private void NewRecipe_Flyout_Opened(object sender, object e)
        {
            Flyout f = sender as Flyout;
        }

        private void NewRecipe_Flyout_Closed(object sender, object e)
        {
            Flyout f = sender as Flyout;
        }

        private void Login_Flyout_Opened(object sender, object e)
        {
            Flyout f = sender as Flyout;
        }

        private void Login_Flyout_Closed(object sender, object e)
        {
            Flyout f = sender as Flyout;
        }

        private void AddIngredient_Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (NumberOfIngredients < 20)
            {
                Ingredient_StackPanel.Children.Add(new ComboBox { Name = string.Format("test{0}", NumberOfIngredients) });

                NumberOfIngredients++;
            }
            
        }

        private void RemoveIngredient_Button_Click(object sender, RoutedEventArgs e)
        {

            if (NumberOfIngredients > 0)
            {
                Ingredient_StackPanel.Children.RemoveAt(NumberOfIngredients);
                NumberOfIngredients--;
            }

        }

        private void SubmitRecipe_Button_Click(object sender, RoutedEventArgs e)
        {
            NewRecipe_Flyout_Closed(sender, e);
        }

        private void AddUserImage_Button_Click(object sender, RoutedEventArgs e)
        {
            UserSubmittedPictures.UserChoosePicture();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (UserInputPassword.Password.Contains(" "))
            {
                loginStatus.Text = "Password cannot include a space";
            }            
        }

        private void userLogin_Button_Click(object sender, RoutedEventArgs e)
        {
            CheckUser(sender, e);           
        }

        private void CheckUser(object sender, RoutedEventArgs e)
        {
            string usersXMLPath = Path.Combine(Package.Current.InstalledLocation.Path, "DataModel/UserTable.xml");
            XDocument LoadedData = XDocument.Load(usersXMLPath);

            var data = from query in LoadedData.Descendants("User")
                       select new User
                       {
                           ID = (string)query.Element("ID"),
                           Name = (string)query.Element("Name"),
                           Email = (string)query.Element("Email"),
                           Password = (string)query.Element("Password"),
                           LoginAttempts = (string)query.Element("LoginAttempts")
                       };

            for (int i = 0; i < data.Count(); i++)
            {
                if (data.ElementAt(i).Email == UserInputUserName.Text)
                {
                    if (data.ElementAt(i).Password == UserInputPassword.Password)
                    {
                        
                    }
                    else
                    {
                        loginStatus.Text = "Username/Email Exists: Password Does not match";
                    }
                }
                else if (data.ElementAt(i).Name == UserInputUserName.Text)
                {
                    if (data.ElementAt(i).Password == UserInputPassword.Password)
                    {
                        
                    }
                    else
                    {
                        loginStatus.Text = "Username/Email Exists: Password Does not match";
                    }
                }
                //loginAttempts++;
            }
    
        }

    }
}