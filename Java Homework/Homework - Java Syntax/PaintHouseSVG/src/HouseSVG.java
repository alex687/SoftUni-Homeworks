import java.io.FileNotFoundException;
import java.io.PrintWriter;
import java.io.UnsupportedEncodingException;
import java.util.List;

public class HouseSVG {

	private List<Double> numbersTop;
	private int[] xCordinates;
	private int spaceBetweenTopNumbers = 15;
	private int numberPixelsSize = 14;

	private List<Double> numbersLeft;
	private int[] yCordinates;
	private int spaceBetweenLeftNumbers = 70;

	private StringBuilder pageCode;
	private String eol = System.getProperty("line.separator");
	private int leftPadding = 35;

	public HouseSVG(List<Double> numbersTop, List<Double> numbersLeft) {
		if (!this.isDataValid(numbersLeft) || !this.isDataValid(numbersTop)) {
			throw new IllegalArgumentException(
					"The given lists are empty or they are not sorted");
		}

		this.pageCode = new StringBuilder(2000);
		this.numbersTop = numbersTop;
		this.numbersLeft = numbersLeft;
	}

	private boolean isDataValid(List<Double> numbers) {
		if (numbers.isEmpty()) {
			return false;
		}

		for (int i = 1; i < numbers.size(); i++) {
			if (numbers.get(i) < numbers.get(i - 1)) {
				return false;
			}
		}

		return true;
	}

	public void addHeaders() {
		this.pageCode.append("<!DOCTYPE html>" + this.eol + "<html>" + this.eol
				+ "<body>" + this.eol + "<svg width=\"1000\" height=\"1000\">"
				+ this.eol);
	}

	private void addTopNumbersAndLines() {
		int xCordinate = this.getMaxLenghtOfNumber(this.numbersLeft) * 14 + this.leftPadding ;
		int[] numbersPixelsSizes = new int[this.numbersTop.size()];
		for (int i = 0; i < this.numbersTop.size(); i++) {
			this.pageCode.append("<text x=\"" + xCordinate
					+ "\" y=\"20\" font-size=\"27\">" + this.numbersTop.get(i)
					+ "</text>" + this.eol);
			numbersPixelsSizes[i] = this.numbersTop.get(i).toString().length()
					* this.numberPixelsSize;
			xCordinate += numbersPixelsSizes[i] + this.spaceBetweenTopNumbers;
		}

		// Draw lines
		 xCordinate = this.getMaxLenghtOfNumber(this.numbersLeft) * 14 + this.leftPadding + this.numberPixelsSize;
		int yCordinate = (this.numbersLeft.size() * this.spaceBetweenLeftNumbers) + 30;
		this.xCordinates = new int[this.numbersTop.size()];
		for (int i = 0; i < this.numbersTop.size(); i++) {
			this.xCordinates[i] = xCordinate;
			this.pageCode
					.append("<line x1=\""
							+ xCordinate
							+ "\" y1=\"30\" x2=\""
							+ xCordinate
							+ "\" y2=\""
							+ yCordinate
							+ "\" stroke-dasharray=\"2, 2\" style=\"stroke:rgb(211,228,244);stroke-width:2\" />"
							+ this.eol);
			if (i + 1 != this.numbersTop.size())
				xCordinate += numbersPixelsSizes[i + 1]
						+ this.spaceBetweenTopNumbers;

		}
	}

	private void addLeftNumbersAndLines() {

		int yCordinate = this.spaceBetweenLeftNumbers;
		for (int i = 0; i < this.numbersLeft.size(); i++) {
			this.pageCode.append("<text x=\"" + this.leftPadding + "\" y=\""
					+ yCordinate + "\" font-size=\"27\">"
					+ this.numbersLeft.get(i) + "</text>" + this.eol);
			yCordinate += this.spaceBetweenLeftNumbers;
		}

		yCordinate = this.spaceBetweenLeftNumbers + 2;

		int xCordinate = this.xCordinates[0];
		int x2Cordinate = this.xCordinates[this.xCordinates.length - 1];
		this.yCordinates = new int[this.numbersLeft.size()];
		for (int i = 0; i < this.numbersLeft.size(); i++) {
			this.yCordinates[i] = yCordinate;
			this.pageCode
					.append("<line x1=\""
							+ xCordinate
							+ "\" y1=\""
							+ yCordinate
							+ "\" x2=\""
							+ x2Cordinate
							+ "\" y2=\""
							+ yCordinate
							+ "\" stroke-dasharray=\"2, 2\" style=\"stroke:rgb(211,228,244);stroke-width:2\" />"
							+ this.eol);
			yCordinate += this.spaceBetweenLeftNumbers + 2;
		}
	}

