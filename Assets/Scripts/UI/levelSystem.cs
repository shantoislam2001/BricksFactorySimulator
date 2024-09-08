using TMPro;
using UnityEngine;

public class levelSystem : MonoBehaviour
{
    public static int level = 1;
    public static int currentXp;
    public static int maxXp = 100;
   [SerializeField] public  ProgressBarCircle pbar;
   [SerializeField] public  TextMeshProUGUI levelText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateText();
    }

    static public void updateText()
    {
        if (currentXp >= maxXp)
        {
            level++;
            currentXp = 0;
            maxXp += 100; 
        }
       
    }

    

    // Update is called once per frame
    void Update()
    {
        levelText.text = "" + level;
        pbar.BarValue = currentXp / maxXp * 100;
    }
}
