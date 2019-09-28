using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
  [SerializeField] private Text resultText;
  [SerializeField] private Button playAgainButton;
  [SerializeField] private Button quitButton;

  public void Initialize(UnityAction playAgainAction, UnityAction quitAction) {
    this.playAgainButton.SetAction(playAgainAction);
    this.quitButton.SetAction(quitAction);

    this.gameObject.SetActive(false);
  }

  public void Show(GameLogic.Result result) {
    switch (result) {
      case GameLogic.Result.HumanWon:
        this.resultText.text = "You won!";
        break;
      case GameLogic.Result.AiWon:
        this.resultText.text = "You lost!";
        break;
      case GameLogic.Result.Draw:
        this.resultText.text = "Draw!";
        break;
    }

    this.gameObject.SetActive(true);
  }
}