using System.Collections;
using UnityEngine;

public class Beat : MonoBehaviour
{
    public void OnHit()
    {
        StartCoroutine(HitAnimation());
    }

    private IEnumerator HitAnimation()
    {
        float scaleIncrement = 0.1f;
        while (transform.localScale.x < 3)
        {
            var oldScale = transform.localScale;
            transform.localScale = oldScale + new Vector3(scaleIncrement, scaleIncrement, scaleIncrement);
            yield return null;
        }
    }
}