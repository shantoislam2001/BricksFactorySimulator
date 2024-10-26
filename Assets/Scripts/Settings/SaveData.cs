using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public int coins;

    public int money;
    public int soil;
    public int coal;
    public int firstClass;
    public int tenHole;
    public int threeHole;
    public int level;
    public int xp;
    // bank
    public int balance;
    public int currentLoanAmount;
    public int pendingInstallment;
    public int weeklyProfit;
    public int installmentPendingDay;
    public int currentOrder;


    public List<string> name;
    public List<string> type;
    public List<string> load;

    public List<string> drumpTruck;

    public List<string> firstClass1k;
    public List<string> firstClass2k;
    public List<string> firstClass3k;
    public List<string> firstClass4k;
    public List<string> firstClass5k;
    public List<string> firstClass6k;

    public List<string> threeHole1k;
    public List<string> threeHole2k;
    public List<string> threeHole3k;
    public List<string> threeHole4k;
    public List<string> threeHole5k;
    public List<string> threeHole6k;

    public List<string> tenHole1k;
    public List<string> tenHole2k;
    public List<string> tenHole3k;
    public List<string> tenHole4k;
    public List<string> tenHole5k;
    public List<string> tenHole6k;
    // Orders save system
    public List<string> bricksType;
    public List<int> bricksQuantity;
    public List<float> perBricksPrice;
    public List<string> acceptTime;
    public List<int> orderXP;
    public List<float> totalAmount;
    public List<int> pendingPayment;
    public List<string> acceptStatus;
    public List<int> delivaredBricks;
    public int activeOrder;
    public List<string> client;
    public List<string> activeOrders;
}



