package _4_problem;

import java.util.Scanner;

public class SmallestOf3Numbers {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);

		double firstNum = scan.nextDouble();
		double secondNum = scan.nextDouble();
		double tirthNum = scan.nextDouble();
		
		double minOfFistAndSec = Math.min(firstNum, secondNum);
		double min = Math.min(minOfFistAndSec, tirthNum);
		
		System.out.println(min);
	}

}
