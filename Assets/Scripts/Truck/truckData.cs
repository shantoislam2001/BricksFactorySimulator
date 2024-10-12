using TMPro;
using UnityEngine;

public class truckData : MonoBehaviour
{
    [SerializeField] TextMeshPro truckNumber;
    public string name;
    public string type;
    public string load;
    public string status;
    public int fuel;
    public int damage;
    public string time;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        truckNumber.text = gameObject.name;
        name = gameObject.name; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
