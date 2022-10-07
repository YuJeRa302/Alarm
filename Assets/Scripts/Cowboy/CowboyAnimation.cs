using UnityEngine;

public class CowboyAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    enum TransitionParametr
    {
        IsRotate
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<CowboyController>(out CowboyController cowboy))
        {
            var transitionParametr = Animator.StringToHash(TransitionParametr.IsRotate.ToString());
            _animator.SetBool(transitionParametr, !_animator.GetBool(transitionParametr));
        }
    }
}
