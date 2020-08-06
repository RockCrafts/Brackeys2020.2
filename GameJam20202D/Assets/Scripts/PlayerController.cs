using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool hasKey = false;
    SpriteRenderer sr;
    Animator a;
    Rigidbody2D rb;
    bool isJumping = false;
    bool isDucking = false;
    bool isGrounded = false;
    bool gCheck1 = false;
    bool gCheck2 = false;
    bool gCheck3 = false;
    public LayerMask ground;
    public float jumpForce = 400f;
    public float speed = 5f;
    [SerializeField] //Collider when ducking
    BoxCollider2D duckCollider;
    [SerializeField] //Collider when not ducking.
    BoxCollider2D normCollider;
    float DistanceToSide;
    float DistanceToTheGround;
    public GameObject groundCheck;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        a = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        DistanceToTheGround = normCollider.bounds.extents.y + duckCollider.bounds.extents.y;
        DistanceToSide = normCollider.bounds.extents.x;
    }

    
    void Update()
    {
        
        float x = Input.GetAxisRaw("Horizontal");   
        float y = Input.GetAxisRaw("Vertical");

        if (GetComponent<RewindCore>().getRewinding()) return;
       
        

        gCheck1 = Physics2D.Raycast(transform.position, Vector3.down, DistanceToTheGround+ 0.01f, ground);
        Vector3 VDisSide = new Vector3(DistanceToSide-0.05f, 0, 0);

        gCheck2 = Physics2D.Raycast(transform.position+ VDisSide, Vector3.down, DistanceToTheGround + 0.01f, ground);
        gCheck3 = Physics2D.Raycast(transform.position-VDisSide, Vector3.down, DistanceToTheGround + 0.01f, ground);
        Debug.DrawRay(transform.position - VDisSide, Vector3.down, Color.red);
        Debug.DrawRay(transform.position + VDisSide, Vector3.down, Color.blue);
        Debug.DrawRay(transform.position, Vector3.down);
        isGrounded = gCheck1 || gCheck2 || gCheck3;
        print(isGrounded);
        a.SetFloat("Direction", x);
        if (x == 0)
        {
           a.SetBool("Running", false);
        }
        else
        {
            if (x < 0)
            {
               sr.flipX = true;
            }
            else if (x > 0)
            {
               sr.flipX = false;
            }
           a.SetBool("Running", true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
        }
        if (y < 0)
        {
            if (!isDucking) duck();
        }
        else
        {
            if (isDucking) unDuck();
        }
        
        transform.Translate(Vector2.right * x * speed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        if (isJumping)
        {
            jump();
        }
    }
    void jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
        isJumping = false;
    }
    void duck()
    {
        normCollider.enabled = false;
        duckCollider.enabled = true;
        a.SetBool("Crouching", true);
        isDucking = true;
    }
    void unDuck()
    {
        normCollider.enabled = true;
        duckCollider.enabled = false;
        a.SetBool("Crouching", false);
        isDucking = false;
    }
}
