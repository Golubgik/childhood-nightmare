using System.Collections;
using UnityEngine;

namespace monster
{
    public class MonsterMovement : BaseMonsterMovement
    {
        [SerializeField] private float _moveCooldown;
        [SerializeField] public bool _doNoise;

        private void Start()
        {
            StartCoroutine(MoveCoroutine());
        }

        private IEnumerator MoveCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_moveCooldown);
                DoStep(_doNoise);
            }
        }
    }
}
