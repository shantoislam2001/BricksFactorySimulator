using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialAT5 : MonoBehaviour
{

    public GameObject objectToActivate;
    private Collider triggerCollider;
    public string playerTag = "player";
    [SerializeField] public GameObject panel;
    [SerializeField] public AudioSource voice;
    [SerializeField] public aiCharacter ai;
    [SerializeField] public Animator animator;
    [SerializeField] public List<Transform> wp1;
    [SerializeField] public GameObject ob6;
    [SerializeField] public TextMeshProUGUI textMassage;
    private string massage = "This is your garage\r\nFrom here you can repair your vehicles\r\n ";

    private void OnTriggerEnter(Collider other)
    {
        // Check if the triggering object has the specified tag
        if (other.CompareTag(playerTag))
        {
            // Activate the specified GameObject
            textMassage.text = massage;
            panel.SetActive(true);
            voice.Play();
            gameObject.SetActive(false);
            animator.SetBool("talk", true);
            Invoke("events", 4f);
        }
    }

    void events()
    {
        animator.SetBool("walk", true);
        panel.SetActive(false);
        animator.SetBool("talk", false);
        ai.SwitchWaypoints(wp1);
        ob6.SetActive(true);
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
