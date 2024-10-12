using JetBrains.Annotations;
using TMPro;
using UI.Dialogs;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TruckBuy : MonoBehaviour
{
    [SerializeField] public GameObject drumpTruck;
    [SerializeField] public GameObject truck;
    [SerializeField] public GameObject van;
    [SerializeField] public GameObject buyPanel;
    [SerializeField] public GameObject numberSetupPanel;
    [SerializeField] public GameObject officeCanvas;
    [SerializeField] public GameObject inputPanel;

    [SerializeField] public InputField input;
    private string customName;
    private GameObject cTruck;
    private int r = 4;

    Vector3 Position = new Vector3(2, 1, 0); // Example for spacing objects

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input.characterLimit = 13;
        input.onValueChanged.AddListener(OnInputChange);
    }

    public void BuyDrumpTruck()
    {
        if(currency.money >= 1000) {
            if(parking.haveEmptySlot())
            {
                buyPanel.SetActive(false);
                officeCanvas.SetActive(false);


                uDialog.NewDialog()
       .SetColorScheme("Green Highlight")
       .SetThemeImageSet(eThemeImageSet.SciFi)
       .SetIcon(eIconType.Warning)
       .SetTitleText("Confirmation")
       .SetShowTitleCloseButton(false)
       .SetContentText("<b>Warning:</b> Are you sure")
       .SetDimensions(400, 200)

       .AddButton("Confirm", () => { dtBuySucsese(); })
       .AddButton("Cancel", () => { /* Call cancel functionality */})
       .SetCloseWhenAnyButtonClicked(true);


            } else
            {
                warning("No empty slot in parking lot");
            }
        }
        else
        {
            warning("Not enough money");
        }
    }


    public void BuyTruck()
    {
        if (currency.money >= 1000)
        {
            if (parking.haveEmptySlot())
            {
                buyPanel.SetActive(false);
                officeCanvas.SetActive(false);


                uDialog.NewDialog()
       .SetColorScheme("Green Highlight")
       .SetThemeImageSet(eThemeImageSet.SciFi)
       .SetIcon(eIconType.Warning)
       .SetTitleText("Confirmation")
       .SetShowTitleCloseButton(false)
       .SetContentText("<b>Warning:</b> Are you sure")
       .SetDimensions(400, 200)

       .AddButton("Confirm", () => { TruckBuySucsese(); })
       .AddButton("Cancel", () => { /* Call cancel functionality */})
       .SetCloseWhenAnyButtonClicked(true);


            }
            else
            {
                warning("No empty slot in parking lot");
            }
        }
        else
        {
            warning("Not enough money");
        }
    }


    public void BuyVan()
    {
        if (currency.money >= 1000)
        {
            if (parking.haveEmptySlot())
            {
                buyPanel.SetActive(false);
                officeCanvas.SetActive(false);


                uDialog.NewDialog()
       .SetColorScheme("Green Highlight")
       .SetThemeImageSet(eThemeImageSet.SciFi)
       .SetIcon(eIconType.Warning)
       .SetTitleText("Confirmation")
       .SetShowTitleCloseButton(false)
       .SetContentText("<b>Warning:</b> Are you sure")
       .SetDimensions(400, 200)

       .AddButton("Confirm", () => { VanBuySucsese(); })
       .AddButton("Cancel", () => { /* Call cancel functionality */})
       .SetCloseWhenAnyButtonClicked(true);


            }
            else
            {
                warning("No empty slot in parking lot");
            }
        }
        else
        {
            warning("Not enough money");
        }
    }


    public void warning(string msg)
    {
        uDialog.NewDialog()
        .SetTitleText("Warning")
        .SetContentText(msg)
        .SetIcon(eIconType.Warning)
        .AddButton("Close", (dialog) => dialog.Close());
    }


    


    public void dtBuySucsese()
    {
        inputPanel.SetActive(true);
        currency.money -= 1000;
        GameObject ob = Instantiate(drumpTruck, Position, Quaternion.identity);
        cTruck = ob;
        parking.park(ob.name);
    }

    public void TruckBuySucsese()
    {
        inputPanel.SetActive(true);
        currency.money -= 1000;
        GameObject ob = Instantiate(truck, Position, Quaternion.identity);
        cTruck = ob;
        parking.park(ob.name);
    }


    public void VanBuySucsese()
    {
        inputPanel.SetActive(true);
        currency.money -= 1000;
        GameObject ob = Instantiate(truck, Position, Quaternion.identity);
        cTruck = ob;
        parking.park(ob.name);
    }


    public void setNameByCost()
    {
        if (currency.money >= 30000)
        {
            inputPanel.SetActive(false);
            currency.money -= 30000;
            cTruck.name = customName;
            transport.trucks.Add(customName);
            truckData td = cTruck.GetComponent<truckData>();

            if(td.type == "Drump truck")
            {
                transport.drumpTruck.Add(customName);
            }

            cTruck.gameObject.transform.Find("Truck number").GetComponent<TextMeshPro>().text = customName;
        } else
        {
            warning("Not enough money");
        }
       
 
    }

    public void setNameByRandom()
    {
        string randomNumber = "SI-24-" + r++;
        inputPanel.SetActive(false);
        cTruck.name = randomNumber;
        transport.trucks.Add(randomNumber);
        truckData td = cTruck.GetComponent<truckData>();
        if (td.type == "Drump truck")
        {
            transport.drumpTruck.Add(randomNumber);
        }
        cTruck.gameObject.transform.Find("Truck number").GetComponent<TextMeshPro>().text = randomNumber;
    }


    private void OnInputChange(string text)
    {
       customName = text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
