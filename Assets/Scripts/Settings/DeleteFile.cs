using System.IO;
using UnityEngine;

public class DeleteFile : MonoBehaviour
{
    private string saveFilePath;

    private void Awake()
    {
        // Define the path to the save file
        saveFilePath = Path.Combine(Application.persistentDataPath, "savefile.json");
    }

    private void Start()
    {
        DeleteSaveFile();
    }

    // Method to delete the save file
    public void DeleteSaveFile()
    {
        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
            Debug.Log("Save file deleted!");
        }
        else
        {
            Debug.LogWarning("No save file found to delete.");
        }
    }
}
