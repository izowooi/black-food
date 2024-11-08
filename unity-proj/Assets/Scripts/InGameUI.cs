using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public TextMeshProUGUI citizenDialogueText;
    public TextMeshProUGUI citizenStatusText;
    public Button gunButton;
    public Button foodButton;
    public Button rejectButton;
    
    void Start()
    {
        gunButton.onClick.AddListener(HandleGunAction);
        foodButton.onClick.AddListener(HandleFoodAction);
        rejectButton.onClick.AddListener(HandleRejectAction);
    }
    
    // 상태창 갱신 함수
    public void UpdateStatusDisplay()
    {
        citizenStatusText.text = CitizenManager.Instance.GetCurrentCitizen().GenerateDescription();
    }

    // 대사창 갱신 함수
    public void UpdateDialogueDisplay()
    {
        citizenDialogueText.text = CitizenManager.Instance.GetCurrentCitizen().GenerateDialogue();
    }
    public void StartNewDay()
    {
        // CitizenManager.Instance.StartNewDay();
        // ShowCurrentCitizen();
        
        UpdateStatusDisplay();
        UpdateDialogueDisplay();
    }

    void ShowCurrentCitizen()
    {
        // Citizen currentCitizen = CitizenManager.Instance.GetCurrentCitizen();
        // if (currentCitizen != null)
        // {
        //     citizenDialogueText.text = $"Hello, I'm {currentCitizen.name}. I am a {currentCitizen.job}.";
        //     citizenJobText.text = currentCitizen.job;
        // }
        // else
        // {
        //     StartNewDay(); // 모든 시민이 끝났다면 다음 날로 넘어갑니다.
        // }
    }

    void HandleGunAction()
    {
        Debug.Log("Gun action");
        CitizenManager.Instance.RemoveCurrentCitizen();
        ProceedToNextCitizen();
    }

    void HandleFoodAction()
    {
        Debug.Log("Food action");
        CitizenManager.Instance.GiveFoodToCurrentCitizen();
        ProceedToNextCitizen();
    }

    void HandleRejectAction()
    {
        Debug.Log("Reject action");
        ProceedToNextCitizen(); // 아무 일도 하지 않고 다음 시민으로 넘어갑니다.
    }

    void ProceedToNextCitizen()
    {
        CitizenManager.Instance.ProceedToNextCitizen();
        ShowCurrentCitizen();
    }
}