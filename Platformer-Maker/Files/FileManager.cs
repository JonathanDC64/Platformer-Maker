using System.Web.Script.Serialization;
using System.IO;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Platformer_Maker.Files
{
	public class FileManager
	{
		public static string CurrentDirectory = Directory.GetCurrentDirectory();
		public static void WriteObjectFile<T>(T obj, string filename)
		{
			string JSON = JsonConvert.SerializeObject(obj);
			File.WriteAllText(CurrentDirectory + "/" + filename, JSON);
		}

		public static T ReadObjectFile<T>(string filename)
		{
			string text = File.ReadAllText(CurrentDirectory + "/" + filename);
			T obj = JsonConvert.DeserializeObject<T>(text);
			return obj;
		}

		public static bool FileExists(string filename)
		{
			return File.Exists(CurrentDirectory + "/" + filename);
		}
	}
}
