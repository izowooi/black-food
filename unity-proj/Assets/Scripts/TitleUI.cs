using UnityEngine;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
    private UIManager uiManager;
    [SerializeField] private Button startButton;

    private void Start()
    {
        uiManager = transform.parent.GetComponent<UIManager>();
        startButton.onClick.AddListener(MoveToIngameScene);
    }

    public void MoveToIngameScene()
    {
        Debug.Log("Move to InGame Scene");
        CitizenManager.Instance.AssignCitizens();
        CitizenManager.Instance.StartNewDay();
        SupplyManager.Instance.Initizlie();
        uiManager.ShowInGameUI();
    }
    
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    
    public void LogHello()
    {
        Debug.Log("Hello");
    }
}
