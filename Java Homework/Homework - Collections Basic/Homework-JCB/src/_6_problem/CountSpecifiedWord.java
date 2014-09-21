package _6_problem;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;

public class CountSpecifiedWord {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		String input = scan.nextLine().toLowerCase();
		List<String> words = new ArrayList<>(Arrays.asList(input.split("\\W+")));
		String word = scan.nextLine();
		System.out.println(words.stream().filter(x -> x.equals(word)).count());
	}

}
