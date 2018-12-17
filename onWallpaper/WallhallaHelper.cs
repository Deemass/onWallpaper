using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace onWallpaper
{
    class WallhallaHelper
    {
        private bool isDownloading = false;
        private ArrayList arrayList = new ArrayList();
        private ArrayList downloadedList = new ArrayList();
        private static string IMG_LIST_URL = "https://wallhalla.com/random";
        private static string IMG_DETAIL_URL = "https://wallhalla.com/wallpaper/";
        //private static string DEFAULT_IMG_URL = "https://alpha.wallhaven.cc/wallpapers/full/wallhaven-";

        public string getImgListAsync()
        {
            if (string.IsNullOrEmpty(CommonHelper.RESO))
            {
                IMG_LIST_URL += "?reso_atleast=1&reso=" + CommonHelper.RESO;
            }
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(new Uri(IMG_LIST_URL));
            req.ServicePoint.Expect100Continue = false;
            req.ServicePoint.UseNagleAlgorithm = false;
            req.AllowWriteStreamBuffering = false;
            req.Headers.Add("x-requested-with", "XMLHttpRequest");
            HttpWebResponse resp = (HttpWebResponse) req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string result = reader.ReadToEnd();
            req.Abort();
            JObject json = (JObject)JsonConvert.DeserializeObject(result);
            JArray datArray = JArray.Parse(json["results"]["response"]["docs"].ToString());
            foreach (var item in datArray)
            {
                JObject jdata = (JObject)item;
                arrayList.Add(jdata["id"].ToString());
            }
            return arrayList.Count.ToString();
        }

        public string DownloadImage(string id,string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(new Uri(url));
            req.ServicePoint.Expect100Continue = false;
            req.ServicePoint.UseNagleAlgorithm = false;
            req.AllowWriteStreamBuffering = false;
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string result = reader.ReadToEnd();
            req.Abort();

            ArrayList urls = new ArrayList();
            ArrayList ratios = new ArrayList();

            string pattern = "(?<=data-wallurl=\").*?(?=\")";
            MatchCollection mc = Regex.Matches(result, pattern);

            string ratioPattern = "(?<=info-reso\">).*?(?=</div>)";
            MatchCollection ratioMC = Regex.Matches(result, ratioPattern);
            string imgUrl = "";
            string imgPath = "";

            if (mc.Count > 0)
            {
                foreach (Match t in mc)
                {
                    urls.Add("https:"+ t.Value.ToString().Trim());
                }
            }
            if (ratioMC.Count > 0)
            {
                foreach (Match t in ratioMC)
                {
                    ratios.Add(t.Value.ToString().Trim());
                }
            }
            for (int i=0; i<urls.Count; i++)
            {
                if (CommonHelper.CheckReso((string)ratios[i]))
                {
                    imgUrl = (string) urls[i];
                    break;
                }
            }
            if (imgUrl != "")
            {
                WebClient client = new WebClient();
                imgPath = CommonHelper.GetConfigValue("downloadPath") + id + ".jpg";
                client.DownloadFile(new Uri(imgUrl), imgPath);
            }
            return imgPath;
        }

        public void StartDownloadQueue()
        {
            if (arrayList.Count < 5)
            {
                getImgListAsync();
            }
            if (arrayList.Count > 0 && !isDownloading)
            {
                isDownloading = true;
                int size = arrayList.Count;
                for (int i=0;i<2;i++)
                {
                    string imgPath = DownloadImage((string)arrayList[i], IMG_DETAIL_URL + (string)arrayList[i]);
                    downloadedList.Add(imgPath);
                }
                arrayList.RemoveRange(0, size);
                isDownloading = false;
                Trace.WriteLine("StartDownloadQueue：批次下载完成！");
            }
        }

        public string NextImagePath()
        {
            string imgPath = "";
            if (!isDownloading && downloadedList.Count == 0 && arrayList.Count == 0)
            {
                getImgListAsync();
                if (arrayList.Count > 0)
                {
                    imgPath = DownloadImage((string)arrayList[0], IMG_DETAIL_URL + (string)arrayList[0]);
                    arrayList.RemoveAt(0);
                    Task.Factory.StartNew(StartDownloadQueue);
                }
            }else if(downloadedList.Count > 0)
            {
                imgPath = (string) downloadedList[0];
                downloadedList.RemoveAt(0);
            }
            //检查已下载文件池是否小于5
            if (downloadedList.Count < 5 && !isDownloading)
            {
                Task.Factory.StartNew(StartDownloadQueue);
            }
            //检查历史图片缓存是否超过10张
            return imgPath;
        }
    }
}
