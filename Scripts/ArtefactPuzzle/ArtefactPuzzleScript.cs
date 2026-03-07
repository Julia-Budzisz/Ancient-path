using System.Collections.Generic;
using UnityEngine;

public class ArtefactPuzzleScript : MonoBehaviour
{
    // Manages the artefact puzzle interaction, player input, piece collection, and completion logic.
     
    public Camera artefactCamera; // Camera used to focus on the artefact
    public GameObject player; // Reference to the player object
    public GameObject finalPiece; // Object to reveal when puzzle is completed
    public Animator animator; // Animator controlling artefact animations

    private bool playerInRange = false;
    public static bool artefactActive = false;
    public bool insideArtefact = false;
    public bool isArtefactCompleted = false;
    public bool activateGlobalActivation = false;

    public List<string> collectedPieces = new List<string>();
    public List<GameObject> artefactSlots = new List<GameObject>();
    public List<string> slotNames = new List<string>();

    [SerializeField] public GameObject text;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            OpenArtefact();    
        }

        if (insideArtefact && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseArtefact();
        }

        if (insideArtefact && Input.GetKeyDown(KeyCode.F))
        {
            InsertPiece();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.GetComponent<CharacterController>() != null)
        {
            playerInRange = true;
            text.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            playerInRange = false;
            text.SetActive(false);
        }
    }

    private void OpenArtefact()
    {
        artefactCamera.gameObject.SetActive(true);
        player.SetActive(false);
        insideArtefact = true;
        artefactActive = true;
        text.SetActive(false);
    }

    private void CloseArtefact()
    {
        artefactCamera.gameObject.SetActive(false);
        player.SetActive(true);
        insideArtefact = false;
        artefactActive = false;
        text.SetActive(true);
    }

    public void InsertPiece()
    {
        // Insert a collected piece into its slot
        for (int i = 0; i < slotNames.Count; i++)
        {
            string name = slotNames[i];

          
            if (collectedPieces.Contains(name) && !artefactSlots[i].activeSelf)
            {
                artefactSlots[i].SetActive(true); 
                collectedPieces.Remove(name);

                // Count empty slots
                int filledslots = 0;

                foreach (GameObject slot in artefactSlots)
                {
                    if (!slot.activeSelf)
                    {
                        filledslots++;
                    }
                }

                isArtefactCompleted = false; 
                if (filledslots >= 3)
                {
                    isArtefactCompleted = true;
                }

                if (name == "Piece4")
                {
                    activateGlobalActivation = true;
                    
                }

                return; 
            }
        }
    }

    // Add piece to the collection if not already collected
    public void AddPiece(string pieceName)
    {
        if (!collectedPieces.Contains(pieceName))
        {
            collectedPieces.Add(pieceName);
        }
    }

    public void CheckPuzzleSolved(ArtefactSegment[] segments)
    {
        // Check if all segments are locked/completed
        foreach (ArtefactSegment segment in segments)
        {
            if (!segment.isLocked)
            {
                return;
            }              
        }

        animator.SetBool("isCompleted", true);

        if (animator.GetBool("isCompleted"))
        {
            finalPiece.SetActive(true);
        }
    }  
}
