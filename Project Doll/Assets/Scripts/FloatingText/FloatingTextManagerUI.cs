using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingTextManagerUI : MonoBehaviour
{
    [SerializeField] GameObject floatingTextPrefab;
    //[SerializeField] float textDuration = 3f;
    //string[] sentencesToSay;
    // Start is called before the first frame update

    public void ShowText(string[] sentences, float textDuration)
    {
        Debug.Log("Showing UI text");
        StartCoroutine(ShowTextCoroutine(sentences, textDuration));        
    }

    IEnumerator ShowTextCoroutine(string[] sentences, float textDuration)
    {
        foreach (string sentence in sentences)
        {
            GameObject floatingText = Instantiate(
            floatingTextPrefab,
            Vector3.zero,
            Quaternion.identity) as GameObject;

            // Set text
            floatingText.GetComponent<TextMeshProUGUI>().text = sentence;

            // Create UI in TextManagerUI canvas and move to bottom
            floatingText.transform.SetParent(transform);
            floatingText.transform.position = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0, 0));

            Destroy(floatingText, textDuration);
            yield return new WaitForSeconds(textDuration);
        }
    }
}
