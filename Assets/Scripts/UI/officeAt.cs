using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    // Reference to the GameObject to be activated
    public GameObject objectToActivate;
    private Collider triggerCollider;

    // Tag of the player object
    public string playerTag = "player";

    private void OnTriggerEnter(Collider other)
    {
        // Check if the triggering object has the specified tag
        if (other.CompareTag(playerTag))
        {
            // Activate the specified GameObject
            objectToActivate.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the triggering object has the specified tag
        if (other.CompareTag(playerTag))
        {
            // Activate the specified GameObject
            objectToActivate.SetActive(false);
        }
    }

   

    void OnDrawGizmos()
    {
        // Get the collider attached to this object
        triggerCollider = GetComponent<Collider>();

        // Set the color for the Gizmos
        Gizmos.color = new Color(1, 0, 0, 0.5f);  // Red color with 50% transparency

        // Draw different Gizmos based on the type of collider
        if (triggerCollider is BoxCollider box)
        {
            Gizmos.DrawCube(box.bounds.center, box.size);
        }
        else if (triggerCollider is SphereCollider sphere)
        {
            Gizmos.DrawSphere(sphere.bounds.center, sphere.radius);
        }
        // Add more for different colliders if needed
    }
}
