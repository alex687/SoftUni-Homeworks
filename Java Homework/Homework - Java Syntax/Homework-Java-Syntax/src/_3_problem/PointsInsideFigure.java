package _3_problem;

import java.util.Scanner;
import dots.Dots;

public class PointsInsideFigure {

	// Not a good name :( sorry
	public static boolean insideFigureOne(Dots dot) {
		// 12.5 <= x <= 22.5 && 6<= y <= 8.5
		return dot.getX() >= 12.5 && dot.getX() <= 22.5 && dot.getY() >= 6
				&& dot.getY() <= 8.5;
	}

	public static boolean insideSecondFigure(Dots dot) {
		// 12.5 <= x <= 13.5 && 8.5<= y <= 13.5
		return dot.getX() >= 12.5 && dot.getX() <= 17.5 && dot.getY() >= 8.5
				&& dot.getY() <= 13.5;
	}

	public static boolean insideThirthFigure(Dots dot) {
		// 20 <= x <= 22.5 && 8.5<= y <= 13.5
		return dot.getX() >= 20 && dot.getX() <= 22.5 && dot.getY() >= 8.5
				&& dot.getY() <= 13.5;
	}

	public static void main(String[] args) {

		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);

		Dots dot = new Dots();
		dot.setX(scan.nextDouble());
		dot.setY(scan.nextDouble());

		if (insideFigureOne(dot) || insideSecondFigure(dot)
				|| insideThirthFigure(dot)) {
			System.out.println("Inside");
		} else {
			System.out.println("Outside");
		}
	}

}
