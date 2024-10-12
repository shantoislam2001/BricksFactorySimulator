using UnityEngine;
using System.Collections.Generic;

public class transport : MonoBehaviour
{
   public static List<string> trucks = new List<string> { "SI 24- 01", "SI 24- 02", "SI 24- 03" };
    public static List<string> drumpTruck = new List<string> { "SI 24- 01"};
   public static List<string> inRoute = new List<string>();

    public static Queue<string> firstClass1k = new Queue<string>();
    public static Queue<string> firstClass2k = new Queue<string>();
    public static Queue<string> firstClass3k = new Queue<string>();
    public static Queue<string> firstClass4k = new Queue<string>();
    public static Queue<string> firstClass5k = new Queue<string>();
    public static Queue<string> firstClass6k = new Queue<string>();

    public static Queue<string> threeHole1k = new Queue<string>();
    public static Queue<string> threeHole2k = new Queue<string>();
    public static Queue<string> threeHole3k = new Queue<string>();
    public static Queue<string> threeHole4k = new Queue<string>();
    public static Queue<string> threeHole5k = new Queue<string>();
    public static Queue<string> threeHole6k = new Queue<string>();

    public static Queue<string> tenHole1k = new Queue<string>();
    public static Queue<string> tenHole2k = new Queue<string>();
    public static Queue<string> tenHole3k = new Queue<string>();
    public static Queue<string> tenHole4k = new Queue<string>();
    public static Queue<string> tenHole5k = new Queue<string>();
    public static Queue<string> tenHole6k = new Queue<string>();

    public static Queue<string> client = new Queue<string>(new[] {"P1", "P2", "P3", "P4", "P5", "P6", "P7"});






    void Start()
    {
        
    }

    

    void Update()
    {
        // Update logic as needed
    }
}
