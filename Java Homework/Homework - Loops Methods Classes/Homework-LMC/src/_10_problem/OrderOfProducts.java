package _10_problem;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class OrderOfProducts {
	public static List<String[]> readFile(String fileURL) throws FileNotFoundException, IOException{
		List<String[]> inputValues = new ArrayList<>();
		
		try (BufferedReader fileReader = new BufferedReader(new FileReader(fileURL));) {
			while (true) {
				String line = fileReader.readLine();

				if (line == null)
					break;

				inputValues.add(line.split(" "));
			}
		
		}
		return inputValues;
	}
	
	public static HashMap<String, Double> loadProducts() throws FileNotFoundException, IOException{
		List<String[]> input = readFile("10-problem-txt"+File.separator+"Products.txt");
		HashMap<String, Double> products = new HashMap<>(); 
		for (String[] inputLine : input) {
			products.put(inputLine[0], Double.parseDouble(inputLine[1]));
		}
		
		return products;
	}
	
	public static HashMap<String, Double> loadOrder() throws FileNotFoundException, IOException{
		List<String[]> input = readFile("10-problem-txt"+File.separator+"Order.txt");
		HashMap<String, Double> order = new HashMap<>();
		
		for (String[] inputLine : input) {
			if(order.containsKey(inputLine[1])){
				Double quantity = order.get(inputLine[1]);
				quantity += Double.parseDouble(inputLine[0]);
				order.put(inputLine[1], quantity);
			}
			else{
				order.put(inputLine[1], Double.parseDouble(inputLine[0]));
			}
		}
		
		return order;
	}
	
	public static void main(String[] args) {
		try {
			HashMap<String, Double> order = loadOrder();
			HashMap<String, Double> products = loadProducts();
			Double total = (double) 0; 
			for (String productName : order.keySet()) {
				Double size = order.get(productName);
				total += products.get(productName) * size;
			}
			
			System.out.println(total);
		} catch (IOException e) {
			System.err.println("Error");
		}
	}

}
