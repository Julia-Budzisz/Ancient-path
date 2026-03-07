using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrapManager : MonoBehaviour
{
    // ArrowTrapManager – controls the logic of an arrow trap system.
    // Spawns arrows from designated spawn points while the player is inside the trap area.

    [SerializeField] List<Transform> spawnPoints = new List<Transform>(); // Positions where arrows spawn
    [SerializeField] GameObject arrowPrototype; // Prefab of the arrow
    
    
    private float delayBetweenArrows = 0.5f;  // Time delay between each arrow spawn
    private bool playerInside = false; // Tracks whether the player is in range
    private Coroutine coroutine; // Reference to the running spawn coroutine

    public void OnTriggerEnter(Collider other)
    {
        // Start spawning arrows when the player enters the trap area
        if (other.TryGetComponent<CharacterController>(out var controller))
        {
            playerInside = true;

            if (coroutine == null)
            {
                coroutine = StartCoroutine(ArrowSpawner());
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // Stop spawning arrows when the player exits the trap area
        if (other.TryGetComponent<CharacterController>(out var controller))
        {
            playerInside = false;

            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }
        }
    }

    private IEnumerator ArrowSpawner()
    {
        // Spawns arrows sequentially from all spawn points while the player is inside
        while (playerInside)
        {
            foreach (Transform spawn in spawnPoints)
            {
                Instantiate(arrowPrototype, spawn.position, spawn.rotation);
                yield return new WaitForSeconds(delayBetweenArrows);

                if (!playerInside)
                    yield break; // Stop immediately if player leaves during loop
            }
        }
    }
}
