using UnityEngine;

public class disclaimer : MonoBehaviour
{
    [SerializeField] public GameObject playerCanvas;
    [SerializeField] public GameObject dsclaimerCanvas;
    [SerializeField] public AudioSource voice;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (dsclaimerCanvas.activeSelf)
        {
            voice.Play();
        }
    }


    public void ok()
    {
        playerCanvas.SetActive(true);
        dsclaimerCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
