package onelevshopapp;

import java.math.BigDecimal;

public class Computer extends ElectronicsProduct {
	public Computer(String name, double price, int quantity,
			AgeRestriction ageRestrictionLevel) {
		super(name, price, quantity, ageRestrictionLevel, 24);
	}

	@Override
	public BigDecimal getPrice() {
		if (this.quantity > 1000) {
			return this.price.multiply(new BigDecimal(0.95));
		}
		
		return this.price;
	}
}
