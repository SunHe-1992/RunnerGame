public interface IObserver
{
    void OnNotify(string eventName);
}

public class QuestObserver : IObserver
{
    private QuestManager questManager;

    public QuestObserver(QuestManager manager)
    {
        questManager = manager;
    }

    public void OnNotify(string eventName)
    {
        if (eventName == "QuestCompleted")
        {
            // Handle quest completion event
        }
    }
}

public class AchievementObserver : IObserver
{
    private AchievementManager achievementManager;

    public AchievementObserver(AchievementManager manager)
    {
        achievementManager = manager;
    }

    public void OnNotify(string eventName)
    {
        if (eventName == "AchievementUnlocked")
        {
            // Handle achievement unlocked event
        }
    }
}
