using System;
using UnityEditor;
using UnityEngine;

public class UI_Options : MonoBehaviour
{
    private void Start()
    {
        Game_Manager.Instance.UI_Options = this;
    }

    public void CloseOptions()
    {
        Menu_Manager.Instance.CloseOptions();
    }
}
