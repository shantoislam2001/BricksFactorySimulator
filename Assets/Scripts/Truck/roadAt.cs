using UnityEngine;

public class roadAt : MonoBehaviour
{
    [SerializeField] public GameObject ob;

    private void OnTriggerEnter(Collider other)
    {
        // Get the main parent of the colliding object
        GameObject mainParent = other.transform.root.gameObject;

        // Check if the main parent has the "Car" tag and the specified GameObject (ob) is inactive
        if (mainParent.CompareTag("Car") && ob.activeSelf == false)
        {
           
            mainParent.SetActive(false);
        }
       
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
