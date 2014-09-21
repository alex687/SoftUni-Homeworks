package _3_problem;

import java.util.Scanner;

public class LargestSequenceEqualStrings {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		String input = scan.nextLine();
		String[] strings = input.split(" ");
		
		String sequence = strings[0] + " ";
		String maxSequence = "";
		for (int i = 1; i < strings.length; i++) {
			if(strings[i].equals(strings[i-1])){
				sequence += strings[i] + " ";
			}
			else{
				if(maxSequence.length() < sequence.length()){
					maxSequence = new String(sequence);
				}
				sequence =  strings[i] + " ";
			}
		}
		
		if(maxSequence.length() < sequence.length()){
			maxSequence = new String(sequence);
		}
		System.out.println(maxSequence);
	}

}
