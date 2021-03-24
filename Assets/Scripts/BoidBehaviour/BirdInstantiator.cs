using UnityEngine;


namespace Assets.Scripts.BoidBehaviour
{ 
    public class BirdInstantiator : MonoBehaviour
    {
        public GameObject birdPrefab;

        [Range(0, 40)]
        public int number;

        private void Start()
        {
            for (int i = 0; i < number; i++)
            {
                Instantiate(birdPrefab, Vector3.zero, Quaternion.identity);
            }
        }
    }
}