using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text scoreText;

    public void SetScoreText(string text)
    {
        scoreText.text = text;
    }
}
