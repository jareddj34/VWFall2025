using UnityEngine;
using UnityEngine.XR.Management;
using System.Collections;

public class SpawnHere : MonoBehaviour
{
    public Transform spawnPoint;  // Assign in inspector
    public GameObject[] xrOrigin;   // Assign your XR Origin



    IEnumerator Start()
    {
        // Wait for XR to initialize fully
        yield return new WaitForSeconds(0.1f);

        Debug.Log("Spawning XR Origin at designated spawn point.");

        if (xrOrigin != null && spawnPoint != null)
        {
            foreach (GameObject origin in xrOrigin)
            {
                if (origin != null)
                {
                    origin.transform.position = spawnPoint.position;
                    origin.transform.rotation = spawnPoint.rotation;
                }
            }
        }
    }
}