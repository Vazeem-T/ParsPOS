using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsVanSale.Services.ViewService
{
    public class ProgressTracker
    {
		private static Dictionary<string, int> downloadProgress = new Dictionary<string, int>();

		public static void SetProgress(string downloadKey, int progress)
		{
			downloadProgress[downloadKey] = progress;
		}

		public static int GetProgress(string downloadKey)
		{
			return downloadProgress.TryGetValue(downloadKey, out int progress) ? progress : 0;
		}
	}
}
