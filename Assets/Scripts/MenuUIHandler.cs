using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif
// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField PlayerPseudoInput;

    public void OnPlayerPseudoValueChanged()
    {
        Debug.Log(PlayerPseudoInput.text);
        MainManager.Instance.PlayerPseudo = PlayerPseudoInput.text;
    }
    
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    // private void Start()
    // {
    //     ColorPicker.Init();
    //     //this will call the NewColorSelected function when the color picker have a color button clicked.
    //     ColorPicker.onColorChanged += NewColorSelected;
    //     ColorPicker.SelectColor(MainManager.Instance.TeamColor);
    // }

    // public void SaveColorClicked()
    // {
    //     MainManager.Instance.SaveColor();
    // }

    // public void LoadColorClicked()
    // {
    //     MainManager.Instance.LoadColor();
    //     ColorPicker.SelectColor(MainManager.Instance.TeamColor);
    // }

    public void Exit()
    {
        // MainManager.Instance.SaveColor(); 
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
