using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Retry : MonoBehaviour
{
    public string load;

    public int Complete;

    public GameObject loadgameobject;

    public void Start()
    {
        DontDestroyOnLoad(loadgameobject);
    }
    public void Update()
    {
        PlayerController SceneGet = FindObjectOfType<PlayerController>();

        string check;
        string launcher = "Launcher";
        check = SceneManager.GetActiveScene().name;

        if(check == launcher)
        {

        }
        else
        {
            load = SceneGet.PrevScene;
        }
        if(SceneGet != null)
        {
            Complete = SceneGet.Complete;
        }
    }
}
