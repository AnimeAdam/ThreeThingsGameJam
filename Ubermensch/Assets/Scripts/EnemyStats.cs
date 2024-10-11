using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public enum EnemyType{
        Mage,
        Warrior,
        Soldier,
        PlayerTroops
    }

    public int maxHealth = 3;
    public int currentHealth;
    public float movementSpeed = 2f;
    public EnemyType enemyType;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ApplyDamage(int damage)
    {
        currentHealth -= damage;
        CheckIfDead();
    }

    void CheckIfDead()
    {
        if (currentHealth <= 0){
            gameObject.SendMessage("DestoryThisEnemy");
        }

    }
}
