using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CutsceneManager : MonoBehaviour {
    public TextAsset[] textFiles;
    public TextMeshProUGUI textObject;
    public Player player;

    private void Start() {
        Init();
    }

    private IEnumerator DrawText(string[] lines) {
        foreach (string line in lines) {
            yield return new WaitForSeconds(4);
            textObject.text = line;
        }
    }

    public void Init() {
        int currentChamber = SceneChanger.GetCurrentChamberIndex();

        switch (currentChamber) {
            case 0: 
                // the first cutscene is pretty straight forward:
                // it talks some text.
                // TODO: make the player actually talks with sound
                string[] lines = textFiles[0].text.Split('\n');
                player.canMove = false;
                StartCoroutine(DrawText(lines));
                player.canMove = true;
                return;

            case 1:
                string[] secondLines = textFiles[0].text.Split('\n');
                StartCoroutine(DrawText(secondLines));
                break;
        }
    }
}
