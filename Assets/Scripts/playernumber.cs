using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playernumber : MonoBehaviour
{
    public int number=1;
    public TMP_Text numbertext;    


    
    void Start()
    {
        Updatenumbertext();
    }


    public void updatenumber(int amount)
    {
        
        number +=amount;
        if(number<0)
        {
            number=0;
        }
        Updatenumbertext();
    }
    void Updatenumbertext()
    {
        if(numbertext!=null)
        {
            numbertext.text=number.ToString();
        }
    } 
}
