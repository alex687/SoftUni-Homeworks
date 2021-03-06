package _3_problem;

import java.util.ArrayList;

public class FullHouse {

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

		String[] cards = new String[allCards.size()];
		cards = allCards.toArray(cards);

		int count = 0;
		for (int i = 0; i < cards.length; i++) {
			char face1 = cards[i].charAt(0);

			for (int j = i + 1; j < cards.length; j++) {
				char face2 = cards[j].charAt(0);

				for (int j2 = j + 1; j2 < cards.length; j2++) {
					char face3 = cards[j2].charAt(0);

					for (int k = 0; k < cards.length; k++) {
						char face4 = cards[k].charAt(0);

						for (int k2 = k + 1; k2 < cards.length; k2++) {
							char face5 = cards[k2].charAt(0);

							if (face1 == face2 && face2 == face3
									&& face4 == face5 && face5 != face1) {
								System.out.println(cards[i] + cards[j]
										+ cards[j2] + cards[k] + cards[k2]);
								count++;
							}
						}
					}
				}
			}
		}
		System.out.println(count);
	}

}
