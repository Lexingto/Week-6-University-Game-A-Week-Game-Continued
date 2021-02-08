using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopDuplicate : MonoBehaviour
{
    public static StopDuplicate instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
