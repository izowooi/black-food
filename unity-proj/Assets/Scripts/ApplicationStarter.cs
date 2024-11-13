using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationStarter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        InitializeCitizenManager();
        
        SceneManager.LoadScene("InGameScene");

        // AllocateUserResources();
        //
    }

    void InitializeCitizenManager()
    {
        CitizenManager.Instance.Initialize();
    }


    void AllocateUserResources()
    {
    }

}