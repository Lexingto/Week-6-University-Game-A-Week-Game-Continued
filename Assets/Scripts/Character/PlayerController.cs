using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    Vector2 boxExtents;

    Rigidbody2D rigidBody;
    Animator animator;

    public AudioSource audioSource;
    public AudioClip clip;
    public AudioClip clip2;

    public float speed;
    public float jumpForce;
    public float airControlForce;
    public float airControlMax;

    public int Complete;

    public GameObject Checkpoint;
    public GameObject CheckpointTrigger;

    public GameObject[] pauseObjects;

    public int Happy = 3;
    public int Lives = 3;

    public bool Move = true;
    public bool Jumped;
    public bool CutsceneActive;

    public string lvl1;
    public string PrevScene;

    public Image JumpBar;

    void Start()
    { 
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxExtents = GetComponent<BoxCollider2D>().bounds.extents;

        Retry retry = FindObjectOfType<Retry>();

        retry.Complete = Complete;
    }

    //Animation
    private void Update()
    {
        //Animation bools

        GameObject cut = GameObject.Find("Timeline");

        if (cut != null)
        {
            CutsceneActive = true;
        }
        else
        {
            CutsceneActive = false;
        }

        if(CutsceneActive == false)
        {
            //AD keys
            if (Input.GetKeyDown("a"))
            {
                if (Move == true)
                {
                    Vector3 theScale = transform.localScale;
                    theScale.x = -5;
                    transform.localScale = theScale;

                    animator.SetBool("Walking", true);
                }
            }
            if (Input.GetKeyUp("a"))
            {
                if (Move == true)
                {
                    animator.SetBool("Walking", false);
                }
            }
            if (Input.GetKeyDown("d"))
            {
                if (Move == true)
                {
                    Vector3 theScale = transform.localScale;
                    theScale.x = 5;
                    transform.localScale = theScale;

                    animator.SetBool("Walking", true);
                }
            }
            if (Input.GetKeyUp("d"))
            {
                if (Move == true)
                {
                    animator.SetBool("Walking", false);
                }
            }


            //arrow keys 
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (Move == true)
                {
                    Vector3 theScale = transform.localScale;
                    theScale.x = 5;
                    transform.localScale = theScale;

                    animator.SetBool("Walking", true);
                }
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                if (Move == true)
                {
                    animator.SetBool("Walking", false);
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (Move == true)
                {
                    Vector3 theScale = transform.localScale;
                    theScale.x = -5;
                    transform.localScale = theScale;

                    animator.SetBool("Walking", true);
                }
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                if (Move == true)
                {
                    animator.SetBool("Walking", false);
                }
            }
        }
        

        //Keep Happy within changing limits

        if(Happy >= 5)
        {
            Happy = 5;
        }

        if(Happy <= 0)
        {
            Happy = 0;
        }

        //Keep Complete within limits

        if(Complete >= 1)
        {
            Complete = 1;
        }

        //Player Stat Changes

        if (Happy == 5)
        {
            speed = 7;
            jumpForce = 9;
            airControlMax = 1.7f;

            string SceneName;
            string SampleScene = "SampleScene";

            SceneName = SceneManager.GetActiveScene().name;

            if (SceneName == SampleScene)
            {
                GameObject Environment = GameObject.Find("Environment");
                Environment.transform.GetChild(0).gameObject.SetActive(true);
            }
        }

        if (Happy == 4)
        {
            speed = 6;
            jumpForce = 8.5f;
            airControlMax = 1.6f;

            string SceneName;
            string SampleScene = "SampleScene";

            SceneName = SceneManager.GetActiveScene().name;

            if (SceneName == SampleScene)
            {
                GameObject Environment = GameObject.Find("Environment");
                Environment.transform.GetChild(0).gameObject.SetActive(true);
            }
        }

        if (Happy == 3)
        {
            speed = 5;
            jumpForce = 8;
            airControlMax = 1.5f;

            string SceneName;
            string SampleScene = "SampleScene";

            SceneName = SceneManager.GetActiveScene().name;

            if(SceneName == SampleScene)
            {
                GameObject Environment = GameObject.Find("Environment");
                Environment.transform.GetChild(0).gameObject.SetActive(false);
            }
        }

        if (Happy == 2)
        {
            speed = 4;
            jumpForce = 7;
            airControlMax = 1.4f;

            string SceneName;
            string SampleScene = "SampleScene";

            SceneName = SceneManager.GetActiveScene().name;

            if (SceneName == SampleScene)
            {
                GameObject Environment = GameObject.Find("Environment");
                Environment.transform.GetChild(0).gameObject.SetActive(false);
            }
        }

        if (Happy == 1)
        {
            speed = 3;
            jumpForce = 6;
            airControlMax = 1.3f;

            string SceneName;
            string SampleScene = "SampleScene";

            SceneName = SceneManager.GetActiveScene().name;

            if (SceneName == SampleScene)
            {
                GameObject Environment = GameObject.Find("Environment");
                Environment.transform.GetChild(0).gameObject.SetActive(false);
            }
        }

        if (Happy <= 0)
        {
            speed = 2;

            string SceneName;
            string SampleScene = "SampleScene";

            SceneName = SceneManager.GetActiveScene().name;

            if (SceneName == SampleScene)
            {
                GameObject Environment = GameObject.Find("Environment");
                Environment.transform.GetChild(0).gameObject.SetActive(false);
            }
        }

    }
    private void FixedUpdate()
    {

        GameObject cut = GameObject.Find("Timeline");

        if(cut != null)
        {
            CutsceneActive = true;
            Debug.Log(cut);
        }
        else
        {
            CutsceneActive = false;
        }

        if (Move == true && CutsceneActive == false)
        {
            float h = Input.GetAxis("Horizontal");
            // check if we are on the ground
            Vector2 bottom =
                new Vector2(transform.position.x, transform.position.y - boxExtents.y);
            Vector2 hitBoxSize = new Vector2(boxExtents.x * 2.0f, 0.05f);

            RaycastHit2D result = Physics2D.BoxCast(bottom, hitBoxSize, 0.0f,
                new Vector3(0.0f, -1.0f), 0.0f, 1 << LayerMask.NameToLayer("Ground"));

            bool grounded = result.collider != null && result.normal.y > 0.9f;
            if (grounded)
            {
                if (Input.GetAxis("Jump") > 0.0f && Jumped == false)
                {
                    Jumped = true;
                    animator.SetBool("Jumping", true);

                    audioSource.PlayOneShot(clip2, 0.5f);
                    rigidBody.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
                }

                else
                {
                    animator.SetBool("Jumping", false);
                    rigidBody.velocity = new Vector2(speed * h, rigidBody.velocity.y);
                }
                GameObject Player = GameObject.Find("Player");
                Player.GetComponent<Rigidbody2D>().gravityScale = 1f;
            }

            else
            {
                float vx = rigidBody.velocity.x;
                if (h * vx < airControlMax)
                    rigidBody.AddForce(new Vector2(h * airControlForce, 0));
            }
        }
    }

    //COLLISION
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject Player = GameObject.Find("Player");
        Retry retry = FindObjectOfType<Retry>();

        if (other.tag == "Fall")
        {
            Lives -= 1;

            LifeCheck();

            if (Lives != 0)
            {
                this.rigidBody.Sleep();

                Player.transform.position = Checkpoint.transform.position;
                this.rigidBody.velocity = new Vector3(0, 0);

                this.rigidBody.WakeUp();
            }
        }
        
        //win changes

        if (other.tag == "Win")
        {
            SceneManager.LoadScene(0);
            Destroy(Player);
        }

        /*
        if (other.name == "WinBox" || other.name == "WinBox (1)")
        {
            if (Complete == 2)
            {
                SceneManager.LoadScene(0);
                Destroy(Player);
            }
            else
            {
                Complete += 1;
                Complete += retry.Complete;
                SceneManager.LoadScene(0);
                Destroy(Player);
            }
        }
        */

        //////////////////////////////
        ///


        if (other.tag == "Enemy")
        {
            if(Move == true)
            {
                audioSource.PlayOneShot(clip, 0.5f);
                Lives -= 1;

                LifeCheck();

                if (Lives !=0)
                {
                    this.rigidBody.Sleep();

                    Player.transform.position = Checkpoint.transform.position;
                    this.rigidBody.velocity = new Vector2(0, 0);

                    this.rigidBody.WakeUp();
                }

            }
        }
    }

    //HAPPY & SAD CHANGE
    public void NegativeChange()
    {
        if(Happy == 0)
        {

        }
        Happy -= 1;
    }

    public void PositiveChange()
    {
        if (Happy == 5)
        {

        }
        Happy += 1;
    }

    //DYING

    public void LifeCheck()
    {
        if(Lives == 0)
        {
            PrevScene = SceneManager.GetActiveScene().name;

            StartCoroutine(DeathAnimation());
        }
    }

    IEnumerator DeathAnimation()
    {
        GameObject Player = GameObject.Find("Player");

        while (true)
        {
            animator.SetBool("Death", true);
            Move = false;
            yield return new WaitForSeconds(4);
            SceneManager.LoadScene(3);
            yield return new WaitForSeconds(0);
        }
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown("p") || Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
               // Cursor.visible = true;
                //Cursor.lockState = CursorLockMode.None;

                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                //Cursor.visible = false;

                Time.timeScale = 1;
                hidePaused();
            }
        }
    }
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }
}
