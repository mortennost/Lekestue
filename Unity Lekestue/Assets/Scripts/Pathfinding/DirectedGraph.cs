using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace AssemblyCSharp
{
	public class DirectedGraph
	{
		public Dictionary<int, Vertex> vertices;
		public Dictionary<int, List<int>> edges;
		
		private int _gridSize;
		private int _unitSize;
		
		public DirectedGraph( int gridSize, int unitSize )
		{
			_gridSize = gridSize;
			_unitSize = unitSize;
			//Debug.Log ( "DirectedGraph created" );
			
			vertices = new Dictionary<int, Vertex>();
			edges = new Dictionary<int, List<int>>();
			
			for ( int row = 0; row < _gridSize; ++row ) {
				
				for ( int col = 0; col < _gridSize; ++col ) {
					int index = vertices.Count;
					
					AddVertex( new Vertex( index,
						new Vector3( 	col * unitSize +( (float)_unitSize / 2.0f ),
										0.0f,
										row * _unitSize + ( (float)_unitSize / 2.0f ) ) ) );
						//new Vector3( col * unitSize, 0.0f, row * _unitSize ) ) );
				
				}
			}
			
			//0 1 2 
			//3 4 5
			//6 7 8 - last row dont check below
					
			//0		1 	2 	3
			//4 	5 	6 	7
			//8 	9 	10 	11
			
			//self + 1 			// not for last on each row
			//self + width + 1 	// not for last on each row
			
			//self + width - 1 	// not on first of each row
			//self + width // all // not for last row
			
			
			
			for ( int row = 0; row < _gridSize; ++row ) {
				for ( int col = 0; col < _gridSize; ++col ) {
					
					int self = col + ( row * _gridSize );
					
					if ( col != ( gridSize - 1 ) ) {
						//Debug.Log ( "Edge made for: " + self + " and " + ( self + 1 ) );
						AddEdge( vertices[ self ], vertices[ self + 1 ] );
						
						AddEdge( vertices[ self + 1], vertices[ self ] );
						
						if ( row != gridSize -1 ) {
						
							//Debug.Log ( "Edge made for: " + self + " and " + ( self + gridSize + 1 ) );
							AddEdge( vertices[ self ], vertices[ self + _gridSize + 1 ] );
						
							AddEdge( vertices[ self + _gridSize + 1 ], vertices[ self ] );
						}
						
						
					}
					
					if ( row != ( gridSize - 1 ) ) {
						//Debug.Log( "Edge made for: " + self + " and " + ( self + gridSize ) );
						AddEdge( vertices[ self ], vertices[ self + _gridSize ] );
						
						AddEdge( vertices[ self + _gridSize ], vertices[ self ] );
					}
					
					if ( ( col != 0 ) && ( row != _gridSize - 1 ) ) {
						//Debug.Log( "Edge made for: " + self + " and " + ( self + gridSize - 1 ) );
						AddEdge( vertices[ self ], vertices[ self + _gridSize - 1 ] );
						
						AddEdge( vertices[ self + _gridSize - 1 ], vertices[ self ] );
					}
				
				}
				
				
			}
			//Debug.Log( "WE FUCKING MADE " + edges.Count + " EDGES !! DURR " );
		}
		
		public void AddVertex(Vertex vertex)
		{
			vertices.Add(vertex.Index, vertex);
			edges.Add(vertex.Index, new List<int>());
		}
		
		public void AddEdge(Vertex vertex1, Vertex vertex2)
		{
			List<int> vertexConnections;
			if (edges.TryGetValue(vertex1.Index, out vertexConnections))
			{
				vertexConnections.Add(vertex2.Index);
			}
		}
		
		public int GetClosestVertex( Vector3 position )
		{
			int closestVertex;
			
			int roundedX = (int)Mathf.Clamp( Mathf.Floor( position.x ), 0, (_gridSize - 1 ) * _unitSize );
			int roundedZ = (int)Mathf.Clamp( Mathf.Floor( position.z ), 0, (_gridSize - 1 ) * _unitSize );
			closestVertex =  roundedX + roundedZ * GameObject.Find( "Grid" ).GetComponent<GridScript>().gridSize;
			//MidpointRounding.
			return closestVertex;
		}
		
		public void ToggleTraversable(Vector3 minPos, int xSize, int zSize, bool isTraversable)
		{
			/*
			int firstVertexIndex = GetClosestVertex(minPos);
			
			Vertex vertex;
			vertices.TryGetValue(firstVertexIndex, out vertex);
			vertex.IsTraversable = isTraversable;
			*/
			
			for ( int row = 0; row < xSize; ++row )
			{
				for ( int col = 0; col < zSize; ++col )
				{
					
					vertices[ GetClosestVertex( minPos + new Vector3( row, 0, col ) ) ].ToggleTraversable();
				}
			}
			
			
			/*
			for (int row = 0; row < xSize; ++row)
			{
				if (row > 0) firstVertexIndex += _gridSize;
				
				for (int column = 0; column < zSize; ++column)
				{
					firstVertexIndex += column;
					
					vertices.TryGetValue(firstVertexIndex, out vertex);
					vertex.IsTraversable = isTraversable;
				}
			}*/
			
			
			
			
		}
		
		
		public List<Vector3> GetShortestPath( Vector3 startPosition, Vector3 endPosition )
		{
			int startVertex = GetClosestVertex( startPosition );
			int endVertex = GetClosestVertex( endPosition );
			
			List<Vector3> path = new List<Vector3>();
			path.Add( vertices[ startVertex ].Position );
			
			int activeVertex = startVertex;
			List<int> connectedVertices;
			
			Vertex currentVertex;
			bool done = false;
			
			while ( !done )
			{
				// get all edges to active vertex
				if ( edges.TryGetValue( activeVertex, out connectedVertices ) )
				{
					currentVertex = null;
					float minDistanceSqr = Mathf.Infinity;
					
					// check all connected vertexes
					foreach ( int vertex in connectedVertices )
					{
						
						if ( vertices[ vertex ].IsTraversable || ( vertex == endVertex ) )
						{
							float distanceSqr = Vector3.SqrMagnitude( vertices[endVertex].Position - vertices[ vertex ].Position );
							
							// if distance is 0 then we're at endVertex
							if ( distanceSqr == 0 )
								done = true;
							
							// add the closest vertex to our curVertex
							if ( distanceSqr < minDistanceSqr )
							{
								minDistanceSqr = distanceSqr;
								currentVertex = vertices[vertex];
								
							}
						}
						
					}
					
					
					if ( currentVertex != null ) {
						path.Add( currentVertex.Position );
						activeVertex = currentVertex.Index;
					}
							
					if ( path.Count > 100 ) {
						path.Clear();
						done = true;
					}
					
				}
			}
			return path;
		}
		
		/*
		public List<Vector3> GetShortestPat( Vector3 startPosition, Vector3 endPosition )
		{
			
			int startVertex = GetClosestVertex ( startPosition );
			int endVertex = GetClosestVertex( endPosition );
			Vertex end;
			vertices.TryGetValue(endVertex, out end);
				
			List<Vector3> path = new List<Vector3>();
			path.Add(startPosition);
			
			int activeVertex = startVertex;
			List<int> connectedVertices;
			
			while ( ( activeVertex != endVertex ) )
			{
				
				if (edges.TryGetValue(activeVertex, out connectedVertices))
				{
					Vertex chosenVertex = null;
					float minDistanceSquared = Mathf.Infinity;
					foreach(int vertex in connectedVertices)
					{					
						Vertex connectedVertex;
						if (vertices.TryGetValue(vertex, out connectedVertex))
						{
							if (connectedVertex.IsTraversable)
							{
								// calculate distances to end vertex
								Vector3 distanceVector = end.Position - connectedVertex.Position;
								float distanceSquared = Vector3.SqrMagnitude( distanceVector );//Mathf.Pow(distanceVector.x, 2.0f) + Mathf.Pow(distanceVector.y, 2.0f) + Mathf.Pow(distanceVector.z, 2.0f);
								
								if (distanceSquared < minDistanceSquared)
								{
									minDistanceSquared = distanceSquared;
									chosenVertex = connectedVertex;
								}
							}
						}
					}
					
					if (chosenVertex != null)
					{
						path.Add(chosenVertex.Position);
						activeVertex = chosenVertex.Index;
					}
					else
					{
						activeVertex = endVertex;
					}
				}
			}
			
			return path;
		}
		*/
	}
}

