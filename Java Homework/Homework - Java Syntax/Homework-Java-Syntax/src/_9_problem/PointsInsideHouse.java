package _9_problem;

import java.util.Scanner;
import dots.Dots;

public class PointsInsideHouse {
	public static boolean isInsideTheHouse(double cordinateX, double cordinateY) {

		// check if inside the house
		double leftSide = ((12.5 - 17.5) * (cordinateY - 3.5) - (8.5 - 3.5)
				* (cordinateX - 17.5));
		double rightSide = ((22.5 - 17.5) * (cordinateY - 3.5) - (8.5 - 3.5)
				* (cordinateX - 17.5));

		boolean leftRoof = leftSide <= 0.0;
		boolean rightRoof = rightSide >= 0.0;
		boolean roof = leftRoof == true && rightRoof == true
				&& cordinateY <= 8.5;

		boolean leftWall = cordinateY >= 8.5 && cordinateY <= 13.5
				&& cordinateX >= 12.5 && cordinateX <= 17.5;
		boolean rightWall = cordinateY >= 8.5 && cordinateY <= 13.5
				&& cordinateX >= 20 && cordinateX <= 22.5;
		boolean walls = leftWall == true || rightWall == true;

		if (roof || walls) {
			return true;
		}

		return false;
	}

	
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);

		Dots dot = new Dots();
		dot.setX(scan.nextDouble());
		dot.setY(scan.nextDouble());

		if (isInsideTheHouse(dot.getX(), dot.getY())) {
			System.out.println("Inside");
		} else {
			System.out.println("Outside");
		}
	}

}
