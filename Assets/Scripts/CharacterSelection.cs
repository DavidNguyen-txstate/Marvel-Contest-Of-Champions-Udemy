using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] List<GameObject> characters;
    [SerializeField] List<string> names = new List<string>() { "Wolverine", "Spiderman", "Hulk", "Thanos" };
    [SerializeField] GameObject character;
    [SerializeField] new string name;

    public void HandleOnMouseOver()
    {
        foreach(GameObject c in characters)
        {
            c.SetActive(false);
        }

        character.SetActive(true);
    }

    public void HandleOnMouseDown()
    {
        GameState.LeftCharacter = name;
        RandomEnemySelect();
        SceneManager.LoadSceneAsync("Main");
    }

    private void RandomEnemySelect()
    {
        names.Remove(name);
        System.Random random = new System.Random();
        int r = random.Next(3);
        GameState.RightCharacter = names[r];
    }
}
