using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialAT2 : MonoBehaviour
{

    public GameObject objectToActivate;
    private Collider triggerCollider;
    public string playerTag = "player";
    [SerializeField] public GameObject panel;
    [SerializeField] public AudioSource voice;
    [SerializeField] public aiCharacter ai;
    [SerializeField] public Animator animator;
    [SerializeField] public List<Transform> wp1;
    [SerializeField] public TextMeshProUGUI pText;
    public string massage = "This is your office room.\r\n  here you can manage everything.\r\n please enter office and click on computer icon then you will get management features\r\n";
    [SerializeField] public GameObject ob3;
    [SerializeField] public GameObject icon;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the triggering object has the specified tag
        if (other.CompareTag(playerTag))
        {
            // Activate the specified GameObject
            pText.text = massage;
            panel.SetActive(true);
            icon.SetActive(true);
            voice.Play();
            gameObject.SetActive(false);
            animator.SetBool("talk", true);
            Invoke("events", 8f);
        }
    }

    void events()
    {
        
        panel.SetActive(false);
        animator.SetBool("talk", false);
        icon.SetActive(false);
      //  Invoke("active", 10f);
    }

    void active()
    {
        ob3.SetActive(true);
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
