using System.IO;
using SimpleJSON;

public class AudioTextLoader
{
    private const string FilePathName = "Assets/Resources/SoundDescriptions.json";
    private static JSONNode _descriptions;
    private static JSONNode _selectedDescriptions;


    public static string GetAudioDescription(string soundName)
    {
        if (_selectedDescriptions == null)
            LoadDescriptions();

        return _selectedDescriptions[soundName].Value;
    }


    private static void LoadDescriptions()
    {
        var reader = File.OpenText(FilePathName);
        var text = reader.ReadToEnd();
        var list = JSON.Parse(text);
        _descriptions = list["Lists"];
        _selectedDescriptions = list["Selected"];
        reader.Close();
    }


    private static void SaveDescriptions()
    {
        var node = new JSONObject();
        node["Lists"] = _descriptions;
        node["Selected"] = _selectedDescriptions;
        string text = node;
        File.WriteAllText(FilePathName, text);
    }
}