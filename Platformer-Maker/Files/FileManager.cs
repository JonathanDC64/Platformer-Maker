using System.Web.Script.Serialization;
using System.IO;
namespace Platformer_Maker.Files
{
	public class FileManager
	{
		public static string CurrentDirectory = Directory.GetCurrentDirectory();
		public static void WriteObjectFile<T>(T obj, string filename)
		{
			string JSON = new JavaScriptSerializer().Serialize(obj);
			File.WriteAllText(CurrentDirectory + "/" + filename, JSON);
		}

		public static T ReadObjectFile<T>(string filename)
		{
			string text = File.ReadAllText(CurrentDirectory + "/" + filename);
			T obj = (T)(new JavaScriptSerializer().Deserialize(text, typeof(T)));
			return obj;
		}

		public static bool FileExists(string filename)
		{
			return File.Exists(CurrentDirectory + "/" + filename);
		}
	}
}
