using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] bool isP1Health;

    float original_health_value;
    float new_health_value;
    float difference_between_health_values;

    public Image health_sprite;

    float original_health_x;
    float health_ratio;
    float health_y_scale;
    float health_z_scale;

    // Start is called before the first frame update
    void Start()
    {
        original_health_x = health_sprite.transform.localScale.x;
        health_y_scale = health_sprite.transform.localScale.y;
        health_z_scale = health_sprite.transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(isP1Health)
        {
            health_ratio = GameState.P1Health;
        }
        else
        {
            health_ratio = GameState.P2Health;
        }

        original_health_value = health_sprite.rectTransform.position.x;
        health_sprite.transform.localScale = new Vector3(original_health_x * health_ratio, health_y_scale, health_z_scale);
        new_health_value = health_sprite.rectTransform.position.x;
        difference_between_health_values = new_health_value - original_health_value;
        health_sprite.transform.Translate(new Vector3(-difference_between_health_values, 0f, 0f));

        if (health_ratio < 0.25f)
        {
            health_sprite.color = new Color(255, 0, 0);
        }
        else if (health_ratio < 0.5f)
        {
            health_sprite.color = new Color(255, 255, 0);
        }
        else
        {
            health_sprite.color = new Color(0, 255, 0);
        }

        if(health_ratio <= 0)
        {
            if(isP1Health)
            {
                GameState.IsPlayer1Dead = true;
            }
            else
            {
                GameState.IsPlayer2Dead = true;
            }

            Destroy(gameObject);
        }
    }
}
