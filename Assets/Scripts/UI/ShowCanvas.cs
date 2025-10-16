using UnityEngine;

public class ShowCanvas : MonoBehaviour
{

    public GameObject obj;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowObj() {
        obj.SetActive(true);
    }

    public void HideObj() {
        Destroy(obj);
    }
}
