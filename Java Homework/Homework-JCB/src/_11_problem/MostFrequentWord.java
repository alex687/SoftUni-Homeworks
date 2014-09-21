package _11_problem;

import java.util.HashMap;
import java.util.Scanner;

public class MostFrequentWord {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);

		String text = scan.nextLine().toLowerCase();
		String[] words = text.split("\\W+");
		int times = 0;
		HashMap<String, Integer> wordsCounter = new HashMap<>();
		for (int i = 0; i < words.length; i++) {
			if (wordsCounter.containsKey(words[i])) {
				int before = wordsCounter.get(words[i]);
				wordsCounter.put(words[i], before + 1);
			} else {
				wordsCounter.put(words[i], 1);
			}
			if (times < wordsCounter.get(words[i])) {
				times = wordsCounter.get(words[i]);
			}
		}

		for (String word : wordsCounter.keySet()) {
			if (times == wordsCounter.get(word)) {
				System.out.println(word + " -> " + times);
			}
		}

	}
}
