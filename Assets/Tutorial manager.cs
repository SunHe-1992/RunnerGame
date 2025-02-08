using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Text tutorialText;
    public QuestManager questManager;

    void Start()
    {
        // Display tutorial text
        tutorialText.text = "Welcome to the game! Complete quests to progress.";

        // Add initial tutorial quest
        questManager.AddQuest("Welcome Quest", "Complete this quest to learn the basics.");
    }
}
