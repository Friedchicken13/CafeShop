
## Background

I like coffee.

So I built an app to fetch coffee for people from my favourite barista.

The app keeps track of coffee ordered; what the balance is for each user; what users have paid for already; and what is still owed.

## Data

We've got the following data

- `Data/prices.json` - provided by our barista. Has details of what beverages are available, and what their prices are.
- `Data/orders.json` - list of beverages ordered by users of the app.
- `Data/payments.json` - list of payments made by users paying for items they have purchased.

## Requirements

- Load the list of prices
- Load the orders
  - Calculate the total cost of each user's orders
- Load the payments
  - Calculate the total payment for each user
  - Calculate what each user now owes
- Return a JSON string containing the results of this work.


