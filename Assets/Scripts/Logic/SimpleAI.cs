using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimpleAI {
  public int PlayTurn(int[] choices) {
    List<int> emptyChoices = new List<int>();

    for (int i = 0; i < choices.Count(); i++) {
      if (choices[i] == GameLogic.EmptyChoice) {
        emptyChoices.Add(i);
      }
    }

    int randomIndex = Random.Range(0, emptyChoices.Count);

    return emptyChoices[randomIndex];
  }
}