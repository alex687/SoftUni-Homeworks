import java.util.Arrays;
import java.util.Collection;
import java.util.HashMap;
import java.util.Scanner;
import java.util.Set;
import java.util.TreeMap;

public class Orders {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		HashMap<String, HashMap<String, Long>> products = new HashMap<String, HashMap<String, Long>>();
		int n = scan.nextInt();
		scan.nextLine();
// The better solution will be with another class and comparing... 
		// Class()  -> compa
		//
		TreeMap<Integer, String> aperances = new TreeMap<>();

		for (int i = 0; i < n; i++) {
			String input = scan.nextLine();
			String[] inputSplited = input.split(" ");

			aperances.put(i, inputSplited[2]);

			if (products.containsKey(inputSplited[2])) {
				if (products.get(inputSplited[2]).containsKey(inputSplited[0])) {
					Long amountBefore = products.get(inputSplited[2]).get(
							inputSplited[0]);
					products.get(inputSplited[2]).put(inputSplited[0],
							amountBefore + Long.parseLong(inputSplited[1]));
				}

				else {
					products.get(inputSplited[2]).put(inputSplited[0],
							Long.parseLong(inputSplited[1]));

				}
			} else {
				products.put(inputSplited[2], new HashMap<>());
				products.get(inputSplited[2]).put(inputSplited[0],
						Long.parseLong(inputSplited[1]));
			}
		}

		for (int t : aperances.keySet()) {
			String name = aperances.get(t);
			if (products.containsKey(name)) {
				System.out.print(name + ": ");
				HashMap<String, Long> customers = products.get(name);
				Set<String> customersNames = customers.keySet();
				String[] customersNamesArray = new String[0];
				customersNamesArray = customers.keySet().toArray(
						customersNamesArray);
				Arrays.sort(customersNamesArray);
				for (int i = 0; i < customersNamesArray.length; i++) {
					String customer = customersNamesArray[i];
					if (i + 1 == customersNamesArray.length)
						System.out.print(customer + " "
								+ customers.get(customer));
					else
						System.out.print(customer + " "
								+ customers.get(customer) + ", ");
				}
				System.out.println();
				products.remove(name);
			}

		}

	}

}
