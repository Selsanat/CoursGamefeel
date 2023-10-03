using IIMEngine.Movements2D;
using UnityEngine;

namespace LOK.Common.Characters.Kenney
{
    public class KenneySimpleMovement : MonoBehaviour
    {
        #region DO NOT MODIFY
        #pragma warning disable 0414
        
        [Header("Movements")]
        [SerializeField] private KenneyMovementsData _movementsData;
        
        #pragma warning restore 0414
        #endregion

        private void Awake()
        {
            //Find Movable Interfaces (at the root of this gameObject)
            //You will need to :
            // - Check if movements are locked
            // - Read Move Dir
            // - Write Move Orient
            // - Write Move Speed
            Movable2D _Movable = gameObject.GetComponent<Movable2D>();
            _Movable.MoveSpeed = _movementsData.Speed;
        }

        private void Update()
        {
            //If Movements are locked
            //Force MoveSpeed to 0
            //If there is MoveDir
            //Set MoveSpeed to MovementsData.SpeedMax
            //Set Move OrientDir to Movedir
            //Else
            //Set MoveSpeed to 0
            Movable2D _Movable = gameObject.GetComponent<Movable2D>();
            if (_Movable.AreMovementsLocked)
            {
                _Movable.MoveSpeed = 0;
            }
            _Movable.OrientDir = _Movable.MoveDir;
            if(_Movable.MoveDir != Vector2.zero)
            {
                _Movable.MoveSpeed = _movementsData.SpeedMax;
            }
            else
            {
                _Movable.MoveSpeed = 0;
            }
        }
    }
}