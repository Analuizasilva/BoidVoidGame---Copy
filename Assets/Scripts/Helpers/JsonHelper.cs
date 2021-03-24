using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonHelper
{
    public static T[] GetJsonArray<T>(string json, string wrapperName)
    {
        var jsonWrapper = json.Replace(wrapperName, "Content");
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(jsonWrapper);
        return wrapper.Content;
    }
}
