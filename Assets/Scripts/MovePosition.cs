using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class MovePosition : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        XRSimpleInteractable objectInteractable = GetComponent<XRSimpleInteractable>();
        objectInteractable.selectEntered.AddListener((SelectEnterEventArgs arg) => {
            Debug.Log("Move Position");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
