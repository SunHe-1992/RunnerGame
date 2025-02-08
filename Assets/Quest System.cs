using System.Collections.Generic;

public class Quest
{
    public string questName;
    public string description;
    public bool isCompleted;

    public Quest(string name, string desc)
    {
        questName = name;
        description = desc;
        isCompleted = false;
    }
}

public class QuestManager
{
    public List<Quest> activeQuests = new List<Quest>();

    public void AddQuest(string name, string desc)
    {
        activeQuests.Add(new Quest(name, desc));
    }

    public void CompleteQuest(string name)
    {
        Quest quest = activeQuests.Find(q => q.questName == name);
        if (quest != null)
            quest.isCompleted = true;
    }
}
