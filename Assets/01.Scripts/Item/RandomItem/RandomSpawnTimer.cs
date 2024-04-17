using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnTimer : MonoBehaviour
{
    private float _spawnCooltime;

    private void Update()
    {
        _spawnCooltime += Time.deltaTime;

        if (_spawnCooltime >= 60)
        {
            _spawnCooltime = 0;
            
            
        }
    }
}
