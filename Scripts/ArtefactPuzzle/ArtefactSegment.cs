using UnityEngine;


// Manages a single segment of an artefact puzzle
// Handles rotation and checking if it is in the correct state

public class ArtefactSegment : MonoBehaviour
{
    public Material normalMaterial;
    public Material outlineMaterial;

    [Range(0, 3)]
    public int currentState = 0; // Current rotation state of the segment

    [Range(0, 3)]
    public int correctState; // Target rotation state for completion

    public bool isLocked = false; // True if the segment is correctly aligned


    public void Rotate(int direction)
    {
        if (isLocked) return; // Do not rotate if already correct

        currentState += direction;

        if (currentState > 3) currentState = 0;
        if (currentState < 0) currentState = 3;

        transform.localRotation = Quaternion.Euler( -90, 0, currentState * 90);

        CheckCorrectState();
    }

    private void CheckCorrectState()
    {
        // Lock the segment if it matches the correct state
        if (currentState == correctState)
        {
            isLocked = true;
        }
    }
}
