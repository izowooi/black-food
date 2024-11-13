using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReportUI : MonoBehaviour
{
    private UIManager uiManager;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI survivingCitizensText;
    [SerializeField] private TextMeshProUGUI currentFoodText;
    [SerializeField] private TextMeshProUGUI currentCurrencyText;
    [SerializeField] private TextMeshProUGUI citizenDetailsText;
    [SerializeField] private TextMeshProUGUI foodDetailsText;
    [SerializeField] private TextMeshProUGUI currencyDetailsText;
    [SerializeField] private Button purchaseFoodButton;
    [SerializeField] private Button startNextDayButton;

    private void Start()
    {
        uiManager = transform.parent.GetComponent<UIManager>();
        // 버튼 이벤트 연결
        purchaseFoodButton.onClick.AddListener(OnPurchaseFood);
        startNextDayButton.onClick.AddListener(OnStartNextDay);

        // UI 업데이트 초기화
        UpdateUI();
    }

    private void UpdateUI()
    {
        // CitizenManager와 SupplyManager의 데이터로 UI 갱신
        if (CitizenManager.Instance != null)
        {
            survivingCitizensText.text = $"생존주민수 : {CitizenManager.Instance.GetSurvivingCitizensCount()}";
            citizenDetailsText.text = CitizenManager.Instance.GetCitizenDetails();
        }

        if (SupplyManager.Instance != null)
        {
            titleText.text = $"{SupplyManager.Instance.GetCurrentDay} 일차 보고서";
            currentFoodText.text = $"남은 식량 : {SupplyManager.Instance.GetCurrentFood()}";
            currentCurrencyText.text = $"남은 재화 : {SupplyManager.Instance.GetCurrentCurrency()}";
            foodDetailsText.text = SupplyManager.Instance.GetFoodDetails();
            currencyDetailsText.text = SupplyManager.Instance.GetCurrencyDetails();
        }
    }

    private void OnPurchaseFood()
    {
        // 식량 구매 로직
        if (SupplyManager.Instance != null)
        {
            SupplyManager.Instance.PurchaseFood();
            UpdateUI(); // 구매 후 UI 업데이트
        }
    }

    private void OnStartNextDay()
    {
        // 다음 날 시작 로직
        if (CitizenManager.Instance != null)
        {
            if (CitizenManager.Instance.GetSurvivingCitizensCount() > 0)
            {
                CitizenManager.Instance.StartNewDay();
                uiManager.ShowInGameUI();
            }
            else
            {
                uiManager.ShowGameOverUI();
                Debug.Log("Game Over");
            }
        }
    }
}