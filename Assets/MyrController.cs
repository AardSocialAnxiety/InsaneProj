using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyrController : MonoBehaviour
{
    //how fast Myr can move
    public float topSpeed = 10f;
    //which way is Myr facing
    bool facingRight = true;

    //physics of Myr
    private void FixedUpdate()
    {
        //get move direction
        float move = Input.GetAxis("Horizontal");

        //add velocity to rigidbody in the move direction * speed
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);

        //if facing the negative direction, an dnot facing right - flip
        if (move > 0 && !facingRight)
            flip();
        else if (move < 0 && facingRight)
            flip();
    }

    void flip()
    {
        //saying we are facing opposite directions
        facingRight = !facingRight;

        //get the local scale
        Vector3 theScale = transform.localScale;

        //flip on x axis
        theScale.x *= -1;

        //apply that to the local scale
        transform.localScale = theScale;
    }
}
