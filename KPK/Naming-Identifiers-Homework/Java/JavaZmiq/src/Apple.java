import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;


public class Apple {
	public static Random randomGenerator;
	private Point apple;
	private Color color;
	
	public Apple(Snake s) {
		apple = generateApple(s);
		color = Color.RED;		
	}
	
	public void draw(Graphics g){
		apple.render(g, color);
	}	
	
	public Point getPoint(){
		return apple;
	}
	
	private Point generateApple(Snake s) {
		randomGenerator = new Random();
		int x = randomGenerator.nextInt(30) * 20; 
		int y = randomGenerator.nextInt(30) * 20;
		for (Point snakePoint : s.body) {
			if (x == snakePoint.getX() || y == snakePoint.getY()) {
				return generateApple(s);				
			}
		}
		
		return new Point(x, y);
	}
}
