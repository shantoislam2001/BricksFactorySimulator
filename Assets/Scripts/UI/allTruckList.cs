using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class allTruckList : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform itemHolder;
    public int numOfItem;

    public Sprite dTruck;
    public Sprite van;
    public Sprite truck;

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        RefreshTruckList();
    }

   public void RefreshTruckList()
    {
        // Clear existing UI items
        foreach (Transform child in itemHolder)
        {
            Destroy(child.gameObject);
        }

        // Populate the UI with the updated list
        for (int i = 0; i < transport.trucks.Count; i++)
        {

            truckData td = GameObject.Find(transport.trucks[i]).GetComponent<truckData>();
            GameObject item = Instantiate(itemPrefab, itemHolder);
            item.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text ="Status : "+ td.status;
            item.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = "Number : " + transport.trucks[i];
            item.transform.GetChild(7).GetComponent<TextMeshProUGUI>().text = "Load : " + td.load;
            item.transform.GetChild(8).GetComponent<TextMeshProUGUI>().text = "Time left :"+ td.time;
            item.transform.GetChild(9).GetComponent<TextMeshProUGUI>().text = "Damage : " + td.damage;
            item.transform.GetChild(10).GetComponent<TextMeshProUGUI>().text = "Fuel : " + td.fuel;

            if (td.type == "Drump truck")
            {
                item.transform.GetChild(0).GetComponent<Image>().sprite = dTruck;
            }
            else if (td.type == "Van")
            {
                item.transform.GetChild(0).GetComponent<Image>().sprite = van;
            }
            else if (td.type == "Truck")
            {
                item.transform.GetChild(0).GetComponent<Image>().sprite = truck;
            }

        }
    }

  
    void Update()
    {
       
    }
}
