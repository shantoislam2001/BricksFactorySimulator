using UnityEngine;

public class CarEngineSound : MonoBehaviour
{
    public AudioSource engineAudioSource; // Main engine audio source
    public AudioClip gearChangeClip; // Audio clip for gear changing sound
    public float[] gearPitchMin = { 1.6f, 1.5f, 1.4f, 1.3f, 1.2f }; // Min pitch for each gear
    public float[] gearPitchMax = { 2.0f, 2.0f, 1.9f, 1.8f, 1.7f }; // Max pitch for each gear
    public float gearChangeVolume = 1.0f;

    private int currentGear = 1;
    private float carSpeed; // Speed of the car (you can set this externally or calculate from Rigidbody)
    private float maxSpeed = 200f; // Max speed of the car in km/h
    private Rigidbody carRigidbody;

    private void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        UpdateCarSpeed();
        UpdateEngineSound();
    }

    private void UpdateCarSpeed()
    {
        // Assuming carRigidbody is attached to the car
        carSpeed = carRigidbody.linearVelocity.magnitude * 3.6f; // Convert from m/s to km/h
    }

    private void UpdateEngineSound()
    {
        // Change gear based on speed
        int newGear = CalculateCurrentGear();

        if (newGear != currentGear)
        {
            // Play gear change sound
            AudioSource.PlayClipAtPoint(gearChangeClip, transform.position, gearChangeVolume);
            currentGear = newGear;
        }

        // Calculate pitch based on the current speed and gear
        float pitchRange = gearPitchMax[currentGear - 1] - gearPitchMin[currentGear - 1];
        float speedPercent = Mathf.Clamp01(carSpeed / maxSpeed);
        engineAudioSource.pitch = gearPitchMin[currentGear - 1] + (speedPercent * pitchRange);
    }

    private int CalculateCurrentGear()
    {
        // You can adjust these speed thresholds for different gears
        if (carSpeed < 40f) return 1;
        else if (carSpeed < 80f) return 2;
        else if (carSpeed < 120f) return 3;
        else if (carSpeed < 160f) return 4;
        else return 5;
    }
}
