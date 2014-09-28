import java.awt.Color;
import java.awt.Graphics;

public class Point {
	private int x, y;
	private final int width = 20;
	private final int height = 20;
	
	public Point(Point p) {
		this(p.x, p.y);
	}
	
	public Point(int x, int y) {
		this.x = x;
		this.y = y;
	}	
		
	public int getX() {
		return x;
	}
	
	public void setX(int x) {
		this.x = x;
	}
	
	public int getY() {
		return y;
	}
	
	public void setY(int y) {
		this.y = y;
	}
	
	public void render(Graphics g, Color color) {
		g.setColor(Color.BLACK);
		g.fillRect(x, y, width, height);
		g.setColor(color);
		g.fillRect(x + 1, y + 1, width - 2, height - 2);		
	}
	
	public String toString() {
		return "[x=" + x + ",y=" + y + "]";
	}
	
	public boolean equals(Object object) {
        if (object instanceof Point) {
            Point otherPoint = (Point) object;
            return (x == otherPoint.x) && (y == otherPoint.y);
        }
        return false;
    }
}
