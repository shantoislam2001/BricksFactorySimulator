using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class clientList : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI Name;
    [SerializeField] public TextMeshProUGUI Address;
    [SerializeField] public TextMeshProUGUI Distence;
    [SerializeField] public TextMeshProUGUI BrickType;
    [SerializeField] public TextMeshProUGUI BrickQuantity;
    [SerializeField] public TextMeshProUGUI AcceptTime;
    [SerializeField] public TextMeshProUGUI PricePerBrick;
    [SerializeField] public TextMeshProUGUI TotalAmount;
    [SerializeField] public TextMeshProUGUI XP;
    [SerializeField] public ProgressBar pbar;
    [SerializeField] public TextMeshProUGUI pbarText;
    [SerializeField] public TextMeshProUGUI pandingPayment;

    public static clientData currentClient;
    public static GameObject cClient;

    // for ui 
    [SerializeField] public GameObject acceptB;
    [SerializeField] public GameObject cencelB;
    [SerializeField] public GameObject image;
    [SerializeField] public GameObject textUi;
    [SerializeField] public GameObject pberUi;
    [SerializeField] public GameObject textUi2;
    [SerializeField] public GameObject textUi3;
    [SerializeField] public GameObject ddUi;
    [SerializeField] public GameObject ddUi1;
    [SerializeField] public GameObject ddUi2;
    [SerializeField] public GameObject sendUi;
    [SerializeField] public GameObject pbarTextUi;
    [SerializeField] public GameObject availableTruckUi;
    [SerializeField] public GameObject timeUi;
    [SerializeField] public GameObject advancePui;
    [SerializeField] public GameObject getPui;
    [SerializeField] public GameObject requestPui;
    [SerializeField] public GameObject pendingPui;
    [SerializeField] public GameObject doneUi;


    void Start()
    {
        
    }

    public void p1()
    {
        cClient = gameObject.transform.Find("P1").GameObject();
        clientData cd = gameObject.transform.Find("P1").GetComponent<clientData>();
        updateInfo(cd);
        updateUi(cd);   
    }

    public void updateInfo(clientData cd)
    {
        currentClient = cd;
        Name.text = "Name: " + cd.name;
        Address.text = "Address: " + cd.address;
        Distence.text = "Distence: " + cd.distence + "km";
        BrickType.text = "Brick type: " + cd.brickType;
        BrickQuantity.text = "Brick quantity: " + cd.brickQuantity;
        AcceptTime.text = "Time to accept : " + cd.acceptTime;
        PricePerBrick.text = "Price is offered for each brick :" + cd.perBrickPrice.ToString("F2");
        TotalAmount.text = "Total amount: $" + FormatCurrency(cd.totalAmount);
        XP.text = "XP: " + cd.xp;
       // pbar.BarValue = 20.0f;
         pbarText.text = cd.delivered + " / " + cd.brickQuantity;
        pandingPayment.text = "Pending payment: $" + FormatCurrency(cd.totalAmount);
        
        if (cd.delivered >= cd.brickQuantity)
        {
            cd.accept = "done";
            updateUi(cd);
        }
    }


    public void updateUi(clientData cd)
    {
        string s = cd.accept;
        if (s == "none")
        {
            acceptB.SetActive(true);
            cencelB.SetActive(true);
            image.SetActive(false);
            textUi.SetActive(false);
            pberUi.SetActive(false);
            textUi2.SetActive(false);
            textUi3.SetActive(false);
            ddUi.SetActive(false);
            ddUi2.SetActive(false);
            ddUi1.SetActive(false);
            sendUi.SetActive(false);
            pbarTextUi.SetActive(false);
            availableTruckUi.SetActive(false);
            timeUi.SetActive(false);
            advancePui.SetActive(false);
            getPui.SetActive(false);
            requestPui.SetActive(false);
            pendingPui.SetActive(false);
            doneUi.SetActive(false);
        }
        else if (s == "accepted")
        {
            acceptB.SetActive(false);
            cencelB.SetActive(false);
            image.SetActive(true);
            textUi.SetActive(true);
            pberUi.SetActive(true);
            textUi2.SetActive(true);
            textUi3.SetActive(true);
           // ddUi.SetActive(true);
            sendUi.SetActive(true);
            pbarTextUi.SetActive(true);
            availableTruckUi.SetActive(true);
            timeUi.SetActive(true);
            pendingPui.SetActive(true);
            doneUi.SetActive(false);

            if(cd.brickType == "First Class")
            {
                ddUi.SetActive(true);
                ddUi1.SetActive(false);
                ddUi2.SetActive(false);
            } else if (cd.brickType == "Ten Hole")
            {
                ddUi2.SetActive(true);
                ddUi.SetActive(false);
                ddUi1.SetActive(false);
            } else if (cd.brickType == "Three Hole")
            {
                ddUi1.SetActive(true);
                ddUi.SetActive(false);
                ddUi2.SetActive(false);
            }


            if (cd.advancePayment == true)
            {
                advancePui.SetActive(false);
                getPui.SetActive(false);
                requestPui.SetActive(true);
            } else
            {
                advancePui.SetActive(true);
                getPui.SetActive(false);
                requestPui.SetActive(false);
            }
        }
        else if (s == "done")
        {
            acceptB.SetActive(false);
            cencelB.SetActive(false);
            image.SetActive(false);
            textUi.SetActive(false);
            pberUi.SetActive(false);
            textUi2.SetActive(false);
            textUi3.SetActive(false);
            ddUi.SetActive(false);
            ddUi1.SetActive(false);
            ddUi2.SetActive(false);
            sendUi.SetActive(false);
            pbarTextUi.SetActive(false);
            availableTruckUi.SetActive(false);
            timeUi.SetActive(false);
            advancePui.SetActive(false);
            getPui.SetActive(false);
            requestPui.SetActive(false);
            doneUi.SetActive(true);
            pendingPui.SetActive(false);
        }
        
    }

    public void Accept()
    {
        currentClient.accept = "accepted";
        updateUi(currentClient);
    }

    public void Cencel()
    {
        cClient.SetActive(false);
        transport.client.Enqueue(cClient.name);
    }

    public void getAvancePayment()
    {
        int m = (currentClient.pandingPayment / 100) * 30;
        currency.money += m;
        currentClient.pandingPayment -= m;
        pandingPayment.text = "Pending payment: $" + FormatCurrency(currentClient.pandingPayment);
        currentClient.paidPayment += m;
        advancePui.SetActive(false) ;
       // updateInfo(currentClient);
       // updateUi(currentClient);
    }

    public void Done()
    {
        currency.money += currentClient.pandingPayment; 
        levelSystem.currentXp += currentClient.xp;
        levelSystem.updateText();
        cClient.SetActive(false);
        Debug.Log(cClient.name);
    }

    private string FormatCurrency(float value)
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
