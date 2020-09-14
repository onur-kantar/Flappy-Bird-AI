using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeHandler : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Pipes pipePrefab = null;

    [Header("Settings")]
    [SerializeField] private float secondsBetweenSpawns = 2f;

    private float spawnTimer;
    private readonly List<Pipes> pipes = new List<Pipes>();
    float centerHeight;
    int i;

    void Update()
    {
        SpawnNewPipes();
        RemoveOldPipes();
    }
    private void RemoveOldPipes()
    {
        for(i = 0; i < pipes.Count; i++)
        {
            if(pipes[i].transform.position.x < -15f)
            {
                Destroy(pipes[i].gameObject);
                pipes.RemoveAt(i);
            }
        }
    }
    public void ResetPipes()
    {
        foreach (var pipe in pipes)
        {
            Destroy(pipe.gameObject);
        }
        pipes.Clear();
        spawnTimer = 0f;
    }
    void SpawnNewPipes()
    {
        spawnTimer -= Time.deltaTime;

        if(spawnTimer > 0f) { return; }

        centerHeight = Random.Range(0.3f, 3.0f);
        Pipes newPipe = Instantiate(pipePrefab, transform.position, Quaternion.identity);
        newPipe.transform.Translate(Vector3.up * centerHeight);

        pipes.Add(newPipe);
        spawnTimer = secondsBetweenSpawns;
    }
}
