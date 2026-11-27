using UnityEngine;

namespace monster
{
    public abstract class BaseMonsterMovement : MonoBehaviour
    {
        protected MonsterStep _curStep;
        [SerializeField] public MonsterStep _startStep;
        [SerializeField] protected GameObject _wavePrefab;
        [SerializeField] private GameDirector _director;

        protected void Awake()
        {
            _curStep = _startStep;
            transform.position = _curStep.transform.position;
        }

        public void DoStep(bool noise, MonsterStep step = null)
        {
            var lastStep = _curStep;
            var curStep = step ?? _curStep?.GetNext();

            if (curStep == null)
                return;

            if (curStep.hasMonster)
                curStep = curStep?.GetNext();

            if (curStep == null)
                return;

            _curStep = curStep;
            transform.position = _curStep.transform.position;
            lastStep.hasMonster = false;
            _curStep.hasMonster = true;

            if (_wavePrefab == null || !noise)
                return;

            GameObject item = Instantiate(_wavePrefab, _curStep.transform);
            _director.stalker?.Move(lastStep);
        }
    }
}
