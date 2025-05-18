using System.Collections;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    public bool isTakingDamage;

    [SerializeField] private HealthController _healthController;
    [SerializeField] private SliderController _sliderController;

    public void TakeDamage(int damage)
    {
        if (_healthController == null) return;

        isTakingDamage = true;
        _healthController.DecreaseHealth(damage);

        // Panel açma-kapama iþlemi burada devam edebilir.
        if (_healthController.health > 0)
        {
            PanelController.instance.OpenPanel(_sliderController._statPanel);
        }
        else
        {
            PanelController.instance.ClosePanel(_sliderController._statPanel);
        }

        StartCoroutine(ResetTakingDamage());
        StartCoroutine(ClosePanelAfterSeconds());
    }


    private IEnumerator ResetTakingDamage()
    {
        yield return new WaitForSeconds(2f);
        isTakingDamage = false;
    }

    private IEnumerator ClosePanelAfterSeconds()
    {
        yield return new WaitForSecondsRealtime(2f);
        if (!isTakingDamage)
        {
            PanelController.instance.ClosePanel(_sliderController._statPanel);
        }
    }
}
