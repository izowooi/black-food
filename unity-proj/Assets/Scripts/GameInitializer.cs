public class GameInitializer
{
    public GameInitializer()
    {
    }

    public void InitializeGame(System.Action onInitializationComplete)
    {
        // 예시로 사운드 및 에셋 번들을 로드하는 로직을 추가할 수 있습니다.
        // 여기서는 단순히 시민 초기화만 수행합니다.
        CitizenManager.Instance.InitializeCitizens();
        onInitializationComplete?.Invoke();
    }
}