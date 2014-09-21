package _10_problem;

import java.util.Scanner;
import java.util.Set;
import java.util.TreeSet;

public class ExtractAllUniqueWords {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner in = new Scanner(System.in);
		String[] text = in.nextLine().toLowerCase().split("\\W+");
		Set<String> setWords = new TreeSet<>();
		for (String word : text) {
			setWords.add(word);
		}

		for (String word : setWords) {
			System.out.print(word + " ");
		}
	}

}
