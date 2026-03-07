using Unity.VisualScripting;
using UnityEngine;

public class GlobalActivation : MonoBehaviour
{
    //This script manages the global activation of traps, enemies, UI, and doors when the artefact is completed

    public GameObject arrowTrap;
    public GameObject floorTrap;
    public GameObject[] enemies;
    public ArtefactPuzzleScript artefact;
    public GameObject partsUI;
    public GameObject finalDoor;
    private bool activated = false;

    private void Update()
    {
        if (activated) return; // Skip if already activated

        // Check if artefact triggered global activation
        if (artefact.activateGlobalActivation)
        {
            activated = true; // Prevent repeated activation

            // Enable traps and enemies, hide UI, open final door
            arrowTrap.SetActive(true);
            floorTrap.SetActive(true);
            partsUI.SetActive(false);
            finalDoor.SetActive(false);

            foreach (var enemy in enemies)
            {
                enemy.SetActive(true);
            }

        }
    }
}
