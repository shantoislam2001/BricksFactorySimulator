using UnityEngine;
using UnityEngine.InputSystem.XR;

public class TriggerControl : MonoBehaviour
{
    public GameObject currentCar;
    public GameObject playerCamera;
    public GameObject carCamera;
    public GameObject enterButton;
    public GameObject exitButton;
    public GameObject canvasC;
    public GameObject canvasP;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            currentCar = other.gameObject;
            enterButton.SetActive(true); // Show Enter button
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            enterButton.SetActive(false); // Hide Enter button when away from car
            currentCar = null;
        }
    }

    public void EnterCar()
    {
        if (currentCar != null)
        {
            this.gameObject.SetActive(false); // Disable player
            this.transform.SetParent(currentCar.transform); // Set player as child of the car
            currentCar.GetComponent<TriggerCar>().EnableCarCamera(); // Activate car camera
            exitButton.SetActive(true); // Show Exit button
            enterButton.SetActive(false); // Hide Enter button
            canvasP.SetActive(false);
            canvasC.SetActive(true);
            currentCar.transform.Find("Audio Source").gameObject.SetActive(true);
            currentCar.GetComponent<CarController>().enabled = true;
            currentCar.GetComponent<SlideZoom>().enabled = true;
        }
    }

    public void ExitCar()
    {
        if (currentCar != null)
        {
            this.transform.SetParent(null); // Unparent from car
            this.gameObject.SetActive(true); // Enable player
            currentCar.GetComponent<TriggerCar>().DisableCarCamera(); // Deactivate car camera
            exitButton.SetActive(false); // Hide Exit button
           
            canvasP.SetActive(true);
            canvasC.SetActive(false);
            currentCar.transform.Find("Audio Source").gameObject.SetActive(false);
            currentCar.GetComponent<CarController>().enabled = false;
            currentCar.GetComponent<SlideZoom>().enabled = false;
            currentCar = null;
        }
    }
}
