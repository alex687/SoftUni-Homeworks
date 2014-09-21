package _8_problem;

import java.util.Scanner;

public class CountEqualBitPairs {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		long number = scan.nextInt();

		int beforeBit = 0;
		if ((number & (1)) > 0) {
			beforeBit = 1;
		}
		number = number >> 1;
		int counter = 0;
		while (number > 0) {
			if ((number & (1)) > 0) {
				if (beforeBit == 1) {
					counter++;
				}
				beforeBit = 1;
			}

			if ((number & (1)) == 0) {
				if (beforeBit == 0) {
					counter++;
				}
				beforeBit = 0;
			}
			number = number >> 1;
		}

		System.out.println(counter);
	}

}
