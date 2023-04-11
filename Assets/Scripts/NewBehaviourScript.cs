using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Sirenix.OdinInspector;
using System.Linq;
using DG.Tweening;


public class NewBehaviourScript : MonoBehaviour
{
    [BoxGroup("GameObjects"), SerializeField, ReadOnly]
    public List<GameObject> Cubes;

    [Button]
    private void SetRefs()
    {
        Cubes = GameObject.FindGameObjectsWithTag("Cubes").ToList();
    }

    [Button]
    private void Clear()
    {
        Cubes.Clear();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelaySpawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DelaySpawn()
    {

        for (int i = 0; i < Cubes.Count; i++)
        {
            yield return new WaitForSeconds(5f);
            Cubes[i].SetActive(true);
            yield return new WaitForSeconds(5f);

        }
    }


    async void ShowGameObjects()
    {
        for (int i = 0; i < Cubes.Count; i++)
        {
            Cubes[i].SetActive(true);
            await Task.Delay(5000);
        }
    }
}
