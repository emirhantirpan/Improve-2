using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public string enemyName;
    public int enemyHealth;
    public int enemyLevel;

    public TMP_Text enemyNameText;
    public SliderController sliderController;
    public HealthController healthController;
    public LevelController levelController;
    public XpController xpController;

    public EnemyPooler pooler;

    public void Setup(EnemyPooler enemyPooler)
    {
        enemyPooler = pooler;
    }
    public void Update()
    {
        Initialize();
        DisplayTexts();
        Die();
    }
    public virtual void Initialize()
    {
        
    }
    public virtual void DisplayTexts()
    {
        enemyNameText.text = enemyName;
    }
    public void OnMouseOver()
    {
        PanelController.instance.OpenPanel(sliderController._statPanel);
    }
    public void OnMouseExit()
    {
        PanelController.instance.ClosePanel(sliderController._statPanel);
    }
    public void SetPool()
    {
        if (pooler != null)
        {
            pooler.ReturnEnemyToPool(gameObject);  // Kendini pool'a geri gönder
        }
        else
        {
            Debug.LogWarning("Pooler referansý bulunamadý!");
        }
    }
    public void Die()
    {
        if (healthController.health == 0)
        {
            xpController.GainXP(10);
            Destroy(gameObject, 1f);
        }
    }
}
