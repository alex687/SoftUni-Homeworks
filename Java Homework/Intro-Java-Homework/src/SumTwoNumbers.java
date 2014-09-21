import java.util.Scanner;


public class SumTwoNumbers {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		Integer firstNumber =  scan.nextInt();
		Integer secondNumber = scan.nextInt();
		System.out.println(firstNumber + secondNumber);

	}

}
