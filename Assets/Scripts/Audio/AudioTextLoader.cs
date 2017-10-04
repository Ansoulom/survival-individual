using System.IO;
using SimpleJSON;

public class AudioTextLoader
{
    private const string FilePathName = "Assets/Resources/SoundDescriptions.json";
    private static JSONNode _descriptions;
    private static JSONNode _selectedDescriptions;
    private static JSONNode _base;


    public static string GetSelectedDescription(string soundName)
    {
        if (_selectedDescriptions == null)
            LoadDescriptions();

        return _selectedDescriptions[soundName].Value;
    }


    public static void SetSelectedDescription(string soundName, string value)
    {
        _selectedDescriptions[soundName] = value;
        SaveDescriptions();
    }


    private static void LoadDescriptions()
    {
        var reader = File.OpenText(FilePathName);
        var text = reader.ReadToEnd();
        _base = JSON.Parse(text);
        _descriptions = _base["Lists"];
        _selectedDescriptions = _base["Selected"];
        reader.Close();
    }


    public static void RemoveDescription(string name, string desc)
    {
        for (var i = 0; i < _descriptions[name].Count; ++i)
        {
            if (desc.Equals(_descriptions[name][i].Value))
            {

                _descriptions[name].Remove(i);
                break;
            }
        }
        SaveDescriptions();
    }


    public static void ChangeDescription(string name, string oldDesc, string newDesc)
    {
        if (string.IsNullOrEmpty(newDesc)) return;
        if (string.IsNullOrEmpty(oldDesc))
        {
            _descriptions[name].Add(newDesc);
            return;
        }
        for (var i = 0; i < _descriptions[name].Count; ++i)
        {
            if (oldDesc.Equals(_descriptions[name][i].Value))
            {
                _descriptions[name][i] = newDesc;
                break;
            }
        }
        //if(!succeeded)_descriptions[name].Add(newDesc);
        SaveDescriptions();
    }


    private static void SaveDescriptions()
    {
        // THIS SHIT IS BROKEN STAY AWAY
        _base["Lists"] = _descriptions;
        _base["Selected"] = _selectedDescriptions;
        var text = _base.ToString();
        File.WriteAllText(FilePathName, text);
    }


    public static string[] GetDescriptions(string soundName)
    {
        if(_descriptions == null)
            LoadDescriptions();

        var array = _descriptions[soundName].AsArray;
        var stringArray = new string[array.Count];
        for (var i = 0; i < array.Count; ++i)
        {
            stringArray[i] = array[i].Value;
        }

        return stringArray;
    }
}