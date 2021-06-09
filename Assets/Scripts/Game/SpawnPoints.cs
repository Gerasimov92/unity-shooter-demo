using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField] private Transform[] points;

    public Transform GetRandomPoint()
    {
        return points[Random.Range(0, points.Length)];
    }
}
