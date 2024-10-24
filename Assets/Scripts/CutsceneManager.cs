using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public TextMeshProUGUI cutsceneText; // Assign in Inspector
    public float textDisplayTime = 3f; // Time each message is displayed
    public float fadeDuration = 1f; // Duration for the text to fade out
    public string[] cutsceneLines; // The array of text lines for the cutscene

    private int currentLineIndex = 0;

    private void Start()
    {
        cutsceneText.gameObject.SetActive(true);
        StartCoroutine(DisplayCutscene());
    }

    private IEnumerator DisplayCutscene()
    {
        while (currentLineIndex < cutsceneLines.Length)
        {
            cutsceneText.text = cutsceneLines[currentLineIndex];
            cutsceneText.alpha = 1; // Make the text fully visible

            yield return new WaitForSeconds(textDisplayTime);

            // Fade out the text
            yield return StartCoroutine(FadeOutText());

            currentLineIndex++;
        }

        // Hide text completely after the last line
        cutsceneText.gameObject.SetActive(false);
        // Optionally, you could trigger the end of the cutscene or load the next scene here.
        SceneManager.LoadScene("Game");
    }

    private IEnumerator FadeOutText()
    {
        float elapsedTime = 0f;
        Color originalColor = cutsceneText.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, elapsedTime / fadeDuration);
            cutsceneText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        cutsceneText.alpha = 0; // Ensure it's fully invisible at the end
    }
}
