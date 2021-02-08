using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableManage : MonoBehaviour
{
    public int CompleteGet;
    
    public Button start;
    public Button Level1;
    void Start()
    {
        Retry retry = FindObjectOfType<Retry>();
        CompleteGet = retry.Complete;

        Debug.Log(CompleteGet);

        switch (CompleteGet)
        {
            case 0:
                start.interactable = true;
                break;
            case 1:
                start.interactable = true;
                Level1.interactable = true;
                break;
        }

    }
}
