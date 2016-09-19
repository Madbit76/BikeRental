namespace BikeRental.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BikeRental.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Provides unit tests for the BikeRental application.
    /// </summary>
    [TestClass]
    public class RentalTests
    {
        /// <summary>
        /// Checks if total price can be correctly calculated for rentals by hour.
        /// </summary>
        [TestMethod, Description("Checks if total price can be correctly calculated for rentals by hour")]
        public void CanCalculateRentalByHourTotalPrice()
        {
            var rental = new RentalByHour(10);
            Assert.AreEqual(10, rental.Units);
            Assert.AreEqual(5, rental.UnitPrice);
            Assert.AreEqual(50, rental.TotalPrice);
        }

        /// <summary>
        /// Checks if total price can be correctly calculated for rentals by day.
        /// </summary>
        [TestMethod, Description("Checks if total price can be correctly calculated for rentals by day")]
        public void CanCalculateRentalByDayTotalPrice()
        {
            var rental = new RentalByDay(10);
            Assert.AreEqual(10, rental.Units);
            Assert.AreEqual(20, rental.UnitPrice);
            Assert.AreEqual(200, rental.TotalPrice);
        }

        /// <summary>
        /// Checks if total price can be correctly calculated for rentals by week.
        /// </summary>
        [TestMethod, Description("Checks if total price can be correctly calculated for rentals by week")]
        public void CanCalculateRentalByWeekTotalPrice()
        {
            var rental = new RentalByWeek(10);
            Assert.AreEqual(10, rental.Units);
            Assert.AreEqual(60, rental.UnitPrice);
            Assert.AreEqual(600, rental.TotalPrice);
        }

        /// <summary>
        /// Checks if a single <see cref="RentalByHour"/> can be correctly charged to an <see cref="Invoice"/>.
        /// </summary>
        [TestMethod, Description("Checks if a single RentalByHour can be correctly charged to an Invoice")]
        public void CanChargeRentByHour()
        {
            TestSingleRental(new RentalByHour(8));
        }

        /// <summary>
        /// Checks if a single <see cref="RentalByDay"/> can be correctly charged to an <see cref="Invoice"/>.
        /// </summary>
        [TestMethod, Description("Checks if a single RentalByDay can be correctly charged to an Invoice")]
        public void CanChargeRentByDay()
        {
            TestSingleRental(new RentalByDay(5));
        }

        /// <summary>
        /// Checks if a single <see cref="RentalByWeek"/> can be correctly charged to an <see cref="Invoice"/>.
        /// </summary>
        [TestMethod, Description("Checks if a single RentalByWeek can be correctly charged to an Invoice")]
        public void CanChargeRentByWeek()
        {
            TestSingleRental(new RentalByWeek(4));
        }

        /// <summary>
        /// Checks if family rental discounts are only applied for invoices with 3-5 rentals. 
        /// </summary>
        [TestMethod, Description("Checks if family rental discounts are only applied for invoices with 3-5 rentals")]
        public void ShouldApplyFamilyRentalDiscountWhen3To5Rentals()
        {
            var rental = new RentalByHour(1);
            var invoice = new Invoice();

            // 0-2 rentals. Should not apply discount.
            Assert.IsFalse(invoice.AppliesForFamilyRentalDiscount);
            invoice.AddItem(rental);
            Assert.IsFalse(invoice.AppliesForFamilyRentalDiscount);
            invoice.AddItem(rental);
            Assert.IsFalse(invoice.AppliesForFamilyRentalDiscount);

            // 3-5 rentals. Should apply discount.
            invoice.AddItem(rental);
            Assert.IsTrue(invoice.AppliesForFamilyRentalDiscount);
            invoice.AddItem(rental);
            Assert.IsTrue(invoice.AppliesForFamilyRentalDiscount);
            invoice.AddItem(rental);
            Assert.IsTrue(invoice.AppliesForFamilyRentalDiscount);

            // 6+ rentals. Should not apply discount. 
            for (int i = 0; i < 5; i++)
            {
                invoice.AddItem(rental);
                Assert.IsFalse(invoice.AppliesForFamilyRentalDiscount);
            }
        }

        /// <summary>
        /// Checks if <see cref="Invoice"/> subtotal and total are correctly calculated when family rental discount is NOT applied.
        /// </summary>
        [TestMethod, Description("Checks if Invoice subtotal and total are correctly calculated when family rental discount is NOT applied")]
        public void CanCalculateInvoiceTotalWithoutDiscount()
        {
            var invoice = new Invoice();
            var rentals = new List<IBillable>
            {
                new RentalByDay(1),
                new RentalByHour(1),
            };

            rentals.ForEach(r => invoice.AddItem(r));
            Assert.AreEqual(2, invoice.ItemCount);
            Assert.IsFalse(invoice.AppliesForFamilyRentalDiscount);
            var expectedTotal = rentals.Sum(r => r.Units * r.UnitPrice);
            Assert.AreEqual(expectedTotal, invoice.SubTotalPrice);
            Assert.AreEqual(expectedTotal, invoice.TotalPrice);
        }

        /// <summary>
        /// Checks if <see cref="Invoice"/> subtotal and total are correctly calculated when family rental discount is applied.
        /// </summary>
        [TestMethod, Description("Checks if Invoice subtotal and total are correctly calculated when family rental discount is applied")]
        public void CanCalculateInvoiceTotalWithDiscount()
        {
            var invoice = new Invoice();
            var rentals = new List<IBillable>
            {
                new RentalByDay(1),
                new RentalByHour(1),
                new RentalByWeek(1)
            };

            rentals.ForEach(r => invoice.AddItem(r));
            Assert.AreEqual(3, invoice.ItemCount);
            Assert.IsTrue(invoice.AppliesForFamilyRentalDiscount);
            var expectedSubTotal = rentals.Sum(r => r.Units * r.UnitPrice);
            var expectedTotal = expectedSubTotal - expectedSubTotal * Invoice.FamilyRentalDiscount;
            Assert.AreEqual(expectedSubTotal, invoice.SubTotalPrice);
            Assert.AreEqual(expectedTotal, invoice.TotalPrice);
        }

        /// <summary>
        /// Checks if attempting to add an undefined <see cref="IBillable"/> to an <see cref="Invoice"/> throws an exception.
        /// </summary>
        [TestMethod, Description("Checks if attempting to add an undefined IBillable to an Invoice throws an exception.")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowsWhenAddingUndefinedBillableToInvoice()
        {
            new Invoice().AddItem(null);
        }

        private void TestSingleRental(IBillable rental)
        {
            var invoice = new Invoice();
            invoice.AddItem(rental);
            Assert.AreEqual(1, invoice.ItemCount);
            Assert.AreEqual(rental.UnitPrice * rental.Units, invoice.TotalPrice);
        }
    }
}