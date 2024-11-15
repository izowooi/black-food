using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    private UIManager uiManager;
    [SerializeField] 
    private CitizenSpawner citizenSpawner;
    public TextMeshProUGUI citizenDialogueText;
    public TextMeshProUGUI citizenStatusText;
    public TextMeshProUGUI waitingCitizenCountText;
    public Button gunButton;
    public Button foodButton;
    public Button rejectButton;
    
    void Start()
    {
        uiManager = transform.parent.GetComponent<UIManager>();
        gunButton.onClick.AddListener(HandleGunAction);
        foodButton.onClick.AddListener(HandleFoodAction);
        rejectButton.onClick.AddListener(HandleRejectAction);
        
        RefreshUI();
    }

    public void SpwanCitizen()
    {
        var array = CitizenManager.Instance.CitizenQueue.ToArray();
        var citizenIds = new List<int>();
        
        foreach (var citizen in array)
        {
            citizenIds.Add(citizen.IllustrationId);
        }
        
        citizenSpawner.ArrangeCitizens(citizenIds.ToArray());
    }
    public void RefreshUI()
    {
        UpdateStatusDisplay();
        UpdateDialogueDisplay();
        UpdateWaitingCitizenCount();
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
    
    // 대기 중인 시민수 갱신 함수
    public void UpdateWaitingCitizenCount()
    {
        waitingCitizenCountText.text = $"1 일차\n{CitizenManager.Instance.CitizenQueue.Count} 명 대기 중";
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
        citizenSpawner.ProceedToNextCitizen();
        
        if ( CitizenManager.Instance.GetCurrentCitizen() == null)
        {
            //하루를 종료하고
            // 리포트 UI 를 활성화한다.
            CitizenManager.Instance.EndDay();
            SupplyManager.Instance.EndDay();
            uiManager.ShowReportUI();
            
        }
        else
        {
            ShowCurrentCitizen();
            UpdateStatusDisplay();
            UpdateDialogueDisplay();
        }
    }
}