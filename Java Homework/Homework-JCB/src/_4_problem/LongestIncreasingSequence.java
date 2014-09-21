package _4_problem;

import java.util.Scanner;

public class LongestIncreasingSequence {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		String input = scan.nextLine();
		String[] numbers = input.split(" ");

		String sequence = numbers[0] + " ";
		String longestSequence = "";
		int lastInt = Integer.parseInt(numbers[0]);
		for (int i = 1; i < numbers.length; i++) {
			if (lastInt < Integer.parseInt(numbers[i])) {
				lastInt = Integer.parseInt(numbers[i]);
				sequence += numbers[i] + " ";
			} else {
				if (longestSequence.length() < sequence.length()) {
					longestSequence = new String(sequence);
				}
				System.out.println(sequence);
				lastInt = Integer.parseInt(numbers[i]);
				sequence = numbers[i] + " ";
			}
		}

		if (longestSequence.length() < sequence.length()) {
			longestSequence = new String(sequence);
		}
		
		if (!sequence.isEmpty()) {
			System.out.println(sequence);
		}
		System.out.println("Longest: " + longestSequence);
	}

}
