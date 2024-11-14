using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenSpawner : MonoBehaviour
{
    [SerializeField] private CitizenPortrait citizenPrefab; // 시민 프리팹
    [SerializeField] private RectTransform outsideTransform; // 기준이 되는 RectTransform
    [SerializeField] private RectTransform parentTransform; // 기준이 되는 RectTransform
    [SerializeField] private float spacing = 100f; // 각 시민 간의 간격

    private Dictionary<int, CitizenPortrait> citizenPool = new Dictionary<int, CitizenPortrait>(); // 풀링 딕셔너리
    private List<CitizenPortrait> activeCitizens = new List<CitizenPortrait>(); // 현재 활성화된 시민 리스트
    private int poolSize = 12; // 기본 풀 크기 (필요 시 조정 가능)

    private void Start()
    {
        InitializePool();
    }

    // 풀 초기화
    private void InitializePool()
    {
        for (int i = 1; i <= poolSize; i++)
        {
            string imagePath = $"Texture/citizen_{i:D2}";
            CitizenPortrait citizen = Instantiate(citizenPrefab, outsideTransform); // UI 바깥쪽에 배치
            citizen.Initialize(i, imagePath);
            citizen.Refresh();
            citizenPool.Add(i, citizen);
        }
    }
    
    public void TestBtn1()
    {
        int[] citizenIds = { 1, 2, 3, 4, 5 };
        ArrangeCitizens(citizenIds);
    }
    
    public void TestBtn2()
    {
        int[] citizenIds = { 6, 7, 8, 9, 10 };
        ArrangeCitizens(citizenIds);
    }
    
    public void TestBtn3()
    {
        ProceedToNextCitizen();
    }

    // 시민 배치
    public void ArrangeCitizens(int[] citizenIds)
    {
        ClearActiveCitizens();

        for (int i = 0; i < citizenIds.Length; i++)
        {
            CitizenPortrait citizen = GetPooledCitizen(citizenIds[i]);
            if (citizen == null) return;

            citizen.transform.SetParent(parentTransform, false);

            // 위치 설정
            RectTransform rectTransform = citizen.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(i * spacing, 0); // 오른쪽으로 간격 배치

            activeCitizens.Add(citizen);
        }

        // 생성 순서대로 오브젝트를 재정렬하여 뒤에 생성된 오브젝트가 먼저 그려지도록 설정
        for (int i = activeCitizens.Count - 1; i >= 0; i--)
        {
            activeCitizens[i].transform.SetAsLastSibling();
        }
    }

    // 시민 제거 후 풀로 반환
    private void RemoveCitizen(CitizenPortrait citizen)
    {
        citizen.transform.SetParent(outsideTransform, false); // 풀링된 위치로 재배치
        activeCitizens.Remove(citizen);
        citizenPool[citizen.Id] = citizen;
    }

    // 풀에서 시민 가져오기
    private CitizenPortrait GetPooledCitizen(int id)
    {
        if (citizenPool.ContainsKey(id))
        {
            CitizenPortrait citizen = citizenPool[id];
            return citizen;
        }
        
        return null; // 풀에 남은 시민이 없을 경우 null 반환
    }

    // 활성화된 시민 초기화
    private void ClearActiveCitizens()
    {
        foreach (CitizenPortrait citizen in activeCitizens)
        {
            citizen.transform.SetParent(outsideTransform); // 풀로 반환
            citizenPool[citizen.Id] = citizen;
        }

        activeCitizens.Clear();
    }

    // 다음 시민으로 이동 시 호출 (CitizenManager의 ProceedToNextCitizen에 호출 가능)
    public void ProceedToNextCitizen()
    {
        if (activeCitizens.Count > 0)
        {
            CitizenPortrait citizen = activeCitizens[0];
            RemoveCitizen(citizen);
        }
    }
}