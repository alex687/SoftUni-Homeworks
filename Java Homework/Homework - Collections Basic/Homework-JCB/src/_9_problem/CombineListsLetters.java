package _9_problem;

import java.util.ArrayList;
import java.util.Scanner;

public class CombineListsLetters {

	public static boolean contains (String[] l1, char letter){
		for (int i = 0; i < l1.length; i++) {
			if (l1[i].charAt(0) == letter) {
				return true;
			}
		}
		return false;
	}
	
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		String[] l1 = scan.nextLine().split(" ");
		String[] l2 = scan.nextLine().split(" ");
		
		ArrayList<Character> combined = new ArrayList<>();
		for (int i = 0; i < l1.length; i++) {
			combined.add(l1[i].charAt(0));
		}

		for (int i = 0; i < l2.length; i++) {
			if (!contains(l1, l2[i].charAt(0) )) {
				combined.add(l2[i].charAt(0));
			}
		}
		for (Character letter : combined) {
			System.out.print(letter + " ");
		}
	}

}
