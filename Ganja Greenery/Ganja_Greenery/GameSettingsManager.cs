using System.Collections.Generic;

// GameSettingsManager requires several parameters: an ID for the setting to change, and the value to change it width.
// Because value and id are both strings, a dictionary has been defined.

class GameSettingsManager
{
    protected Dictionary<string, string> stringSettings;

    public GameSettingsManager()
    {
        stringSettings = new Dictionary<string, string>();
    }

    // SetValue method
    // Use GameSettingsManager.SetValue("string_name", "string_value") to store a string combination in the dictionary.
    public void SetValue(string key, string value)
    {
        stringSettings[key] = value;
    }

    // GetValue method
    // Use GameSettingsManager.GetValue("string_name", "string_value") to retrieve a string combination from the dictionary.
    public string GetValue(string key)
    {
        if (stringSettings.ContainsKey(key))
            return stringSettings[key];
        else
            return "";

    }
}

