using UnityEngine.Events;
using UnityEngine.UI;

public static class ButtonExtensions {
  public static void SetAction(this Button button, UnityAction action) {
    button.onClick.RemoveAllListeners();
    button.onClick.AddListener(action);
  }
}
