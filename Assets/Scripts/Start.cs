using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour {
    public GameControl gameControl;

    public void OnStart()
    {
        gameControl.GameStart();
    }
}
