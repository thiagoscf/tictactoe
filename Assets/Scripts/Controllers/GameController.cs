using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
  private enum TurnType { Human, Ai }

  [SerializeField] private Grid grid;
  [SerializeField] private GameOver gameOver;

  private GameLogic gameLogic;

  private void Start() {
    this.gameLogic = new GameLogic();
    this.grid.Initialize(this.PlayHumanTurn);
    this.gameOver.Initialize(
      playAgainAction: () => SceneManager.LoadScene("Game"),
      quitAction: Application.Quit);

    this.PrepareNextTurn((TurnType)Random.Range(0, 2));
  }

  private void PrepareNextTurn(TurnType turnType) {
    GameLogic.Result result = this.gameLogic.CheckGameOver();

    if (result != GameLogic.Result.NotOver) {
      this.grid.PrepareForGameOver();
      this.gameOver.Show(result);
      return;
    }

    if (turnType == TurnType.Human) {
      this.grid.PrepareForHumanTurn();
    } else {
      this.grid.PrepareForAiTurn();
      this.PlayAiTurn();
    }
  }

  private void PlayAiTurn() {
    int choice = this.gameLogic.PlayAiTurn();
    this.grid.PlayAiTurn(choice, () => this.PrepareNextTurn(TurnType.Human));
  }

  private void PlayHumanTurn(int choice, UnityAction onComplete) {
    if (this.gameLogic.IsChoiceValid(choice)) {
      this.gameLogic.PlayHumanTurn(choice);
      onComplete?.Invoke();

      this.PrepareNextTurn(TurnType.Ai);
    }
  }
}