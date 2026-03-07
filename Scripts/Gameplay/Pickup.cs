using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    // Pickup – handles player interaction with collectible items
    // Updates UI slots, notifies the ArtefactPuzzleScript system, and destroys the collected object.
    // and destroys the picked-up object and its associated text prompt.

    [SerializeField] private GameObject text; // UI prompt displayed when player is in range
    [SerializeField] private string pieceName; // Identifier for the collected item
    private bool playerInRange = false; // Tracks if the player is in interaction range

    [SerializeField] private Image[] slots;   // UI slots to fill with collected item icons
    [SerializeField] private Sprite icon;   // Icon representing this item in the UI

    void Update()
    {
        // Check for player interaction every frame
        CheckPickup();
    }
    
    public void CheckPickup()
    {
        // Handles item pickup when the player presses 'F'
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            foreach (Image slot in slots)
            {
                if (!slot.enabled)
                {
                    slot.sprite = icon;
                    slot.enabled = true;
                    break;
                }
            }

            // Notify the ArtefactPuzzleScript about the collected piece
            ArtefactPuzzleScript artefact = Object.FindAnyObjectByType<ArtefactPuzzleScript>();
            artefact.AddPiece(pieceName);

            // Remove the item from the scene
            Destroy(gameObject);
            Destroy(text);
        }
    }

   
    public void OnTriggerEnter(Collider other)
    {
        // Enable interaction prompt when player enters trigger area
        if (other.TryGetComponent<CharacterController>(out var controller))
        {
            playerInRange = true;
            text.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        // Disable interaction prompt when player leaves trigger area
        if (other.TryGetComponent<CharacterController>(out var controller))
        {
            playerInRange = false;
            text.SetActive(false);
        }
    }
}

