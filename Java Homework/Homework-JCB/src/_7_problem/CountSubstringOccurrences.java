package _7_problem;

import java.util.Scanner;

public class CountSubstringOccurrences {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		String text = scan.nextLine().toLowerCase();
		String substring = scan.nextLine().toLowerCase();
		int count = 0;
		for (int i = 0; i < text.length() - substring.length() + 1; i++) {
			if (text.charAt(i) == substring.charAt(0)) {
				if (checkSubstring(text, i, substring)) {
					count++;
				}
				// checkSubstring(args, i, substring))
			}
		}

		System.out.println(count);
	}

	private static boolean checkSubstring(String text, int startText,
			String substring) {
		for (int j = 0; j < substring.length(); j++) {
			if (text.charAt(j + startText) != substring.charAt(j)) {
				return false;
			}
		}

		return true;
	}

}
