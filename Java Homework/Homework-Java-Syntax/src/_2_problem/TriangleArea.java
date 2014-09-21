package _2_problem;

import java.util.Scanner;
import dots.Dots;

public class TriangleArea {
	public static Scanner scan = new Scanner(System.in);

	public static Dots readCordinatesFromConsole() {
		Dots dot = new Dots();
		dot.setX(scan.nextInt());
		dot.setY(scan.nextInt());

		return dot;
	}

	public static int calculateTriangleAria(Dots a, Dots b, Dots c) {
		double area = ((a.getX() * (b.getY() - c.getY()))
				+ (b.getX() * (c.getY() - a.getY())) + (c.getX() * (a.getY() - b
				.getY()))) / 2;
		return Math.abs((int)area);
	}

	public static void main(String[] args) {

		Dots a, b, c;
		a = readCordinatesFromConsole();
		b = readCordinatesFromConsole();
		c = readCordinatesFromConsole();

		int area = calculateTriangleAria(a, b, c);
		System.out.println(area);
	}

}
