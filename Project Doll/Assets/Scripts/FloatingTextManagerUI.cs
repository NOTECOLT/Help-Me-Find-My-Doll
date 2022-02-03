using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingTextManagerUI : MonoBehaviour
{
    [SerializeField] GameObject floatingTextPrefab;
    [SerializeField] GameObject target;
    [SerializeField] float textDuration = 3f;
    [SerializeField] string[] sentencesToSay;
    // Start is called before the first frame update

    public void ShowText(string[] sentences, float textDuration, GameObject target)
    {
        StartCoroutine(ShowTextCoroutine(sentences, textDuration, target));        
    }

    IEnumerator ShowTextCoroutine(string[] sentences, float textDuration, GameObject target)
    {
        foreach (string sentence in sentences)
        {
            GameObject floatingText = Instantiate(
            floatingTextPrefab,
            transform.position,
            Quaternion.identity) as GameObject;

            floatingText.GetComponent<TextMeshPro>().text = sentence;
            floatingText.GetComponent<FloatingTextFollow>().SetToFollow(target);

            Destroy(floatingText, textDuration);
            yield return new WaitForSeconds(textDuration);
        }
    }
}
