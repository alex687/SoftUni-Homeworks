package products;

import java.util.Comparator;

public class Product implements Comparable<Product> {
	private String name;
	private double price;
	public static Comparator<Product> comparator = new Comparator<Product>() {

		@Override
		public int compare(Product product1, Product product2) {
			return product1.compareTo(product2);
		}

	};

	public Product(String name, double price) {
		this.setName(name);
		this.setPrice(price);
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public double getPrice() {
		return price;
	}

	public void setPrice(double price) {
		this.price = price;
	}

	@Override
	public int compareTo(Product compareProduct) {
		if (this.getPrice() == compareProduct.getPrice()) {
			return 0;
		} else {
			if (this.getPrice() > compareProduct.getPrice()) {
				return 1;
			} else {
				return -1;
			}
		}
	}

	@Override
	public String toString() {
		return this.getPrice() + " " + this.getName();
	}

	@Override
	public int hashCode() {
		String namePrice = this.getName() + this.getPrice();
		return namePrice.hashCode();
	}
}
