using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(AI());
    }

    // Update is called once per frame
    void Update()
    {
        if(GameState.IsPlayer2Dead || GameState.IsPlayer1Dead)
        {
            return;
        }

        if (GameState.IsPlayer2Damaged)
        {
            animator.Play("Damage");
            GameState.IsPlayer2Damaged = false;
            return;
        }

        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
        {
            animator.Play("Idle");
            GameState.IsPlayer2Attacking = false;
        }
    }

    IEnumerator AI()
    {
        while(!GameState.CanFight)
        {
            yield return null;
        }

        if(GameState.P1.transform.position.x < GameState.P2.transform.position.x)
        {
            if(gameObject.transform.position.x > -6)
            {
                GameState.P2.transform.position += new Vector3(-2, 0, 0);
            }
        }
        else
        {
            if (gameObject.transform.position.x < 6)
            {
                GameState.P2.transform.position += new Vector3(2, 0, 0);
            }
        }

        yield return new WaitForSeconds(1);

        System.Random random = new System.Random();
        int r = random.Next(2);

        if(r == 0)
        {
            animator.Play("Attack1");
            GameState.IsPlayer2Attacking = true;
        }
        else
        {
            animator.Play("Attack2");
            GameState.IsPlayer2Attacking = true;
        }

        yield return new WaitForSeconds(1);

        if(!GameState.IsPlayer2Dead && !GameState.IsPlayer1Dead)
        {
            StartCoroutine(AI());
        }
    }
}
