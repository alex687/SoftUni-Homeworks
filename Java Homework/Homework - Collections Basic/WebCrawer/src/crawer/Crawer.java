package crawer;

import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.PrintWriter;
import java.io.UnsupportedEncodingException;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;

import org.apache.commons.validator.routines.UrlValidator;
import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

public class Crawer {

	private String url;
	private HashSet<String> crawedUrls;
	private int depth;

	public void printUrls() {
		for (String url : this.crawedUrls) {
			System.out.println(url);
		}
	}
	public void printToFile(String fileName) throws FileNotFoundException, UnsupportedEncodingException{
		try (PrintWriter writer = new PrintWriter(fileName, "UTF-8");) {
			for (String url : this.crawedUrls) {
				writer.println(url);
			}
		}
	}
	public int getDepth() {
		return depth;
	}

	public void setDepth(int depth) {
		this.depth = depth;
	}

	public String getUrl() {
		return url;
	}

	public void setUrl(String url) {
		UrlValidator urlValidator = new UrlValidator();
		if (urlValidator.isValid(url)) {
			this.url = url;
		} else {
			throw new IllegalArgumentException("The url is not valid");
		}
	}

	public Crawer(String url, int depth) {
		this.setUrl(url);
		this.setDepth(depth);
		this.crawedUrls = new HashSet<>();
	}

	public void startCrawing() throws IOException {
		Document doc = Jsoup.connect(this.url).get();
		this.crawedUrls.add(this.url);

		this.craw(doc, 0);
	}

	private void craw(Document doc, int currentDepth) {
		Elements resultLinks = doc.select("a[href]");
		List<Document> notCrawedPages = new ArrayList<>();
		for (Element link : resultLinks) {
			if (!this.crawedUrls.contains(link.attr("abs:href"))
					&& link.attr("href").charAt(0) != '#') {
				try {
					notCrawedPages.add(Jsoup.connect(link.attr("abs:href"))
							.get());

					this.crawedUrls.add(link.attr("abs:href"));
					System.out.println(link.attr("abs:href") + " -"
							+ (int) (currentDepth + 1));

				} catch (Exception e) {
				}
			}
		}

		for (Document page : notCrawedPages) {
			if (currentDepth + 1 < this.depth) {
				this.craw(page, currentDepth + 1);
			}
		}
	}
}
