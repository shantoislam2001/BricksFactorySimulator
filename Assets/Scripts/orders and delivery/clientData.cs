using System.Data;
using UnityEngine;

public class clientData : MonoBehaviour
{
    public string name;
    public string address;
    public int distence;
    public string brickType;
    public int brickQuantity;
    public string acceptTime;
    public float perBrickPrice;
    public string accept;
    public int delivered;
    public float totalAmount;
    public int xp;
    public bool advancePayment = false;
    public int pandingPayment;
    public int paidPayment;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("working");
        totalAmount = perBrickPrice * brickQuantity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
