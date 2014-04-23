using System;
using moolah.Domain.Models;
using moolah.Domain.Services;

namespace moolah.Console
{
    class Program
    {
        
        static void Main ( string [] args )
        {

            var b = new Bill
            {
                Id = 1,
                Name = "Macy's Card",
                Amount = 25.0m,
                PayeeId = 2,
                DueDate = new DateTime( 2014, 04, 02 ),
                IsAutoPay = false,
                IsChargedInterest = true,
                InterestRate = 23.99m,
                IsPaid = false

            };

            //try
            //{
            //    System.Console.WriteLine( "Creating {0}", b.Name );
            //    bills.CreateAsync( b ).ContinueWith( ( c ) => GetBills() );
            //}
            //catch ( Exception e )
            //{
            //    System.Console.WriteLine( "Error \n{0}", e.Message );
            //}
            var client = new MoolahApiClient();

            client.Bills.Create(b).ContinueWith((task) =>
            {
                System.Console.WriteLine("Getting all bills...");
                client.Bills.Get().ContinueWith((res) =>
                {
                    var bills = res.Result;
                    foreach (var bill in bills)
                    {
                        System.Console.WriteLine(bill.Name);
                    }
                });
            });

            

            //System.Console.WriteLine( "Getting one bill..." );
            //client.Bills.GetById(1).ContinueWith( ( res ) =>
            //{
            //    var bill = res.Result;
            //    System.Console.WriteLine("{0}: {1}", bill.Id,  bill.Name );
            //} );

            //System.Console.WriteLine( "Creating new bill..." );
            //client.Bills.Create( b ).ContinueWith( ( res ) =>
            //{
            //    var id = res.Result;
            //    System.Console.WriteLine( "New Bill Id: {0}", id  );
            //} );

            System.Console.Read();

        }

        
    }
}
