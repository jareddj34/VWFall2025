using UnityEngine;
using UnityEngine.InputSystem;

public class ShowMenu : MonoBehaviour
{

    public InputActionProperty inputAction;
    public GameObject quad;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inputAction.action.WasPressedThisFrame())
        {
            Debug.Log("Primary Button Pressed");
            quad.SetActive(!quad.activeSelf);
        }
    }
}
