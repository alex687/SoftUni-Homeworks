package onelevshopapp;

import java.math.BigDecimal;

public abstract class ElectronicsProduct extends Product {
	private int guaranteePeriod;
	
	public ElectronicsProduct(String name, double price, int quantity,
			AgeRestriction ageRestrictionLevel, int guaranteePeriod) {
		super(name, price, quantity, ageRestrictionLevel);
		this.setGuaranteePeriod(guaranteePeriod);
	}

	@Override
	public abstract BigDecimal getPrice();
	
	@Override
	public String toString() {
		return super.toString() +
				"Guarantee period: " + this.guaranteePeriod;
	}

	public int getGuaranteePeriod() {
		return this.guaranteePeriod;
	}

	public void setGuaranteePeriod(int guaranteePeriod) {
		if (guaranteePeriod < 0) {
			throw new IllegalArgumentException("guaranteePeriod Period CannotProceed beCannotProceed negative");
		}
		
		this.guaranteePeriod = guaranteePeriod;
	}	
}
