using System;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Pipe
{
    public class PipeGenerator : ObjectPool
    {
        [SerializeField] private GameObject _template;
        [SerializeField] private float _secondsBetweenSpawn;
        [SerializeField] private float _maxSpawnPositionY;
        [SerializeField] private float _minSpawnPositionY;

        private float _elapsedTime = 0;

        private void Start()
        {
            Initialize(_template);
            SpawnPipe();
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime > _secondsBetweenSpawn)
            {
                SpawnPipe();
            }
        }

        private void SpawnPipe()
        {
            if (TryGetObject(out GameObject pipe))
            {
                _elapsedTime = 0;

                float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                pipe.SetActive(true);
                pipe.transform.position = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

                DisableObjectAboardScreen();
            }
        }
    }
}