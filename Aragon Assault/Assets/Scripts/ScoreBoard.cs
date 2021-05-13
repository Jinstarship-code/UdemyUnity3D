using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    protected int score = 0;

    public void IncreaseScore(int amountToIncrease)
    {
        Debug.Log($"Score is now: {score}");
        score += amountToIncrease;
    }
}
