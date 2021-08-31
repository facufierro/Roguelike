using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    public State State { get; set; }

    public void Initialize()
    {
        Stats = new Stats(2, 2, 4, 2, 2, 2);
        MovementSpeed = 10;
        Health = MaxHealth();
    }

    public IEnumerator Movement()
    {

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
        {
            State = State.MOVING;
            if (!Physics2D.OverlapCircle(transform.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0), 0.2f, LayerMask.GetMask("BlockingLayer")))
                transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        }
        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
        {
            State = State.MOVING;
            if (!Physics2D.OverlapCircle(transform.position + new Vector3(0, Input.GetAxisRaw("Vertical"), 0), 0.2f, LayerMask.GetMask("BlockingLayer")))
                transform.position += new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
        }

        yield return new WaitForSeconds(0.2f);
        State = State.IDLE;
        StartCoroutine(Movement());

    }
    public IEnumerator MeleeAttack()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
        {
            if (Physics2D.OverlapCircle(transform.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0), 0.2f) != null && Physics2D.OverlapCircle(transform.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0), 0.2f).tag == "Enemy")
                Physics2D.OverlapCircle(transform.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0), 0.2f).GetComponent<Enemy>().Health -= MeleeDamage();

        }
        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
        {
            if (Physics2D.OverlapCircle(transform.position + new Vector3(0, Input.GetAxisRaw("Vertical"), 0), 0.2f) != null && Physics2D.OverlapCircle(transform.position + new Vector3(0, Input.GetAxisRaw("Vertical"), 0), 0.2f).tag == "Enemy")
                Physics2D.OverlapCircle(transform.position + new Vector3(0, Input.GetAxisRaw("Vertical"), 0), 0.2f).GetComponent<Enemy>().Health -= MeleeDamage();

        }
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(MeleeAttack());

    }

    public void Death()
    {
        if (Health <= 0)
            gameObject.SetActive(false);
    }
    //public void MeleeAttack()
    //{
    //    if (Input.anyKeyDown)
    //        if (Physics2D.OverlapCircle(transform.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.2f) != null && Physics2D.OverlapCircle(transform.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.2f).transform.tag == "Enemy")
    //        {
    //            Physics2D.OverlapCircle(transform.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.2f).transform.GetComponent<Enemy>().Health -= MeleeDamage();
    //            print("attack");
    //        }
    //    IEnumerator SmoothAttack()
    //    {
    //        yield return new WaitForSeconds(0.1f);
    //    }
    //}
    //public void RangedAttack()
    //{

    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

    //        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
    //        if (hit.collider != null)
    //        {
    //            Debug.Log(hit.collider.gameObject.name);

    //        }
    //    }

    //}
}
