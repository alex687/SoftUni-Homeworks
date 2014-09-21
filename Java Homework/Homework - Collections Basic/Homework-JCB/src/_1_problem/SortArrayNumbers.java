package _1_problem;

import java.util.Arrays;
import java.util.Scanner;

public class SortArrayNumbers {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		int n = scan.nextInt();
		scan.nextLine();
		int[] numbers = new int[n];
		
		for (int i = 0; i < n; i++) {
			numbers[i] = scan.nextInt();
		}
		Arrays.sort(numbers);
		
		for (int number : numbers) {
			System.out.print(number + " ");
		}
		System.out.println();
	}

}
