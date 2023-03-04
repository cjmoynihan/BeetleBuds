using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashController : MonoBehaviour
{
    private Animator slashAnimator;

    private void Start()
    {
        slashAnimator = GetComponent<Animator>();
        StartCoroutine(DestroySlash());
    }

    IEnumerator DestroySlash()
    {
        AnimatorStateInfo slashState = slashAnimator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(slashState.length);
        Destroy(gameObject);
    }
}
