using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Common.Helpers
{
	public class VideoHelper
	{
		public static string MakeVideoName(string filename)
		{
			string extension = Path.GetExtension(filename);
			string name = "VIDEO_" + Guid.NewGuid().ToString();
			return name + extension;
		}
	}
}
