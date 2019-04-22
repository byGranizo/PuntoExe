using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBlock : MonoBehaviour {
    Animator anim;
    private void Awake() {
        anim = GetComponent<Animator>();
    }

    void Start() {
        StartCoroutine(launchAnimation());
    }

    IEnumerator launchAnimation() {
        anim.SetInteger("Animation", Random.Range(1, 4));
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
