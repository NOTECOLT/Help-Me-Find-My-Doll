using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    [SerializeField] GameObject floatingTextPrefab;
    [SerializeField] float textDuration = 5.0f;
    [SerializeField] float textSpawnOffset = 1.0f;


    // Variables
    bool textActive;

    // Start is called before the first frame update
    void Start()
    {
        textActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowText()
    {
        // Starts ShowTextCoroutine to show text
        if (Input.GetKeyDown(KeyCode.E) && !textActive)
        {
            StartCoroutine(ShowTextCoroutine());
        } 
    }

    private IEnumerator ShowTextCoroutine()
    {
        // Creates text, destroys after textDuration
        GameObject text = Instantiate(
                floatingTextPrefab,
                new Vector2(transform.position.x, transform.position.y + textSpawnOffset),
                Quaternion.identity)
                as GameObject;
        textActive = true;

        yield return new WaitForSeconds(textDuration);
        textActive = false;
        Destroy(text, textDuration);
    }
}
