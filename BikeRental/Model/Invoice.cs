namespace BikeRental.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents an invoice containing <see cref="IBillable"/> items.
    /// </summary>
    /// <remarks>
    /// A fixed family rental discount will be applied to the <see cref="TotalPrice"/> when the invoice contains 3 to 5 items.
    /// </remarks>
    public class Invoice
    {
        /// <summary>
        /// The percentage to discount from the <see cref="TotalPrice"/> when applicable.
        /// </summary>
        public const decimal FamilyRentalDiscount = 0.3m; // 30%

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public Invoice()
        {
            Items = new List<IBillable>();
        }

        /// <summary>
        /// Gets a value indicating if this instance applies for a family rental discount.
        /// </summary>
        public bool AppliesForFamilyRentalDiscount => Items.Count >= 3 && Items.Count <= 5;

        /// <summary>
        /// Gets the sum of all item prices, without taking discounts into consideration.
        /// </summary>
        public decimal SubTotalPrice { get; private set; }

        /// <summary>
        /// Gets the sum of all item prices, applying discounts where applicable. 
        /// </summary>
        public decimal TotalPrice => AppliesForFamilyRentalDiscount ? SubTotalPrice - (SubTotalPrice * FamilyRentalDiscount) : SubTotalPrice;

        /// <summary>
        /// Gets the amount of items.
        /// </summary>
        public int ItemCount => Items.Count;

        private IList<IBillable> Items { get; }

        /// <summary>
        /// Adds a new item.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void AddItem(IBillable item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            Items.Add(item);
            SubTotalPrice += item.TotalPrice;
        }
    }
}