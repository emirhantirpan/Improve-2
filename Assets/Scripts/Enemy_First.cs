using UnityEngine;

public class Enemy_First : EnemyController
{
    public override void Initialize()
    {
        enemyName = "FirstBandit";
        enemyHealth = healthController.health;
        enemyLevel = levelController.level;
    }
}
