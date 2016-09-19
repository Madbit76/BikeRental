namespace BikeRental.Model
{
    /// <summary>
    /// Defines a type of rental that is charged by the day and costs $20 each.
    /// </summary>
    public class RentalByDay : Rental
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="units">The amount of units to bill.</param>
        public RentalByDay(int units)
        {
            UnitPrice = 20;
            Units = units;
        }

        /// <summary>
        /// Gets the unit price.
        /// </summary>
        public override decimal UnitPrice { get; }
    }
}