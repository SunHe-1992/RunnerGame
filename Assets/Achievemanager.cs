using System.Collections.Generic;
using UnityEngine;

public class Achievement
{
    public string achievementName;
    public string description;
    public bool isUnlocked;

    public Achievement(string name, string desc)
    {
        achievementName = name;
        description = desc;
        isUnlocked = false;
    }
}

public class AchievementManager
{
    public List<Achievement> achievements = new List<Achievement>();

    public void UnlockAchievement(string name)
    {
        Achievement achievement = achievements.Find(a => a.achievementName == name);
        if (achievement != null)
            achievement.isUnlocked = true;
    }
}
