using UnityEngine;
using System.IO;
using System.Collections.Generic;
using TMPro;
using NUnit.Framework;
using UI.Dialogs;

public class SaveGame : MonoBehaviour
{
    private string saveFilePath;
    public static List<string> Type = new List<string>();
    public static List<string> Load = new List<string>();

    [SerializeField] public GameObject drumpTruck;
    [SerializeField] public GameObject truck;
    [SerializeField] public GameObject van;
    [SerializeField] public GameObject disclimerUI;
    [SerializeField] public GameObject character;
    [SerializeField] public GameObject voice;
    [SerializeField] public GameObject orders;
    [SerializeField] public GameObject areaTrigger;
    [SerializeField] public GameObject canvasPlayer;
    [SerializeField] public GameObject orderList;

    public List<string> bricksType = new List<string>();
    public List<int> bricksQuantity = new List<int>();
    public List<float> perBricksPrice = new List<float>();
    public List<string> acceptTime = new List<string>();
    public List<int> orderXP = new List<int>();
    public List<float> totalAmount = new List<float>();
    public List<int> pendingPayment = new List<int>();
    public List<string> acceptStatus = new List<string>();
    public List<int> delivaredBricks = new List<int>();

    Vector3 Position = new Vector3(2, 1, 0);

    private void Start()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "saveData.json");
        LoadGame(); // Automatically load the game on start
    }

    public void getData()
    {
        Type.Clear();
        Load.Clear();
        GameObject cTruck = null;
        for (int i = 0; i < transport.trucks.Count; i++)
        {
            cTruck = GameObject.Find(transport.trucks[i]);
            Type.Add(cTruck.GetComponent<truckData>().type);
            Load.Add(cTruck.GetComponent<truckData>().load);
        }
    }

    public void saveGame()
    {
        getData();
        getOrderData();
        SaveData data = new SaveData
        {
            coins = 11,

            money = currency.money,
            soil = currency.soil,
            coal = currency.coal,
            firstClass = currency.firstClass,
            tenHole = currency.tenHole,
            threeHole = currency.threeHole,
            level = levelSystem.level,
            xp = levelSystem.currentXp,
            currentOrder = order.activeOrder,

            // bank 
            balance = Bank.balance,
            currentLoanAmount = Bank.currentLoanAmount,
            pendingInstallment = Bank.pendingInstallment,
            installmentPendingDay = Bank.installmentPendingDay,
            weeklyProfit = Bank.weeklyProfit,

            name = transport.trucks,
            type = Type,
            load = Load,

            drumpTruck = transport.drumpTruck,

            firstClass1k = new List<string>(transport.firstClass1k),
            firstClass2k = new List<string>(transport.firstClass2k), 
            firstClass3k = new List<string>(transport.firstClass3k),
            firstClass4k = new List<string>(transport.firstClass4k),
            firstClass5k = new List<string>(transport.firstClass5k),
            firstClass6k = new List<string>(transport.firstClass6k),
            tenHole1k = new List<string>(transport.tenHole1k),
            tenHole2k = new List<string>(transport.tenHole2k),
            tenHole3k = new List<string>(transport.tenHole3k),
            tenHole4k = new List<string>(transport.tenHole4k),
            tenHole5k = new List<string>(transport.tenHole5k),
            tenHole6k = new List<string>(transport.tenHole6k),
            threeHole1k = new List<string>(transport.threeHole1k),
            threeHole2k = new List<string>(transport.threeHole2k),
            threeHole3k = new List<string>(transport.threeHole3k),
            threeHole4k = new List<string>(transport.threeHole4k),
            threeHole5k = new List<string>(transport.threeHole5k),
            threeHole6k = new List<string>(transport.threeHole6k),
            // orders save system 
            activeOrders = transport.activeOrders,
            client = new List<string>(transport.client),
            bricksType = this.bricksType,
            bricksQuantity = this.bricksQuantity,
            perBricksPrice = this.perBricksPrice,
            acceptTime = this.acceptTime,
            orderXP = this.orderXP,
            totalAmount = this.totalAmount,
            pendingPayment = this.pendingPayment,
            acceptStatus = this.acceptStatus,
            delivaredBricks = this.delivaredBricks,


        };
       
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Game Saved: " + json);
    }

    public void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            stopTutorial();
            string json = File.ReadAllText(saveFilePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            // Use the loaded data (e.g., update UI, player stats, etc.)
            Debug.Log("Game Loaded: Coins: " + data.coins + ", Items: " + string.Join(", ", data.type[1]));

            currency.money = data.money;
            currency.soil = data.soil;
            currency.coal = data.coal;
            currency.firstClass = data.firstClass;
            currency.tenHole = data.tenHole;
            currency.threeHole = data.threeHole;
            levelSystem.level = data.level;
            levelSystem.currentXp = data.xp;
            order.activeOrder = data.currentOrder;
            // bank
            Bank.balance = data.balance;
            Bank.currentLoanAmount = data.currentLoanAmount;
            Bank.weeklyProfit = data.weeklyProfit;
            Bank.installmentPendingDay = data.installmentPendingDay;
            Bank.pendingInstallment = data.pendingInstallment;

            transport.trucks = data.name;
            transport.drumpTruck = data.drumpTruck;

           itaret(transport.firstClass1k, data.firstClass1k);
           itaret(transport.firstClass2k, data.firstClass2k);
           itaret(transport.firstClass3k, data.firstClass3k);
           itaret(transport.firstClass4k, data.firstClass4k);
           itaret(transport.firstClass5k, data.firstClass5k);
           itaret(transport.firstClass6k, data.firstClass6k);
           itaret(transport.tenHole1k, data.tenHole1k);
           itaret(transport.tenHole2k, data.tenHole2k);
           itaret(transport.tenHole3k, data.tenHole3k);
           itaret(transport.tenHole4k, data.tenHole4k);
           itaret(transport.tenHole5k, data.tenHole5k);
           itaret(transport.tenHole6k, data.tenHole6k);
           itaret(transport.threeHole1k, data.threeHole1k);
           itaret(transport.threeHole2k, data.threeHole2k);
           itaret(transport.threeHole3k, data.threeHole3k);
           itaret(transport.threeHole4k, data.threeHole4k);
           itaret(transport.threeHole5k, data.threeHole5k);
           itaret(transport.threeHole6k, data.threeHole6k);
            
            

            GameObject cTruck = null;
            for (int i = 0; i < data.name.Count; i++)
            {
               
                if(i < 3)
                {
                    cTruck = GameObject.Find(data.name[i]);
                    if (data.load[i] != "Empty")
                    {
                        cTruck.transform.Find("Bricks").gameObject.SetActive(true);
                        cTruck.GetComponent<truckData>().load = data.load[i];
                    }
                    parking.park(data.name[i]);
                }
                else
                {
                    if (data.type[i] == "Drump truck")
                    {
                        cTruck = Instantiate(drumpTruck, Position, Quaternion.identity);
                        cTruck.name = data.name[i];
                    }
                    else
                    if (data.type[i] == "Truck")
                    {
                        cTruck = Instantiate(truck, Position, Quaternion.identity);
                        cTruck.name = data.name[i];
                    }
                    else
                    if (data.type[i] == "Van")
                    {
                        cTruck = Instantiate(van, Position, Quaternion.identity);
                        cTruck.name = data.name[i];
                    }
                    if(data.load[i] != "Empty")
                    {
                        cTruck.transform.Find("Bricks").gameObject.gameObject.SetActive(true);
                        cTruck.GetComponent<truckData>().load = data.load[i];
                    }
                    cTruck.gameObject.transform.Find("Truck number").GetComponent<TextMeshPro>().text = data.name[i];
                    parking.park(data.name[i]);

                }
            }

            // Order save system 
            itaret(transport.client, data.client);
            Debug.Log("all client" + data.client[0]);
            transport.activeOrders = data.activeOrders;

            GameObject cClient = null;
            for(int i = 0;i < data.activeOrders.Count; i++)
            {
                cClient = orderList.transform.Find(data.activeOrders[i]).gameObject;
                cClient.SetActive(true);
                cClient.GetComponent<clientData>().brickType = data.bricksType[i];
                cClient.GetComponent<clientData>().brickQuantity = data.bricksQuantity[i];
                cClient.GetComponent<clientData>().perBrickPrice = data.perBricksPrice[i];
                cClient.GetComponent<clientData>().acceptTime = data.acceptTime[i];
                cClient.GetComponent<clientData>().xp = data.orderXP[i];
                cClient.GetComponent<clientData>().totalAmount = data.totalAmount[i];
                cClient.GetComponent<clientData>().pandingPayment = data.pendingPayment[i];
                cClient.GetComponent<clientData>().accept = data.acceptStatus[i];
                cClient.GetComponent<clientData>().delivered = data.delivaredBricks[i];
                
            }

        }
        else
        {
            Debug.Log("No save file found.");
        }
    }

    public void getOrderData()
    {
        bricksType.Clear();
        bricksQuantity.Clear();
        perBricksPrice.Clear();
        acceptTime.Clear();
        orderXP.Clear();
        totalAmount.Clear();
        pendingPayment.Clear();
        acceptStatus.Clear();
        delivaredBricks.Clear();

        GameObject cClient = null;
        for (int i = 0; i < transport.activeOrders.Count; i++)
        {
            cClient = orderList.transform.Find(transport.activeOrders[i]).gameObject;
            bricksType.Add(cClient.GetComponent<clientData>().brickType);
            bricksQuantity.Add(cClient.GetComponent<clientData>().brickQuantity);
            perBricksPrice.Add(cClient.GetComponent<clientData>().perBrickPrice);
            acceptTime.Add(cClient.GetComponent<clientData>().acceptTime);
            orderXP.Add(cClient.GetComponent<clientData>().xp);
            totalAmount.Add(cClient.GetComponent<clientData>().totalAmount);
            pendingPayment.Add(cClient.GetComponent<clientData>().pandingPayment);
            acceptStatus.Add(cClient.GetComponent<clientData>().accept);
            delivaredBricks.Add(cClient.GetComponent<clientData>().delivered);

        }
    }

    public void itaret(Queue<string> q, List<string> l)
    {
        q.Clear();
        foreach (string s in l)
        {
            q.Enqueue(s);
        }
    }

    public void stopTutorial()
    {
        disclimerUI.SetActive(false);
        character.SetActive(false);
        areaTrigger.SetActive(false);
        voice.SetActive(false);
        orders.GetComponent<order>().enabled = true;
        canvasPlayer.SetActive(true);
    }

}
