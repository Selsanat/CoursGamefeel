using System.Collections;
using IIMEngine.Movements2D;
using UnityEngine;

namespace LOK.Common.Characters.Kenney
{
    public class KenneyVisualOrient : MonoBehaviour
    {
        #region DO NOT MODIFY
        #pragma warning disable 0414

        [Header("Entity Root")]
        [SerializeField] private GameObject _entityRoot;

        [Header("Orient")]
        [SerializeField] private Transform _orientRoot;

        [Header("Flip Effect")]
        [SerializeField] private float _flipDuration = 0.5f;

        private IMove2DOrientReader _orientReader;

        private float _startScaleX = 0f;

        private bool _isFlipping = false;
        
        #pragma warning restore 0414
        #endregion

        private void Awake()
        {
            _orientReader = _entityRoot.GetComponent<IMove2DOrientReader>();
            //Store _startScaleX using _orientRoot
            _startScaleX = _orientReader.OrientX;
        }

        private void OnEnable()
        {
            //Set orientRoot localScale using orientReader orientX
            _orientRoot.localScale.Set(_orientReader.OrientX, _orientRoot.localScale.y,0);
        }

        private void OnDisable()
        {
            //Reset FLipping State
            _isFlipping = false;
        }

        private void Update()
        {
            //Detect if kenney need to flip ScaleX (using orientReader and current scale.x)
            //Bonus : you can create a flip animation using _flipDuration
            if (_orientReader.OrientX !=  _startScaleX)
            {
                _isFlipping = true;
            }
        }
    }
}