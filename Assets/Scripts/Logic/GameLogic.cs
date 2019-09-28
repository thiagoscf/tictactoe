using System.Linq;
using UnityEngine.Events;

public class GameLogic {
  public const int EmptyChoice = 0;
  public const int HumanChoice = 1;
  public const int AiChoice = 2;

  public enum Result {
    NotOver,
    HumanWon,
    AiWon,
    Draw
  }

  private int[] choices;
  private SimpleAI simpleAi;

  public GameLogic() {
    this.choices = new int[9];
    this.simpleAi = new SimpleAI();
  }

  public bool IsChoiceValid(int choice) {
    return this.choices[choice] == EmptyChoice;
  }

  public void PlayHumanTurn(int choice) {
    this.choices[choice] = HumanChoice;
  }

  public int PlayAiTurn() {
    int aiChoice = this.simpleAi.PlayTurn(this.choices);

    this.choices[aiChoice] = AiChoice;

    return aiChoice;
  }

  public Result CheckGameOver() {
    if (this.HasWon(HumanChoice)) {
      return Result.HumanWon;
    }

    if (this.HasWon(AiChoice)) {
      return Result.AiWon;
    }

    if (!this.choices.Contains(EmptyChoice)) {
      return Result.Draw;
    }

    return Result.NotOver;
  }

  private bool HasWon(int player) {
#region Horizontal
    if (player.Equals(this.choices[0], this.choices[1], this.choices[2])) {
      return true;
    }

    if (player.Equals(this.choices[3], this.choices[4], this.choices[5])) {
      return true;
    }

    if (player.Equals(this.choices[6], this.choices[7], this.choices[8])) {
      return true;
    }
#endregion

#region Vertical
    if (player.Equals(this.choices[0], this.choices[3], this.choices[6])) {
      return true;
    }

    if (player.Equals(this.choices[1], this.choices[4], this.choices[7])) {
      return true;
    }

    if (player.Equals(this.choices[2], this.choices[5], this.choices[8])) {
      return true;
    }
#endregion

#region Diagonal
    if (player.Equals(this.choices[0], this.choices[4], this.choices[8])) {
      return true;
    }

    if (player.Equals(this.choices[2], this.choices[4], this.choices[6])) {
      return true;
    }
#endregion

    return false;
  }
}
