using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RectTransform titleUI;
    [SerializeField] private RectTransform inGameUIRect;
    [SerializeField] private InGameUI inGameUI;
    [SerializeField] private RectTransform reportUI;
    [SerializeField] private RectTransform gameOverUI;

    private void Start()
    {
        ShowTitleUI();
    }

    public void ShowTitleUI()
    {
        SetActive(titleUI, true);
        SetActive(inGameUIRect, false);
        SetActive(reportUI, false);
        SetActive(gameOverUI, false);
    }
    public void ShowInGameUI()
    {
        SetActive(titleUI, false);
        SetActive(inGameUIRect, true);
        SetActive(reportUI, false);
        SetActive(gameOverUI, false);
        inGameUI.SpwanCitizen();
    }

    public void ShowReportUI()
    {
        SetActive(titleUI, false);
        SetActive(inGameUIRect, false);
        SetActive(reportUI, true);
        SetActive(gameOverUI, false);
    }

    public void ShowGameOverUI()
    {
        SetActive(titleUI, false);
        SetActive(inGameUIRect, false);
        SetActive(reportUI, false);
        SetActive(gameOverUI, true);
    }

    private void SetActive(Transform transformUI, bool isActive)
    {
        Vector3 scale = transformUI.localScale;
        scale.x = isActive ? 1 : 0;
        transformUI.localScale = scale;
    }
}