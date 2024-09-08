using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UI.Dialogs;

public class SoilList : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform itemHolder;
    public int numOfItem;

    private Timer timer;
    private GameObject cTruck;
    private Vector3 startPosition = new Vector3(533f, 0.11f, 546f);

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        RefreshTruckList();
    }

    void RefreshTruckList()
    {
        // Clear existing UI items
        foreach (Transform child in itemHolder)
        {
            Destroy(child.gameObject);
        }

        // Populate the UI with the updated list
        for (int i = 0; i < transport.drumpTruck.Count; i++)
        {
            GameObject item = Instantiate(itemPrefab, itemHolder);
            item.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = transport.drumpTruck[i];

            int index = i;
            item.GetComponent<Button>().onClick.AddListener(() => OnItemClick(index, transport.drumpTruck[index]));
        }
    }

    void OnItemClick(int index, string truck)
    {
        if (currency.money >= 225)
        {
            cTruck = GameObject.Find(truck);
            if (cTruck == null)
            {
                Debug.LogError("Truck not found: " + truck);
                return;
            }

            cTruck.transform.position = startPosition;
            cTruck.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            cTruck.GetComponent<CarAI>().enabled = true;
            cTruck.transform.Find("Audio Source").gameObject.SetActive(true);
            CarAI carAI = cTruck.GetComponent<CarAI>();
            carAI.SetActiveWaypointList("Car1", "go");

            timer = new Timer(210f, timeUp);
            TimerManager.AddTimer(timer);

            truckData truckDataComponent = cTruck.GetComponent<truckData>();
            truckDataComponent.status = "In route";
            truckDataComponent.load = "Soil";

            currency.removeMoney(225);
            transport.inRoute.Add(truck);
            transport.drumpTruck.RemoveAt(index);
            cTruck.GetComponent<BoxCollider>().enabled = false;

            RefreshTruckList();  // Refresh the list after removing the item
            Debug.Log("Clicked item number: " + index + " with value: " + truck);
        } else
        {
            warning();
        }
    }

    public void timeUp()
    {
        if (cTruck == null)
        {
            Debug.LogError("Truck not found for timeUp event.");
            return;
        }

        cTruck.transform.position = new Vector3(245f, 0.11f, 577f);
        cTruck.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        cTruck.SetActive(true);

        CarAI carAI = cTruck.GetComponent<CarAI>();
        carAI.SetActiveWaypointList("Car1", "return");

        cTruck.transform.Find("Soil").gameObject.SetActive(true);

        // Refresh the list after the truck returns
        RefreshTruckList();

        timer = new Timer(210f, timeEnd);
        TimerManager.AddTimer(timer);
    }

    public void timeEnd()
    {
        cTruck.transform.Find("Soil").gameObject.SetActive(false);
        currency.addSoil(15);
        
        transport.drumpTruck.Add(cTruck.gameObject.name);
        transport.inRoute.Remove(cTruck.gameObject.name);
        truckData truckDataComponent = cTruck.GetComponent<truckData>();
        truckDataComponent.status = "Parked";
        truckDataComponent.load = "Empty";
        parking.park(cTruck.gameObject.name);
        //  CarAI carAI = cTruck.GetComponent<CarAI>();
        // carAI.SetActiveWaypointList("Car1", "park");
        cTruck.GetComponent<CarAI>().enabled = false;
        cTruck.transform.Find("Audio Source").gameObject.SetActive(false);
        cTruck.GetComponent<BoxCollider>().enabled = true;
        RefreshTruckList();

    }

    public void warning()
    {
        uDialog.NewDialog()
        .SetTitleText("Warning")
        .SetContentText("Not enough momey")
        .SetIcon(eIconType.Warning)
        .AddButton("Close", (dialog) => dialog.Close());
    }

    void Update()
    {
        if (timer != null)
        {
          //  Debug.Log(timer.GetRemainingTime());
        }
    }
}
