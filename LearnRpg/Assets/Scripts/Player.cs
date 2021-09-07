using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

    }

    private void FixedUpdate()
    {
        //Input Variables. you can check the inputs under 
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Rest MoveDelta
        moveDelta = new Vector3(x, y, 0);

        //Swap Sprite Direction, wether you're going right or left (Changes orientation of the sprite)
        if(moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;

        } else if (moveDelta.x < 0) {

            transform.localScale = new Vector3(-1, 1, 1);

        }
        //Make Sure we Collide with wall
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y),
            Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Creatures", "Blocking"));

        if(hit.collider == null)
        {
            //Make the Sprite Move

            transform.Translate(0,moveDelta.y * Time.deltaTime,0);
        }
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2( moveDelta.x,0),
            Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Creatures", "Blocking"));

        if (hit.collider == null)
        {
            //Make the Sprite Move

            transform.Translate( moveDelta.x * Time.deltaTime, 0,0);
        }


    }
}
