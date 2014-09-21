package _5_problem;

import java.util.Scanner;

public class AngleUnitConverter {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		int n = scan.nextInt();
		scan.nextLine();
		
		String input[] = new String[n];
		for (int i = 0; i < n; i++) {
			input[i] = scan.nextLine();
		}
		
	
		for (int i = 0; i < input.length; i++) {
			String[] splitInput = input[i].split(" ");
			
			if(splitInput[1].equals("deg")){
				double result = Math.toRadians(Double.parseDouble(splitInput[0]));
				System.out.printf("%.6f rad%n", result);
			}
			
			if(splitInput[1].equals("rad")){
				double result = Math.toDegrees(Double.parseDouble(splitInput[0]));
				System.out.printf("%.6f deg%n", result);
			}
		}

	}

}
