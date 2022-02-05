using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeText : MonoBehaviour {
    [SerializeField] private TimeManager _timeManager;
    private float _timeElapsed;
    [SerializeField] private int _totalMinutes = 300;

    [SerializeField] private int _minutesPassed = 0;
    [SerializeField] private int _hoursPassed = 0;
    [SerializeField] private int _increment = 15;

    void Update() {
        _timeElapsed = _timeManager.GetTimeElapsedPercentage();
        
        _minutesPassed = ((int)((_timeElapsed / 100) * _totalMinutes)) % 60;
        _hoursPassed = (int)(((_timeElapsed / 100) * _totalMinutes) / 60);

        string minutesString = (_minutesPassed < 10) ? "0" + _minutesPassed.ToString() : _minutesPassed.ToString();

        if (_minutesPassed % _increment == 0) {
            GetComponent<TMP_Text>().text = (7 + _hoursPassed).ToString() + ":" + (minutesString) + " PM";
        }
        
        if (_hoursPassed >= 4) {
            GetComponent<TMP_Text>().color = Color.red;
        }
    }
}
