using System.Collections.Generic;
using UnityEngine;

public class CitizenManager
{
    private static CitizenManager instance;
    
    public static CitizenManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CitizenManager();
            }
            return instance;
        }
    }
    private List<Citizen> citizens = new List<Citizen>();
    
    private List<Citizen> currentQueue = new List<Citizen>();
    public List<Citizen> CitizenQueue => currentQueue;

    private int currentCitizenIndex;

    //서버에서 시민 정보를 가져와서 저장해야함
    public void Initialize()
    {
        citizens.Clear();
    }
    
    //서버에서 가져온 시민 정보 중 일부를 할당해줘야함
    public void AssignCitizens()
    {
        citizens.Clear();
        citizens.Add(new Citizen(1, "말자", "Farmer", 45, new string[] { "배고프다", "밥 좀 다오" }, 
                                 hunger: 20, aggression: 10, disease: 5, dailyHungerInc: 5, dailyAggressionInc: 2, dailyDiseaseInc: 1));
        citizens.Add(new Citizen(2, "숙자", "Teacher", 30, new string[] { "애미야!", "술 좀 다오" },
                                 hunger: 15, aggression: 5, disease: 10, dailyHungerInc: 4, dailyAggressionInc: 1, dailyDiseaseInc: 2));
        // citizens.Add(new Citizen(3, "Michael", "Doctor", 40, new string[] { "Health is wealth.", "Let's treat the sick." },
        //                          hunger: 10, aggression: 8, disease: 12, dailyHungerInc: 3, dailyAggressionInc: 1, dailyDiseaseInc: 2));
        // citizens.Add(new Citizen(4, "Sarah", "Nurse", 35, new string[] { "I care for everyone.", "Your health matters." },
        //                          hunger: 12, aggression: 6, disease: 9, dailyHungerInc: 4, dailyAggressionInc: 1, dailyDiseaseInc: 2));
        // citizens.Add(new Citizen(5, "David", "Engineer", 50, new string[] { "Let's build something great!", "Engineering is art." },
        //                          hunger: 18, aggression: 10, disease: 7, dailyHungerInc: 5, dailyAggressionInc: 2, dailyDiseaseInc: 1));
        // citizens.Add(new Citizen(6, "Emma", "Chef", 28, new string[] { "Cooking is love.", "Let's make something delicious." },
        //                          hunger: 8, aggression: 4, disease: 6, dailyHungerInc: 3, dailyAggressionInc: 1, dailyDiseaseInc: 1));
        // citizens.Add(new Citizen(7, "Chris", "Soldier", 33, new string[] { "Protect the city.", "Stay strong!" },
        //                          hunger: 25, aggression: 30, disease: 15, dailyHungerInc: 6, dailyAggressionInc: 5, dailyDiseaseInc: 3));
        // citizens.Add(new Citizen(8, "Olivia", "Artist", 29, new string[] { "Art is life.", "Creativity never dies." },
        //                          hunger: 14, aggression: 5, disease: 8, dailyHungerInc: 4, dailyAggressionInc: 2, dailyDiseaseInc: 1));
        // citizens.Add(new Citizen(9, "James", "Builder", 38, new string[] { "Let's construct something.", "The city is growing." },
        //                          hunger: 20, aggression: 7, disease: 10, dailyHungerInc: 5, dailyAggressionInc: 2, dailyDiseaseInc: 1));
        // citizens.Add(new Citizen(10, "Sophia", "Scientist", 42, new string[] { "Discovery awaits.", "Knowledge is power." },
        //                          hunger: 15, aggression: 6, disease: 5, dailyHungerInc: 4, dailyAggressionInc: 1, dailyDiseaseInc: 2));
    }
    public void StartNewDay()
    {
        currentQueue.Clear();
        List<Citizen> shuffledCitizens = new List<Citizen>(citizens);
        shuffledCitizens.Shuffle();
        int numCitizensToQueue = Mathf.Min(6, shuffledCitizens.Count);
        for (int i = 0; i < numCitizensToQueue; i++)
        {
            currentQueue.Add(shuffledCitizens[i]);
        }
        currentCitizenIndex = 0;
    }
    
    public void EndDay()
    {
        CheckCitizenStatus();
    }

    public Citizen GetCurrentCitizen()
    {
        if (currentCitizenIndex < currentQueue.Count)
        {
            return currentQueue[currentCitizenIndex];
        }
        return null;
    }

    public void RemoveCurrentCitizen()
    {
        if (currentCitizenIndex < currentQueue.Count)
        {
            citizens.Remove(currentQueue[currentCitizenIndex]);
        }
    }

    public void GiveFoodToCurrentCitizen()
    {
        if (currentCitizenIndex < currentQueue.Count)
        {
            currentQueue[currentCitizenIndex].ReceiveFood();
        }
    }

    public void ProceedToNextCitizen()
    {
        currentCitizenIndex++;
    }
    
    //모든 시민에 대하여 생존 체크를 한다.
    public void CheckCitizenStatus()
    {
        for (int i = 0; i < citizens.Count; i++)
        {
            citizens[i].PassDay();
            if (!citizens[i].IsAlive())
            {
                citizens.RemoveAt(i);
            }
        }
    }

    public int GetSurvivingCitizensCount()
    {
        return citizens.Count;
    }

    public string GetCitizenDetails()
    {
        string ret =
            "0 명을 아오지로 보냈습니다.\n" +
            "0 명이 굶어 죽었습니다.\n" +
            "0 명이 싸우다 죽었습니다.\n" +
            "0 명이 질병으로 죽었습니다.\n\n" +
            "남은 병사 : 1명\n" +
            "남은 농부 : 2명\n" +
            "남은 학생 : 0명\n" +
            "남은 상인 : 0명\n" +
            "남은 기술자 : 0명\n" +
            "남은 작업자 : 0명 \n";
        return ret;
    }
}