using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneTrigger : MonoBehaviour
{
    public GameObject Timeline;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        Retry retry = FindObjectOfType<Retry>();
        if (collision.tag == "Player")
        {
            Timeline.SetActive(true);

            player.Complete += 1;

            StartCoroutine(StopMove());
        }
    }

    IEnumerator StopMove()
    {
        while(true)
        {
            GameObject pla = GameObject.Find("Player");

            PlayerController player = FindObjectOfType<PlayerController>();
            Retry retry = FindObjectOfType<Retry>();

            var playe = player.GetComponent<Rigidbody2D>();

            playe.Sleep();

            yield return new WaitForSeconds(4);

            playe.IsAwake();

            Timeline.SetActive(false);

            SceneManager.LoadScene(0);
            Destroy(pla);

            yield return new WaitForSeconds(0);
        }
    }

}
