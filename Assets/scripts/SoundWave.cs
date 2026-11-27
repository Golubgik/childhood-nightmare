using UnityEngine;

public class SoundWave : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPrefab;
    [SerializeField] private int _count = 12;
    [SerializeField] private float _radius = 1f;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _lifetime = 1f;
    [SerializeField] private bool _evilSound;

    private void Start()
    {
        SpawnBurst();
    }

    public void SpawnBurst()
    {
        if (_spawnPrefab == null)
            return;

        for (int i = 0; i < _count; i++)
        {
            float angle = (i / (float)_count) * Mathf.PI * 2f;
            Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f);

            Vector3 spawnPos = transform.position + direction * _radius;

            GameObject obj = Instantiate(_spawnPrefab, spawnPos, Quaternion.identity);
            WavePiece mover = obj.GetComponent<WavePiece>();

            if (mover == null)
                mover = obj.AddComponent<WavePiece>();

            mover.Initialize(direction, _speed, _lifetime, _evilSound);

            Destroy(this);
        }
    }

    private class WavePiece : MonoBehaviour
    {
        private Vector3 direction;
        private float speed;
        private float lifeTime;
        private bool evilSound;

        public void Initialize(Vector3 direction, float speed, float lifeTime, bool evilSound)
        {
            this.direction = direction.normalized;
            this.speed = speed;
            this.lifeTime = Time.time + lifeTime;
            this.evilSound = evilSound;
        }

        private void Update()
        {
            transform.position += direction * speed * Time.deltaTime;

            if (lifeTime <= Time.time)
                Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "sound")
                return;

            if (evilSound && collision.gameObject.tag == "SoundEvil")
                return;

            speed = 0;
            lifeTime = Time.time + 1;
            return;
        }
    }
}
