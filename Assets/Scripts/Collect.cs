using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collect : MonoBehaviour
{
    public List<GameObject> Collectables;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collectables"))
        {
            Collectables.Add(other.gameObject);
            for (int i = 0; i < Collectables.Count; i++)
            {
                Collectables[i].transform.DOScale(Vector3.zero, 0.5f);
                Collectables[i].transform.DOJump(transform.position,1,1, .15f).SetEase(Ease.Linear);
                Invoke("DestroyObj", 10f);
            }
        }

    }
    //Use Corountines or SystemThread or Invoke to remove items from the List

    private void DestroyObj()
    {
       foreach(GameObject food in Collectables)
        {
            Destroy(food);
        }
        Collectables.Clear();
    }
}
