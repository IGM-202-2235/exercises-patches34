using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimalTypes
{
    Elephant,
    Turtle,
    Snail,
    Octopus,
    Kangaroo
}

public class SpawnManager : Singleton<SpawnManager>
{
    // (Optional) Prevent non-singleton constructor use.
    protected SpawnManager() { }

    public SpriteRenderer animalPrefab;

    public List<Sprite> animalSprites;

    public int animalCount = 20;

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
        
        for(int i = 0; i < animalCount; i++)
        {
            SpawnAnimal(PickRandomAnimal());
        }
    }

    public void SpawnAnimal(AnimalTypes type)
    {
        SpriteRenderer newAnimal = Instantiate(animalPrefab);

        newAnimal.sprite = animalSprites[(int)type];

        //  Color it
        newAnimal.color = Random.ColorHSV(0, 1, 1, 1, 1, 1);

        //  Set its location
        float heightStd = (Camera.main.orthographicSize * 2f) / 8f;
        float widthStd = heightStd * Camera.main.aspect;

        float x = Gaussian(0, widthStd);
        float y = Gaussian(0, heightStd);
        
        newAnimal.transform.position = new Vector3(x, y);

        spawnedAnimals.Add(newAnimal);
    }

    public void CleanUp()
    {
        foreach(SpriteRenderer animal in spawnedAnimals)
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

        if(randValue < .6f)
        {
            return AnimalTypes.Elephant;
        }
        else if(randValue < .84f)
        {
            return AnimalTypes.Snail;
        }
        else
        {
            return AnimalTypes.Octopus;
        }
    }

}
