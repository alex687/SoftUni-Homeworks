package geometry.shapes;

import java.util.Arrays;

import geometry.vertices.Vertex;

public abstract class Shape {
	protected Vertex[] vertices;

	public Shape(int numberOfVertices) {
		this.vertices = new Vertex[numberOfVertices];
	}

	public String toString() {
		StringBuilder verticesText = new StringBuilder();
		Arrays.asList(vertices).stream()
				.forEach(x -> verticesText.append(x.toString() + "\r\n"));

		return verticesText.toString();
	}
}
