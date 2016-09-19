namespace BikeRental.Model
{
    /// <summary>
    /// Defines a type of rental that is charged by the week and costs $60 each.
    /// </summary>
    public class RentalByWeek : Rental
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="units">The amount of units to bill.</param>
        public RentalByWeek(int units)
        {
            UnitPrice = 60;
            Units = units;
        }

        /// <summary>
        /// Gets the unit price.
        /// </summary>
        public override decimal UnitPrice { get; }
    }
}