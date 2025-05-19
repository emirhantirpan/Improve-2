using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public int maxValue;
    public int minValue = 0;
    public Image _fillImage;
    public Slider _slider;
    public GameObject _statPanel;

    public HealthController HealthController;

    private void Awake()
    {
        _statPanel.SetActive(false);
        Debug.Log(gameObject.name);
        AdjustEnemyType(gameObject.name);
    }
    private void AdjustEnemyType(string enemyType)
    {
        switch (enemyType)
        {
            case "EnemyIskeletor":
                HealthController.health = 100;

                break;
            case "EnemyOrk":
                HealthController.health = 150;

                break;
            case "Player":
                _statPanel.SetActive(true);
                HealthController.health = 1000;

                break;
        }
        maxValue = HealthController.health;
        _slider.value = HealthController.health;
        _slider.maxValue = maxValue;
        _slider.minValue = minValue;
    }
}
