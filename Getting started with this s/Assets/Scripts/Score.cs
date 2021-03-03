using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public GameObject player;
    public Text scoreText;
    public Text kurText;
     
    // Update is called once per frame
    void Update()
    {
        scoreText.text = player.transform.position.z.ToString("0");
        //Transform child = transform.Find("Level");
        //Text t = child.GetComponent<Text>();
        //t.text = "KUR";
    }
}
