using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Grid : MonoBehaviour {
  private const int ButtonCount = 9;
  private const float AiTurnDelay = 1;

  [SerializeField] private Transform buttonContainer;
  [SerializeField] private GridButton buttonPrefab;
  [SerializeField] private Text turnInfo;

  private GridButton[] buttons;
  private UnityAction<int, UnityAction> onButtonClickAction;

  public void Initialize(UnityAction<int, UnityAction> onButtonClickAction) {
    this.onButtonClickAction = onButtonClickAction;
    this.buttons = new GridButton[ButtonCount];

    for (int i = 0; i < this.buttons.Length; i++) {
      this.buttons[i] = Instantiate(this.buttonPrefab, parent: this.buttonContainer);
      this.buttons[i].Initialize(i, this.PlayHumanTurn);
    }
  }

  public void PrepareForGameOver() {
    this.SetInteractable(false);
    this.turnInfo.text = string.Empty;
  }

  public void PrepareForAiTurn() {
    this.SetInteractable(false);
    this.turnInfo.text = "AI's turn";
  }

  public void PrepareForHumanTurn() {
    this.SetInteractable(true);
    this.turnInfo.text = "Human's turn";
  }

  public void PlayAiTurn(int buttonIndex, UnityAction onComplete) {
    this.Schedule(
      AiTurnDelay,
      () => {
        this.buttons[buttonIndex].SetText("O");
        this.SetInteractable(true);
        onComplete?.Invoke();
      });
  }

  private void PlayHumanTurn(int buttonIndex) {
    this.onButtonClickAction?.Invoke(buttonIndex, () => {
      this.SetInteractable(false);
      this.buttons[buttonIndex].SetText("X");
    });
  }

  private void SetInteractable(bool interactable) {
    foreach (GridButton gridButton in this.buttons) {
      gridButton.interactable = interactable;
    }
  }
}