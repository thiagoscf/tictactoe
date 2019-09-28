using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public static class GameObjectExtensions {
  public static Coroutine Schedule(this MonoBehaviour mono, float time, UnityAction action) {
    if (Mathf.Approximately(time, 0.0f) || time < 0) {
      action?.Invoke();
      return null;
    }

    return mono.StartCoroutine(Wait(time, action));
  }

  private static IEnumerator Wait(float seconds, UnityAction actionToPerform) {
    yield return new WaitForSeconds(seconds);
    actionToPerform?.Invoke();
  }
}