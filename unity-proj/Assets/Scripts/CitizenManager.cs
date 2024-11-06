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
    private int currentCitizenIndex;

    public void InitializeCitizens()
    {
        // 예시로 10명의 시민을 초기화합니다.
        citizens.Add(new Citizen("John", "Farmer"));
        citizens.Add(new Citizen("Emily", "Teacher"));
        citizens.Add(new Citizen("Michael", "Doctor"));
        citizens.Add(new Citizen("Sarah", "Nurse"));
        citizens.Add(new Citizen("David", "Engineer"));
        citizens.Add(new Citizen("Emma", "Chef"));
        citizens.Add(new Citizen("Chris", "Soldier"));
        citizens.Add(new Citizen("Olivia", "Artist"));
        citizens.Add(new Citizen("James", "Builder"));
        citizens.Add(new Citizen("Sophia", "Scientist"));
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
            currentQueue[currentCitizenIndex].foodCount++;
        }
    }

    public void ProceedToNextCitizen()
    {
        currentCitizenIndex++;
    }
}