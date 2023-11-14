using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public List<GameObject> characters;
    public List<GameObject> p1Characters;
    public List<GameObject> p2Characters;
    public List<GameObject> p1HealthCharacters;
    public List<GameObject> p2HealthCharacters;

    [SerializeField] GameObject SpawnPointLeft;
    [SerializeField] GameObject SpawnPointRight;
    [SerializeField] GameObject VsScreen;
    [SerializeField] GameObject FightText;
    [SerializeField] GameObject HealthBars;

    GameObject leftChar;
    GameObject rightChar;
    bool playedDeathSequence;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSequence(leftChar, GameState.LeftCharacter, SpawnPointLeft, rightChar, GameState.RightCharacter, SpawnPointRight));
    }

    // Update is called once per frame
    void Update()
    {
        if(GameState.IsPlayer1Dead && !playedDeathSequence)
        {
            playedDeathSequence = true;
            GameState.P1.GetComponent<Animator>().enabled = false;
            GameState.P1.GetComponent<Animator>().enabled = true;
            GameState.P1.GetComponent<Animator>().Play("Death");
        }
        else if(GameState.IsPlayer2Dead && !playedDeathSequence)
        {
            playedDeathSequence = true;
            GameState.P2.GetComponent<Animator>().enabled = false;
            GameState.P2.GetComponent<Animator>().enabled = true;
            GameState.P2.GetComponent<Animator>().Play("Death");
        }
    }

    GameObject GetCharacter(string name, List<GameObject> characters)
    {
        foreach(GameObject go in characters)
        {
            if(name.ToLower().Equals(go.name.ToLower()))
            {
                go.SetActive(true);
                return go;
            }
        }
        return null;
    }

    IEnumerator StartSequence(GameObject character1, string name1, GameObject spawnPoint1, GameObject character2, string name2, GameObject spawnPoint2)
    {
        VsScreen.SetActive(true);
        GameObject p1 = GetCharacter(name1, p1Characters);
        p1.SetActive(true);
        GameObject p2 = GetCharacter(name2, p2Characters);
        p2.SetActive(true);
        yield return new WaitForSeconds(2);
        VsScreen.SetActive(false);
        GameObject p1Health = GetCharacter(name1, p1HealthCharacters);
        p1Health.SetActive(true);
        GameObject p2Health = GetCharacter(name2, p2HealthCharacters);
        p2Health.SetActive(true);
        HealthBars.SetActive(true);
        character1 = SetupCharacter(character1, name1, spawnPoint1, -90);
        yield return new WaitForSeconds(3);
        SetAnimatorToIdle(character1.GetComponent<Animator>());
        character1.AddComponent<UserControl>();
        yield return new WaitForSeconds(3);
        character2 = SetupCharacter(character2, name2, spawnPoint2, 90);
        character2.AddComponent<AIControl>();
        GameState.P1 = character1;
        GameState.P2 = character2;
        yield return new WaitForSeconds(3);
        SetAnimatorToIdle(character2.GetComponent<Animator>());
        FightText.SetActive(true);
        yield return new WaitForSeconds(1);
        FightText.SetActive(false);
        GameState.CanFight = true;
    }

    GameObject SetupCharacter(GameObject character, string name, GameObject spawnPoint, int rotation)
    {
        character = GetCharacter(name, characters);
        character = GameObject.Instantiate(character, spawnPoint.transform);
        character.transform.parent = null;
        character.transform.rotation = Quaternion.Euler(0, rotation, 0);
        Animator animator = character.GetComponent<Animator>();
        animator.Play("Intro");
        return character;
    }

    void SetAnimatorToIdle(Animator animator) 
    {
        animator.Play("Idle");
    }
}
