using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpCooldown : MonoBehaviour
{ 
    public void Update()
    {
        PlayerController jump = FindObjectOfType<PlayerController>();

        if (jump.Jumped == true)
        {
            StartCoroutine(Cooldown());
        }
        else if (jump.Jumped == false)
        {
            jump.JumpBar.fillAmount = 1f;
            StopAllCoroutines();
            return;
        }
    }

    public IEnumerator Cooldown()
    {
        PlayerController jump = FindObjectOfType<PlayerController>();

        while (true)
        {
            jump.JumpBar.fillAmount -= (float)0.000009f;

            if (jump.JumpBar.fillAmount == 0)
            {
                jump.Jumped = false;
                yield return null;
            }
            yield return null;
        }
    }
}
