using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour {
    public Button button;

    private void Start() {
        button.onClick.AddListener(StartGame);
    }

    private void StartGame() {
        SceneChanger.LoadScene("Chamber_0");
    }
}
