using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;

    private float surviveTime;
    private bool isGameover;
    void Start() {
        surviveTime = 0;
        isGameover = false;
    }

    void Update() {
        if (!isGameover) {
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int)surviveTime;
        } else {
            // 게임 오버인 상태에서 R 누른 경우
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void EndGame() {
        isGameover = true;
        gameoverText.SetActive(true);
        
        // 최고기록 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");
        if (surviveTime > bestTime) {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        // 최고기록을 recordText 컴포넌트로 표시
        recordText.text = "Best Time: " + (int) bestTime;
    }
}
