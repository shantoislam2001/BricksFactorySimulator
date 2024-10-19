using TMPro;
using UI.Dialogs;
using UnityEngine;
using UnityEngine.UI;

public class Payments : MonoBehaviour
{
    [SerializeField] public GameObject truckRentItem;
    [SerializeField] public Text rentCostDisplay;
    [SerializeField] public GameObject canvasList;
    [SerializeField] public GameObject canvasOffice;
    [SerializeField] public GameObject listPanel;
    [SerializeField] public GameObject officePanel;
    [SerializeField] public AudioSource voice;
    private int totalRentCost = 0;
    public static int pendingRentDay = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // pendingRentDay = 3;
    }



    public void TruckRentBilPost (int cost) {

        if (cost > 0 && pendingRentDay < 3) 
        {
            truckRentItem.SetActive(true);
            rentCostDisplay.text = "$" + FormatCurrency(cost);
            pendingRentDay++;
            voice.Play();
        }

    }

  public void payRentTruckBill()
    {
        if (currency.money >=  totalRentCost)
        {
            truckRentItem.SetActive(false);
            currency.money -= totalRentCost;
            totalRentCost = 0;
            pendingRentDay--;
        } else
        {
            listPanel.SetActive(false);
            canvasList.SetActive(false);
            officePanel.SetActive(false);
            canvasOffice.SetActive(false);
            warning();
        }
    }

    private string FormatCurrency(int value)
    {
        if (value >= 1000000)
        {
            return (value / 1000000f).ToString("0.0") + "M";
        }
        else if (value >= 1000)
        {
            return (value / 1000f).ToString("0.0") + "k";
        }
        else
        {
            return value.ToString();
        }
    }
    public int i = 1;
    public int day = 0;
    // Update is called once per frame
    void Update()
    {
        if(dayNight.timeOfDay == 0 && i == 1)
        {
            day++;
            i++;
            TruckRentBilPost(totalRentCost += TruckRent.dtRentCost + TruckRent.truckRentCost + TruckRent.vanRentCost);
            Bank.sendProfit();
            Invoke("resetI", 120f);
        }
    }

    void resetI()
    {
        i = 1;
    }

    public void warning()
    {
        uDialog.NewDialog()
        .SetTitleText("Warning")
        .SetContentText("Not enough money")
        .SetIcon(eIconType.Warning)
        .AddButton("Close", (dialog) => dialog.Close());
    }

}
