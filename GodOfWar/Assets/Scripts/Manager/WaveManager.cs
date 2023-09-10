    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;

    public class WaveManager : MonoBehaviour
    {
        public List<Wave> objects = new List<Wave>();
        private int currentObjectIndex = 0;
        private int totalWaves;

        public TMP_Text waveCountText;
        public TMP_Text realTimeText;

        private float gameStartTime;

        private void Start()
        {
            totalWaves = objects.Count;
            gameStartTime = Time.time;

            // Display the initial wave count
            int initialWaveCount = Mathf.FloorToInt((Time.time - gameStartTime) / objects[currentObjectIndex].activeTime) + 1;
            waveCountText.text = "Wave Count: " + initialWaveCount;

            // Start updating real-time text
            StartCoroutine(UpdateRealTime());

            // Start the object sequence automatically when the scene starts
            StartCoroutine(ObjectSequence());
        }

        private IEnumerator ObjectSequence()
        {
            while (currentObjectIndex < totalWaves)
            {
                TurnOffAllObjects();

                Wave obj = objects[currentObjectIndex];
                obj.gameObject.SetActive(true);
                obj.isOn = true;

                yield return new WaitForSeconds(obj.activeTime);

                obj.gameObject.SetActive(false);
                obj.isOn = false;

                currentObjectIndex++;

                // Calculate the current wave count based on the elapsed time and wave duration
                int currentWaveCount = Mathf.FloorToInt((Time.time - gameStartTime) / obj.activeTime) + 1;

                // Update the wave count text
                waveCountText.text = "Wave Count: " + currentWaveCount;

                yield return null;
            }

            // Sequence is over, reset index for next time
            currentObjectIndex = 0;
        }

        private IEnumerator UpdateRealTime()
        {
            while (true)
            {
                // Calculate the elapsed real-time since the game started
                float elapsedTime = Time.time - gameStartTime;

                // Update the real-time text
                realTimeText.text = "Real Time: " + elapsedTime.ToString("F2");

                yield return null;
            }
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
