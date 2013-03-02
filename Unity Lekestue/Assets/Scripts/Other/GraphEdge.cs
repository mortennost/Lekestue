using System;

namespace AssemblyCSharp
{
	public class GraphEdge
	{
		private int fromIndex;
		private int toIndex;
		private double cost;
		
		public GraphEdge(int _fromIndex, int _toIndex, double _cost)
		{
			this.fromIndex	= _fromIndex;
			this.toIndex	= _toIndex;
			this.cost		= _cost;
		}
	}
}

