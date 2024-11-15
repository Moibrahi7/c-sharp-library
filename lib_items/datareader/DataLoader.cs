using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using library;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;


namespace libraryDataLoader {
    public class DataLoader(){
        public void loadData(string filePath){
            JObject jObject = JObject.Load(new JsonTextReader(File.OpenText(filePath)));
            JArray resources = (JArray) jObject["mediaItems"];
            List<MediaItem> items = new();

            foreach (var item in resources){
                if (item["mediaType"].Value<string>() == "Book"){
                    Program.lib.AddMediaItem(new Book(item["title"].Value<string>(), item["barrower"].Value<string>() , item["author"].Value<string>().Split(',').ToList<string>(), item["numberOfPages"].Value<int>(), new Guid(item["id"].Value<string>())));
                }
                else{
                    Program.lib.AddMediaItem(new MediaItem(item["title"].Value<string>(), item["barrower"].Value<string>(), new Guid(item["id"].Value<string>())));
                }
            }
        }
    }
}