using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{

    public int Detection { get; set; }

    public void Initialize()
    {
        Stats = new Stats(2, 2, 2, 2, 2, 2);
        MovementSpeed = 5;
        Detection = 8;
        Health = MaxHealth();
    }
    public void Death()
    {
        if (Health <= 0)
            gameObject.SetActive(false);
    }

    public IEnumerator Movement()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
        {
            if (!Physics2D.OverlapCircle(transform.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0), 0.2f, LayerMask.GetMask("BlockingLayer")))
                transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        }
        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
        {
            if (!Physics2D.OverlapCircle(transform.position + new Vector3(0, Input.GetAxisRaw("Vertical"), 0), 0.2f, LayerMask.GetMask("BlockingLayer")))
                transform.position += new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
        }
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(Movement());

    }
    //public void Move(Player Target)
    //{
    //    Vector3 North = new Vector2(0, 1);
    //    Vector3 East = new Vector2(1, 0);
    //    Vector3 South = new Vector2(0, -1);
    //    Vector3 West = new Vector2(-1, 0);

    //    if (Movement == false)
    //    {
    //        for (int i = 0; i < Physics2D.OverlapCircleAll(transform.position, Detection).Length; i++)
    //        {
    //            if (Physics2D.OverlapCircleAll(transform.position, Detection)[i].tag == "Player")
    //            {
    //                StartCoroutine(SmoothMovement());
    //                if (Physics2D.OverlapCircle(transform.position, 0.2f, LayerMask.GetMask("BlockingLayer")))
    //                {
    //                    StartCoroutine(SmoothMovement());
    //                }
    //            }
    //        }
    //    }
    //    IEnumerator SmoothMovement()
    //    {
    //        Movement = true;
    //        if (Target.State == State.MOVING)
    //        {

    //            // Player is North
    //            if (Mathf.Abs(Target.transform.position.y - transform.position.y) > Mathf.Abs(Target.transform.position.x - transform.position.x))
    //            {
    //                if (Target.transform.position.y < transform.position.y)
    //                {
    //                    if (!Physics2D.OverlapCircle(transform.position + South, 0.2f, LayerMask.GetMask("BlockingLayer")))
    //                    {
    //                        transform.position += South;
    //                    }
    //                }
    //                else
    //                {
    //                    if (Target.transform.position.y < transform.position.y)
    //                    {
    //                        if (!Physics2D.OverlapCircle(transform.position + North, 0.2f, LayerMask.GetMask("BlockingLayer")))
    //                        {
    //                            transform.position += North;
    //                        }
    //                    }
    //                }

    //            }
    //            else
    //            {
    //                if (Target.transform.position.x < transform.position.x)
    //                {
    //                    if (!Physics2D.OverlapCircle(transform.position + West, 0.2f, LayerMask.GetMask("BlockingLayer")))
    //                    {
    //                        transform.position += West;
    //                    }
    //                }
    //                else
    //                {

    //                    if (!Physics2D.OverlapCircle(transform.position + East, 0.2f, LayerMask.GetMask("BlockingLayer")))
    //                    {
    //                        transform.position += East;
    //                    }
    //                }
    //            }

    //        }
    //        yield return new WaitForSeconds(0.2f);
    //        Movement = false;
    //    }
    //}
    public void Idle()
    {
    }
    public IEnumerator MeleeAttack()
    {

        yield return new WaitForSeconds(0.2f);
        StartCoroutine(MeleeAttack());

    }

}
