package geometry.shapes;

import geometry.vertices.*;

public class Triangle extends PlaneShape {

	public Triangle(double x1, double y1, double x2, double y2, double x3,
			double y3) {
		super(3);

		this.vertices[0] = new Vertex2D(x1, y1);
		this.vertices[1] = new Vertex2D(x2, y3);
		this.vertices[2] = new Vertex2D(x3, y3);
	}

	@Override
	public double getArea() {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public double getPerimeter() {
		// TODO Auto-generated method stub
		return 0;
	}

}
