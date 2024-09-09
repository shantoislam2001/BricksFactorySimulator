using Unity.VisualScripting;
using UnityEngine;

public class order : MonoBehaviour
{
    private int level;
    [SerializeField] public GameObject list;
    public Timer timer;
    public static int activeOrder = 0;
    [SerializeField] public AudioSource newOrder;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sendOrder();
    }

    // for order sending 
    public void sendOrder()
    {
        int maxO = maxOrder(levelSystem.level);
        if (maxO > activeOrder)
        {
            newOrder.Play();    
            GameObject client = list.transform.Find(transport.client.Dequeue()).gameObject;
            clientData cd = client.GetComponent<clientData>();
            activeOrder++;
            client.SetActive(true);
            cd.brickType = type();
            cd.brickQuantity = quantity(levelSystem.level);
            cd.perBrickPrice = price();
            cd.acceptTime = time();
            cd.xp = cd.brickQuantity / 20;
            cd.totalAmount = cd.perBrickPrice * cd.brickQuantity;
            cd.pandingPayment = (int)cd.totalAmount;
            timer = new Timer(300f, timeUp);
            TimerManager.AddTimer(timer);

        } else
        {
            timer = new Timer(300f, timeUp);
            TimerManager.AddTimer(timer);
        }
    }
    public void timeUp()
    {
        sendOrder();
    }






   // For max order
    public int maxOrder(int l)
    {
        if (l == 1)
        {
            return 2;
        }
        else if (l == 2)
        {
            return 2;
        }
        else if (l == 3)
        {
            return 3;
        }
        else if (l == 4)
        {
            return 3;
        }
        else if (l == 5)
        {
            return 4;
        }
        else if (l == 6)
        {
            return 4;
        }
        else if (l == 7)
        {
            return 5;
        }
        else if (l == 8)
        {
            return 5;
        }
        else if (l == 9)
        {
            return 6;
        }
        else if (l > 9)
        {
            return 7;
        }else
        {
            return 7;
        }

    }

    // for price 
    public float price()
    {
        float r = Random.Range(0.3f, 0.7f);
        return r;
    }

    // for quantity
    public int quantity(int l)
    {
        int[] q = { 1000, 2000, 3000, 4000, 6000, 8000, 10000, 15000, 20000, 24000, 31000, 45000, 62000,
        76000,83000,100000};
        int i = 0;
        if(l <= 3)
        {
            i = Random.Range(0, 3);
            
        }
        else if (l > 3 && l <= 7)
        {
            i = Random.Range(3, 10);

        }
        else if (l > 7 && l <= 12)
        {
            i = Random.Range(5, 12);

        }
        else if (l > 12)
        {
            i = Random.Range(3, 15);

        }
        return q[i];
    }

    // for type 
    public string type()
    {
        string[] t = { "First Class", "Ten Hole", "Three Hole" };
        int i = Random.Range(0, 2);
        return t[i];
    }

    // for accept time 
    public string time()
    {
        string[] t = { "Day", "Night", "Anytime" };
        int i = Random.Range(0, 2);
        return t[i];
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
