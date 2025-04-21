using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChestController : MonoBehaviour
{
    [Header("UI")]
    public GameObject interactionPanel;
    public GameObject rewardPanel;
    public CanvasGroup rewardCanvasGroup;
    public Image rewardIconUI;

    [Header("Chest Settings")]
    public Transform lidTransform;
    public float openAngle = 45f;
    public float openSpeed = 2f;

    [Header("Reward")]
    public Sprite rewardIcon;
    public string rewardName = "Altýn Anahtar";
    public AudioSource rewardSound;
    public ParticleSystem rewardParticle;

    private bool isPlayerNearby = false;
    private bool isOpened = false;
    private Quaternion initialRotation;
    private Quaternion targetRotation;

    void Start()
    {
        interactionPanel.SetActive(false);
        rewardPanel.SetActive(false);
        rewardCanvasGroup.alpha = 0f;

        initialRotation = lidTransform.localRotation;
        targetRotation = Quaternion.Euler(openAngle, 0, 0) * initialRotation;
    }

    void Update()
    {
        if (isPlayerNearby && !isOpened && Input.GetKeyDown(KeyCode.E))
        {
            OpenChest();
        }

        if (isOpened && Quaternion.Angle(lidTransform.localRotation, targetRotation) > 0.1f)
        {
            lidTransform.localRotation = Quaternion.Slerp(lidTransform.localRotation, targetRotation, Time.deltaTime * openSpeed);
        }
    }

    private void OpenChest()
    {
        isOpened = true;
        interactionPanel.SetActive(false);
        rewardPanel.SetActive(true);
        rewardCanvasGroup.alpha = 1f;

        Item rewardItem = new KeyItem(rewardName, rewardIcon);
        Inventory.Instance?.AddItem(rewardItem);

        if (rewardIconUI != null && rewardIcon != null)
            rewardIconUI.sprite = rewardIcon;

       // rewardSound?.Play();
        rewardParticle?.Play();

        StartCoroutine(FadeOutRewardPanel());
    }

    private IEnumerator FadeOutRewardPanel()
    {
        yield return new WaitForSeconds(5f);

        float fadeDuration = 1f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            rewardCanvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rewardCanvasGroup.alpha = 0f;
        rewardPanel.SetActive(false);
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
}
