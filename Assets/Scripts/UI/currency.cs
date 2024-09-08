using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class currency : MonoBehaviour
{
    public TextMeshProUGUI moneyT;
    public TextMeshProUGUI firstClassT;
    public TextMeshProUGUI threeHoleT;
    public TextMeshProUGUI tenHoleT;
    public TextMeshProUGUI soilT;
    public TextMeshProUGUI coalT;

    public static int money;
    public static int firstClass;
    public static int threeHole;
    public static int tenHole;
    public static int coal;
    public static int soil;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        money = 10000;
        soil = 100; 
        coal = 100;
        firstClass = 2000;
    }

    // Update is called once per frame
    void Update()
    {
        setText();

    }

    public static void addMoney(int m)
    {
        money += m;
    }

    public static void removeMoney(int m)
    {
        money -= m;
    }

    public static void addFirstClass(int m) { firstClass += m; }
    public static void removeFirstClass(int m) { firstClass -= m; }
    public static void addThreeHole(int m) { threeHole += m; }
    public static void removeThreeHole(int m) { threeHole -= m; }
    public static void addTenHole(int m) { tenHole += m; }
    public static void removeTenHole(int m) { tenHole -= m; }
    public static void addSoil(int m) { soil += m; }
    public static void removeSoil(int m) { soil -= m; }
    public static void addCoal(int m) { coal += m; }
    public static void removeCoal(int m) { coal -= m; }




    public void setText() {
        moneyT.text = FormatCurrency(money);
        firstClassT.text = FormatCurrency(firstClass);
        threeHoleT.text = FormatCurrency(threeHole);
        tenHoleT.text = FormatCurrency(tenHole);
        coalT.text = coal + "T";
        soilT.text = soil + "T";
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
}
