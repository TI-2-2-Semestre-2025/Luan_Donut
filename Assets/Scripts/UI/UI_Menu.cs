using UnityEngine;
using UnityEngine.UI;

public class UI_Menu : MonoBehaviour
{
    

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

    public void OpenOptions()
    {
        Game_Manager.Instance.UI_Options.OpenOptions();
    }

    

}
