using UnityEngine;
using System.IO;

public static class FileSaver 
{
  
   public static void Save<T>(string fileName, T saveObject )
    {
        if (!File.Exists(fileName))
        {
            File.Create(fileName);
        }
        string json = JsonUtility.ToJson(saveObject);
        File.WriteAllText(fileName, json); 
    }


    public static T Load<T>(string fileName) where T : class
    {
        if (!File.Exists(fileName))
        {
            return null;
        }
        string json = File.ReadAllText(fileName);
        T savedObject = JsonUtility.FromJson<T>(json);
        return savedObject;
    }
}
