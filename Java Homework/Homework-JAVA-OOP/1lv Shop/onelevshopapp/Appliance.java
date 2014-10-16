package onelevshopapp;

import java.math.BigDecimal;

public class Appliance extends ElectronicsProduct {
	public Appliance(String name, double price, int quantity,
			AgeRestriction ageRestrictionLevel) {
		super(name, price, quantity, ageRestrictionLevel, 6);
	}

	@Override
	public BigDecimal getPrice() {
		if (this.quantity < 50) {
			return this.price.multiply(new BigDecimal(1.05));
		}
		
		return this.price;
	}
}
