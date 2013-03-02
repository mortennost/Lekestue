using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class GridNode
	{
		private Vector3 position;
		public Vector3 Position
		{
			get { return position; }
			set { position = value; }
		}
		
		public GridNode()
		{
			this.Position = Vector3.zero;
		}
		
		public GridNode(Vector3 _position)
		{
			this.Position = _position; 
		}
	}
}

