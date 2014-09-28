import java.awt.Canvas;
import java.awt.Dimension;
import java.awt.Graphics;

@SuppressWarnings("serial")
public class TheGame extends Canvas implements Runnable {
	public static Snake snake;
	public static Apple apple;
	static int to4ki;
	
	private Graphics globalGraphics;
	private Thread runThread;
	public static final int width = 600;
	public static final int height = 600;
	private final Dimension gameDimensions = new Dimension(width, height);
	
	static boolean gameRunning = false;
	
	public void paint(Graphics g){
		this.setPreferredSize(gameDimensions);
		globalGraphics = g.create();
		to4ki = 0;
		
		if(runThread == null){
			runThread = new Thread(this);
			runThread.start();
			gameRunning = true;
		}
	}
	
	public void run(){
		while(gameRunning){
			snake.tick();
			render(globalGraphics);
			try {
				Thread.sleep(120);
			} catch (Exception e) {
			}
		}
	}
	
	public TheGame(){	
		snake = new Snake();
		apple = new Apple(snake);
	}
		
	public void render(Graphics g){
	    g.clearRect(0,0, width, height+25);
		g.drawRect(0, 0, width, height);			
		snake.render(g);
		apple.draw(g);
		g.drawString("score= " + to4ki, 10, height + 25);		
	}
}

