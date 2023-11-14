using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static string LeftCharacter;
    public static string RightCharacter;
    public static GameObject P1;
    public static GameObject P2;
    public static bool CanFight;
    public static bool IsPlayer1Attacking;
    public static bool IsPlayer2Attacking;
    public static bool IsPlayer1Dead;
    public static bool IsPlayer2Dead;
    public static bool IsPlayer1Damaged;
    public static bool IsPlayer2Damaged;
    public static float P1Health = 1.0f;
    public static float P2Health = 1.0f;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
