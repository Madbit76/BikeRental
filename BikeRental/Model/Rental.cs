namespace BikeRental.Model
{
    /// <summary>
    /// Defines a type of rental. 
    /// </summary>
    public abstract class Rental : IBillable
    {
        /// <summary>
        /// Gets the unit price.
        /// </summary>
        public abstract decimal UnitPrice { get; }

        /// <summary>
        /// Gets or sets the amount of units to bill. 
        /// </summary>
        public int Units { get; set; }

        /// <summary>
        /// Gets the total price, based on unit price and units. 
        /// </summary>
        public decimal TotalPrice => UnitPrice * Units;
    }
}