using System.Collections.Generic;
using System.IO;
using System.Threading;
using SimpleJSON;

public class AudioTextLoader
{
    private static List<JSONNode> _descriptionList;
    private static JSONNode _selectedList;
    private const string FilePathName = "Assets/Resources/SoundDescriptions";


    public static string GetAudioDescription(string soundName)
    {
        if (_descriptionList == null)
        {
            LoadDescriptions();
        }

        var text = _selectedList[soundName];
        return text;
    }


    private static void LoadDescriptions()
    {
        _descriptionList = new List<JSONNode>();
        var filePath = new DirectoryInfo(FilePathName);
        var fileInfo = filePath.GetFiles("*.json", SearchOption.AllDirectories);

        foreach (var file in fileInfo)
        {
            var reader = file.OpenText();
            var text = reader.ReadToEnd();
            var list = JSON.Parse(text);
            _descriptionList.Add(list);
            reader.Close();
        }
        _selectedList = _descriptionList[0];
    }
}