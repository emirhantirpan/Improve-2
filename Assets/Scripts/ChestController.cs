using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChestController : MonoBehaviour
{
    public GameObject interactionPanel;
    public GameObject rewardPanel;
    public CanvasGroup rewardCanvasGroup; // Panelin CanvasGroup'u
    

    public Transform lidTransform;
    public AudioSource rewardSound;
    public float openAngle = 45f;
    public float openSpeed = 2f;

    private bool isPlayerNearby = false;
    private bool isOpened = false;
    private Quaternion initialRotation;
    private Quaternion targetRotation;

    void Start()
    {
        interactionPanel.SetActive(false);
        rewardPanel.SetActive(false);
        rewardCanvasGroup.alpha = 0f; // Baþlangýçta görünmez
        initialRotation = lidTransform.localRotation;
        targetRotation = Quaternion.Euler(openAngle, 0, 0) * initialRotation;
    }

    void Update()
    {
        if (isPlayerNearby && !isOpened && Input.GetKeyDown(KeyCode.E))
        {
            isOpened = true;
            interactionPanel.SetActive(false);
            rewardPanel.SetActive(true);
            rewardCanvasGroup.alpha = 1f;
           // rewardSound.Play();
            StartCoroutine(FadeOutRewardPanel());
        }

        if (isOpened && Quaternion.Angle(lidTransform.localRotation, targetRotation) > 0.1f)
        {
            lidTransform.localRotation = Quaternion.Slerp(lidTransform.localRotation, targetRotation, Time.deltaTime * openSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpened)
        {
            isPlayerNearby = true;
            interactionPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            interactionPanel.SetActive(false);
        }
    }

    private IEnumerator FadeOutRewardPanel()
    {
        yield return new WaitForSeconds(5f); // 5 saniye bekle

        float fadeDuration = 1f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            rewardCanvasGroup.alpha = alpha;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rewardCanvasGroup.alpha = 0f;
        rewardPanel.SetActive(false); // Tamamen görünmez hale gelince paneli kapat
    }
}
