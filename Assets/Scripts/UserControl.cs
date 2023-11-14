using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameState.CanFight || GameState.IsPlayer1Dead || GameState.IsPlayer2Dead)
        {
            return;
        }

        if(GameState.IsPlayer1Damaged)
        {
            animator.Play("Damage");
            GameState.IsPlayer1Damaged = false;
            return;
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            animator.Play("Attack1");
            GameState.IsPlayer1Attacking = true;
        }
        else if(Input.GetKeyDown(KeyCode.X))
        {
            animator.Play("Attack2");
            GameState.IsPlayer1Attacking = true;
        }
        else if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
        {
            animator.Play("Idle");
            GameState.IsPlayer1Attacking = false;
        }

        if(Input.GetKey(KeyCode.LeftArrow) && gameObject.transform.position.x < 8)
        {
            gameObject.transform.position += new Vector3(1, 0, 0);
        }
        else if(Input.GetKey(KeyCode.RightArrow) && gameObject.transform.position.x > -8)
        {
            gameObject.transform.position += new Vector3(-1, 0, 0);
        }
    }
}
