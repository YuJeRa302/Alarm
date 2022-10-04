using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] Animator _animator;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<CowboyController>(out CowboyController cowboy))
        {
            if (_animator.GetBool("IsRotate") == true)
            {
                _animator.SetBool("IsRotate", false);
            }
            else
            {
                _animator.SetBool("IsRotate", true);
            }
        }
    }
}
