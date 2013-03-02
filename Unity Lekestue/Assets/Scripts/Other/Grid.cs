using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Grid
	{
		private const uint DEFAULT_GRID_SIZE = 10;
		private const uint DEFAULT_UNIT_SIZE = 10;

		private uint gridSize;
		private uint unitSize;
		private GridNode[,] nodes;
		
		public uint GridSize
		{
			get { return gridSize; }
			set { gridSize = (value > 0 && value < uint.MaxValue) ? value : DEFAULT_GRID_SIZE; }
		}
		
		public uint UnitSize
		{
			get { return unitSize; }
			set { unitSize = (value > 0 && value < uint.MaxValue) ? value : DEFAULT_UNIT_SIZE; }
		}
		
		
		public Grid (uint _gridSize, uint _unitSize)
		{
			this.GridSize = _gridSize;
			this.UnitSize = _unitSize;
			
			CreateNodes();
		}
		
		public Vector3 GetCenter()
		{
			return new Vector3(	(float)gridSize * (float)unitSize / 2.0f, 0.0f, 
								(float)gridSize * (float)unitSize / 2.0f);
		}
		
		private void CreateNodes()
		{
			// Instantiate 2D-array to gridSize * gridSize nodes
			nodes = new GridNode[GridSize, GridSize];
			
			// Standard offset for the node's middle (width / 2 and height / 2)
			Vector3 nodeOffsetForMiddle = new Vector3((float) unitSize / 2.0f, 0.0f, (float) unitSize / 2.0f);
			
			for (int row = 0; row < nodes.GetUpperBound(0); ++row)
			{
				for (int col = 0; col < nodes.GetUpperBound(1); ++col)
				{
					Vector3 nodePosition = new Vector3((float) row * unitSize, 0.0f, (float) col * unitSize);
					
					nodePosition += nodeOffsetForMiddle;
					
					nodes[row, col] = new GridNode(nodePosition);
				}
			}
		}
	}
}