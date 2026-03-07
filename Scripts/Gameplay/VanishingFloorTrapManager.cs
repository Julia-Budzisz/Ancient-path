using UnityEngine;

public class VanishingFloorTrapManager : MonoBehaviour
{
    public BoxCollider boxCollider; // The BoxCollider that detects when the player steps on the trap
    public bool isTriggerActive = false; // Flag indicating whether the trap trigger is active

    void Update()
    {
        // If the BoxCollider is enabled, set the trigger flag to true
        // This is used by other scripts (e.g., VanishingPlatform) to know when the trap should activate
        if (boxCollider.enabled)
        {
            isTriggerActive = true;
        }
    }
}
