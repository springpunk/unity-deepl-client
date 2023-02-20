# unity-deepl-client

DeepL API Client for Unity

# Notes:

- Currently **only supports syncronous API communication**, so it's better used within the editor.
  I'm working on asyncronous requests with callbacks.
- I have also decided not to throw errors should the request fail, but this may change in future versions (I'll try to maintain backward-compatibility for at least a couple of updates)

# How to install (using the Unity Package Manager)

- Click Window > Package Manager
- Press the "+" button in the top left corner
- Select "Add package from git URL..."
- Paste the git url for this repository: `https://github.com/springpunk/unity-deepl-client.git`

# Example usage

```cs
using Springpunk.DeepLAPICLient;

public static class TranslationManager {
    // Your DeepL API auth key
    private const string DEEPL_AUTH_KEY = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx:xx";
    private const string DEEPL_USER_AGENT = "<MyAppName>/<version>";

    public /*static*/ DeepLClient deepLClient = new(DEEPL_AUTH_KEY, DEEPL_USER_AGENT)

    public static string EnglishToItalian(string text){
        return deepLClient.GetTranslation(text, DeepLLang.ENGLISH, DeepLLang.ITALIAN)
    }
}
```
