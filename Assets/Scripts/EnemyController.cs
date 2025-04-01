using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public string enemyName;
    public int enemyHealth;
    public int enemyLevel;

    //public TMP_Text enemyNameText;
    public HealthController healthController;
    //public LevelController levelController;

    public void Update()
    {
        Initialize();
        DisplayTexts();
    }
    public virtual void Initialize()
    {

    }
    public virtual void DisplayTexts()
    {
        //enemyNameText.text = enemyName;
    }
}
