using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingTextManager : MonoBehaviour
{
    [SerializeField] GameObject floatingTextPrefab;
    [SerializeField] GameObject target;
    [SerializeField] float textDuration = 3f;
    [SerializeField] string[] sentencesToSay;
    // Start is called before the first frame update

    public void ShowText(string[] sentences, float textDuration, GameObject target)
    {
        // sentences = string[] of sentences
        // textDuration = duration of each sentence in sentence
        // target = gameObject for text to follow
        StartCoroutine(ShowTextCoroutine(sentences, textDuration, target));        
    }

    IEnumerator ShowTextCoroutine(string[] sentences, float textDuration, GameObject target)
    {
        // Loop through sentences array
        foreach (string sentence in sentences)
        {
            // Instantiate text
            GameObject floatingText = Instantiate(
            floatingTextPrefab,
            transform.position,
            Quaternion.identity) as GameObject;

            // Set text 
            floatingText.GetComponent<TextMeshPro>().text = sentence;
            // Make text follow target
            floatingText.GetComponent<FloatingTextFollow>().SetToFollow(target);

            Destroy(floatingText, textDuration);
            yield return new WaitForSeconds(textDuration);
        }
    }
}
