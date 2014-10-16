package onelevshopapp;

import java.math.BigDecimal;

public class Customer {
	private String name;
	private int age;
	private BigDecimal balance;
	
	public Customer(String name, int age, double balance) {
		this.setName(name);
		this.setAge(age);
		this.setBalance(new BigDecimal(balance));
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (name.isEmpty() || name == null) {
			throw new IllegalArgumentException("name cannot be empty");
		}
		
		this.name = name;
	}

	public int getAge() {
		return this.age;
	}

	public void setAge(int age) {
		if (age < 0 || age > 100) {
			throw new IllegalArgumentException("age cannot be negative or above 100");
		}
		
		this.age = age;
	}

	public BigDecimal getBalance() {
		return this.balance;
	}

	public void setBalance(BigDecimal balance) {
		if (balance.compareTo(new BigDecimal(0.0)) == -1) {
			throw new IllegalArgumentException("balance cannot be negative");
		}
		
		this.balance = balance;
	}
}
