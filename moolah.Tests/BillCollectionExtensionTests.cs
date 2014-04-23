using System;
using System.Linq;
using moolah.Domain.Extensions;
using moolah.Domain.Models;
using moolah.Domain.Services;
using moolah.Tests.Mocks;
using Xunit;

namespace moolah.Tests
{
    public class BillCollectionExtensionTests
    {
        private MockBillsApiService svc = new MockBillsApiService();

        [Fact]
        public void TotalDueReturnsCorrectAmount()
        {
            var bills = svc.GetSync();
            var expected = 250.0m;
            var sut = bills.TotalDue();
            Assert.Equal(sut, expected);

        }

        [Fact]
        public void AreAutoPayReturnsOnlyAutoPayBills()
        {
            var bills = svc.GetSync();
            var sut = bills.AreAutoPay();

            Assert.True(sut.All(b => b.IsAutoPay));
        }

        [Fact]
        public void AreNotAutoPayReturnsOnlyAutoPayBills ()
        {
            var bills = svc.GetSync();
            var sut = bills.AreNotAutoPay();

            Assert.True( sut.All( b => b.IsAutoPay == false) );
        }

        [Fact]
        public void ArePaidReturnsOnlyAutoPayBills ()
        {
            var bills = svc.GetSync();
            var sut = bills.ArePaid();

            Assert.True(sut.All(b => b.IsPaid));
        }

        [Fact]
        public void AreNotPaidReturnsOnlyAutoPayBills ()
        {
            var bills = svc.GetSync();
            var sut = bills.AreNotPaid();

           Assert.True(sut.All(b => b.IsPaid == false));
        }

        [Fact]
        public void DueBeforeNextPaycheckReturnsCorrectListOfBills()
        {
            DateTimeProvider.SetCurrentDateTime( new DateTime( 2014, 03, 09 ) );
            var bills = svc.GetSync();
            var settings = new Settings
            {
                PayInterval = 2,
                BasePayDay = new DateTime(2014, 02, 27),
                PaycheckAmount = 1490.12m
            };

            var sut = bills.DueBeforeNextPaycheck(settings);
            Assert.Equal(sut.Count(), 1);
            Assert.Equal(sut.TotalDue(), 25);
        }

        [Fact]
        public void DueNextPayPeriodReturnsCorrectListOfBills ()
        {
            DateTimeProvider.SetCurrentDateTime(new DateTime(2014,03,09));
            var bills = svc.GetSync();
            var settings = new Settings
            {
                PayInterval = 2,
                BasePayDay = new DateTime( 2014, 02, 27 ),
                PaycheckAmount = 1490.12m
            };

            var sut = bills.DueNextPayPeriod( settings );
            Assert.Equal( sut.Count(), 2);
            Assert.Equal( sut.TotalDue(), 225 );
        }

    }
}
