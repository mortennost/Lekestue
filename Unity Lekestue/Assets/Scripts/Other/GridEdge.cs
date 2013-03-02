using System;

namespace AssemblyCSharp
{
	/* Class representation of a graph edge, used for path plotting between two nodes */
	public class GridEdge
	{
		// Connecting-from node (valid node index >= 0)
		private uint fromIndex;
		public uint FromIndex
		{
			get { return fromIndex; }
			set { fromIndex = (value >= 0 && value < uint.MaxValue) ? value : 0; }
		}
		// Connecting-to node (valid node index >= 0)
		private uint toIndex;
		public uint ToIndex
		{
			get { return toIndex; }
			set { toIndex = (value >= 0 && value < uint.MaxValue) ? value : 0; }
		}
				
		public GridEdge(uint _fromIndex, uint _toIndex)
		{
			this.fromIndex	= _fromIndex;
			this.toIndex	= _toIndex;
		}
	}
}

