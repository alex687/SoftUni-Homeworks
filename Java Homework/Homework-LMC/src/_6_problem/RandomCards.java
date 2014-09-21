package _6_problem;

import java.util.ArrayList;
import java.util.Random;
import java.util.Scanner;

public class RandomCards {

	public static void main(String[] args) {
		String[] faces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J",
				"Q", "K", "A" };
		String[] suits = { "♣", "♦", "♥", "♠" };
		ArrayList<String> allCards = new ArrayList<String>();
		for (String face : faces) {
			for (String suit : suits) {
				String tempcard = face + suit;
				allCards.add(tempcard);
			}
		}
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		int numberOfRandomHands = scan.nextInt();
		
		Random rand = new Random();
		for (int i = 0; i < numberOfRandomHands; i++) {
			for (int j = 0; j < 5; j++) {
				int randomIndex = rand.nextInt(allCards.size());
				System.out.print(allCards.get(randomIndex) + " ");
			}
			System.out.println();
		}
	}

}
