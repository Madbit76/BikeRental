# Bike Rental exercise
###### By Axel Magagnini

## Context
A company rents bikes under following options:

1. Rental by hour, charging $5 per hour
2. Rental by day, charging $20 a day
3. Rental by week, changing $60 a week
4. Family Rental, is a promotion that can include from 3 to 5 Rentals (of any type) with a discount of 30% of the total price

## Assigment
1. Implement a set of classes to model this domain and logic
2. Add automated tests to ensure a coverage over 85%
3. Use GitHub to store and version your code
4. Apply all the recommended practices you would use in a real project
5. Add a README.md file to the root of your repository to explain: your design, the development practices you applied and how run the tests.

Note: we don't expect any kind of application, just a set of classes with its automated tests.

## Deliverables
The link to your repository 

## Description of design

###### The following assumptions are made
- Rentals will to be added to an invoice object which will provide price totals and calculate applicable discounts.
- The family rental discount will never change. 
- The user wants to enforce a fixed unit price per rental type, and this price will never change.
- The user does not want custom/flexible rental types, and prefers to supply as little information as possible. 
- No negative units will be entered for rentals. 

###### Development practices used
- The solution is divided into two projects. One contains the domain, and the other contains unit tests for that domain.
- A common interface is provided for all rental types, allowing new future rental types to blend into current logic. 
- Decimal types are used for properties representing money, since they provide more precision and a smaller range.
- An abstract Rental class implements calculation of total price.
- Rental implementors are forced to provide a fixed unit price. 
- Invoice subtotal will only be recalculated when adding a new rental, to optimize performance.
- Every public class and member will include XML comments that can be displayed in Intellisense™. 

###### Running the provided tests
1. Open BikeRental.sln using Visual Studio 2015.
2. From Visual Studio menu, select: Test > Run > All Tests.
3. Check that all unit tests pass successfully.
4. From Visual Studio menu, select: Test > Analyze Code Coverage > All Tests.
5. Check that 100% of the domain code is covered by tests.