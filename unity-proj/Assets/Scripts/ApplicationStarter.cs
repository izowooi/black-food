using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationStarter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InitializeCitizenManager();
        
        AssignCitizensToManager();
        
        StartNewDay();
        
        // AllocateUserResources();
        //
        MoveToIngameScene();
    }

    void InitializeCitizenManager()
    {
        CitizenManager.Instance.InitializeCitizens();
    }

    // CitizenManager에 시민들을 할당하는 메서드 (예시, 실제 구현 필요)
    void AssignCitizensToManager()
    {
        CitizenManager.Instance.AssignCitizens();
    }

    void StartNewDay()
    {
        CitizenManager.Instance.StartNewDay();
    }

    void AllocateUserResources()
    {
    }

    void MoveToIngameScene()
    {
        SceneManager.LoadScene("IngameScene");
    }
}