using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashController : MonoBehaviour {
  private void Start() {
    this.Schedule(2f, this.TransitionToGameScene);
  }

  private void TransitionToGameScene() {
    SceneManager.LoadSceneAsync("Game");
  }
}