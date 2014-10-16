package geometry.shapes;

import geometry.vertices.Vertex3D;

public class SquarePyramid extends SpaceShape{
	private double baseWidth;
	private double height;
	private double slantHeight;

	public SquarePyramid(double x, double y, double z, double baseWidth,
			double height, double slantHeight) {
		
		super(1);
		this.vertices[0] = new Vertex3D(x, y, z);
		
		this.setBaseWidth(baseWidth);
		this.setHeight(height);
		this.setSlantHeight(slantHeight);
	}

	@Override
	public double getArea() {
		double faceArea = (1.0 / 2.0) * (4 * this.baseWidth) * this.height;
		double baseArea = this.getBaseArea();
		return faceArea + baseArea;
	}

	@Override
	public double getVolume() {
		return (1.0 / 3.0) * this.getBaseArea() * this.height;
	}

	private double getBaseArea() {
		return this.baseWidth * this.baseWidth;
	}

	public double getBaseWidth() {
		return this.baseWidth;
	}

	public void setBaseWidth(double baseWidth) {
		if (baseWidth < 0) {
			throw new IllegalArgumentException("Base width cannot be < 0");
		}
		
		this.baseWidth = baseWidth;
	}

	public double getHeight() {
		return this.height;
	}

	public void setHeight(double height) {
		if (height < 0) {
			throw new IllegalArgumentException("Height cannot be < 0");
		}
		
		this.height = height;
	}

	public double getSlantHeight() {
		return this.slantHeight;
	}

	public void setSlantHeight(double slantHeight) {
		if (slantHeight < 0) {
			throw new IllegalArgumentException("SlantHeight cannot be < 0");
		}
		
		this.slantHeight = slantHeight;
	}
}
