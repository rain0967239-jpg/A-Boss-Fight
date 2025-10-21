using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D boxcollider;

    private int LeftRight = 0;
    private int FrontBack = 0;

    [Header("Main")]
    [SerializeField] private float speed;

    [Header("dash")]
    [SerializeField] private float dashingPower;
    [SerializeField] private float dashingTime;
    [SerializeField] private float dashingCooldown;
    [SerializeField] private TrailRenderer trailRenderer;
    private bool canDash = true;
    private bool isDashing;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxcollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (isDashing)
        {
            return;
        }
        //run direction
        /*horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");*/

        FrontBack = 0;
        LeftRight = 0;
        if (Input.GetKey("w"))
            FrontBack = 1;
        if (Input.GetKey("s"))
            FrontBack = -1;
        if (Input.GetKey("d"))
            LeftRight = 1;
        if (Input.GetKey("a"))
            LeftRight = -1;
        //set anim
        /*if (verticalInput > 0)
        {
            anim.SetBool("up", true);
            anim.SetBool("down", false);
            anim.SetBool("side", false);
        }
        else if (verticalInput < 0)
        {
            anim.SetBool("down", true);
            anim.SetBool("up", false);
            anim.SetBool("side", false);
        }
            
        if (horizontalInput > 0)
        {
            //left
            anim.SetBool("up", false);
            anim.SetBool("down", false);
            anim.SetBool("side", true);
            transform.localScale = new Vector3(-5, 5, 5);
        }
        else if (horizontalInput < 0)
        {
            //right
            anim.SetBool("up", false);
            anim.SetBool("down", false);
            anim.SetBool("side", true);
            transform.localScale = new Vector3(5, 5, 5);
        }*/

        if (FrontBack > 0)
        {
            anim.SetBool("up", true);
            anim.SetBool("down", false);
            anim.SetBool("side", false);
        }
        else if (FrontBack < 0)
        {
            anim.SetBool("down", true);
            anim.SetBool("up", false);
            anim.SetBool("side", false);
        }

        if (LeftRight > 0)
        {
            //left
            anim.SetBool("up", false);
            anim.SetBool("down", false);
            anim.SetBool("side", true);
            transform.localScale = new Vector3(-5, 5, 5);
        }
        else if (LeftRight < 0)
        {
            //right
            anim.SetBool("up", false);
            anim.SetBool("down", false);
            anim.SetBool("side", true);
            transform.localScale = new Vector3(5, 5, 5);
        }
        // main movement system 
        rb.linearVelocity = new Vector2(LeftRight * speed, FrontBack * speed);

        if (Input.GetKeyDown(KeyCode.RightShift) && canDash)
            StartCoroutine(Dash());
        else if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
            StartCoroutine(Dash());
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        boxcollider.enabled = false;
        rb.linearVelocity = new Vector2(LeftRight * dashingPower * speed, FrontBack * dashingPower * speed);
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        trailRenderer.emitting = false;
        isDashing = false;
        boxcollider.enabled = true;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}