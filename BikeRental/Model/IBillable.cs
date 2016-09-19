namespace BikeRental.Model
{
    /// <summary>
    /// Defines an interface for objects that have an unit price and can calculate the total to bill.
    /// </summary>
    public interface IBillable
    {
        /// <summary>
        /// Gets the unit price.
        /// </summary>
        decimal UnitPrice { get; }

        /// <summary>
        /// Gets or sets the amount of units to bill. 
        /// </summary>
        int Units { get; set; }

        /// <summary>
        /// Gets the total price, based on unit price and units. 
        /// </summary>
        decimal TotalPrice { get; }
    }
}
