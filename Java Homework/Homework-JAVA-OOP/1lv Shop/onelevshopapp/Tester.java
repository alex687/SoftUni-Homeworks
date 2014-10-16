package onelevshopapp;

import java.math.RoundingMode;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

import onelevshopapp.customexceptions.ProductManagementException;

public class Tester {

	public static void main(String[] args) {
		FoodProduct cigars = new FoodProduct("420 Blaze it fgt", 6.90, 2,
				AgeRestriction.Adult, "2014-10-20");
		Customer pecata = new Customer("Pecata", 18, 30.00);

		System.out.println(pecata.getBalance()
				.setScale(2, RoundingMode.CEILING));
		System.out.println(cigars.getQuantity());

		try {
			PurchaseManager.ProcessPurchase(pecata, cigars);
		} catch (ProductManagementException e) {
			System.err.println(e.getMessage());
		}

		System.out.println(pecata.getBalance()
				.setScale(2, RoundingMode.CEILING));
		System.out.println(cigars.getQuantity());

		Customer gopeto = new Customer("Gopeto", 18, 0.44);

		try {
			PurchaseManager.ProcessPurchase(gopeto, cigars);
		} catch (ProductManagementException e) {
			System.err.println(e.getMessage());
		}

		List<Product> products = new ArrayList<Product>();

		products.add(new FoodProduct("Toothpaste Aquafresh", 5.00, 10,
				AgeRestriction.None, "2016-05-07"));
		products.add(new FoodProduct("Vita bread", 1.10, 2,
				AgeRestriction.Adult, "2014-10-20"));
		products.add(new FoodProduct("7Days", 0.79, 111,
				AgeRestriction.Teenager, "2014-05-12"));
		products.add(new Computer("ExtraDelux XF 11", 699.90, 20,
				AgeRestriction.None));
		products.add(new Computer("TheBesto", 1699.90, 2, AgeRestriction.Adult));
		products.add(new Appliance("Eldom Oven", 299.90, 60,
				AgeRestriction.None));

		Comparator<Product> byDateOfExpiry = (p1, p2) -> Long.compare(
				((FoodProduct) p1).getDaysUntilExpiry(),
				((FoodProduct) p2).getDaysUntilExpiry());
		Comparator<Product> byPrice = (p1, p2) -> p1.getPrice().compareTo(
				p2.getPrice());

		Product expirableProduct = products.stream()
				.filter(p -> p instanceof Expirable).sorted(byDateOfExpiry)
				.findFirst().get();

		System.out.println(expirableProduct);
		System.out.println("\n ----------------");

		List<Product> adultAgerestrictionByPrice = products.stream()
				.filter(p -> p.ageRestrictionLevel == AgeRestriction.Adult)
				.sorted(byPrice).collect(Collectors.toList());

		for (Product product : adultAgerestrictionByPrice) {
			System.out.println(product + "\n");
		}
	}
}
