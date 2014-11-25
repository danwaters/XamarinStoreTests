using System;
using Xamarin.UITest;

namespace XamStore.Android.Tests
{
	public static class AppExtensions
	{
		public static void WaitAndTapById(this IApp app, string id)
		{
			app.WaitForElement (e => e.Id (id));
			app.Tap (e => e.Id (id));
		}

		public static void WaitAndTapByText(this IApp app, string text)
		{
			app.WaitForElement (e => e.Text (text));
			app.Tap (e => e.Text (text));
		}
	}
}

