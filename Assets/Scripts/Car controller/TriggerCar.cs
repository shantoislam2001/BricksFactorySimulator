using UnityEngine;

public class TriggerCar: MonoBehaviour
{
    public GameObject carCamera;

    public void EnableCarCamera()
    {
        carCamera.SetActive(true);
    }

    public void DisableCarCamera()
    {
        carCamera.SetActive(false);
    }
}
