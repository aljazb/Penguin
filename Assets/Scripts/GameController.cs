using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public void Exit() {
		Application.Quit();
	}

	public void Replay() {
		SceneManager.LoadScene("Game");
	}
}
