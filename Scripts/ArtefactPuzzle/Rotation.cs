using UnityEngine;
using UnityEngine.UI;

// Controls the rotation and selection of artefact segments in the puzzle

public class Rotation : MonoBehaviour
{
    public ArtefactPuzzleScript artefact; // Reference to the main artefact puzzle manager
    public ArtefactSegment[] segments; // All segments of the puzzle
    private bool outlineEnabled = false; // True if outlining is enabled
    private int currentIndex = 0; //Currently selected segment
    void Update()
    {
        // Count how many slots in the artefact are filled

        int filledSlots = 0;

        foreach (GameObject slot in artefact.artefactSlots)
        {
            if (slot.activeSelf)
            {
                filledSlots++;
            }
        }

        // Only enable rotation after at least 3 pieces are collected
        if (filledSlots < 3)
        {
            return;
        }
        // Enable outline highlighting if not already done
        if (!outlineEnabled)
        {
            outlineEnabled = true;
            UpdateOutline();
        }

        int previousIndex = currentIndex;

        // Switch selection with arrow keys
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentIndex--;
            if (currentIndex < 0) currentIndex = segments.Length - 1;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentIndex++;
            if (currentIndex >= segments.Length) currentIndex = 0;
        }

        // Update outline if selection changed
        if (previousIndex != currentIndex)
        {
            UpdateOutline();
        }

        // Rotate current segment
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            segments[currentIndex].Rotate(-1);
            artefact.CheckPuzzleSolved(segments);

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            segments[currentIndex].Rotate(1);
            artefact.CheckPuzzleSolved(segments);

        }


    }
    private void UpdateOutline()
    {
        // Update materials to show which segment is selected
        for (int i = 0; i < segments.Length; i++)
        {
            Renderer rend = segments[i].GetComponent<Renderer>();
            if (rend == null) continue;

            if (i == currentIndex)
            {
                // Selected segment: show normal + outline materials
                rend.materials = new Material[] { segments[i].normalMaterial, segments[i].outlineMaterial };
            }
            else
            {
                // Other segments: show normal material only
                rend.materials = new Material[] { segments[i].normalMaterial };
            }
        }
    }
}
