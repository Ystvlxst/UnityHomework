using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _maxSpeed;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float jumpForse = 0.15f;
        float scaleX = 1f;
        float scaleY = 1f;

        if (Input.GetKey(KeyCode.A))
        {
            _animator.SetBool(AnimatorPlayerController.Params.IsRunning, true);
            transform.Translate(_maxSpeed * Time.deltaTime * -1, 0, 0);

            transform.localScale = new Vector2(scaleX, scaleY);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _animator.SetBool(AnimatorPlayerController.Params.IsRunning, true);
            transform.Translate(_maxSpeed * Time.deltaTime, 0, 0);

            transform.localScale = new Vector2(-scalePlayerX, scalePlayerY);
        }
        else
        {
            _animator.SetBool(AnimatorPlayerController.Params.IsRunning, false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            _animator.SetTrigger(AnimatorPlayerController.Params.Jump);
            transform.Translate(0, jumpForse, 0);
        }
    }
}

public static class AnimatorPlayerController
{
    public static class Params
    {
        public const string IsRunning = nameof(IsRunning);
        public const string Jump = nameof(Jump);
    }
}
