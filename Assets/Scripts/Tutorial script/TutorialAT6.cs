using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialAT6 : MonoBehaviour
{

    public GameObject objectToActivate;
    private Collider triggerCollider;
    public string playerTag = "player";
    [SerializeField] public GameObject panel;
    [SerializeField] public AudioSource voice;
    [SerializeField] public AudioSource voice1;
    [SerializeField] public AudioSource voice2;
    [SerializeField] public AudioSource voice3;
    [SerializeField] public AudioSource voice4;
    [SerializeField] public aiCharacter ai;
    [SerializeField] public Animator animator;
    [SerializeField] public List<Transform> wp1;
    [SerializeField] public TextMeshProUGUI pText;
    public string massage = "this is your gas station \r\n";
   // [SerializeField] public GameObject ob3;
    [SerializeField] public GameObject icon;
    [SerializeField] public GameObject icon1;
    [SerializeField] public GameObject characterOB;
    [SerializeField] public order Orders;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the triggering object has the specified tag
        if (other.CompareTag(playerTag))
        {
            // Activate the specified GameObject
            pText.text = massage;
            panel.SetActive(true);
          //  icon.SetActive(true);
            voice.Play();
            gameObject.SetActive(false);
            animator.SetBool("talk", true);
            Invoke("next1", 2f);
        }
    }

    void events()
    {

        panel.SetActive(false);
        animator.SetBool("talk", false);
        icon.SetActive(false);
        ai.SwitchWaypoints(wp1);
        animator.SetBool("walk", true);
        Invoke("end", 60f);
    }

    void end()
    {
        characterOB.SetActive(false);
        Orders.enabled = true; 
    }

    void next1()
    {
        pText.text = massage;
        panel.SetActive(true);
      //  icon1.SetActive(true);
        voice1.Play();
        
        Invoke("next2", 3f);
    }

    void next2()
    {
        pText.text = "Clicking on this icon in the upper right side will give you options to create bricks\r\n";
        panel.SetActive(true);
        icon.SetActive(true);
        voice2.Play();

        Invoke("next3", 5f);
    }

    void next3()
    {
        pText.text = "And if you click on this icon next to it, you can buy soil, coal and trucks and even rent trucks\r\n";
        panel.SetActive(true);
        icon.SetActive(false);
        icon1.SetActive(true);
        voice3.Play();

        Invoke("next4",7f);
    }

    void next4()
    {
        pText.text = "Now if you visit the whole factory you will know about many more things.\r\nHope you can manage this factory very well and gain a lot of good experience which can be useful in your future.\r\nI'm leaving now, we'll see each other again in the future.\r\ngood bye\r\n";
        panel.SetActive(true);
        icon.SetActive(false);
        icon1.SetActive(false);
        voice4.Play();

        Invoke("events", 15f);
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
