using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    // Reference to the GameObject to be activated
    public GameObject objectToActivate;

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

    // Debugging: Draw the trigger area in the scene view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, GetComponent<Collider>().bounds.size);
    }
}
