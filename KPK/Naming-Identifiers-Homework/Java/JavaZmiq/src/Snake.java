import java.awt.Color;
import java.awt.Graphics;
import java.util.LinkedList;

public class Snake{
	private static final int START_X = 120;
	private static final int START_Y = 100;
	private static final int END_X = 300;
	
	LinkedList<Point> body = new LinkedList<Point>();
	private Color color;
	private int velocityX, velocityY;
	
	public Snake() {
		color = Color.GREEN;
		body.add(new Point(300, 100)); 
		body.add(new Point(280, 100)); 
		body.add(new Point(260, 100)); 
		body.add(new Point(240, 100)); 
		body.add(new Point(220, 100)); 
		body.add(new Point(200, 100)); 
		body.add(new Point(180, 100));
		body.add(new Point(160, 100));
		body.add(new Point(140, 100));		
		body.add(new Point(120, 100));
			
		velocityX = 20;
		velocityY = 0;
	}
	
	public void render(Graphics g) {		
		for (Point point : this.body) {
			point.render(g, color);
		}
	}
	
	public void tick() {
		Point newPoint = new Point((body.get(0).getX() + velocityX), (body.get(0).getY() + velocityY));
		
		if (newPoint.getX() > TheGame.width - 20) {
		 	TheGame.gameRunning = false;
		} else if (newPoint.getX() < 0) {
			TheGame.gameRunning = false;
		} else if (newPoint.getY() < 0) {
			TheGame.gameRunning = false;
		} else if (newPoint.getY() > TheGame.height - 20) {
			TheGame.gameRunning = false;
		} else if (TheGame.apple.getPoint().equals(newPoint)) {
			body.add(TheGame.apple.getPoint());
			TheGame.apple = new Apple(this);
			TheGame.to4ki += 50;
		} else if (body.contains(newPoint)) {
			TheGame.gameRunning = false;
			System.out.println("You ate yourself");
		}	
		
		for (int i = body.size()-1; i > 0; i--) {
			body.set(i, new Point(body.get(i-1)));
		}	
		
		body.set(0, newPoint);
	}

	public int getVelocityX() {
		return velocityX;
	}

	public void setVelocityX(int velX) {
		this.velocityX = velX;
	}

	public int getVelocityY() {
		return velocityY;
	}

	public void setVelocityY(int velY) {
		this.velocityY = velY;
	}
}
