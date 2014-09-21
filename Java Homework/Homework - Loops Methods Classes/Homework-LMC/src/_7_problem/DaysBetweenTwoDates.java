package _7_problem;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Scanner;

public class DaysBetweenTwoDates {

	public static void main(String[] args) throws ParseException {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		SimpleDateFormat format = new SimpleDateFormat("dd-MM-yyyy");
		Date firstDate = format.parse(scan.nextLine());
		Date secondDate = format.parse(scan.nextLine());
		
		long diff = firstDate.getTime() - secondDate.getTime();
		long diffDays = diff / (24 * 60 * 60 * 1000);
		System.out.println(Math.abs(diffDays));
	}

}
