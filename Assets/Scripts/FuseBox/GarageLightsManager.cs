using UnityEngine;

public class GarageLightsManager : MonoBehaviour
{
    
    [SerializeField]
    private FuseManager fuseManager; 

    // Update is called once per frame
    void Update()
    {
        if(fuseManager.GetPuzzleState())
        {
            foreach (Transform child in transform)
            { 
                // Activate the child GameObject
                child.gameObject.SetActive(true);
            }
            /* Transform child = transform.Find("childName"); // Find child by name
            if (child != null)
            {
                child.gameObject.SetActive(true);
            } */
        }
    }
}
