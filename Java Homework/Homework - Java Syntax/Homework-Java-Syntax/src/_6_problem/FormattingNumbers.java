package _6_problem;

import java.util.Scanner;

public class FormattingNumbers {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);

		int a = scan.nextInt();
		double b = scan.nextDouble();
		double c = scan.nextDouble();

		String aHexString = Integer.toHexString(a).toUpperCase();
		String aBinary = String.format("%10s", Integer.toBinaryString(a))
				.replace(' ', '0');

		if (c % 1 == 0) {
			System.out.printf("|%-10s|%s|%10.2f|%-10.0f|", aHexString, aBinary,
					b, c);
		} else {
			System.out.printf("|%-10s|%s|%10.2f|%-10.3f|", aHexString, aBinary,
					b, c);
		}
	}

}
