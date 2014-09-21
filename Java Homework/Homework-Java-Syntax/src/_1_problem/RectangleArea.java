package _1_problem;

import java.util.Scanner;


public class RectangleArea {


	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		int a = Integer.parseInt(scan.nextLine());
		int b = Integer.parseInt(scan.nextLine());
		
		int rectangleArea = a * b ;
		
		System.out.println(rectangleArea);
	}

}
