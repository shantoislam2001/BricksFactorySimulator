using UnityEngine;
using TMPro;

public class CheckFonts : MonoBehaviour
{
    void Start()
    {
        // Find all TextMeshPro objects in the scene
        TextMeshProUGUI[] textObjects = FindObjectsOfType<TextMeshProUGUI>();

        if (textObjects.Length > 0)
        {
            Debug.Log("Found " + textObjects.Length + " TextMeshProUGUI objects.");

            // Loop through each TextMeshPro object and check the font
            foreach (TextMeshProUGUI textObj in textObjects)
            {
                if (textObj.font != null)
                {
                    Debug.Log("Text Object: " + textObj.name + " | Font: " + textObj.font.name);
                }
                else
                {
                    Debug.LogWarning("Text Object: " + textObj.name + " has no font assigned.");
                }
            }
        }
        else
        {
            Debug.LogWarning("No TextMeshProUGUI objects found in the scene.");
        }
    }
}
