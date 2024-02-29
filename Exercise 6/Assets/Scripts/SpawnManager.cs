using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimalTypes
{
    Elephant,
    Turtle,
    Snail,
    Octopus,
    Kanagroo
}

public class SpawnManager : Singleton<SpawnManager>
{
    // (Optional) Prevent non-singleton constructor use.
    protected SpawnManager() { }

    [SerializeField]
    SpriteRenderer animalPrefab;

    [SerializeField]
    List<Sprite> animalSprites;

    [SerializeField]
    public int minSpawnCount, maxSpawnCount;

    public int SpawnCount
    {
        get
        {
            return spawnedAnimals.Count;
        }
    }

    int spawnedTotal = 0;

    public int SpawnedTotal
    {
        get { return spawnedTotal; }
    }

    List<SpriteRenderer> spawnedAnimals = new List<SpriteRenderer>();

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Spawn()
    {
        CleanUp();

        int spawnCount = Random.Range(minSpawnCount, maxSpawnCount);

        for (int i = 0; i < spawnCount; i++)
        {
            SpawnAnimal();
        }
    }

    public void SpawnAnimal()
    {
        SpriteRenderer newAnimal = Instantiate(animalPrefab);

        //  Change sprite
        newAnimal.sprite = animalSprites[(int)PickRandomAnimal()];

        //  Change color
        newAnimal.color = Random.ColorHSV(0, 1, 1, 1, 1, 1);

        //  Set position
        float screenH = Camera.main.orthographicSize * 2f;
        float screenW = screenH * Camera.main.aspect;

        float x = Gaussian(0, screenW / 8f);
        float y = Gaussian(0, screenH / 8f);

        newAnimal.transform.position = new Vector3(x, y, 0);

        spawnedAnimals.Add(newAnimal);

        ++spawnedTotal;
    }

    void CleanUp()
    {
        foreach (SpriteRenderer animal in spawnedAnimals)
        {
            Destroy(animal.gameObject);
        }

        spawnedAnimals.Clear();
    }


    float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);

        float gaussValue =
                 Mathf.Sqrt(-2.0f * Mathf.Log(val1)) *
                 Mathf.Sin(2.0f * Mathf.PI * val2);

        return mean + stdDev * gaussValue;
    }

    AnimalTypes PickRandomAnimal()
    {
        float randValue = Random.Range(0f, 1f);

        if (randValue < .6f)
        {
            return AnimalTypes.Elephant;
        }
        else if (randValue < .84f)
        {
            return AnimalTypes.Snail;
        }
        else
        {
            return AnimalTypes.Octopus;
        }
    }

}
