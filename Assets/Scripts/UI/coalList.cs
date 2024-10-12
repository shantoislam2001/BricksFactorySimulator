using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UI.Dialogs;

public class coalList : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform itemHolder;
    public int numOfItem;

    [SerializeField] public GameObject uiObject;
    [SerializeField] public GameObject listPanel;
    [SerializeField] public GameObject canvasList;
    [SerializeField] public GameObject timerSoil;
    [SerializeField] public GameObject timerCoal;
    [SerializeField] public GameObject soilButton;
    [SerializeField] public GameObject coalButton;

    private Dictionary<GameObject, Timer> truckTimers = new Dictionary<GameObject, Timer>();
    private Vector3 startPosition = new Vector3(533f, 0.11f, 546f);
    public Queue<GameObject> tq = new Queue<GameObject>();  // Store the truck object instead of the name

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
        if (currency.money >= 500)
        {
            GameObject cTruck = GameObject.Find(truck);
            if (cTruck == null)
            {
                Debug.LogError("Truck not found: " + truck);
                return;
            }

            tq.Enqueue(cTruck);  // Store the truck object instead of its name
            cTruck.transform.position = startPosition;
            cTruck.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            cTruck.GetComponent<CarAI>().enabled = true;
            cTruck.transform.Find("Audio Source").gameObject.SetActive(true);
            CarAI carAI = cTruck.GetComponent<CarAI>();
            carAI.SetActiveWaypointList("Car1", "go");

            Timer truckTimer = new Timer(210f, () => timeUp(cTruck));  // Pass the truck object to timeUp
            TimerManager.AddTimer(truckTimer);
            truckTimers[cTruck] = truckTimer;  // Store the timer for this truck

            truckData truckDataComponent = cTruck.GetComponent<truckData>();
            truckDataComponent.status = "In route";
            truckDataComponent.load = "Coal";

            currency.removeMoney(500);
            transport.inRoute.Add(truck);
            transport.drumpTruck.RemoveAt(index);
            cTruck.GetComponent<BoxCollider>().enabled = false;
            uiObject.SetActive(false);
            listPanel.SetActive(false);
            canvasList.SetActive(false);
            timerSoil.SetActive(true);
            timerCoal.SetActive(true);
            soilButton.SetActive(false);
            coalButton.SetActive(false);
            RefreshTruckList();  // Refresh the list after removing the item
            Debug.Log("Clicked item number: " + index + " with value: " + truck);
            Invoke("activeButtons", 5f);
        }
        else
        {
            warning();
        }
    }

    public void timeUp(GameObject qTruck)
    {
        if (qTruck == null)
        {
            Debug.LogError("Truck not found in queue.");
            return;
        }

        qTruck.transform.position = new Vector3(245f, 0.11f, 577f);
        qTruck.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        qTruck.SetActive(true);

        CarAI carAI = qTruck.GetComponent<CarAI>();
        carAI.SetActiveWaypointList("Car1", "return");

        qTruck.transform.Find("Coal").gameObject.SetActive(true);

        RefreshTruckList();  // Refresh the list when truck returns

        Timer returnTimer = new Timer(210f, () => timeEnd(qTruck));  // Another timer for the return
        TimerManager.AddTimer(returnTimer);
        truckTimers[qTruck] = returnTimer;  // Update the truck's timer for the return
    }

    public void timeEnd(GameObject cTruck)
    {
        if (cTruck == null)
        {
            Debug.LogError("Truck not found.");
            return;
        }

        cTruck.transform.Find("Coal").gameObject.SetActive(false);
        currency.addCoal(10);

        transport.drumpTruck.Add(cTruck.gameObject.name);
        transport.inRoute.Remove(cTruck.gameObject.name);

        truckData truckDataComponent = cTruck.GetComponent<truckData>();
        truckDataComponent.status = "Parked";
        truckDataComponent.load = "Empty";

        parking.park(cTruck.gameObject.name);
        cTruck.GetComponent<CarAI>().enabled = false;
        cTruck.transform.Find("Audio Source").gameObject.SetActive(false);
        cTruck.GetComponent<BoxCollider>().enabled = true;

        RefreshTruckList();  // Refresh list after the truck finishes its return trip

        truckTimers.Remove(cTruck);  // Remove the truck's timer as it's done
    }

    public void warning()
    {
        uDialog.NewDialog()
        .SetTitleText("Warning")
        .SetContentText("Not enough money")
        .SetIcon(eIconType.Warning)
        .AddButton("Close", (dialog) => dialog.Close());
    }

    void activeButtons()
    {
        timerSoil.SetActive(false);
        timerCoal.SetActive(false);
        soilButton.SetActive(true);
        coalButton.SetActive(true);
    }

    void Update()
    {
        // You can add any timer updates here if needed
    }
}
