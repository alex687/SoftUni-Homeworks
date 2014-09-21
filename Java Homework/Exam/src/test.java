import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;
import java.util.Scanner;
import java.util.TreeSet;

public class test {
	private static final boolean isDigit(char ch) {
		return ch >= 48 && ch <= 57;
	}

	/**
	 * Length of string is passed in for improved efficiency (only need to
	 * calculate it once)
	 **/
	private static String getChunk(String s, int slength, int marker) {
		StringBuilder chunk = new StringBuilder();
		char c = s.charAt(marker);
		chunk.append(c);
		marker++;
		if (isDigit(c)) {
			while (marker < slength) {
				c = s.charAt(marker);
				if (!isDigit(c))
					break;
				chunk.append(c);
				marker++;
			}
		} else {
			while (marker < slength) {
				c = s.charAt(marker);
				if (isDigit(c))
					break;
				chunk.append(c);
				marker++;
			}
		}
		return chunk.toString();
	}

	public static int compare(Object o1, Object o2) {

		String s1 = (String) o1;
		String s2 = (String) o2;

		int thisMarker = 0;
		int thatMarker = 0;
		int s1Length = s1.length();
		int s2Length = s2.length();

		while (thisMarker < s1Length && thatMarker < s2Length) {
			String thisChunk = getChunk(s1, s1Length, thisMarker);
			thisMarker += thisChunk.length();

			String thatChunk = getChunk(s2, s2Length, thatMarker);
			thatMarker += thatChunk.length();

			// If both chunks contain numeric characters, sort them numerically
			int result = 0;
			if (isDigit(thisChunk.charAt(0)) && isDigit(thatChunk.charAt(0))) {
				// Simple chunk comparison by length.
				int thisChunkLength = thisChunk.length();
				result = thisChunkLength - thatChunk.length();
				// If equal, the first different number counts
				if (result == 0) {
					for (int i = 0; i < thisChunkLength; i++) {
						result = thisChunk.charAt(i) - thatChunk.charAt(i);
						if (result != 0) {
							return result;
						}
					}
				}
			} else {
				result = thisChunk.compareTo(thatChunk);
			}

			if (result != 0)
				return result;
		}
		return s1Length - s2Length;
	}

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		int n = scan.nextInt();
		scan.nextLine();
		List<String> numbers = new ArrayList<>();

		for (int i = 0; i < n; i++) {
			String number = scan.nextLine().trim();
			numbers.add(number);

		}
		String first = numbers.get(0);
		String second = "";
		String thirth = "";
		// for(int i = 1; i < n; i++){
		// System.out.println(compare(first, second));
		// }
		/*
		 * if(compare(first,numbers.get(i)) == 1 && compare(second ,
		 * numbers.get(i)) == -1){ second = numbers.get(i); }
		 * if(compare(first,numbers.get(i)) == 1 && compare(second ,
		 * numbers.get(i)) == 1 && compare(thirth, numbers.get(i)) == -1){
		 * thirth = numbers.get(i); } }
		 */
		int key = 0;
		for (int i = 1; i < n; i++) {
			if (compare(first, numbers.get(i)) < 0) {
				first = numbers.get(i);
				key = i;
			}
		}

		if (numbers.size() >= 2) {
			if (key > 0)
				second = numbers.get(key - 1);
			else
				second = numbers.get(key + 1);

			for (int i = 1; i < n; i++) {
				if (compare(second, numbers.get(i)) < 0
						&& first != numbers.get(i)) {
					second = numbers.get(i);
					key = i;
				}
			}
		}
		if (numbers.size() >= 3) {
			if (key > 1)
				thirth = numbers.get(key - 1);
			else
				thirth = numbers.get(key + 1);

			for (int i = 1; i < n; i++) {
				if (compare(thirth, numbers.get(i)) < 0
						&& first != numbers.get(i) && second != numbers.get(i)) {
					thirth = numbers.get(i);
				}
			}
		}
		System.out.println(first);
		if (numbers.size() >= 2) {
			System.out.println(second);
		}
		if (numbers.size() >= 3) {
			System.out.println(thirth);
		}
	}
}