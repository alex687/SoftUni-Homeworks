package geometry.shapes;

import geometry.vertices.Vertex3D;

public class Sphere extends SpaceShape {
	private double radius;

	public Sphere(double x, double y, double z, double radius) {
		super(1);
		this.vertices[0] = new Vertex3D(x, y, z);

		this.setRadius(radius);
	}

	@Override
	public double getArea() {
		return 4.0 * Math.PI * Math.pow(this.radius, 2);
	}

	@Override
	public double getVolume() {
		return (4.0 / 3.0) * Math.PI * Math.pow(this.radius, 3);
	}

	public double getRadius() {
		return this.radius;
	}

	public void setRadius(double radius) {
		if (radius < 0) {
			throw new IllegalArgumentException("radius cannot be negative");
		}

		this.radius = radius;
	}
}
