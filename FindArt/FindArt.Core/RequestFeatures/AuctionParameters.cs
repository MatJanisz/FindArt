using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindArt.Core.RequestFeatures
{
	public class AuctionParameters : RequestParameters
	{
		//used in filtering
		public bool Active { get; set; } = true;
	}
}
