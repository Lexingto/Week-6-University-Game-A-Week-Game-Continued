using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RetryButton : MonoBehaviour
{
    public string load;
    // Update is called once per frame
    void Update()
    {
        Retry loadvalue = FindObjectOfType<Retry>();
        load = loadvalue.load;
    }

    public void OnClick()
    {
        SceneManager.LoadScene(load);
    }
}
