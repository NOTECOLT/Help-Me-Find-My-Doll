using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FunctionIfFlag : MonoBehaviour
{
    [SerializeField] string flagName;
    [SerializeField] private UnityEvent[] _functions;
    
    public void CallFunction()
    {
        if (EventFlagManager.Instance.GetFlagValue(flagName))
        {
            for (int i = 0; i < _functions.Length; i++)
            {
                _functions[i].Invoke();
            }
        }
    }
}
