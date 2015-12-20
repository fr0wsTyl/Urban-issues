using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UrbanIssues.Pages
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CreateUrbanIssuePage : Page
	{
		private Geolocator geolocator;
		private CameraCaptureUI camera;

		public CreateUrbanIssuePage()
		{
			this.InitializeComponent();
		}

		// Camera
		private async void OnAddPictureButtonClick(object sender, RoutedEventArgs e)
		{
			this.camera = new CameraCaptureUI();
			var photo = await this.camera.CaptureFileAsync(CameraCaptureUIMode.Photo);
			var img = new Image();
			img.Width = 200;
			img.Height = 200;
			img.Source = new BitmapImage(new Uri(photo.Path));
			this.PicturesToAdd.Children.Add(img);
		}

		// Location
		private async void OnLocationButtonClick(object sender, RoutedEventArgs e)
		{
			this.geolocator = new Geolocator();
			var geoposition = await this.geolocator.GetGeopositionAsync();
			var lat = geoposition.Coordinate.Latitude;
			var lon = geoposition.Coordinate.Longitude;

			this.LocationLatitude.Text = lat.ToString();
			this.LocationLongitude.Text = lon.ToString();
		}

		// create Issue
		private void OnCreateIssueButtonClick(object sender, RoutedEventArgs e)
		{
			
		}

		// cancel
		private void OnCancelIssueButtonClick(object sender, RoutedEventArgs e)
		{
			
		}
	}
}
