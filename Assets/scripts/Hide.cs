using monster;
using UnityEngine;

public class Hide : MonoBehaviour
{
    private SpriteRenderer sprite;
    [SerializeField] private GameDirector _director;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            DoHide();
        }
    }

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void DoHide()
    {
        if (!_director.childHide)
        {
            sprite.enabled = false;
            _director.childHide = true;
            return;
        }
        sprite.enabled = true;
        _director.childHide = false;
    }
}
