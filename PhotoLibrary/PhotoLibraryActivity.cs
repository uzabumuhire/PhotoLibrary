// C#
using System;
using System.Threading.Tasks;

// Xamarin.Android
using Android.App;
using Android.OS;
using Android.Widget;

// Xamarin Media Plugin
using Plugin.Media;
using Plugin.Media.Abstractions;

// Xamarin Permissions Plugin
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace PhotoLibrary
{
    [Activity(
        Label = "PhotoLibraryActivity", 
        MainLauncher = true, 
        Icon = "@mipmap/icon" )]
    public class PhotoLibraryActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "PhotoLibraryUI" layout resource
            SetContentView(Resource.Layout.PhotoLibraryUI);

            // Get our useCamera button from the layout resource,
            // and attach an event to it
            Button useCamera = FindViewById<Button>(Resource.Id.takePicture);
            useCamera.Click += UseCameraButton_Clicked;

            // Get our chooseFromGallery button from the layout resource,
            // and attach an event to it
            Button chooseFromGallery = FindViewById<Button>(Resource.Id.chooseFromGallery);
            chooseFromGallery.Click += ChooseFromGalleryButton_Clicked;
        }

        private void ChooseFromGalleryButton_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void UseCameraButton_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void ChooseFromGallery_Click(object sender, EventArgs e)
        {
        }

    }
}
