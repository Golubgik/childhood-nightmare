using System.Collections;
using UnityEngine;

namespace monster
{
    public class StalkerMovement : BaseMonsterMovement
    {
        [SerializeField] private float _moveCooldown;

        public void Move(MonsterStep step)
        {
            DoStep(false, step);
        }

        public void StartMoving()
        {
            StartCoroutine(MoveCoroutine());
        }

        public void StopMoving()
        {
            StopAllCoroutines();
        }

        private IEnumerator MoveCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_moveCooldown);
                DoStep(false);
            }
        }
    }
}
