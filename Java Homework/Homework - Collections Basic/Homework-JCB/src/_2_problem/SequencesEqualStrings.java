package _2_problem;

import java.util.Scanner;

public class SequencesEqualStrings {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		String input = scan.nextLine();
		String[] strings = input.split(" ");

		String sequence = strings[0] + " ";
		for (int i = 1; i < strings.length; i++) {
			if (strings[i].equals(strings[i - 1])) {
				sequence += strings[i] + " ";
			} else {
				System.out.println(sequence);
				sequence = strings[i] + " ";
			}
		}
		if (!sequence.isEmpty()) {
			System.out.println(sequence);
		}

	}

}
