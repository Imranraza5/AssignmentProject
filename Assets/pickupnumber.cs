using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pickupnumber : MonoBehaviour
{

    public int value=1;
    public TMP_Text valuetext;
    
    void Start()
    {
        if(valuetext!=null)
        {
            valuetext.text=value.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        playernumber player =other.GetComponent<playernumber>();
        if(player!=null)
        {
            player.updatenumber(value);
            Debug.Log("Player number updated to: " + player.number);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }
}
