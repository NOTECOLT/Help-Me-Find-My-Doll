using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingTextManagerUI : MonoBehaviour
{
    [SerializeField] GameObject floatingTextPrefab;
    //[SerializeField] float textDuration = 3f;
    //string[] sentencesToSay;
    bool textIsActive = false;
    GameObject text;
    Queue<string> dialogueQueue;
    Coroutine coroutine;

    // Start is called before the first frame update
    public void Start()
    {
        dialogueQueue = new Queue<string>();
    }
    public void ShowText(float textDuration)
    {
        Debug.Log("Showing UI text");
        ClearText();
        coroutine = StartCoroutine(ShowTextCoroutine(textDuration));        
    }

    IEnumerator ShowTextCoroutine(float textDuration)
    {
        textIsActive = true;
        while (dialogueQueue.Count > 0)
        {
            GameObject floatingText = Instantiate(
            floatingTextPrefab,
            new Vector3(960, 540, 0),
            Quaternion.identity) as GameObject;
            text = floatingText;

            // Set text
            //floatingText.GetComponent<TextMeshProUGUI>().text = dialogueQueue.Dequeue();
            floatingText.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = dialogueQueue.Dequeue();

            // Create UI in TextManagerUI canvas and move to bottom
            floatingText.transform.SetParent(transform);
            floatingText.transform.position = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));

            Destroy(floatingText, textDuration);
            yield return new WaitForSeconds(textDuration);
        }
        textIsActive = false;
    }

    public void ClearText()
    {
        if (textIsActive)
        {
            Destroy(text);
            StopCoroutine(coroutine);
        }

        
    }

    public void QueueText(string text)
    {
        dialogueQueue.Enqueue(text);
    }

    public void ClearQueue()
    {
        dialogueQueue.Clear();
    }
}
