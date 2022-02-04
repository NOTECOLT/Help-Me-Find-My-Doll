using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2FloorCrack : MonoBehaviour {
    public void ChangeCurrentInterface(string name) {
        if (EventFlagManager.Instance.GetFlagValue("puzzle2/blindsOpen") && EventFlagManager.Instance.GetFlagValue("puzzle2/mirrorWorldMove")) {
            GetComponent<PuzzleObject>().ChangeCurrentInterface(name);
        }
    }
}
