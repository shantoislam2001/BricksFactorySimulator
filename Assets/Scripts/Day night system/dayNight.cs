using UnityEngine;
using UnityEngine.UI; // For UI display of time

public class dayNight : MonoBehaviour
{
    public Light sun; // The directional light to simulate the sun
    public Text timeDisplay; // UI Text to display the current time

    [Range(0, 24)] public static float timeOfDay; // Current time of day (0-24 hours)
    public float dayDuration = 24f * 60f; // Duration of one day in real time (24 minutes = 1440 seconds)

    private float sunInitialIntensity;
    [SerializeField] public Text displayDate;

    void Start()
    {
        sunInitialIntensity = sun.intensity;
        timeOfDay = 11;
    }

    void Update()
    {
        UpdateTime();
        UpdateSunPosition();
        UpdateTimeDisplay();
        dateSystem(timeOfDay);
    }

    void UpdateTime()
    {
        // Increment the time of day based on real time
        timeOfDay += (Time.deltaTime / dayDuration) * 24f;
        if (timeOfDay >= 24f) timeOfDay = 0f; // Reset to start of day after 24 hours
    }

    void UpdateSunPosition()
    {
        // Rotate the sun based on the time of day
        float sunRotation = (timeOfDay / 24f) * 360f - 90f;
        sun.transform.rotation = Quaternion.Euler(sunRotation, 170f, 0f);

        // Adjust the sun's intensity for day and night
        sun.intensity = Mathf.Clamp(sunInitialIntensity * Mathf.Sin((timeOfDay / 24f) * Mathf.PI), 0f, sunInitialIntensity);
    }
    public int dayCount = 1;
 
    void dateSystem(float hour)
    {
        int date = 02;
        int month = 02;
        int year = 2025;

        if (hour == 0 && dayCount == 1)
        {
            date++;
            dayCount++;
            if(date == 31)
            {
                month++;
                date = 1;

                if(month == 13)
                {
                    year++;
                    month = 1;
                }
            }
            displayDate.text = date + "/" + month + "/" + year;
            Invoke("resatdayCount", 120f);
        }
 
    }

    void resatdayCount()
    {
        dayCount = 1;
    }

    void UpdateTimeDisplay()
    {
        // Convert timeOfDay into hours and minutes
        int hours = Mathf.FloorToInt(timeOfDay);
        int minutes = Mathf.FloorToInt((timeOfDay - hours) * 60);

        // Display the time in HH:MM format
        timeDisplay.text = string.Format("{0:00}:{1:00}", hours, minutes);
    }
}
