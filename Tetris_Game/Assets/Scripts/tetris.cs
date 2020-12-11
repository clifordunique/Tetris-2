using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetris : MonoBehaviour
{
    public bool gravityApply;
 
    private void Start()
    {
        gravityApply = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "BottomCollider")
        {
            gravityApply = true;
        } 
    }
}
