using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Instructions : MonoBehaviour
{

    public InputActionProperty inputAction;
    public GameObject quad;
    public TextMeshProUGUI textMeshPro;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textMeshPro.text = "Pick up the hatchet to cut down the tree.";
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

    public void ChangeText(string newText) {
        textMeshPro.text = newText;
    }
}
