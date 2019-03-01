using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
    public GameObject[] ball;
    public GameObject gameOverText;
    public GameObject restartButton;
    public GameObject hatTrickImage;
    public GameObject startButton;
    public float preparingTime = 3f;
    public float intervalTime = 1f;
    public float timeLeft = 10f;
    public Text timeLeftText;

    private Camera cam;
    private float maxWidth;
    private bool gameOver = false;
    private bool counting = false;
	// Use this for initialization
	void Start () {
        if (cam == null)
            cam = Camera.main;

        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 cornerPosition = cam.ScreenToWorldPoint(upperCorner);

        maxWidth = cornerPosition.x;


    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(preparingTime);
        counting = true;
        while (timeLeft != 0)
        {
                Vector3 spawnPosition = new Vector3(
                Random.Range(-maxWidth, maxWidth),
                transform.position.y,
                0.0f
                );
                Quaternion spawnRotation = Quaternion.identity;

                int randomIndex = Random.Range(0, ball.Length);
                
                //球体出线的部分
                float ballWidth = ball[randomIndex].GetComponent<Renderer>().bounds.extents.x;
                //去除球体多余的部分
                maxWidth -= ballWidth;

                Instantiate(ball[randomIndex], spawnPosition, spawnRotation);

                yield return new WaitForSeconds(intervalTime);
        }
        GameOver();
    }

    private void Update()
    {
        if (counting)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft < 0)
            {
                timeLeft = 0;
            }
            timeLeftText.text = "TimeLeft:\n" + Mathf.RoundToInt(timeLeft);
        }
    }

    public void GameStart()
    {
        hatTrickImage.active = false;
        startButton.active = false;
        StartCoroutine(Spawn());
    }

    public void GameOver()
    {
        gameOverText.active = true;
        restartButton.active = true;
    }
}
