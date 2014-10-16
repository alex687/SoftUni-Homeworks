package geometry.shapes;

import geometry.vertices.Vertex2D;

public class Circle extends PlaneShape {
	private double radius;

	public Circle(double x1, double y1, double radius) {
		super(1);

		this.vertices[0] = new Vertex2D(x1, y1);
		this.setRadius(radius);
	}

	public double getRadius() {
		return radius;
	}

	public void setRadius(double radius) {
		if (radius < 0) {
			throw new IllegalArgumentException(
					"Invalid Radius. Radius canot be < 0");
		}

		this.radius = radius;
	}

	@Override
	public double getArea() {
		return Math.PI * (this.radius * this.radius);
	}

	@Override
	public double getPerimeter() {
		return 2.0 * Math.PI * this.radius;
	}

}
