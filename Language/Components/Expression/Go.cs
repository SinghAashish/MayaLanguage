namespace Components;

public class Go : IAction
{
    private int stateId;

    public Go(int stateId)
    {
        this.stateId = stateId;
    }

    public void Do(IInput input, Stack stack, IGrammerRuleHandler ruleHandler)
    {
        stack.Push(stateId);
    }
}
