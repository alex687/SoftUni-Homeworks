/*
You must download http://dox.bg/files/dw?a=e68982a3e4 . It's a rar file containing the needed libraries
- dom4j-1.6.1.jar
- poi-ooxml-3.10-FINAL-20140208.jar
- poi-3.10-FINAL-20140208.jar
- xmlbeans-2.3.0.jar
- poi-ooxml-schemas-3.10-FINAL-20140208.jar

These libraries must be in ExcelReader/lib
*/

import java.io.File;
import java.io.FileInputStream;
import java.util.TreeMap;

import org.apache.poi.ss.usermodel.Row;
import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;

public class Reader {

	public static void main(String[] args) {

		try (FileInputStream file = new FileInputStream(new File(
				"excelFile"+File.separator+"Incomes-Report.xlsx"));) {

			XSSFWorkbook workbook = new XSSFWorkbook(file);

			XSSFSheet sheet = workbook.getSheetAt(0);

			java.util.Iterator<Row> rowIterator = sheet.iterator();
			TreeMap<String, Double> cityTotalIncome = new TreeMap<>();
			rowIterator.next();
			while (rowIterator.hasNext()) {
				Row row = rowIterator.next();
				String townName = row.getCell(0).getStringCellValue();
				Double totalIncome = row.getCell(5).getNumericCellValue();

				if (cityTotalIncome.containsKey(townName)) {
					Double currentTotalIncome = cityTotalIncome.get(townName);
					cityTotalIncome.put(townName, currentTotalIncome
							+ totalIncome);
				} else {
					cityTotalIncome.put(townName, totalIncome);
				}
			}
			double grandTotal = 0;
			for (String townName : cityTotalIncome.keySet()) {
				System.out.print(townName + " Total -> ");
				System.out.println(cityTotalIncome.get(townName));

				grandTotal += cityTotalIncome.get(townName);
			}
			System.out.print("Grand Total  -> ");
			System.out.println(grandTotal);
		} catch (Exception e) {
			System.err.println("Error");
		}
	}
}
