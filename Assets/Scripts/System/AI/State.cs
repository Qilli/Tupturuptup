using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/State")]
public class State : ScriptableObject
{
    [System.Serializable]
    public enum StateType
    {
        WALKING,
        DIGGING,
        BUILDING,
        DESTROING,
        USING_CONSTRUCT,
        DECONSTRUCTING,
        FALLING,
        OUT_OF_CONTROL,
        IDLING,
        WALKING_TO_CENTER,
        RAGDOLL,
        RAGDOLL_STANDUP
    }
       


    public BaseAction[] actions;
    public BaseAction[] onEnterStateActions;
    public BaseAction[] onExitStateActions;
    public Transition[] transitions;
    public Transition onForceExitTransition;
    public Color sceneGizmoColor = Color.grey;
    public bool canCharacterBeSelectedInThisState = false;
    public bool isColliderActiveInThisState = true;
    public CommandType cmdType;
    public StateType stateType;

    public void updateState(StateController controller)
    {
        doActions(controller);
        checkTransitions(controller);
    }


    private void doActions(StateController controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].act(controller);
        }
    }

    public virtual void onEnterState(StateController controller)
    {
        for (int i = 0; i < onEnterStateActions.Length; i++)
        {
            onEnterStateActions[i].act(controller);
        }
    }

    public virtual void onExitState(StateController controller)
    {
        for (int i = 0; i < onExitStateActions.Length; i++)
        {
            onExitStateActions[i].act(controller);
        }
    }

    private void checkTransitions(StateController controller)
    {
        if (controller.isForcedToExitActive())
        {
            bool decisionSucceeded = onForceExitTransition.decision.decide(controller);

            if (decisionSucceeded)
            {
                controller.changeControllerState(onForceExitTransition.trueState);
            }
            else
            {
                controller.changeControllerState(onForceExitTransition.falseState);
            }
        }
        else
        {
            for (int i = 0; i < transitions.Length; i++)
            {
                bool decisionSucceeded = transitions[i].decision.decide(controller);

                if (decisionSucceeded)
                {
                    controller.changeControllerState(transitions[i].trueState);
                }
                else
                {
                    controller.changeControllerState(transitions[i].falseState);
                }
            }
        }
    }

}
