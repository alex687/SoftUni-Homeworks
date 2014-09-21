package _1_problem;

import java.util.Scanner;

public class SymmetricNumbersRange {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		int from = scan.nextInt();
		int to = scan.nextInt();
		for (int i = from; i <= to; i++) {
			String number = Integer.toString(i);
			boolean symmetric = true; 
			for (int j = 0; j < number.length()/2; j++) {
				if(number.charAt(j) != number.charAt(number.length()- (j +1))){
					symmetric = false;
					break;
				}
			}
			if(symmetric){
				System.out.println(number);
			}
		}
	}

}
