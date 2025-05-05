using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;

    private bool _isPaused = false;

    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _homeButton;
    private void Awake()
    {
        instance = this;

        PanelController.instance.ClosePanel(_pausePanel);
        _resumeButton.onClick.AddListener(ResumeButton);
        _homeButton.onClick.AddListener(HomeButton);
    }
    public void PauseButtonInput()
    {
        
        _isPaused = !_isPaused;

        if (_pausePanel.activeInHierarchy)
        {
            _pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            _pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }
    public void ResumeButton()
    {
        PanelController.instance.ClosePanel(_pausePanel);
        Time.timeScale = 1f;
    }
    public void HomeButton()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}
