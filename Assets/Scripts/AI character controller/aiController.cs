using System.Collections.Generic;
using UnityEngine;

public class aiController : MonoBehaviour
{
    public aiCharacter ac;
   [SerializeField] public List<Transform> wp1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ac = GetComponent<aiCharacter>();
       // ac.SwitchWaypoints(wp1);
    }

    public void sss()
    {
        Debug.Log("click s");
        ac.SwitchWaypoints(wp1);
    }


    // Update is called once per frame
    void Update()
    {
     //   ac.SwitchWaypoints(wp1);
    }



}
