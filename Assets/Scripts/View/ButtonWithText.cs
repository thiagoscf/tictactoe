using UnityEngine;
using UnityEngine.UI;

public class ButtonWithText : Button {
  [SerializeField] private Text text;

  public Text Text {
    get {
      return this.text;
    }
  }
}
