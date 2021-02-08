using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    public void Update()
    {
        PlayerController Life = FindObjectOfType<PlayerController>();
        GameObject hrt = GameObject.Find("Canvas");

        PlayerController Hap = FindObjectOfType<PlayerController>();
        GameObject hap = GameObject.Find("Canvas");

        string Hapcount = Hap.Happy.ToString();
        string Lifecount = Life.Lives.ToString();
        switch(Lifecount)
        {
            case "0":
                hrt.transform.GetChild(4).gameObject.SetActive(false);
                break;

            case "1":
                hrt.transform.GetChild(3).gameObject.SetActive(false);
                break;

            case "2":
                hrt.transform.GetChild(2).gameObject.SetActive(false);
                break;

        }

        switch (Hapcount)
        {
            case "1":
                hap.transform.GetChild(5).gameObject.SetActive(true);
                hap.transform.GetChild(6).gameObject.SetActive(false);
                hap.transform.GetChild(7).gameObject.SetActive(false);
                hap.transform.GetChild(8).gameObject.SetActive(false);
                hap.transform.GetChild(9).gameObject.SetActive(false);
                break;

            case "2":
                hap.transform.GetChild(5).gameObject.SetActive(true);
                hap.transform.GetChild(6).gameObject.SetActive(true);
                hap.transform.GetChild(7).gameObject.SetActive(false);
                hap.transform.GetChild(8).gameObject.SetActive(false);
                hap.transform.GetChild(9).gameObject.SetActive(false);
                break;

            case "3":
                hap.transform.GetChild(5).gameObject.SetActive(true);
                hap.transform.GetChild(6).gameObject.SetActive(true);
                hap.transform.GetChild(7).gameObject.SetActive(true);
                hap.transform.GetChild(8).gameObject.SetActive(false);
                hap.transform.GetChild(9).gameObject.SetActive(false);
                break;

            case "4":
                hap.transform.GetChild(5).gameObject.SetActive(true);
                hap.transform.GetChild(6).gameObject.SetActive(true);
                hap.transform.GetChild(7).gameObject.SetActive(true);
                hap.transform.GetChild(8).gameObject.SetActive(true);
                hap.transform.GetChild(9).gameObject.SetActive(false);
                break;

            case "5":
                hap.transform.GetChild(5).gameObject.SetActive(true);
                hap.transform.GetChild(6).gameObject.SetActive(true);
                hap.transform.GetChild(7).gameObject.SetActive(true);
                hap.transform.GetChild(8).gameObject.SetActive(true);
                hap.transform.GetChild(9).gameObject.SetActive(true);
                break;

        }
    }
}
