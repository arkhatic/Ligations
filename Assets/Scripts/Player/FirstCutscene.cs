using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FirstCutscene {
    private static void DialogueBox(string text) {
        return;
    }

    private static IEnumerator DialogueCoroutine(float secondsDelay) {
        yield return new WaitForSeconds(secondsDelay);
    }

    public static void StartFirstCoroutine() {
        return;
    }
}
