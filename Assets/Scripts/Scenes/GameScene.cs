using UnityEngine;

public class GameScene : MonoBehaviour
{
    
    public static void Init()
    {
        Time.timeScale = 1.0f;
        GameManager.UI.ShowPopupUI<UI_Production_Text>();
        GameManager.UI.ShowSceneUI<UI_GameScene>();


    }
}
