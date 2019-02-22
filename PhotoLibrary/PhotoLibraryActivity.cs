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
        Icon = "@mipmap/icon",
        Theme = "@style/PhotoLibraryTheme")]
    public class PhotoLibraryActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set view from the "PhotoLibraryUI" layout resource
            SetContentView(Resource.Layout.PhotoLibraryUI);

            // Get takePicture button from the layout resource, and attach an event to it
            Button takePicture = FindViewById<Button>(Resource.Id.takePicture);
            takePicture.Click += TakePictureButton_Clicked;

            // Get chooseFromGallery button from the layout resource, and attach an event to it
            Button chooseFromGallery = FindViewById<Button>(Resource.Id.chooseFromGallery);
            chooseFromGallery.Click += ChooseFromGalleryButton_Clicked;
        }

        private void ChooseFromGalleryButton_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TakePictureButton_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #region Check for device camera and photo album permissions
        public async Task<bool> CheckCameraAlbumPermissions()
        {
            // Determine if permissions to device camera and photo album are enabled
            var deviceCameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            var deviceAlbumStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

            // Ask for the appropriate permissions if not enabled
            if (deviceCameraStatus != PermissionStatus.Granted || deviceAlbumStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] {
                    Permission.Camera,
                    Permission.Storage
                });

                deviceCameraStatus = results[Permission.Camera];
                deviceAlbumStatus = results[Permission.Storage];
            }

            // Check if we have access to the device camera and photo album
            return (deviceCameraStatus == PermissionStatus.Granted && deviceAlbumStatus == PermissionStatus.Granted);
        }
        #endregion

        #region Shows a message dialog using the parameters specified
        public void ShowMessageDialog(string title, string message)
        {
            var dialog = new AlertDialog.Builder(this);
            var alert = dialog.Create();
            alert.SetTitle(title);
            alert.SetMessage(message);
            alert.SetButton("OK", (c, ev) => CrossPermissions.Current.OpenAppSettings());
            alert.Show();
        }
        #endregion
    }
}
