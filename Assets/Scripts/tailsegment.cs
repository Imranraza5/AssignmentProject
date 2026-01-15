using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tailsegment : MonoBehaviour
{
    public int value;
    public TMP_Text numberText;

    public void SetValue(int val)
    {
        value = val;
        numberText.text = value.ToString();
    }
}