package _8_problem;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.math.BigDecimal;

public class SumTwoNumsFromFille {

	public static void main(String[] args) {

		BigDecimal result = new BigDecimal(0);

		try (
				BufferedReader fileReader = new BufferedReader(new FileReader("8-problem-txt"+File.separator+"Input.txt"));
			) {
			while (true) {
				String line = fileReader.readLine();
				
				if (line == null)
					break;
				
				BigDecimal number = new BigDecimal(line);
				result = result.add(number);
			}
			System.out.println(result.toString());
		} catch (IOException ioex) {
			System.err.println("Error");
		}
	}

}
