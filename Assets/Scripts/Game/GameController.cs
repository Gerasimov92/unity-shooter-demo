using Photon.Pun;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private SpawnPoints spawnPoints;
    [SerializeField] private GameObject prefab;

    void Start()
    {
        var pos = spawnPoints.GetRandomPoint().position;
        PhotonNetwork.Instantiate(prefab.name, pos, Quaternion.identity);
    }
}
