import java.util.Scanner;


public class CountBeers {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		int stacks = 0;
		int beers = 0;
		do{
			String input = scan.nextLine();
			if(input.equals("End")){
				break;
			}
			String[] splitInput = input.split(" ");
			if(splitInput[1].equals("beers")){
				beers += Integer.parseInt(splitInput[0]);
			}
			else{
				stacks += Integer.parseInt(splitInput[0]);
			}
		}while(true);
		
		stacks += beers / 20;
		System.out.println(stacks + " stacks + " + (int)(beers % 20) + " beers");
	}

}
