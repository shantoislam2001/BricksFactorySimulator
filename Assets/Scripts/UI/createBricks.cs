using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UI.Dialogs;

public class createBricks : MonoBehaviour
{
    private Timer timer1;
    [SerializeField] private TMP_Dropdown dd1;
    // Text slot 1
    [SerializeField] public TextMeshProUGUI s1soil;
    [SerializeField] public TextMeshProUGUI s1coal;
    [SerializeField] public TextMeshProUGUI s1time;
    [SerializeField] public TextMeshProUGUI s1slotTime;

    // buttons
    [SerializeField] public GameObject createB1;
    private int select1;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        select1 = 0; 
    }


    public void Dropdown1()
    {
        int i = dd1.value;

        if (i == 0)
        {
            select1 = 0;
            s1soil.text = "Soil: 50T";
            s1coal.text = "Coal: 10T";
            s1time.text = "Time: 3m";

        }
        else if (i == 1)
        {
            select1 = 1;
            s1soil.text = "Soil: 40T";
            s1coal.text = "Coal: 15T";
            s1time.text = "Time: 5m";


        }
        else if (i == 2)
        {
            select1 = 2;
            s1soil.text = "Soil: 35T";
            s1coal.text = "Coal: 15T";
            s1time.text = "Time: 6m";

        }else
        {
            select1 = 0;
            s1soil.text = "Soil: 50T";
            s1coal.text = "Coal: 10T";
            s1time.text = "Time: 3m";
        }

    }

    public void click1()
    {
        if (select1 == 0)
        { if (currency.soil >= 50 && currency.coal >= 10)
            {
                currency.removeSoil(50);
                currency.removeCoal(10);
                timer1 = new Timer(180f, timeUp1);
                TimerManager.AddTimer(timer1);
                createB1.SetActive(false);
            } else
            {
                warning("Not enough Soil and Coal");
            }
           
        }  else if (select1 == 1)
        {
            if (currency.soil >= 40 && currency.coal >= 15)
            {
                currency.removeSoil(40);
                currency.removeCoal(15);
                timer1 = new Timer(300f, timeUp1);
                TimerManager.AddTimer(timer1);
                createB1.SetActive(false);
            }
            else
            {
                warning("Not enough Soil and Coal");
            }

        }
        else if (select1 == 2)
        {
            if (currency.soil >= 35 && currency.coal >= 15)
            {
                currency.removeSoil(35);
                currency.removeCoal(15);
                timer1 = new Timer(360f, timeUp1);
                TimerManager.AddTimer(timer1);
                createB1.SetActive(false);
            }
            else
            {
                warning("Not enough Soil and Coal");
            }

        }


    }




    void timeUp1()
    {
        createB1.SetActive(true);
        if (select1 == 0)
        {
            currency.addFirstClass(5000);
        }
        else if (select1 == 1)
        {
            currency.addThreeHole(5000);
        } else if (select1 == 2)
        {
            currency.addTenHole(5000);
        }
    }

    public void warning(string s)
    {
        uDialog.NewDialog()
        .SetTitleText("Warning")
        .SetContentText(s)
        .SetIcon(eIconType.Warning)
        .AddButton("Close", (dialog) => dialog.Close());
    }

    // Update is called once per frame
    void Update()
    {
        s1slotTime.text = timer1.GetFormattedTime();
    }
}
