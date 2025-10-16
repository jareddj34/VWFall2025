using UnityEngine;

public class SpawnOtherObjects : MonoBehaviour
{
    public GameObject parentObj;
    public GameObject[] objects;
    public string colliderName;
    public bool destroySelf = false;
    public Instructions instructions;
    public GameObject treeCanvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instructions = GameObject.Find("InstructionsManager").GetComponent<Instructions>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == colliderName)
        {
            treeCanvas.SetActive(false);
            foreach (GameObject obj in objects)
            {
                if (obj != null)
                {
                    obj.SetActive(true);
                }
            }
            instructions.ChangeText("Place the wood on the fire pit.");
            if(destroySelf) parentObj.SetActive(false);
        }
    }
}
