using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveDataToJson
{
    //This will cause receiver and newObj to point to the same object if the assignment is successful.
    public static void SaveIntoJson<T>(T newValue, ref T receiver, string fileName) where T : class
    {
        receiver = newValue ?? receiver;
        if (receiver != null)
        {
#if UNITY_EDITOR
            string directoryPath = "";
            
                directoryPath = Application.dataPath + "/SavesFiles/";
            
       
#else
            //Change to  Application.persistentDataPath when it's go to production state
            string directoryPath = Application.persistentDataPath + "/SavesFiles/";
#endif

            if (fileName != "")
            {
                string filePath = fileName + ".json";
                string data = JsonUtility.ToJson(receiver);

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                File.WriteAllText(directoryPath + filePath, data);
                //                Debug.Log(receiver + " saved");
            }
            else
            {
                Debug.LogWarning("Save name is empty, it wasn't save");
            }

        }
        else
        {
            Debug.LogWarning("Not valid value");
        }
    }


    public static T LoadFromJson<T>(string fileName) where T : class
    {
#if UNITY_EDITOR
        string directoryPath = "";
       
            directoryPath = Application.dataPath + "/SavesFiles/";
      
#else
        //Change to  Application.persistentDataPath when it's go to production state
        //string filePath = Application.persistentDataPath + "/" + fileName + ".json";
        string directoryPath = Application.persistentDataPath + "/SavesFiles/";
#endif

        string filePath = fileName + ".json";

        if (Directory.Exists(directoryPath))
        {
            if (File.Exists(directoryPath + filePath))
            {
                string dataAsJson = File.ReadAllText(directoryPath + filePath);
                T loadedData = JsonUtility.FromJson<T>(dataAsJson);
                return loadedData;
            }
        }
        return null;
    }
}

[System.Serializable]
public class Match{
    
}
