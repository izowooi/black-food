using System;

public class Citizen
{
    // Properties
    public int IllustrationId { get; private set; }
    public string Name { get; private set; }
    public string Job { get; private set; }
    public int Age { get; private set; }
    public string[] Dialogues { get; private set; }
    
    public int Hunger { get; private set; } // 0 to 100
    public int Aggression { get; private set; } // 0 to 100
    public int Disease { get; private set; } // 0 to 100
    
    private int dailyHungerIncrease;
    private int dailyAggressionIncrease;
    private int dailyDiseaseIncrease;

    // Constructor
    public Citizen(int illustrationId, string name, string job, int age, string[] dialogues,
                   int hunger, int aggression, int disease,
                   int dailyHungerInc, int dailyAggressionInc, int dailyDiseaseInc)
    {
        IllustrationId = illustrationId;
        Name = name;
        Job = job;
        Age = age;
        Dialogues = dialogues;
        
        Hunger = hunger;
        Aggression = aggression;
        Disease = disease;
        
        dailyHungerIncrease = dailyHungerInc;
        dailyAggressionIncrease = dailyAggressionInc;
        dailyDiseaseIncrease = dailyDiseaseInc;
    }

    // Methods
    public string GenerateDescription()
    {
        return $"{Name}, a {Age}-year-old {Job}.";
    }

    public string GenerateDialogue()
    {
        var random = new Random();
        return Dialogues[random.Next(Dialogues.Length)];
    }

    private bool CheckDeathByHunger()
    {
        return new Random().Next(0, 100) < Hunger;
    }

    private bool CheckDeathByAggression()
    {
        return new Random().Next(0, 100) < Aggression;
    }

    private bool CheckDeathByDisease()
    {
        return new Random().Next(0, 100) < Disease;
    }

    public bool IsAlive()
    {
        if (CheckDeathByHunger()) return false;
        if (CheckDeathByDisease()) return false;
        if (CheckDeathByAggression()) return false;
        return true;
    }

    public void PassDay()
    {
        Hunger = Math.Min(100, Hunger + dailyHungerIncrease);
        Aggression = Math.Min(100, Aggression + dailyAggressionIncrease);
        Disease = Math.Min(100, Disease + dailyDiseaseIncrease);
    }

    public void ReceiveFood()
    {
        int hungerReduction = 50;
        int aggressionReduction = 50;
        int diseaseReduction = 50;
        Hunger = Math.Max(0, Hunger - hungerReduction);
        Aggression = Math.Max(0, Aggression - aggressionReduction);
        Disease = Math.Max(0, Disease - diseaseReduction);
    }
}