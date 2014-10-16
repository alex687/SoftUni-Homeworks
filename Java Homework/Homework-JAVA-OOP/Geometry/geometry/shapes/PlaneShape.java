package geometry.shapes;

import geometry.shapes.interfaces.*;

public abstract class PlaneShape extends Shape implements AreaMeasurable, PerimeterMeasurable  {

	public PlaneShape(int numberOfVertices) {
		super(numberOfVertices);
	}

	@Override
	public abstract double getArea();

	@Override
	public abstract double getPerimeter();

	@Override
	public String toString() {
		String className = this.getClass().getSimpleName();
		
		return "Shape Type: " + className +
				"\nArea: " + this.getArea() +
				"\nPerimeter: " + this.getPerimeter() + "\n" + 
				super.toString();
	}	
}
