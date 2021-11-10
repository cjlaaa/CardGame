using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCounter : MonoBehaviour
{
    public Text CounterText;
    private int counter = 0;

    public bool SetCounter(int value)
    {
        counter += value;
        OnCounterChange();
        if (counter <= 0) 
        {
            Destroy(gameObject);
            return false;
        }

        return true;
    }

    private void OnCounterChange()
    {
        CounterText.text = counter.ToString();
    }
}
