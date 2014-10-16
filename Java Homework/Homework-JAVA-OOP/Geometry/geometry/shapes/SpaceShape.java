package geometry.shapes;

import geometry.shapes.interfaces.*;
import geometry.vertices.Vertex3D;

public abstract class SpaceShape extends Shape implements AreaMeasurable,
		VolumeMeasurable {

	public SpaceShape(int numberOfVertices) {
		super(numberOfVertices);
		this.vertices = new Vertex3D[numberOfVertices];
	}

	@Override
	public abstract double getArea();

	@Override
	public abstract double getVolume();

	@Override
	public String toString() {
		String className = this.getClass().getName();

		return "Shape type: " + className + "\nArea: " + this.getArea() + "\n"
				+ "Volume: " + this.getVolume() + "\n" + super.toString();
	}
}
