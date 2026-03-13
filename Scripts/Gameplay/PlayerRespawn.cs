using UnityEngine;

// Handles player death and respawn behavior,
// including teleporting the player back to the respawn point.

public class PlayerRespawn : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private DeathFade deathFade;
    public GameObject respawnPoint; // The point where the player respawns
    void Start()
    {
        controller = GetComponent<CharacterController>(); // Get the CharacterController component on this GameObject
    }

    public void Die()
    {
        // Trigger fade out and back in, then respawn player at respawnPoint
        controller.enabled = false; // Disable player movement during death sequence
        deathFade.FadeOutAndIn(() =>
        {
            transform.position = respawnPoint.transform.position; // Move player to respawn point
            controller.enabled = true; // Re-enable movement after respawn
        });
       
    }
}
