using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Delivery : MonoBehaviour
{
    [SerializeField] public TMP_Text deliveryStatus;
    [SerializeField] public TMP_Text availableTruck;
    [SerializeField] public TMP_Text time;
    [SerializeField] public ProgressBar PBar;
    [SerializeField] private TMP_Dropdown dd1;
    [SerializeField] private TMP_Dropdown dd2;
    [SerializeField] private TMP_Dropdown dd3;

    [SerializeField] public GameObject UiddFirstClass;
    [SerializeField] public GameObject UiddThreeHole;
    [SerializeField] public GameObject UiddTenHole;

    public int ddFirstClassValue;
    private GameObject cTruck;
    private Vector3 startPosition = new Vector3(533f, 0.11f, 546f);
    public Timer timer;
    

    void Start()
    {
        // Initialization logic, if any, goes here
    }

    public void dropdown1()
    {
       if (dd1.value == 0)
        {
            availableTruck.text = "Please select";
        } else if (dd1.value == 1)
        {
            availableTruck.text = "Available truck: " + transport.firstClass1k.Count;
        } else if (dd1.value == 2)
        {
            availableTruck.text = "Available truck: " + transport.firstClass2k.Count;
        } else if (dd1.value == 3)
        {
            availableTruck.text = "Available truck: " + transport.firstClass3k.Count;
        } else if (dd1.value == 4)
        {
            availableTruck.text = "Available truck: " + transport.firstClass4k.Count;
        }  else if (dd1.value == 5)
        {
            availableTruck.text = "Available truck: " + transport.firstClass5k.Count;
        }
        else if (dd1.value == 6)
        {
            availableTruck.text = "Available truck: " + transport.firstClass6k.Count;
        }
    }


    public void dropdown2()
    {
        if (dd2.value == 0)
        {
            availableTruck.text = "Please select";
        }
        else if (dd2.value == 1)
        {
            availableTruck.text = "Available truck: " + transport.threeHole1k.Count;
        }
        else if (dd2.value == 2)
        {
            availableTruck.text = "Available truck: " + transport.threeHole2k.Count;
        }
        else if (dd2.value == 3)
        {
            availableTruck.text = "Available truck: " + transport.threeHole3k.Count;
        }
        else if (dd2.value == 4)
        {
            availableTruck.text = "Available truck: " + transport.threeHole4k.Count;
        }
        else if (dd2.value == 5)
        {
            availableTruck.text = "Available truck: " + transport.threeHole5k.Count;
        }
        else if (dd2.value == 6)
        {
            availableTruck.text = "Available truck: " + transport.threeHole6k.Count;
        }
    }

    public void dropdown3()
    {
        if (dd3.value == 0)
        {
            availableTruck.text = "Please select";
        }
        else if (dd3.value == 1)
        {
            availableTruck.text = "Available truck: " + transport.tenHole1k.Count;
        }
        else if (dd3.value == 2)
        {
            availableTruck.text = "Available truck: " + transport.tenHole2k.Count;
        }
        else if (dd3.value == 3)
        {
            availableTruck.text = "Available truck: " + transport.tenHole3k.Count;
        }
        else if (dd3.value == 4)
        {
            availableTruck.text = "Available truck: " + transport.tenHole4k.Count;
        }
        else if (dd3.value == 5)
        {
            availableTruck.text = "Available truck: " + transport.tenHole5k.Count;
        }
        else if (dd3.value == 6)
        {
            availableTruck.text = "Available truck: " + transport.tenHole6k.Count;
        }
    }


    public void Send()
    {
        if (UiddFirstClass.activeSelf)
        {
            if(dd1.value == 1)
            {
                if (transport.firstClass1k.Count > 0)
                {
                    clientList.currentClient.delivered += 1000;
                    sendTruck(transport.firstClass1k.Dequeue());
                } else
                {
                    
                }
            }
            else if (dd1.value == 2)
            {
                if (transport.firstClass2k.Count > 0)
                {
                    clientList.currentClient.delivered += 2000;
                    sendTruck(transport.firstClass2k.Dequeue());
                }
                else
                {

                }
            }
            else  if (dd1.value == 3)
            {
                if (transport.firstClass3k.Count > 0)
                {
                    clientList.currentClient.delivered += 3000;
                    sendTruck(transport.firstClass3k.Dequeue());
                }
                else
                {

                }
            }
            else if (dd1.value == 4)
            {
                if (transport.firstClass4k.Count > 0)
                {
                    clientList.currentClient.delivered += 4000;
                    sendTruck(transport.firstClass4k.Dequeue());
                }
                else
                {

                }
            }
            else if (dd1.value == 5)
            {
                if (transport.firstClass5k.Count > 0)
                {
                    clientList.currentClient.delivered += 5000;
                    sendTruck(transport.firstClass5k.Dequeue());
                }
                else
                {

                }
            }
            else if (dd1.value == 6)
            {
                if (transport.firstClass6k.Count > 0)
                {
                    clientList.currentClient.delivered += 6000;
                    sendTruck(transport.firstClass6k.Dequeue());
                }
                else
                {

                }
            }
        }
        else  if (UiddThreeHole.activeSelf)
        {
            if (dd2.value == 1)
            {
                if (transport.threeHole1k.Count > 0)
                {
                    clientList.currentClient.delivered += 1000;
                    sendTruck(transport.threeHole1k.Dequeue());
                }
                else
                {

                }
            }
            else if (dd2.value == 2)
            {
                if (transport.threeHole2k.Count > 0)
                {
                    clientList.currentClient.delivered += 2000;
                    sendTruck(transport.threeHole2k.Dequeue());
                }
                else
                {

                }
            }
            else if (dd2.value == 3)
            {
                if (transport.threeHole3k.Count > 0)
                {
                    clientList.currentClient.delivered += 3000;
                    sendTruck(transport.threeHole3k.Dequeue());
                }
                else
                {

                }
            }
            else if (dd2.value == 4)
            {
                if (transport.threeHole4k.Count > 0)
                {
                    clientList.currentClient.delivered += 4000;
                    sendTruck(transport.threeHole4k.Dequeue());
                }
                else
                {

                }
            }
            else if (dd2.value == 5)
            {
                if (transport.threeHole5k.Count > 0)
                {
                    clientList.currentClient.delivered += 5000;
                    sendTruck(transport.threeHole5k.Dequeue());
                }
                else
                {

                }
            }
            else if (dd2.value == 6)
            {
                if (transport.threeHole6k.Count > 0)
                {
                    clientList.currentClient.delivered += 6000;
                    sendTruck(transport.threeHole6k.Dequeue());
                }
                else
                {

                }
            }
        }
        else if (UiddTenHole.activeSelf)
        {
            if (dd3.value == 1)
            {
                if (transport.tenHole1k.Count > 0)
                {
                    clientList.currentClient.delivered += 1000;
                    sendTruck(transport.tenHole1k.Dequeue());
                }
                else
                {

                }
            }
            else if (dd3.value == 2)
            {
                if (transport.tenHole3k.Count > 0)
                {
                    clientList.currentClient.delivered += 2000;
                    sendTruck(transport.tenHole2k.Dequeue());
                }
                else
                {

                }
            }
            else if (dd3.value == 3)
            {
                if (transport.tenHole3k.Count > 0)
                {
                    clientList.currentClient.delivered += 3000;
                    sendTruck(transport.tenHole3k.Dequeue());
                }
                else
                {

                }
            }
            else if (dd3.value == 4)
            {
                if (transport.tenHole4k.Count > 0)
                {
                    clientList.currentClient.delivered += 4000;
                    sendTruck(transport.tenHole4k.Dequeue());
                }
                else
                {

                }
            }
            else if (dd3.value == 5)
            {
                if (transport.tenHole5k.Count > 0)
                {
                    clientList.currentClient.delivered += 5000;
                    sendTruck(transport.tenHole5k.Dequeue());
                }
                else
                {

                }
            }
            else if (dd3.value == 6)
            {
                if (transport.tenHole6k.Count > 0)
                {
                    clientList.currentClient.delivered += 6000;
                    sendTruck(transport.tenHole6k.Dequeue());
                }
                else
                {

                }
            }
        }
    }

    public void sendTruck(string ct)
    {
        updateText();
        cTruck = GameObject.Find(ct);
        cTruck.transform.position = startPosition;
        cTruck.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        cTruck.GetComponent<CarAI>().enabled = true;
        cTruck.transform.Find("Audio Source").gameObject.SetActive(true);
        CarAI carAI = cTruck.GetComponent<CarAI>();
        carAI.SetActiveWaypointList("Car1", "go");

        timer = new Timer(120f, timeUp);
        TimerManager.AddTimer(timer);
        truckData truckDataComponent = cTruck.GetComponent<truckData>();
        truckDataComponent.status = "In route";
        cTruck.GetComponent<BoxCollider>().enabled = false;
    }

    public void timeUp()
    {

        cTruck.transform.position = new Vector3(245f, 0.11f, 577f);
        cTruck.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        cTruck.SetActive(true);

        CarAI carAI = cTruck.GetComponent<CarAI>();
        carAI.SetActiveWaypointList("Car1", "return trip");

        cTruck.transform.Find("Bricks").gameObject.SetActive(false);

        

   
    }

    public void updateText()
    {
        if (dd1.value == 0)
        {
            availableTruck.text = "Please select";
        }
        else if (dd1.value == 1)
        {
            availableTruck.text = "Available truck: " + transport.firstClass1k.Count;
        }
        else if (dd1.value == 2)
        {
            availableTruck.text = "Available truck: " + transport.firstClass2k.Count;
        }
        else if (dd1.value == 3)
        {
            availableTruck.text = "Available truck: " + transport.firstClass3k.Count;
        }
        else if (dd1.value == 4)
        {
            availableTruck.text = "Available truck: " + transport.firstClass4k.Count;
        }
        else if (dd1.value == 5)
        {
            availableTruck.text = "Available truck: " + transport.firstClass5k.Count;
        }
        else if (dd1.value == 6)
        {
            availableTruck.text = "Available truck: " + transport.firstClass6k.Count;
        }
    }

    public string cTime()
    {
        float t = dayNight.timeOfDay;
        if(t > 6.0 && t < 18.0)
        {
            return "Day";
        } else
        {
            return "Night";
        }
    }



    void Update()
    {
        // Update logic, if any, goes here
    }
}
