package main;

import java.io.IOException;

import crawer.Crawer;

public class Main {

	public static void main(String[] args) throws IOException {
		Crawer craw = new Crawer("https://softuni.bg/", 1);
		craw.startCrawing();
		craw.printToFile("urls.txt");
	}

}
