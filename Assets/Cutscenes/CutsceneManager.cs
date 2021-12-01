using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CutsceneManager : MonoBehaviour {
    public TextAsset[] textFiles;
    public TextMeshProUGUI textObject;
    public NextScene nextScene;

    private void Start() {
        Init();
    }

    private IEnumerator DrawText(string[] lines) {
        nextScene.canChangeScene = false;
        foreach (string line in lines) {
            yield return new WaitForSeconds(3);
            textObject.text = line;
        }
        nextScene.canChangeScene = true;
    }

    public void Init() {
        int currentChamber = SceneChanger.GetCurrentChamberIndex();
        Debug.Log(currentChamber);

        switch (currentChamber) {
            case 0: 
                // the first cutscene is pretty straight forward:
                // it talks some text.
                // TODO: make the player actually talks with sound
                string[] lines = textFiles[0].text.Split('\n');
                StartCoroutine(DrawText(lines));
                nextScene.canChangeScene = true;
                return;

            case 1:
                string[] secondLines = textFiles[1].text.Split('\n');
                StartCoroutine(DrawText(secondLines));
                break;
            
            case 2: 
                StartCoroutine(DrawText(textFiles[2].text.Split('\n')));
                break;
            
            case 3:
                StartCoroutine(DrawText(textFiles[3].text.Split('\n')));
                break;
        }
    }
}
