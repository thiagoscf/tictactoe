using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GridButton : Button {
  [SerializeField] private Text text;

  public void Initialize(int buttonIndex, UnityAction<int> onClickAction) {
    this.SetAction(() => onClickAction?.Invoke(buttonIndex));
  }

  public void SetText(string text) {
    this.text.text = text;
  }
}