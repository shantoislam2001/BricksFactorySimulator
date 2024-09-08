using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using UI.Dialogs;

public class loadAT : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdownDt;
    [SerializeField] public GameObject dt;
    [SerializeField] public GameObject truck;
    [SerializeField] public GameObject van;
    [SerializeField] public GameObject canvas;
    private string currentTruck;
    private string selectDt = "First Class(1k)";
    private Timer timer;
    

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

    public void startLoad(float t)
    {
        GameObject cTruck = GameObject.Find(currentTruck);
       
        cTruck.GetComponent<truckData>().load = selectDt;
        cTruck.GetComponent<BoxCollider>().enabled = false;
        timer = new Timer(t, timeUp);
        TimerManager.AddTimer(timer);
        cTruck.transform.position = new Vector3(531f, 0.11f, 609f);
        cTruck.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void timeUp()
    {
        GameObject cTruck = GameObject.Find(currentTruck);
        cTruck.GetComponent<BoxCollider>().enabled = true;
        cTruck.transform.Find("Bricks").gameObject.SetActive(true);

        if (selectDt == "First Class(1k)")
        {
            transport.firstClass1k.Enqueue(currentTruck);
        }
        else if (selectDt == "First Class(2k)")
        {
            transport.firstClass2k.Enqueue(currentTruck);
        }
        else if (selectDt == "Three Hole(1k)")
        {
            transport.threeHole1k.Enqueue(currentTruck);
        }
        else if (selectDt == "Three Hole(2k)")
        {
            transport.threeHole2k.Enqueue(currentTruck);
        }
        else if (selectDt == "Ten Hole(1k)")
        {
            transport.tenHole1k.Enqueue(currentTruck);
        }
        else if (selectDt == "Ten Hole(2k)")
        {
            transport.tenHole2k.Enqueue(currentTruck);
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
        
    }
}
