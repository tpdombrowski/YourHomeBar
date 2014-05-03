using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace YourHomeBar
{
    static class UserSubmittedPictures
    {

        public static async void UserChoosePicture()
        {

            // Instantiate/configure picker object.
            FileOpenPicker openPicker = PickerLocationId.PicturesLibrary.CreateFileOpenPicker(new string[] { ".jpg", ".jpeg", ".png" });

            // Display picker and allow user to select a single file.
            StorageFile picture = await openPicker.PickSingleFileAsync();

            // If the user selected a file ...
            if (picture != null)
            {
                //AddNewRecipe.ChangeUserSubmittedPicture(picture);
            }

        }

        public static FileOpenPicker CreateFileOpenPicker(this PickerLocationId location, string[] filters)
        {

            FileOpenPicker picker = new FileOpenPicker()
            {
                SuggestedStartLocation = location,
                ViewMode = PickerViewMode.Thumbnail
            };
            foreach (string filter in filters)
            {
                picker.FileTypeFilter.Add(filter);
            }

            return picker;

        }

    }
}
