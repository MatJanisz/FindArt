using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindArt.Core.RequestFeatures
{
	public class ProductParameters : RequestParameters
	{
		//used in filtering
		public string ProductTypeName { get; set; }
	}
}
