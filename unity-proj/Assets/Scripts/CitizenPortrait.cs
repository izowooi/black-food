using UnityEngine;
using UnityEngine.UI;

public class CitizenPortrait : MonoBehaviour
{
    [SerializeField] private Image imgCitizen; // img_citizen 이미지 UI

    public int Id { get; private set; }
    private string imagePath;

    // 이미지 경로 초기화
    public void Initialize(int id, string path)
    {
        Id = id;
        imagePath = path;
    }

    // 이미지를 새로고침
    public void Refresh()
    {
        if (imgCitizen == null)
        {
            Debug.LogError("img_citizen 이미지가 설정되지 않았습니다.");
            return;
        }

        // 이미지 로드 및 적용
        Sprite sprite = LoadSpriteFromPath(imagePath);
        if (sprite != null)
        {
            imgCitizen.sprite = sprite;
        }
        else
        {
            Debug.LogError($"이미지를 로드할 수 없습니다: {imagePath}");
        }
    }

    // 경로에서 Sprite를 로드하는 메서드
    private Sprite LoadSpriteFromPath(string path)
    {
        Texture2D texture = Resources.Load<Texture2D>(path); // Resources 폴더 사용 시
        if (texture == null)
        {
            Debug.LogError($"Texture를 로드할 수 없습니다: {path}");
            return null;
        }

        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
    }
}