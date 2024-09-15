using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using UI.Dialogs;

public class loadAT : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdownDt;
    [SerializeField] private TMP_Dropdown dropdownTruck;
    [SerializeField] private TMP_Dropdown dropdownVan;
    [SerializeField] public GameObject dt;
    [SerializeField] public GameObject truck;
    [SerializeField] public GameObject van;
    [SerializeField] public GameObject canvas;
    private string currentTruck;
    private string selectDt = "First Class(1k)";
    private string selectTruck = "First Class(3k)";
    private string selectVan = "First Class(5k)";
    private Timer timer;
    [SerializeField] public AudioSource loadingStart;
    [SerializeField] public AudioSource loadingComplete;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            truckData td = other.gameObject.GetComponent<truckData>();
            currentTruck = other.gameObject.name;
            if (td != null)
            {
                if(td.type == "Drump truck" && td.load == "Empty")
                {
                    canvas.SetActive(true);
                    dt.SetActive(true);
                }  else if (td.type == "Truck" && td.load == "Empty")
                {
                    canvas.SetActive(true);
                    truck.SetActive(true);
                } else if (td.type == "Van" && td.load == "Empty")
                {
                    canvas.SetActive(true);
                    van.SetActive(true);
                }

            }
            
        }
    }

    public void dropdownDrumpTruck () {
        Debug.Log("dt");
        int v = dropdownDt.value;
        if (v == 0)
        {
            selectDt = "First Class(1k)";
        } else if (v == 1)
        {
            selectDt = "First Class(2k)";
        } else if (v == 2)
        {
            selectDt = "Three Hole(1k)";
        }  else if (v == 3)
        {
            selectDt = "Three Hole(2k)";
        } else if (v == 4)
        {
            selectDt = "Ten Hole(1k)";
        } else if (v == 5)
        {
            selectDt = "Ten Hole(2k)";
        } else
        {
            selectDt = "First Class(1k)";
        }

    }

    public void DropdownTruck()
    {
        Debug.Log("truck");
        int v = dropdownTruck.value;
        if (v == 0)
        {
            selectTruck = "First Class(3k)";
        }
        else if (v == 1)
        {
            selectTruck = "First Class(4k)";
        }
        else if (v == 2)
        {
            selectTruck = "Three Hole(3k)";
        }
        else if (v == 3)
        {
            selectTruck = "Three Hole(4k)";
        }
        else if (v == 4)
        {
            selectTruck = "Ten Hole(3k)";
        }
        else if (v == 5)
        {
            selectTruck = "Ten Hole(4k)";
        }
        else
        {
            selectTruck = "First Class(3k)";
        }

    }

    public void DropdownVan()
    {
        Debug.Log("van");
        int v = dropdownVan.value;
        if (v == 0)
        {
            selectVan = "First Class(5k)";
        }
        else if (v == 1)
        {
            selectVan = "First Class(6k)";
        }
        else if (v == 2)
        {
            selectVan = "Three Hole(5k)";
        }
        else if (v == 3)
        {
            selectVan = "Three Hole(6k)";
        }
        else if (v == 4)
        {
            selectVan = "Ten Hole(5k)";
        }
        else if (v == 5)
        {
            selectVan = "Ten Hole(6k)";
        }
        else
        {
            selectVan = "First Class(5k)";
        }

    }


    public void loadDt ()
    {
        
        if (selectDt == "First Class(1k)")
        {
            if (currency.firstClass >= 1000)
            {
                currency.removeFirstClass(1000);
                startLoad(60f);
            } else
            {
                warning();
            }
        } else if (selectDt == "First Class(2k)")
        {
            if (currency.firstClass >= 2000)
            {
                currency.removeFirstClass(2000);
                startLoad(120f);
            }
            else
            {
                warning();
            }
        } else if (selectDt == "Three Hole(1k)")
        {
            if (currency.threeHole >= 1000)
            {
                currency.removeThreeHole(1000);
                startLoad(60f);
            }
            else
            {
                warning();
            }
        }
        else if (selectDt == "Three Hole(2k)")
        {
            if (currency.threeHole >= 2000)
            {
                currency.removeThreeHole(2000);
                startLoad(120f);
            }
            else
            {
                warning();
            }
        }
        else if (selectDt == "Ten Hole(1k)")
        {
            if (currency.tenHole >= 1000)
            {
                currency.removeTenHole(1000);
                startLoad(60f);
            }
            else
            {
                warning();
            }
        }
        else if (selectDt == "Ten Hole(2k)")
        {
            if (currency.tenHole >= 2000)
            {
                currency.removeTenHole(2000);
                startLoad(120f);
            }
            else
            {
                warning();
            }
        }
        canvas.SetActive(false);
        dt.SetActive(false);
    }


    public void loadTruck()
    {

        if (selectTruck == "First Class(3k)")
        {
            if (currency.firstClass >= 3000)
            {
                currency.removeFirstClass(3000);
                startLoad(180f);
            }
            else
            {
                warning();
            }
        }
        else if (selectTruck == "First Class(4k)")
        {
            if (currency.firstClass >= 4000)
            {
                currency.removeFirstClass(4000);
                startLoad(240f);
            }
            else
            {
                warning();
            }
        }
        else if (selectTruck == "Three Hole(3k)")
        {
            if (currency.threeHole >= 3000)
            {
                currency.removeThreeHole(3000);
                startLoad(180f);
            }
            else
            {
                warning();
            }
        }
        else if (selectTruck == "Three Hole(4k)")
        {
            if (currency.threeHole >= 4000)
            {
                currency.removeThreeHole(4000);
                startLoad(240f);
            }
            else
            {
                warning();
            }
        }
        else if (selectTruck == "Ten Hole(3k)")
        {
            if (currency.tenHole >= 3000)
            {
                currency.removeTenHole(3000);
                startLoad(180f);
            }
            else
            {
                warning();
            }
        }
        else if (selectTruck == "Ten Hole(4k)")
        {
            if (currency.tenHole >= 4000)
            {
                currency.removeTenHole(4000);
                startLoad(240f);
            }
            else
            {
                warning();
            }
        }
        canvas.SetActive(false);
        truck.SetActive(false);
    }


    public void loadVan()
    {

        if (selectVan == "First Class(5k)")
        {
            if (currency.firstClass >= 5000)
            {
                currency.removeFirstClass(5000);
                startLoad(300f);
            }
            else
            {
                warning();
            }
        }
        else if (selectVan == "First Class(6k)")
        {
            if (currency.firstClass >= 6000)
            {
                currency.removeFirstClass(6000);
                startLoad(360f);
            }
            else
            {
                warning();
            }
        }
        else if (selectVan == "Three Hole(5k)")
        {
            if (currency.threeHole >= 5000)
            {
                currency.removeThreeHole(5000);
                startLoad(300f);
            }
            else
            {
                warning();
            }
        }
        else if (selectVan == "Three Hole(6k)")
        {
            if (currency.threeHole >= 6000)
            {
                currency.removeThreeHole(6000);
                startLoad(360f);
            }
            else
            {
                warning();
            }
        }
        else if (selectVan == "Ten Hole(5k)")
        {
            if (currency.tenHole >= 5000)
            {
                currency.removeTenHole(5000);
                startLoad(300f);
            }
            else
            {
                warning();
            }
        }
        else if (selectVan == "Ten Hole(6k)")
        {
            if (currency.tenHole >= 6000)
            {
                currency.removeTenHole(6000);
                startLoad(360f);
            }
            else
            {
                warning();
            }
        }
        canvas.SetActive(false);
        van.SetActive(false);
    }


    public void startLoad(float t)
    {
        GameObject cTruck = GameObject.Find(currentTruck);
       loadingStart.Play();
        truckData td = cTruck.GetComponent<truckData>();
        if (td.type == "Drump truck")
        {
            td.load = selectDt;
        }
        else if (td.type == "Truck")
        {
            td.load = selectTruck;
        }
        else if (td.type == "Van")
        {
            td.load = selectVan;
        }

        
        cTruck.GetComponent<BoxCollider>().enabled = false;
        timer = new Timer(t, timeUp);
        TimerManager.AddTimer(timer);
        cTruck.transform.position = new Vector3(531f, 0.11f, 609f);
        cTruck.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        cTruck.GetComponent <CarController>().enabled = false;  
        
        if (cTruck.GetComponent<truckData>().type == "Drump truck")
        {
            transport.drumpTruck.Remove(currentTruck);
        }

    }

    public void timeUp()
    {
        loadingComplete.Play();
        GameObject cTruck = GameObject.Find(currentTruck);
        cTruck.GetComponent<BoxCollider>().enabled = true;
        cTruck.transform.Find("Bricks").gameObject.SetActive(true);
        truckData td = cTruck.GetComponent<truckData>();

        if (td.load == "First Class(1k)")
        {
            transport.firstClass1k.Enqueue(currentTruck);
        }
        else if (td.load == "First Class(2k)")
        {
            transport.firstClass2k.Enqueue(currentTruck);
        }
        else if (td.load == "First Class(3k)")
        {
            transport.firstClass3k.Enqueue(currentTruck);
        }
        else if (td.load == "First Class(4k)")
        {
            transport.firstClass4k.Enqueue(currentTruck);
        }
        else if (td.load == "First Class(5k)")
        {
            transport.firstClass5k.Enqueue(currentTruck);
        }
        else if (td.load == "First Class(6k)")
        {
            transport.firstClass6k.Enqueue(currentTruck);
        }
        else if (td.load == "Three Hole(1k)")
        {
            transport.threeHole1k.Enqueue(currentTruck);
        }
        else if (td.load == "Three Hole(2k)")
        {
            transport.threeHole2k.Enqueue(currentTruck);
        }
        else if (td.load == "Three Hole(3k)")
        {
            transport.threeHole3k.Enqueue(currentTruck);
        }
        else if (td.load == "Three Hole(4k)")
        {
            transport.threeHole4k.Enqueue(currentTruck);
        }
        else if (td.load == "Three Hole(5k)")
        {
            transport.threeHole5k.Enqueue(currentTruck);
        }
        else if (td.load == "Three Hole(6k)")
        {
            transport.threeHole6k.Enqueue(currentTruck);
        }
        else if (td.load == "Ten Hole(1k)")
        {
            transport.tenHole1k.Enqueue(currentTruck);
        }
        else if (td.load == "Ten Hole(2k)")
        {
            transport.tenHole2k.Enqueue(currentTruck);
        }
        else if (td.load == "Ten Hole(3k)")
        {
            transport.tenHole3k.Enqueue(currentTruck);
        }
        else if (td.load == "Ten Hole(4k)")
        {
            transport.tenHole4k.Enqueue(currentTruck);
        }
        else if (td.load == "Ten Hole(5k)")
        {
            transport.tenHole5k.Enqueue(currentTruck);
        }
        else if (td.load == "Ten Hole(6k)")
        {
            transport.tenHole6k.Enqueue(currentTruck);
        }

    }



    public void warning()
    {
        uDialog.NewDialog()
        .SetTitleText("Warning")
        .SetContentText("Not enough bricks")
        .SetIcon(eIconType.Warning)
        .AddButton("Close", (dialog) => dialog.Close());
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject cTruck = GameObject.Find(currentTruck);
        try
        {
            cTruck.GetComponent<truckData>().time = timer.GetFormattedTime();
        }
        catch (Exception ex) { }
    }
}
