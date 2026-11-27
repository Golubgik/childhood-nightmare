using UnityEngine;

public class MonsterStep : MonoBehaviour
{
    [SerializeField] MonsterStep[] _nextsteps;
    public bool hasMonster = false;

    public MonsterStep GetNext()
    {
        if (_nextsteps == null || _nextsteps.Length == 0)
            return null;

        return _nextsteps[UnityEngine.Random.Range(0, _nextsteps.Length)];
    }
}