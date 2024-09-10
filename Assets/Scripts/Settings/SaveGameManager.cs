using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class GameData
{
    public float playerPosX;
    public float playerPosY;
    public float playerPosZ;
    public int playerScore;
    public int playerLevel;
}

public class SaveGameManager : MonoBehaviour
{
    public Transform player; // Reference to the player
    public int playerScore = 0; // Example score
    public int playerLevel = 1; // Example level

    public Button saveButton; // UI Button for saving the game
    public Button quitButton; // UI Button for quitting the game

    private string saveFilePath;

    void Start()
    {
        saveFilePath = Application.persistentDataPath + "/savegame.json";
        LoadGame(); // Automatically load game data when the game starts

        // Assign UI button functions
        saveButton.onClick.AddListener(SaveGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void SaveGame()
    {
        GameData data = new GameData
        {
            playerPosX = player.position.x,
            playerPosY = player.position.y,
            playerPosZ = player.position.z,
            playerScore = playerScore,
            playerLevel = playerLevel
        };

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFilePath, json);

        Debug.Log("Game Saved!");
    }

    public void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            GameData data = JsonUtility.FromJson<GameData>(json);

            // Load saved data
            player.position = new Vector3(data.playerPosX, data.playerPosY, data.playerPosZ);
            playerScore = data.playerScore;
            playerLevel = data.playerLevel;

            Debug.Log("Game Loaded!");
        }
        else
        {
            Debug.Log("No save data found!");
        }
    }

    public void QuitGame()
    {
        SaveGame(); // Save the game before quitting
        Application.Quit(); // Quit the application
        Debug.Log("Game Quit!");
    }
}
