using UnityEngine;
using UnityEngine.Networking;
//using System.Threading.Tasks;
using System.Text;

namespace Springpunk.DeepLAPIClient
{
    public class DeepLClient
    {
        private const string DEEPL_API_URL = "https://api-free.deepl.com/v2/translate";

        private readonly string apiAuthKey = "";
        private readonly string requestUserAgent = "MyApp/1.0.0";

        public DeepLClient(string apiAuthKey, string requestUserAgent)
        {
            this.apiAuthKey = apiAuthKey;
            this.requestUserAgent = requestUserAgent;
        }


        /// <summary>
        /// *Syncronoysly* send a request to the DeepL API and parse the response.
        /// </summary>
        /// <param name="textToTranslate">Text to be translated</param>
        /// <param name="sourceLanguage">Language to translate the text from</param>
        /// <param name="targetLanguage">Language to translate the text to</param>
        /// <returns>The translation of the source text</returns>
        public /*async*/ string GetTranslation(string textToTranslate, string sourceLanguage, string targetLanguage)
        {
            WWWForm form = new WWWForm();
            form.AddField("text", textToTranslate);
            form.AddField("target_lang", targetLanguage);
            form.AddField("source_lang", sourceLanguage);

            UnityWebRequest req = UnityWebRequest.Post(DEEPL_API_URL, form);
            req.SetRequestHeader("Authorization", $"DeepL-Auth-Key {this.apiAuthKey}");
            req.SetRequestHeader("User-Agent", this.requestUserAgent);

            UnityWebRequestAsyncOperation op = req.SendWebRequest();

            while (!op.isDone)
            {
                //await Task.Yield();
            }

            if (op.webRequest.responseCode != 200)
            {
                Debug.LogWarning($"Request terminated with response code: {op.webRequest.responseCode}");
                return "";
            }

            DownloadHandler dh = op.webRequest.downloadHandler;

            while (!dh.isDone)
            {
                //await Task.Yield();
            }

            string jsonResponse = Encoding.UTF8.GetString(dh.data);

            req.Dispose();
            return APIResponse.FromJson(jsonResponse);
        }
    }
}