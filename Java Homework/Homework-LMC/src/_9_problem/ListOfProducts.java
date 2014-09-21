package _9_problem;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.PrintWriter;
import java.io.UnsupportedEncodingException;
import java.util.ArrayList;
import java.util.List;

import products.Product;

public class ListOfProducts {

	public static void printToFile(List<Product> products) throws FileNotFoundException, UnsupportedEncodingException {
		
		try (PrintWriter writer = new PrintWriter("9-problem-txt"+File.separator+"Output.txt", "UTF-8");) {
			for (Product product : products) {
				writer.println(product);
			}
		}
	}

	public static void main(String[] args) {

		List<Product> products = new ArrayList<>();

		try (BufferedReader fileReader = new BufferedReader(new FileReader(
				"9-problem-txt"+File.separator+"Input.txt"));) {
			while (true) {
				String line = fileReader.readLine();

				if (line == null)
					break;

				String input[] = line.split(" ");
				Product product = new Product(input[0],
						Double.parseDouble(input[1]));
				products.add(product);
			}
			products.sort(Product.comparator);
			printToFile(products);
		} catch (IOException ioex) {
			System.err.println("Error");
		}
	}

}
