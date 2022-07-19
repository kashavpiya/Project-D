using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public AudioSource jumpSound;
    public AudioSource deathSound;


    private float movementX;

    public float movementY;

    [SerializeField]
    private float movementSpeed = 7f;


    [SerializeField]
    private float Slidetime = 1f;


    [SerializeField]
    private float jumpForce = 10f;

    private bool isGrounded;
    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";

    [SerializeField]
    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    private string JUMP_ANIMATION = "Jump";

    private string SLIDE_ANIMATION = "Slide";

    private string DEAD_ANIMATION = "Dead";

    private ScoreManager theScoreManager;

    private bool gameIsPaused = false;



    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        theScoreManager = FindObjectOfType<ScoreManager>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        jumpPlayer();
        AnimatePlayer();
        slidePlayer();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            
        }
        else
        {
            Time.timeScale = 1;
            
        }
    }

    void movePlayer()
    {
        if (theScoreManager.scoreIncreasing == true)
        {
            movementX = Input.GetAxisRaw("Horizontal");

            transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * movementSpeed;
        }
       
    }

    void jumpPlayer()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            
            anim.SetBool(JUMP_ANIMATION, true);
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpSound.Play();

        }
    }

    void slidePlayer()
    {
        movementY = Input.GetAxisRaw("Vertical");

        if (movementY < 0)
        {
            anim.SetBool(SLIDE_ANIMATION, true);
            StartCoroutine(dontSlide());
        }
        
    }

    IEnumerator dontSlide()
    {
        yield return new WaitForSeconds(Slidetime);
        anim.SetBool(SLIDE_ANIMATION, false);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
            anim.SetBool(JUMP_ANIMATION, false);

        
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            theScoreManager.scoreIncreasing = false;
            anim.SetBool(DEAD_ANIMATION, true);
            Destroy(gameObject, 2.0f);
            deathSound.Play();
            StartCoroutine(goBackToHome());
            



        }

        if (theScoreManager.scoreIncreasing == false)
        {
            StartCoroutine(dead());
        }

    }

    IEnumerator dead()
    {
        yield return new WaitForSeconds(3f);
        //gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
       
    }


    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    IEnumerator goBackToHome()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("MainMenu");
    }
}
