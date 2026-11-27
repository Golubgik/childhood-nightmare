using monster;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameDirector _director;
    [SerializeField] private GameObject _wavePrefab;
    [SerializeField] private float _spawnInterval = 5f;

    private float _soundTimer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartMusic();
            _director.stalker?.StartMoving();
        }

        if (Input.GetMouseButton(0))
        {
            _soundTimer += Time.deltaTime;

            if (_soundTimer >= _spawnInterval)
            {
                _soundTimer = 0f;
                SpawnWave();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            PauseMusic();
            _director.stalker?.StopMoving();
        }
    }

    private void StartMusic()
    {
        if (!audioSource.isPlaying)
            audioSource.Play();
    }

    private void PauseMusic()
    {
        if (audioSource.isPlaying)
            audioSource.Pause();
    }

    private void SpawnWave()
    {
        if (_wavePrefab == null)
            return;

        GameObject item = Instantiate(_wavePrefab, transform);
    }
}