package _2_problem;

import java.util.Scanner;

public class Gen3LetterWords {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		String characters = scan.nextLine();
		for (int i = 0; i < characters.length(); i++) {
			for (int j = 0; j < characters.length(); j++) {
				for (int j2 = 0; j2 < characters.length(); j2++) {
					System.out.println("" + characters.charAt(i)
							+ characters.charAt(j) + characters.charAt(j2));
				}
			}
		}
	}

}
