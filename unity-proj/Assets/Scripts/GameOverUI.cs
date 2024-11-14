using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    private UIManager uiManager;
    
    private void Start()
    {
        uiManager = transform.parent.GetComponent<UIManager>();
        // 버튼 이벤트 연결
        restartButton.onClick.AddListener(OnRestartButton);
    }

    private void OnRestartButton()
    {
        uiManager.ShowTitleUI();
    }
}
