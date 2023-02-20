using UnityEngine;

namespace Springpunk.DeepLAPIClient
{
    [System.Serializable]
    public struct APIResponse
    {
        [System.Serializable]
        public struct SingleEntry
        {
            public string detected_source_language;
            public string text;
        }
        public SingleEntry[] translations;

        public static string FromJson(string jsonResponse)
        {
            APIResponse parsed = JsonUtility.FromJson<APIResponse>(jsonResponse);
            return parsed.translations[0].text;
        }
    }
}