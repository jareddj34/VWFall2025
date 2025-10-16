using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartPanel : MonoBehaviour
{

    public TextMeshProUGUI txt;
    private int count = 0;
    public float fadeDuration = 0.5f; // Duration for fade in/out
    private bool isTransitioning = false; // Prevent multiple clicks during transition

    public GameObject can;
    private bool pickedUp = false;

    public void incrementCount() {
        if(!pickedUp){
            Debug.Log("incredmenting");
            count++;
            changeText();
            pickedUp = true;
        }

    }

    public void changeText()
    {
        // Prevent multiple clicks during transition
        if (isTransitioning) return;
        
        string newText = "";
        
        if(count == 0){
            newText = "Enjoy the beautiful outdoors";
            count++;
        }
        else if(count == 1) {
            newText = "Use the left JOYSTICK to move around";
            count++;
        }
        else if(count == 2) {
            newText = "Use the GRIP on either controller to pick up objects";
            can.SetActive(true);
            count++;
        }
        else if(count == 3) {
            newText = "You are ready to face the outdoors...";
            count++;
        }
        else {
            Debug.Log("loading next");
            SceneManager.LoadScene(1);
        }
        
        // Start the fade transition
        StartCoroutine(FadeTextTransition(newText));
    }
    
    private IEnumerator FadeTextTransition(string newText)
    {
        isTransitioning = true;
        
        // Fade out
        yield return StartCoroutine(FadeText(1f, 0f));
        
        // Change text
        txt.text = newText;
        
        // Fade in
        yield return StartCoroutine(FadeText(0f, 1f));
        
        isTransitioning = false;
    }
    
    private IEnumerator FadeText(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;
        Color color = txt.color;
        
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            color.a = alpha;
            txt.color = color;
            yield return null;
        }
        
        // Ensure final alpha is set
        color.a = endAlpha;
        txt.color = color;
    }
}
