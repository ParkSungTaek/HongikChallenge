using System.Collections;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    private void Start()
    {
        GameManager.UI.ShowPopupUI<UI_Production_Text>();

    }
    public static void Init()
    {
        GameManager.UI.ShowSceneUI<UI_GameScene>();

    }



}
