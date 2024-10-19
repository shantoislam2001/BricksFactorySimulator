using System.Collections.Generic;
using TMPro;
using UI.Dialogs;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static MultiPanelAnimationScript;

public class TruckRent : MonoBehaviour
{
    public Queue<string> drumpTruck = new Queue<string>();
    public Queue<string> truck = new Queue<string>();
    public Queue<string> van = new Queue<string>();

    [SerializeField] public GameObject truckPrefab;
    [SerializeField] public GameObject drumpTruckPrefab;
    [SerializeField] public GameObject vanPrefab;
    [SerializeField] public GameObject canvasOffice;
    [SerializeField] public GameObject rentPanel;

    [SerializeField] public Text dtRentStatus;
    [SerializeField] public Text truckRentStatus;
    [SerializeField] public Text vanRentStatus;

    public int rentStatusDt = 0;
    public int rentStatusTruck = 0;
    public int rentStatusVan = 0;

    public static int dtRentCost = 0;
    public static int truckRentCost = 0;
    public static int vanRentCost = 0;

    public int r = 0;
    Vector3 Position = new Vector3(2, 1, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    #region Take rent
    public void rentDt()
    {
        rentPanel.SetActive(false);
        canvasOffice.SetActive(false);
        
            if (parking.haveEmptySlot())
            {
                uDialog.NewDialog()
       .SetColorScheme("Green Highlight")
       .SetThemeImageSet(eThemeImageSet.SciFi)
       .SetIcon(eIconType.Warning)
       .SetTitleText("Confirmation")
       .SetShowTitleCloseButton(false)
       .SetContentText("<b>Warning:</b> Are you sure")
       .SetDimensions(400, 200)

       .AddButton("Confirm", () => {
           string n = "Rent " + r++;
           dtRentCost += 90;
           GameObject ob = Instantiate(drumpTruckPrefab, Position, Quaternion.identity);
           ob.name = n;
           parking.park(ob.name);
          
               drumpTruck.Enqueue(ob.name);
               transport.trucks.Add(ob.name);
               transport.drumpTruck.Add(ob.name);
               rentStatusDt++;
               dtRentStatus.text = "Rented : " + rentStatusDt;
           ob.gameObject.transform.Find("Truck number").GetComponent<TextMeshPro>().text = ob.name;


       })
       .AddButton("Cancel", () => { /* Call cancel functionality */})
       .SetCloseWhenAnyButtonClicked(true);


            }
            else
            {
            warning("No empty slot in parking lot");
            }
        
      
    }



    public void rentTruck()
    {
        rentPanel.SetActive(false);
        canvasOffice.SetActive(false);

        if (parking.haveEmptySlot())
        {
            uDialog.NewDialog()
   .SetColorScheme("Green Highlight")
   .SetThemeImageSet(eThemeImageSet.SciFi)
   .SetIcon(eIconType.Warning)
   .SetTitleText("Confirmation")
   .SetShowTitleCloseButton(false)
   .SetContentText("<b>Warning:</b> Are you sure")
   .SetDimensions(400, 200)

   .AddButton("Confirm", () => {
       string n = "Rent " + r++;
       truckRentCost += 220;
       GameObject ob = Instantiate(truckPrefab, Position, Quaternion.identity);
       ob.name = n;
       parking.park(ob.name);

       truck.Enqueue(ob.name);
       transport.trucks.Add(ob.name);
       
       rentStatusTruck++;
       truckRentStatus.text = "Rented : " + rentStatusTruck;
       ob.gameObject.transform.Find("Truck number").GetComponent<TextMeshPro>().text = ob.name;

   })
   .AddButton("Cancel", () => { /* Call cancel functionality */})
   .SetCloseWhenAnyButtonClicked(true);


        }
        else
        {
            warning("No empty slot in parking lot");
        }


    }


    public void rentVan()
    {
        rentPanel.SetActive(false);
        canvasOffice.SetActive(false);

        if (parking.haveEmptySlot())
        {
            uDialog.NewDialog()
   .SetColorScheme("Green Highlight")
   .SetThemeImageSet(eThemeImageSet.SciFi)
   .SetIcon(eIconType.Warning)
   .SetTitleText("Confirmation")
   .SetShowTitleCloseButton(false)
   .SetContentText("<b>Warning:</b> Are you sure")
   .SetDimensions(400, 200)

   .AddButton("Confirm", () => {
       string n = "Rent " + r++;
       vanRentCost += 350;
       GameObject ob = Instantiate(vanPrefab, Position, Quaternion.identity);
       ob.name = n;
       parking.park(ob.name);

       van.Enqueue(ob.name);
       transport.trucks.Add(ob.name);
       
       rentStatusVan++;
       vanRentStatus.text = "Rented : " + rentStatusVan;
       ob.gameObject.transform.Find("Truck number").GetComponent<TextMeshPro>().text = ob.name;

   })
   .AddButton("Cancel", () => { /* Call cancel functionality */})
   .SetCloseWhenAnyButtonClicked(true);
          

        }
        else
        {
            warning("No empty slot in parking lot");
        }


    }

    #endregion Take rent

    #region Give return

    public void returnDt()
    {
        if (Payments.pendingRentDay < 1)
        {
            if (rentStatusDt > 0)
            {
                dtRentCost -= 90;
                string n = drumpTruck.Dequeue();
                transport.trucks.Remove(n);
                transport.drumpTruck.Remove(n);
                Destroy(GameObject.Find(n));
                rentStatusDt--;
                dtRentStatus.text = "Rented : " + rentStatusDt;
            }
            else
            {
                rentPanel.SetActive(false);
                canvasOffice.SetActive(false);
                warning("You have no rented truck");
            }
        } else
        {
            rentPanel.SetActive(false);
            canvasOffice.SetActive(false);
            warning("Please pay truck rent bill");
        }
    }

    public void returnTruck()
    {
        if (Payments.pendingRentDay < 1)
        {
            if (rentStatusTruck > 0)
            {
                truckRentCost -= 220;
                string n = truck.Dequeue();
                transport.trucks.Remove(n);

                Destroy(GameObject.Find(n));
                rentStatusTruck--;
                truckRentStatus.text = "Rented : " + rentStatusTruck;
            }
            else
            {
                rentPanel.SetActive(false);
                canvasOffice.SetActive(false);
                warning("You have no rented truck");
            }
        } else
        {
            rentPanel.SetActive(false);
            canvasOffice.SetActive(false);
            warning("Please pay truck rent bill");
        }
    }

    public void returnVan()
    {
        if (Payments.pendingRentDay < 1)
        {
            if (rentStatusVan > 0)
            {
                vanRentCost -= 350;
                string n = van.Dequeue();
                transport.trucks.Remove(n);

                Destroy(GameObject.Find(n));
                rentStatusVan--;
                vanRentStatus.text = "Rented : " + rentStatusVan;
            }
            else
            {
                rentPanel.SetActive(false);
                canvasOffice.SetActive(false);
                warning("You have no rented truck");
            }
        } else
        {
            rentPanel.SetActive(false);
            canvasOffice.SetActive(false);
            warning("Please pay truck rent bill");
        }
    }


    #endregion Give return



    public void warning(string msg)
    {
        uDialog.NewDialog()
        .SetTitleText("Warning")
        .SetContentText(msg)
        .SetIcon(eIconType.Warning)
        .AddButton("Close", (dialog) => dialog.Close());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
