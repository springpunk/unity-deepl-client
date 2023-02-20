# unity-deepl-client

DeepL API Client for Unity

# Notes:

Currently `only supports syncronous API communication`, so it's better used within the editor.
I'm working on asyncronous requests with callbacks.

# How to install

coming soon

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
