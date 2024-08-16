Class			Methods										Scenario									Output
Basket			AddBagel(Item item)							Add a bagel to the basket					true if successful
																										false if baasket is full
Basket			RemoveBagel(Bagel bagel)					Remove a bagel from the basket				true if succesful
																										false if bagel doesnt exist
BagelShop		ChangeCapacity()							A manager can change capacaites of baskets	true if manager
																										false if not manager
Basket			GetTotalPrice()								Get the total cost of the basket			float of total price
Bagel			GetBagelPrice()								Get the price of a bagel					float of price
Bagel			ChangeFilling(Filling oldF, Filling newF)	Change the old filling for a new			true if succesful
																										false it either doesnt exist
Bagel			AddFilling(Filling filling)					Add a new filling							true if successful
																										false if it doesnt exist
																										false if maximum fillings
Bagel			RemoveFilling(Filling filling)				Remove a filling							true if successful
																										false if it doesnt exist
Bagel			GetFillingsPrice()							Get the price of all available fillings		List of fillings and price
