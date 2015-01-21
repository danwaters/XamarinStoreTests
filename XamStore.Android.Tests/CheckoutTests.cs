using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Queries;
using System;

namespace XamStore.Android.Tests
{
	[TestFixture]
	public class OrderingAShirt
	{
		private IApp app;
		private const string apkPath = "com.xamarin.XamStore.apk";
		private const string apiKey = "YOUR_API_KEY_HERE";

		[SetUp]
		public void Setup()
		{
			app = ConfigureApp.Android.ApiKey (apiKey).ApkFile (apkPath).StartApp ();
		}

		[Test]
		[TestCase(TestName="Hello")]
		public void DoesNothing()
		{
			app.Screenshot ("This app does nothing");
		}
			
		[Test]
		[TestCase(TestName="Checking that stuff out")]
		public void CheckingOut ()
		{
			// Uncomment this line to activate the C# REPL. Try typing these commands into it:
			// tree
			// app.Flash(e => e.Id("cart_menu_item"))

			//app.Repl ();

			app.Screenshot ("Given the app is running");

			app.WaitForElement(e => e.Id("productTitle"));

			app.Screenshot ("I select the Men's T-Shirt option");
			app.Tap(e => e.Id("productTitle"));

			app.WaitForElement (c => c.Id ("productSize"));
			app.Screenshot ("And I see the size dropdown");

			app.Tap (c => c.Id ("productSize"));
			app.Tap (c => c.Raw ("CheckedTextView text:'Medium'"));
			app.Screenshot ("And I change the size to Medium");

			app.Tap (c => c.Id ("productColor"));
			app.Tap (c => c.Raw ("CheckedTextView text:'Green'"));
			app.Screenshot ("And I change the color to Green");

			app.Tap (c => c.Id ("addToBasket"));
			app.Screenshot ("And I add the shirt to my basket");

			app.WaitForElement (c => c.Id ("cart_menu_item"));
			app.Tap (c => c.Id ("cart_menu_item"));
			app.Screenshot ("Then I go to my cart");

			app.WaitForElement(c => c.Marked("Checkout"));
			app.Tap (c => c.Marked ("Checkout"));
			app.Screenshot ("And I checkout");

			app.WaitForElement (c => c.Id ("shippingAddress"), "Could not find shipping information");
			app.Screenshot ("And I a see the shipping information screen");
		}
	}
}



/* Run this command to upload:
mono test-cloud.exe submit ../../../XamStore.Android.Tests/com.xamarin.XamStore.apk API_KEY --devices 14acbe9e --series "master" --locale "en_US" --app-name "Xamarin Store" --assembly-dir ../../../XamStore.Android.Tests/bin/Debug/
*/

/*
apk:
https://www.dropbox.com/s/9wqk6lq7a5cpfox/com.xamarin.XamStore.apk?dl=0
*/

