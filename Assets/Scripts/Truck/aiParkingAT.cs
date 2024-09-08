using UnityEngine;

public class aiParkingAT : MonoBehaviour
{
    GameObject mainParent;
    public Timer timer;
    [SerializeField] public GameObject ob;
    private void OnTriggerEnter(Collider other)
    {
         mainParent = other.transform.root.gameObject;
        if (mainParent.CompareTag("Car") && ob.activeSelf == false)
        {
            timer = new Timer(5f, timeUp);
            TimerManager.AddTimer(timer);


          


        }
    }

    public void timeUp()
    {
        mainParent.GetComponent<CarAI>().enabled = false;
        string n = mainParent.gameObject.name;
        parking.park(n);
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
