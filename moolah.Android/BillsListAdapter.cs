using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using moolah.Domain.Models;
using moolah.Domain.Services;

namespace moolah.Android
{
    public class BillsListAdapter : BaseAdapter<Bill>
    {
        readonly Activity _activity;
        readonly int _layoutResourceId;
        List<Bill> _bills = new List<Bill>();

        public BillsListAdapter ( Activity activity, int layoutResourceId )
        {
            _activity = activity;
            _layoutResourceId = layoutResourceId;
           
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public void Add ( Bill bill )
        {
            _bills.Add( bill );
            NotifyDataSetChanged();
        }

        public void Clear ()
        {
            _bills.Clear();
            NotifyDataSetChanged();
        }
        //Returns the view for a specific bill on the list
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView;
            var currrentItem = this[position];

            if ( row == null )
            {
                var inflater = _activity.LayoutInflater;
                row = inflater.Inflate( _layoutResourceId, parent, false );
            }

            var nameText = row.FindViewById<TextView>( Resource.Id.billNameTextView );
            var amountText = row.FindViewById<TextView>( Resource.Id.billAmountTextView );
            var dueDateText = row.FindViewById<TextView>( Resource.Id.billDueOnTextView );
            var dueInText = row.FindViewById<TextView>( Resource.Id.billDueInTextView );

            nameText.Text = currrentItem.Name;
            dueDateText.Text = currrentItem.DueDate.ToShortDateString();
            amountText.Text = currrentItem.Amount.ToString("C");
            dueInText.Text = String.Format( "Due in {0} days", ( DateTime.Now - currrentItem.DueDate ).Days ); 

            return row;
        }

        public override int Count
        {
            get
            {
                return _bills.Count;
            }
        }

        public override Bill this[int position]
        {
            get
            {
                return _bills[position];
            }
        }
    }
}