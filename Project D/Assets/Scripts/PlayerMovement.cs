using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

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

    private ScoreManager theScoreManager;

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
    }

    void movePlayer()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * movementSpeed;
    }

    void jumpPlayer()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            
            anim.SetBool(JUMP_ANIMATION, true);
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

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
            Destroy(gameObject);
            theScoreManager.scoreIncreasing = false;
        }
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
}
