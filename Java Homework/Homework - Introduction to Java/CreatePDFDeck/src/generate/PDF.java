package generate;

import com.itextpdf.text.BaseColor;
import com.itextpdf.text.Document;
import com.itextpdf.text.DocumentException;
import com.itextpdf.text.Font;
import com.itextpdf.text.Paragraph;
import com.itextpdf.text.pdf.BaseFont;
import com.itextpdf.text.pdf.PdfPTable;
import com.itextpdf.text.pdf.PdfWriter;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;

public class PDF {

	private String documentName;
	private String fontPath = "fonts"+File.separator+"times.ttf";

	private Document document;
	private BaseFont baseFont;

	public PDF(String documentName) throws DocumentException, IOException {
		this.documentName = documentName;
		this.document = new Document();
		this.baseFont = BaseFont.createFont(this.fontPath, BaseFont.IDENTITY_H,
				true);
	}

	public void setFont(String fontPath) throws DocumentException, IOException {
		this.baseFont = BaseFont
				.createFont(fontPath, BaseFont.IDENTITY_H, true);
	}

	public void generateRedBlackTable(String[][] tableData) {
		try {
			PdfWriter.getInstance(this.document, new FileOutputStream(
					this.documentName + ".pdf"));
			this.document.open();

			PdfPTable table = new PdfPTable(4);
			table.setWidthPercentage(100);
			table.getDefaultCell().setFixedHeight(180);

			Font black = new Font(baseFont, 75f, 0, BaseColor.BLACK);
			Font red = new Font(baseFont, 75f, 0, BaseColor.RED);

			for (int i = 0; i < tableData.length; i++) {
				for (int j = 0; j < tableData[i].length; j++) {
					if (j % 2 == 0) {
						table.addCell(new Paragraph(tableData[i][j] + " ",
								black));
					} else {
						table.addCell(new Paragraph(tableData[i][j] + " ", red));
					}
				}
			}
			this.document.add(table);
		} catch (Exception e) {
			this.document.close();
			throw new RuntimeException("The document was not created!!");
		}
	}

	public void save() {
		this.document.close();
	}

}