package main;

import generate.PDF;

public class Main {

	public static void main(String[] args) {
		String[][] table = new String[13][4];

		String card = "";

		for (int i = 2; i <= 14; i++) {
			switch (i) {
			case 10:
				card = "10";
				break;
			case 11:
				card = " J";
				break;
			case 12:
				card = " Q";
				break;
			case 13:
				card = " K";
				break;
			case 14:
				card = " A";
				break;
			default:
				card = Integer.toString(i);
				break;
			}
			table[i-2][0] = (card + '♣');
			table[i-2][1] = (card + '♦');
			table[i-2][2] = (card + '♠');
			table[i-2][3] = (card + '♥');
		}

		for (int i = 0; i < table.length; i++) {
			for (int j = 0; j < table[i].length; j++) {
				System.out.print(org.apache.commons.lang3.StringUtils.leftPad(table[i][j], 5 , " "));
			}
			System.out.println("");
		} 

		try {
			PDF pdfdocument = new PDF("Deck-of-Cards");
			pdfdocument.generateRedBlackTable(table);
			pdfdocument.save();
			System.out.println("PDF document Created:)");
		} catch (Exception e) {
			System.out.println("The document was not created");
		}

	}

}
