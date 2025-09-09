using UnityEngine;
using UnityEngine.UI;

public class UI_Menu : MonoBehaviour
{
    public Button ExitButton;


    public void ChangeSceneByIndex(int index)
    {
        Game_Manager.Instance.ChangeSceneByIndex(index);
    }

    public void ChangeSceneByName(string name)
    {
        Game_Manager.Instance.ChangeSceneByName(name);
    }

    public void ExitGame()
    {
        Menu_Manager.Instance.ExitGame();
    }


}
