using UnityEngine;
using PathCreation;

public class FollowPath : MonoBehaviour
{

    public PathCreator pathCreator;
    [Header("Movement Control")]
    public float duration = 10f; // Time in seconds to complete one full path
    public AnimationCurve speedCurve = AnimationCurve.Linear(0, 1, 1, 1); // Custom speed profile
    public bool useSpeedCurve = false;
    public float speed = 5f; // Keep for backward compatibility, but will be overridden by duration
    private float distanceTravelled;
    private float journeyTime = 0f;
    public Animator animator;
    private bool hasReachedEnd;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // // Once
        // if (!hasReachedEnd)
        // {
        //     if (distanceTravelled + 1f < pathCreator.path.length)
        //     {
        //         distanceTravelled = Mathf.Min(distanceTravelled + speed * Time.deltaTime, pathCreator.path.length);
        //         transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        //         Quaternion rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
        //         transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        //     }
        //     else
        //     {        
        //         // Set anim to idle
        //     }
        // }

        // Duration-based movement (loops)
        if (pathCreator != null && pathCreator.path != null)
        {
            float pathLength = pathCreator.path.length;
            
            // Calculate progress as a percentage (0 to 1) based on duration
            float deltaTime = Time.deltaTime;
            
            if (useSpeedCurve)
            {
                // Use animation curve to modify speed
                float normalizedTime = (journeyTime / duration) % 1f;
                float speedMultiplier = speedCurve.Evaluate(normalizedTime);
                deltaTime *= speedMultiplier;
            }
            
            journeyTime += deltaTime;
            float progress = (journeyTime / duration) % 1f; // Modulo for looping
            
            // Convert progress to distance along path
            distanceTravelled = progress * pathLength;
            
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
            Quaternion rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
    }
    
    // Utility methods for additional control
    public void SetDuration(float newDuration)
    {
        duration = newDuration;
    }
    
    public void PauseMovement()
    {
        enabled = false;
    }
    
    public void ResumeMovement()
    {
        enabled = true;
    }
    
    public void ResetPosition()
    {
        journeyTime = 0f;
        distanceTravelled = 0f;
    }
    
    public float GetProgress()
    {
        return (journeyTime / duration) % 1f;
    }
}
