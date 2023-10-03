using IIMEngine.Movements2D;
using UnityEngine;

namespace LOK.Common.Characters.Kenney
{
    public class KenneyStateIdle : AKenneyState
    {
        Movable2D move;
        protected override void OnStateInit()
        {
            //Find Movable Interfaces inside StateMachine
            //You will need to write Speed and check if movements are locked and read MoveDir
             move = StateMachine.GetComponent<Movable2D>();
        }

        protected override void OnStateEnter(AKenneyState previousState)
        {
            //Force MoveSpeed to 0
            move.MoveSpeed = 0;
        }

        protected override void OnStateUpdate()
        {
            //Do nothing if movements are locked
            if (move.AreMovementsLocked) return;
            //If there is MoveDir
                //Change to StateAccelerate if MovementsData.StartAccelerationDuration > 0
                //Change to StateWalk otherwise
                if(move.MoveDir!=Vector2.zero)
            {
                if(MovementsData.StartAccelerationDuration>0) StateMachine.ChangeState(new KenneyStateAccelerate());
                else StateMachine.ChangeState(new KenneyStateWalk());

            }
        }
    }
}