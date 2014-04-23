using System;
using System.Threading.Tasks;
using Android.App;
using Android.Widget;
using Android.OS;
using moolah.Domain.Models;
using moolah.Domain.Services;

namespace moolah.Android
{
    [Activity( Label = "moolah", MainLauncher = true, Icon = "@drawable/icon" )]
    public class Activity1 : Activity
    {
        private BillsListAdapter adapter;

        protected override async void OnCreate ( Bundle bundle )
        {
            base.OnCreate( bundle );

            // Set our view from the "main" layout resource
            SetContentView( Resource.Layout.Main );

            adapter = new BillsListAdapter(this, Resource.Layout.BillsListItem);
            var listView = FindViewById<ListView>(Resource.Id.listViewBills);
            listView.Adapter = adapter;

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
            var builder = new AlertDialog.Builder( this );

            builder.SetMessage( message );
            builder.SetTitle( title );
            builder.Create().Show();
        }

        async Task LoadBills()
        {
            var billsText = FindViewById<TextView>( Resource.Id.billsText );
            var client = new MoolahApiClient();

            billsText.Text = "Getting Bills From API.";
            adapter.Clear();

            var bs = await client.Bills.Get();
            foreach ( var bill in bs )
            {
                adapter.Add( bill );
            }

            RemoveTextView(billsText);
        }

        private static void RemoveTextView(TextView billsText)
        {
            billsText.Text = "";
            billsText.LayoutParameters.Height = 0;
        }
    }
}

