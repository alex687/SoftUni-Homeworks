package geometry.vertices;

public class Vertex2D implements Vertex {
	private double x;
	private double y;

	public Vertex2D(double x, double y) {
		this.setX(x);
		this.setY(y);
	}

	@Override
	public double getX() {
		return this.x;
	}

	@Override
	public double getY() {
		return this.y;
	}

	@Override
	public void setX(double x) {
		this.x = x;
	}

	@Override
	public void setY(double y) {
		this.y = y;
	}

	@Override
	public String toString() {

		return "x=" + this.getX() + ",y=" + this.getY();
	}
}
