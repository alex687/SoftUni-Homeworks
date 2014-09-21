package _5_problem;

import java.util.Scanner;

public class DecToHex {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		int dec = scan.nextInt();
		
		System.out.println(Integer.toHexString(dec).toUpperCase());
	}

}
