using UnityEngine;

public class KeyController : MonoBehaviour
{
    public GameObject key; // Assign the key GameObject in the Inspector
    public Transform controller; // Assign the controller's transform
    public float rayDistance = 5f; // Adjust the raycast distance
    public LayerMask interactableLayer; // Assign a layer for the key or leave empty for default

    void Update()
    {
        // Check if trigger is pressed
        if (Input.GetButtonDown("Fire1")) // Replace with your VR trigger input if needed
        {
            RaycastHit hit;
            // Perform raycast from the controller
            if (Physics.Raycast(controller.position, controller.forward, out hit, rayDistance, interactableLayer))
            {
                // Check if the raycast hits the key
                if (hit.collider.gameObject == key)
                {
                    // Deactivate the key
                    key.SetActive(false);
                    Debug.Log("Key collected!");
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        // Visualize the raycast in the Scene view for debugging
        if (controller != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(controller.position, controller.forward * rayDistance);
        }
    }
}