import java.util.*;
import java.util.stream.Collectors;

import geometry.shapes.*;
import geometry.shapes.interfaces.PerimeterMeasurable;
import geometry.shapes.interfaces.VolumeMeasurable;

public class Test {

	public static void main(String[] args) {
		Shape[] shapeCollection = new Shape[6];
		shapeCollection[0] = new Triangle(1, -7, 3, 11, 20, 30);
		shapeCollection[1] = new Circle(122, -17, 13);
		shapeCollection[2] = new Rectangle(10, -70, 3, 22);
		shapeCollection[3] = new SquarePyramid(1, -7, 3, 11, 1, 2);
		shapeCollection[4] = new Cuboid(1, -7, 3, 11, 20, 30);
		shapeCollection[5] = new Sphere(97, -12, 3, 50);

		for (Shape shape : shapeCollection) {
			System.out.println(shape);
		}

		List<Shape> largeVolumeShapes = Arrays.asList(shapeCollection).stream()
				.filter(s -> s instanceof VolumeMeasurable)
				.filter(v -> ((VolumeMeasurable) v).getVolume() > 40)
				.collect(Collectors.toList());

		for (Shape shape : largeVolumeShapes) {
			 System.out.println(shape);
		}

		Comparator<Shape> byPerimeter = (s1, s2) -> {
			PerimeterMeasurable Shape1 = (PerimeterMeasurable) s1;
			PerimeterMeasurable Shape2 = (PerimeterMeasurable) s2;
			double perimeterShape1 = Shape1.getPerimeter();
			double perimeterShape2 = Shape2.getPerimeter();

			return perimeterShape1 < perimeterShape2 ? -1
					: perimeterShape1 > perimeterShape2 ? 1 : 0;
		};

		List<Shape> planeShapesByPerimeter = Arrays.asList(shapeCollection)
				.stream().filter(p -> p instanceof PlaneShape)
				.sorted(byPerimeter).collect(Collectors.toList());

		for (Shape shape : planeShapesByPerimeter) {
			System.out.println(shape);
		}
	}
}
