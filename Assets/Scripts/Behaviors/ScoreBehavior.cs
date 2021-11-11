using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public IntegerData score;
    public Text scoreText;
    public IntegerData highScore;

    private void Awake()
    {
        score.OnValueChanged += UpdateScoreText;
        
        UpdateScoreText();
    }

    private void OnDestroy()
    {
        score.OnValueChanged -= UpdateScoreText;
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.value.ToString();
    }

    public void StartScoreCounting()
    {
        StartCoroutine(CountingScore(new WaitForSeconds(0.1f)));
    }

    private IEnumerator CountingScore(WaitForSeconds delay)
    {
            yield return delay;
            score.AddToValue(1);

            StartCoroutine(CountingScore(delay));

    }

    public void StopCounting()
    {
        StopAllCoroutines();
    }

    public void SaveToHighScore()
    {
        if(score.value > highScore.value){
            highScore.SetValue(score.value);
            highScore.SaveValue();
        }
    }

    public void ResetScore()
    {
        score.ResetValue();
    }
}
