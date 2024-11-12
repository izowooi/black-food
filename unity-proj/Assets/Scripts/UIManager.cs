using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RectTransform inGameUI;
    [SerializeField] private RectTransform reportUI;

    private void Start()
    {
        ShowInGameUI();
    }

    public void ShowInGameUI()
    {
        SetActive(inGameUI, true);
        SetActive(reportUI, false);
    }

    public void ShowReportUI()
    {
        SetActive(inGameUI, false);
        SetActive(reportUI, true);
    }

    private void SetActive(Transform transformUI, bool isActive)
    {
        Vector3 scale = transformUI.localScale;
        scale.x = isActive ? 1 : 0;
        transformUI.localScale = scale;
    }
}