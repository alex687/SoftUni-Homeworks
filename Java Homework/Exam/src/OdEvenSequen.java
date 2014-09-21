import java.util.Scanner;

public class OdEvenSequen {
	public static boolean isInteger(String s) {
		try {
			Integer.parseInt(s);
		} catch (NumberFormatException e) {
			return false;
		}
		// only got here if we didn't return false
		return true;
	}

	public static void main(String[] args) {

		Scanner scan = new Scanner(System.in);
		String[] numbers = scan.nextLine().split("\\D+");
		int lenght = 0;
		for (int i = 0; i < numbers.length; i++) {
			if (isInteger(numbers[i])) {
				if (Integer.parseInt(numbers[i]) == 0) {
					boolean even = true;
					if ( numbers.length > i +1 && Integer.parseInt(numbers[i + 1]) % 2 == 0) {
						even = false;
					}
					int count = i + 1;
					lenght = checkOddEven(numbers, lenght, i, even, count);
				}
				if (Integer.parseInt(numbers[i]) % 2 == 0) {
					boolean even = true;
					int count = i + 1;
					lenght = checkOddEven(numbers, lenght, i, even, count);
				}
				if (Integer.parseInt(numbers[i]) % 2 != 0) {
					boolean even = false;
					int count = i + 1;
					lenght = checkOddEven(numbers, lenght, i, even, count);
				}
			}
		}
		System.out.println(lenght);
	}

	private static int checkOddEven(String[] numbers, int lenght, int i,
			boolean even, int count) {
		while (true) {
			if (even) {
				if (numbers.length > count
						&& ((Integer.parseInt(numbers[count]) % 2 != 0 || Integer
								.parseInt(numbers[count]) == 0))) {
					count++;
					even = false;
				} else {
					if (count - i > lenght) {
						lenght = count - i;
					}
					break;
				}
			} else {
				if (numbers.length > count
						&& ((Integer.parseInt(numbers[count]) % 2 == 0 || Integer
								.parseInt(numbers[count]) == 0))) {
					count++;
					even = true;
				} else {
					if (count - i > lenght) {
						lenght = count - i;
					}
					break;
				}
			}
		}
		return lenght;
	}

}
