using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : Interactables
{
    [SerializeField] FloatingTextManager floatingTextManager;
    [SerializeField] Player player;
    [SerializeField] string[] dialogue;
    [SerializeField] float textDuration = 2f;

    public void OnInteract()
    {
        floatingTextManager.ShowText(dialogue, textDuration, player.GetGameObject());
    }
}
