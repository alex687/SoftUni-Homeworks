import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.Scanner;
import java.util.TreeSet;


public class ThreeLargestNumbers {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		int n = scan.nextInt();
		scan.nextLine();
		List<BigDecimal> numbers = new ArrayList<>();
		
		for (int i = 0; i < n; i++) {
			BigDecimal number  = new BigDecimal(scan.nextLine().trim());
			numbers.add(number);
			
		}
		Collections.sort(numbers,Collections.reverseOrder());
		int count = 0;
		for (BigDecimal bigDecimal : numbers) {
			if(count == 3){
				break;
			}
			else{
				System.out.println(bigDecimal.toPlainString());
			}
			count ++;
		}	
	}

}