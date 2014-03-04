using System;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using moolah.Domain.Services;

namespace moolah.Android
{
    [Activity( Label = "moolah.Android", MainLauncher = true, Icon = "@drawable/icon" )]
    public class Activity1 : Activity
    {
        int count = 1;

        protected override async void OnCreate ( Bundle bundle )
        {
            base.OnCreate( bundle );

            // Set our view from the "main" layout resource
            SetContentView( Resource.Layout.Main );

            // Get our button from the layout resource,
            // and attach an event to it
            var button = FindViewById<Button>( Resource.Id.MyButton );
            
            button.Click += delegate { button.Text = string.Format( "{0} clicks!", count++ ); };

            try
            {
                await LoadBills();
            }
            catch (Exception e) {
				CreateAndShowDialog (e.Message, "Error");
			}
            
            
        }

        void CreateAndShowDialog ( string message, string title )
        {
            AlertDialog.Builder builder = new AlertDialog.Builder( this );

            builder.SetMessage( message );
            builder.SetTitle( title );
            builder.Create().Show();
        }

        async Task LoadBills()
        {
            var billsText = FindViewById<TextView>( Resource.Id.billsText );

            billsText.Text = "Getting Bills From API.";
            var client = new MoolahApiClient();

            await client.Bills.Get().ContinueWith( ( task ) =>
            {
                RunOnUiThread(() =>
                {
                    billsText.Text += "\nBack From API...";
                    var bills = task.Result;
                    billsText.Text += "\nThere are " + bills.Count() + " in the DB\n\n";
                    foreach ( var bill in bills )
                    {
                        billsText.Text += bill.Name + "\n";
                    }
                });
                
            } );
        }
    }
}

