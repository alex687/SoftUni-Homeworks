import java.util.*;

public class SortArrayOfStrings {

	public static void main(String[] args) {
		SortedSet<String> sortedStrings = new TreeSet<String>();

		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		int n = Integer.parseInt(scan.nextLine());

		for (int i = 0; i < n; i++) {
			sortedStrings.add(scan.nextLine());
		}

		for (String value : sortedStrings) {
			System.out.println(value);
		}
	}
}
