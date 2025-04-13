using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class EnemyHealthbar : MonoBehaviour
{
    
        public float maxHealth = 100f;
        private float currentHealth;

        public GameObject healthBarCanvas; 
        public Slider healthSlider;

        private Coroutine hideHealthBarCoroutine;

        void Start()
        {
            currentHealth = maxHealth;
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;

            healthBarCanvas.SetActive(false); 
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            healthSlider.value = currentHealth;

            ShowHealthBar();
        }

        private void ShowHealthBar()
        {
            healthBarCanvas.SetActive(true);

            
            if (hideHealthBarCoroutine != null)
            {
                StopCoroutine(hideHealthBarCoroutine);
            }

           
            hideHealthBarCoroutine = StartCoroutine(HideHealthBarAfterDelay());
        }

        private IEnumerator HideHealthBarAfterDelay()
        {
            yield return new WaitForSeconds(4f);
            healthBarCanvas.SetActive(false);
        }
    
}
