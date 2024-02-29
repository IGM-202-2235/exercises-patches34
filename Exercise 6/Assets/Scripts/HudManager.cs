using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    [SerializeField]
    Text scoreLabel;

    const string k_SCORE_STR = "Score: {0}";

    [SerializeField]
    Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        healthSlider.minValue = SpawnManager.Instance.minSpawnCount;
        healthSlider.maxValue = SpawnManager.Instance.maxSpawnCount;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = SpawnManager.Instance.SpawnCount;

        scoreLabel.text = string.Format(k_SCORE_STR, SpawnManager.Instance.SpawnedTotal);
    }
}
