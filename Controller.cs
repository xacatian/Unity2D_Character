using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveDirection;
    private Rigidbody2D rb;
    private bool playerRightFace=true;
    private bool Ground;
    public Transform groundCheck;
    public float radiusCheck;
    public LayerMask groundLayer;
    private float extraJump;
    public float extraJumpNumber;


    private void Start() 
    {
        rb=GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space)&&extraJump>0)
        {
            rb.velocity=Vector2.up*jumpForce;
            extraJump--;
        }
        if(Ground==true)
        {
            extraJump=extraJumpNumber;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && extraJump==0&&Ground==true)
        {
            rb.velocity=Vector2.up*jumpForce;
        }
    }

    private void FixedUpdate() 
    {
        Ground=Physics2D.OverlapCircle(groundCheck.position,radiusCheck,groundLayer);

        moveDirection=Input.GetAxis("Horizontal");
        rb.velocity=new Vector2(moveDirection*speed,rb.velocity.y);

        if(playerRightFace==false&&moveDirection>0)
        {
            Flip();
        }

        if(playerRightFace==true&&moveDirection<0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        playerRightFace=!playerRightFace;
        Vector3 Scaler=transform.localScale;
        Scaler.x*=-1;
        transform.localScale=Scaler;
    }
}
