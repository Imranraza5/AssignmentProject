using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {get;set;}
   public GameObject failpanel,completepanel;
    void Start()
    {
        if(instance!=null)
        {
            instance=this;
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
