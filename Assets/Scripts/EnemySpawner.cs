using UnityEngine;
using UnityEngine.InputSystem;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    private void Awake()
    {
        instance = this;
    }
    /*public EnemyPooler enemyPooler;  
    public Transform spawnPoint;     
    public Transform playerTransform;  

    public PlayerAttack playerAttackScript; 
    public HealthController healthController;
    public SliderController sliderController;

    public string enemyName;  // Spawn edilecek d��man�n ad�
    public int enemyHealth;   // Spawn edilecek d��man�n sa�l���
    public int enemyLevel;
    public void SpawnEnemy()
    {
   
        GameObject newEnemy = enemyPooler.GetEnemyFromPool();

   
        newEnemy.transform.position = spawnPoint.position;

        EnemyController controller = newEnemy.GetComponent<EnemyController>();
        if (controller != null)
        {
            // Burada d��ar�dan gelen de�erlerle SetUp fonksiyonunu �a��r�yoruz
            controller.SetUp(enemyName, enemyHealth, enemyLevel);
        }

        EnemyMovement movement = newEnemy.GetComponent<EnemyMovement>();
        if (movement != null)
        {
            movement.Setup(playerTransform); 
        }

      
        EnemyAttack attack = newEnemy.GetComponent<EnemyAttack>();
        if (attack != null)
        {
            attack.Setup(playerAttackScript, healthController); 
        }

        
        EnemyTakeDamage takeDamage = newEnemy.GetComponent<EnemyTakeDamage>();
        if (takeDamage != null)
        {
            takeDamage.SetUp(healthController, sliderController); 
        }

        
    }*/

    public GameObject enemyPrefab;  // Inspector'dan prefab atayaca��n yer
    public Transform spawnPoint;

    public void SpawnEnemy()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        // Burada enemyPrefab i�inde tan�ml� her �ey (component'lar, inspector de�erleri) oldu�u gibi gelir
            
        }
    }
}
