package geometry.shapes;

import geometry.vertices.Vertex2D;

public class Rectangle extends PlaneShape {
	private double width;
	private double height;

	public Rectangle(double x1, double y1, double width, double height) {
		super(1);

		this.vertices[0] = new Vertex2D(x1, y1);
		this.setHeight(height);
		this.setWidth(width);
	}

	public double getWidth() {
		return width;
	}

	public void setWidth(double width) {
		if (width <= 0) {
			throw new IllegalArgumentException(
					"Invalid width. Width cannot be < 0");
		}

		this.width = width;
	}

	public double getHeight() {
		return height;
	}

	public void setHeight(double height) {
		if (height <= 0) {
			throw new IllegalArgumentException(
					"Invalid height. Height cannto be < 0");
		}

		this.height = height;
	}

	@Override
	public double getArea() {
		return this.width * this.height;
	}

	@Override
	public double getPerimeter() {
		return (2 * this.width) + (2 * this.height);
	}
}
