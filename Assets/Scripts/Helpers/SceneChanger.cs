using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneChanger {
    public static string GetCurrentSceneName() {
        Scene scene = SceneManager.GetActiveScene();
        return scene.name;
    }

    public static int GetCurrentChamberIndex() {
        string curChamber = SceneChanger.GetCurrentSceneName();
        return int.Parse(curChamber.Split('_')[1]) + 1;
    }

    public static void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public static void LoadNextChamber() {
        string curChamber = SceneChanger.GetCurrentSceneName();
        int chamberIndex = int.Parse(curChamber.Split('_')[1]) + 1;
        string nextChamber = $"Chamber_{chamberIndex}";

        SceneManager.LoadScene(nextChamber);
    }

    public static void LoadPreviousChamber() {
        string curChamber = SceneChanger.GetCurrentSceneName();
        int chamberIndex = int.Parse(curChamber.Split('_')[1]) - 1;
        string nextChamber = $"Chamber_{chamberIndex}";

        SceneManager.LoadScene(nextChamber);
    }
}
