using UnityEngine;

public class Interview : MonoBehaviour
{

    private bool destroyed = false;
    public Transform spawnPoint;

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
        if(!destroyed)
        {
            Instantiate(this.gameObject, spawnPoint.position, spawnPoint.rotation);
            Destroy(other.gameObject);
            destroyed = true;
        }
    }
}
