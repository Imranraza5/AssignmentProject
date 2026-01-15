using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishscript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        playernumber player = other.GetComponent<playernumber>();
        if (player != null)
        {
            player.FinishGame();
        }
    }
}