using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "New EffectGrenade", menuName = "ItemMenu/Items/Grenades/EffectGrenade")]
public class EffectGrenade : Grenade
{
    //[SerializeField] private Image effectImage;
    private const int amount = 3;
    public override void Initialize()
    {
        //var canvas = GameObject.Find("Canvas");
        //ObjectPoolManager.CreateObjectPool(effectImage, amount, (img) =>
        //{
        //    img.transform.SetParent(canvas.transform, false);
        //});
    }

    public override void Use()
    {
        EventBus.Publish(new EffectEnemiesEvent(damage));
        PlayerController.Instance.StartCoroutine(ActivateEffectImage()); 
    }

    private IEnumerator ActivateEffectImage()
    {
        //var img = ObjectPoolManager.GetObjectFromPool(effectImage);
        //if (img == null) yield break;

        //img.gameObject.SetActive(true);

        //// Optional: fade in/out
        //var canvasGroup = img.GetComponent<CanvasGroup>();
        //if (canvasGroup != null)
        //{
        //    canvasGroup.alpha = 1f;
        //}

        yield return null;

        //img.gameObject.SetActive(false);
    }
}
