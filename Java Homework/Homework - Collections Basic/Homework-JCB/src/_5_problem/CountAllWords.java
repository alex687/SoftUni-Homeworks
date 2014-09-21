package _5_problem;

import java.util.Scanner;

public class CountAllWords {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		String input = scan.nextLine();
		System.out.println(input.split("\\W+").length);
	}

}
