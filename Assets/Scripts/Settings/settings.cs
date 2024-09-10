using TMPro;
using UnityEngine;

public class settings : MonoBehaviour
{
    [SerializeField] public TMP_Dropdown dd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        autoSet();
        int cq = QualitySettings.GetQualityLevel();
        dd.value = cq;
    }


    public void setDD()
    {
        if(dd.value == 0)
        {
            QualitySettings.SetQualityLevel(0, true);
        }
        else if (dd.value == 1)
        {
            QualitySettings.SetQualityLevel(1, true);
        }
        else if (dd.value == 2)
        {
            QualitySettings.SetQualityLevel(2, true);
        }
        else if (dd.value == 3)
        {
            QualitySettings.SetQualityLevel(3, true);
        }
        else if (dd.value == 4)
        {
            QualitySettings.SetQualityLevel(4, true);
        }
        else if (dd.value == 5)
        {
            QualitySettings.SetQualityLevel(5, true);
        }
    }


    void autoSet()
    {
        int deviceMemory = SystemInfo.systemMemorySize; 
        int processorCount = SystemInfo.processorCount;  
        int graphicsMemory = SystemInfo.graphicsMemorySize; 

        
        if (deviceMemory >= 8192 && processorCount >= 8 && graphicsMemory >= 4096)
        {
            QualitySettings.SetQualityLevel(5, true); 
        }
        else if (deviceMemory >= 6144 && processorCount >= 6 && graphicsMemory >= 3072)
        {
            QualitySettings.SetQualityLevel(4, true); 
        }
        else if (deviceMemory >= 4096 && processorCount >= 4 && graphicsMemory >= 2048)
        {
            QualitySettings.SetQualityLevel(3, true); 
        }
        else if (deviceMemory >= 3072 && processorCount >= 4 && graphicsMemory >= 1536)
        {
            QualitySettings.SetQualityLevel(2, true); 
        }
        else if (deviceMemory >= 2048 && processorCount >= 2 && graphicsMemory >= 1024)
        {
            QualitySettings.SetQualityLevel(1, true); 
        }
        else
        {
            QualitySettings.SetQualityLevel(0, true); 
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
