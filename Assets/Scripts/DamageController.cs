using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        bool isPlayer1 = gameObject.name.ToLower().Equals(GameState.LeftCharacter);

        if(isPlayer1)
        {
            if(col.gameObject.name.ToLower().Equals(GameState.RightCharacter.ToLower() + "_body") && GameState.IsPlayer1Attacking)
            {
                GameState.IsPlayer2Damaged = true;
                GameState.P2Health -= 0.1f;
            }
        }
        else
        {
            if(col.gameObject.name.ToLower().Equals(GameState.LeftCharacter.ToLower() + "_body") && GameState.IsPlayer2Attacking)
            {
                GameState.IsPlayer1Damaged = true;
                GameState.P1Health -= 0.1f;
            }
        }
    }
}
