using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{

    public GameObject destination;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            other.gameObject.transform.position = destination.transform.position;
            Debug.Log("Touched player");
        }
    }
}
