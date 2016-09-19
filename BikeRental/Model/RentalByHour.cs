namespace BikeRental.Model
{
    /// <summary>
    /// Defines a type of rental that is charged by the hour and costs $5 each.
    /// </summary>
    public class RentalByHour : Rental
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="units">The amount of units to bill.</param>
        public RentalByHour(int units)
        {
            UnitPrice = 5;
            Units = units;
        }

        /// <summary>
        /// Gets the unit price.
        /// </summary>
        public override decimal UnitPrice { get; }
    }
}