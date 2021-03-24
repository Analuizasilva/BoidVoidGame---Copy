using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public static class Context
{
    public static T Get<T>(string key)
    {
        var jsonString = PlayerPrefs.GetString(key);
        var value = JsonConvert.DeserializeObject<T>(jsonString);
        return value;
    }

    public static void Set(string key, object value, bool forceSave = false)
    {
        var jsonString = JsonConvert.SerializeObject(value);
        PlayerPrefs.SetString(key, jsonString);

        if (forceSave)
        {
            PlayerPrefs.Save();
        }
    }

    public static void DeleteAll(bool forceSave = false)
    {
        PlayerPrefs.DeleteAll();

        if (forceSave)
        {
            PlayerPrefs.Save();
        }
    }

    public static void Delete(string key, bool forceSave = false)
    {
        PlayerPrefs.DeleteKey(key);

        if (forceSave)
        {
            PlayerPrefs.Save();
        }
    }

    public static bool HasKey(string key)
    {
        return PlayerPrefs.HasKey(key);
    }
}