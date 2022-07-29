using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    Image bar;
    float maxHealth;
    float health;

    public Transform player;

    void Start()
    {
        bar = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        maxHealth = GetComponentInParent<BaseEnemyScript>().maxHealth; //uncomment this line and change with context
        player = FindObjectOfType<PlayerMovementAdvanced>().transform;
    }

    void Update()
    {
        health = GetComponentInParent<BaseEnemyScript>().health; //uncomment this line and change with context
        bar.fillAmount = health / maxHealth;

        transform.LookAt(player);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        transform.GetChild(0).gameObject.SetActive(health!=maxHealth);
    }
}
