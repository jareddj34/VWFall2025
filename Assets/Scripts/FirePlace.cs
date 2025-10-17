using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FirePlace : MonoBehaviour
{

    public GameObject[] transparents;
    public GameObject[] reals;
    private int i = 0;

    public GameObject fire;
    public Instructions instructions;

    public GameObject lighterCanvas;

    public AudioSource fireSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instructions = GameObject.Find("InstructionsManager").GetComponent<Instructions>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Wood") {
            transparents[i].SetActive(false);
            reals[i].SetActive(true);
            i++;
            if(i == 3) {
                instructions.ChangeText("Use the lighter to start the fire.");
                lighterCanvas.SetActive(true);
            }
            Destroy(other.gameObject);
        }

        if(other.gameObject.name == "Lighter" && i >= 3) {
            fire.SetActive(true);
            fireSound.Play();
            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene() {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(2);
    }
}
