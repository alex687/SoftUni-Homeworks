import java.io.FileNotFoundException;
import java.io.UnsupportedEncodingException;
import java.util.*;

public class Main {

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
		List<Double> numbersTop = new ArrayList<Double>();
		numbersTop.add((double) 5);
		numbersTop.add((double) 10);
		numbersTop.add((double) 12.5);
		numbersTop.add((double) 15);
		numbersTop.add((double) 17.5);
		numbersTop.add((double) 20);
		numbersTop.add((double) 22.5);
		numbersTop.add((double) 25);
		numbersTop.add((double) 27.5);

		List<Double> numbersLeft = new ArrayList<Double>();
		numbersLeft.add((double) 3.5);
		numbersLeft.add((double) 6);
		numbersLeft.add((double) 8.5);
		numbersLeft.add((double) 11);
		numbersLeft.add((double) 13.5);
		numbersLeft.add((double) 16);
		numbersLeft.add((double) 17);
		numbersLeft.add((double) 20);
		HouseSVG house = new HouseSVG(numbersTop, numbersLeft);
		house.addHeaders();
		house.generateHouse(12.5);

		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		int numberPoints = Integer.parseInt(scan.nextLine());
		for (int i = 0; i < numberPoints; i++) {

			String inputStr = scan.nextLine();
			String inp[] = inputStr.split(" ");

			double data[] = new double[2];
			data[0] = Double.parseDouble(inp[0]);
			data[1] = Double.parseDouble(inp[1]);

			if (data[0] < 8) {
				data[0] = 8;
			} else if (data[0] > 23) {
				data[0] = 23;
			}
			if (data[1] < 2) {
				data[1] = 2;
			} else if (data[1] > 17) {
				data[1] = 17;
			}
			
			if(isInsideTheHouse(data[0], data[1])){
				house.addPoint(data[0],  data[1], "black");
			}
			else{
				house.addPoint(data[0], data[1], "#bfbfbf");

			}
		}
		house.addClosingHeaders();

		try {
			house.saveHouseToFile("house");
			System.out.println("The file was created");
		} catch (FileNotFoundException | UnsupportedEncodingException e) {
			System.out.println("The file was not created");
		}
	}

}
