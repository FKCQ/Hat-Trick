using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Restart : MonoBehaviour {
    public void GameRestart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
