using System.Collections;
using UnityEngine;

public class VanishingPlatform : MonoBehaviour
{
    [SerializeField] private float disappearTime = 3; // Time before platform disappears
    [SerializeField] private bool canReset; // Can the platform reset after disappearing
    [SerializeField] private float resetTime; // Delay before platform resets

    [SerializeField] private Animator myAnim;  // Animator for platform disappearance
    [SerializeField] private VanishingFloorTrapManager manager; // Reference to manager controlling trigger
    [SerializeField] private BoxCollider secondBoxCollider; // Optional secondary collider to disable

    void Start()
    {
        // Set animation speed based on disappear time, prevent division by zero
        if (disappearTime <= 0) disappearTime = 0.1f;
        myAnim = GetComponent<Animator>();
        myAnim.SetFloat("DisappearTime", 1 / disappearTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if player entered and trigger is active in manager
        if (other.GetComponent<CharacterController>() != null && manager.isTriggerActive)
        {
          
            secondBoxCollider.enabled = false;
            myAnim.SetBool("Trigger", true); // Start disappear animation

        }
    }

    public void TriggerReset()
    {
        // Start reset coroutine if allowed
        if ((canReset))
        {
            StartCoroutine(Reset());
        }
    }

    IEnumerator Reset()
    {
        // Wait for reset time and disable disappear animation
        yield return new WaitForSeconds(resetTime);
        myAnim.SetBool("Trigger", false);
    }
}
