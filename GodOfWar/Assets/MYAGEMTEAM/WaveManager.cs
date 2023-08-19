using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public List<Wave> objects = new List<Wave>();
    private int currentObjectIndex = 0;

    private Coroutine sequenceCoroutine;

    private IEnumerator ObjectSequence()
    {
        while (currentObjectIndex < objects.Count)
        {
            TurnOffAllObjects();

            Wave obj = objects[currentObjectIndex];
            obj.gameObject.SetActive(true);
            obj.isOn = true;

            yield return new WaitForSeconds(obj.activeTime);

            obj.gameObject.SetActive(false);
            obj.isOn = false;

            currentObjectIndex++;

            yield return null;
        }

        // Sequence is over, reset index for next time
        currentObjectIndex = 0;
    }

    private void Start()
    {
        // Start the object sequence automatically when the scene starts
        sequenceCoroutine = StartCoroutine(ObjectSequence());
    }

    private void TurnOffAllObjects()
    {
        foreach (Wave obj in objects)
        {
            obj.gameObject.SetActive(false);
            obj.isOn = false;
        }
    }

}
