using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReportUI : MonoBehaviour
{
    private UIManager uiManager;
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
            survivingCitizensText.text = $"Surviving Citizens: {CitizenManager.Instance.GetSurvivingCitizensCount()}";
            citizenDetailsText.text = CitizenManager.Instance.GetCitizenDetails();
        }

        if (SupplyManager.Instance != null)
        {
            currentFoodText.text = $"Current Food: {SupplyManager.Instance.GetCurrentFood()}";
            currentCurrencyText.text = $"Current Currency: {SupplyManager.Instance.GetCurrentCurrency()}";
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
            CitizenManager.Instance.StartNewDay();
            UpdateUI(); // 다음 날 시작 후 UI 업데이트
            uiManager.ShowReportUI();
        }
    }
}