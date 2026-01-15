using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {get;set;}
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