	private int getMaxLenghtOfNumber(List<Double> numbers) {
		int maxLenght = 0;
		for (Double number : numbers) {
			if (maxLenght < number.toString().length()) {
				maxLenght = number.toString().length();
			}
		}

		return maxLenght;
	}

	// TODO make house movable :) !!!!!!!
	private void addTheHouse(int leftCordinate) {
		int rightCordinate = leftCordinate + 300;
		int topCordinate = (rightCordinate - leftCordinate) / 2 + leftCordinate;
		this.pageCode
				.append("<polygon points=\""
						+ topCordinate
						+ ",70 "
						+ rightCordinate
						+ ",217 "
						+ leftCordinate
						+ ",217\" style=\"fill:blue;stroke:#002065;stroke-width:2;fill-opacity:0.3;stroke-opacity:0.8\" />"
						+ this.eol);
		this.pageCode
				.append("<rect x=\""
						+ leftCordinate
						+ "\" y=\"217\" width=\"150\" height=\"143\" style=\"fill:blue;stroke:#002065;stroke-width:2;fill-opacity:0.3;stroke-opacity:0.8\" />"
						+ this.eol);
		leftCordinate += 223;
		this.pageCode
				.append("<rect x=\""
						+ leftCordinate
						+ "\" y=\"217\" width=\"77\" height=\"143\" style=\"fill:blue;stroke:#002065;stroke-width:2;fill-opacity:0.3;stroke-opacity:0.8\" />"
						+ this.eol);
	}

	private int scaleThePoint(List<Double> numbers, int[] cordinates,
			double cordinate) {
		int closestPointCordinate;

		double minDiff = Double.MAX_VALUE;
		int minIndex = 0;
		for (int i = 1; i < numbers.size(); i++) {
			if (minDiff > numbers.get(i) - cordinate
					&& Math.abs(numbers.get(i)) - Math.abs(cordinate) <= 0) {
				minDiff = Math.abs(numbers.get(i) - cordinate);
				minIndex = i;
			}
		}

		if (numbers.get(minIndex) == cordinate) {
			closestPointCordinate = cordinates[minIndex];
		} else {
			if (minIndex == numbers.size() - 1) {
				int scaling = (int) (cordinates[minIndex] / numbers
						.get(minIndex));

				closestPointCordinate = (int) (cordinate * scaling);
			} else {
				int scaling = (int) ((cordinates[minIndex] - cordinates[minIndex + 1]) / (numbers
						.get(minIndex) - numbers.get(minIndex + 1)));

				double first = (cordinate - numbers.get(minIndex)) * scaling;
				closestPointCordinate = (int) (cordinates[minIndex] + first);
			}
		}

		return closestPointCordinate;
	}

	public void addClosingHeaders() {
		this.pageCode.append("</svg>" + this.eol + this.eol + "</body>"
				+ this.eol + "</html>" + this.eol);
	}

	public void generateHouse(double leftCordinate) {
		this.addTopNumbersAndLines();
		this.addLeftNumbersAndLines();
		this.addTheHouse(this.scaleThePoint(this.numbersTop, this.xCordinates,
				leftCordinate));
	}

	public void addPoint(double cordinateX, double cordinateY, String color) {

		this.pageCode.append("<circle cx=\""
				+ this.scaleThePoint(numbersTop, xCordinates, cordinateX)
				+ "\" cy=\""
				+ this.scaleThePoint(numbersLeft, yCordinates, cordinateY)
				+ "\" r=\"5\" fill=\"" + color + "\" />" + this.eol);
	}

	public void saveHouseToFile(String fileName) throws FileNotFoundException,
			UnsupportedEncodingException {
		try (PrintWriter writer = new PrintWriter(fileName + ".html", "UTF-8")) {
			writer.println(this.pageCode.toString());
			writer.close();
		}
	}

	public String getPageCode() {
		return this.pageCode.toString();
	}

}