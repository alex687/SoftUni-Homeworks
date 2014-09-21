package _7_problem;

import java.util.Scanner;

public class CountBitsOne {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		long number = scan.nextInt();
		int countOfOnes = 0;
		while(number > 0){
			if((number & 1) == 1){
				countOfOnes++;
			}
			number = number >> 1;
		}
		System.out.println(countOfOnes);
	
	}

}
