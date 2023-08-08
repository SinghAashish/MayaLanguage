using System.Collections;

namespace Components;

public class ProgramTreeNode : ITreeNode
{
    private ArrayList expressions;

    public ProgramTreeNode(ITreeNode firstExpression, ITreeNode followingExpression)
    {
        expressions = new ArrayList();
        AddExpression(firstExpression);
        AddExpression(followingExpression);
    }

    public ProgramTreeNode(ITreeNode expression)
    {
        expressions = new ArrayList();
        AddExpression(expression);
    }

    public void AddExpression(ITreeNode expression)
    {
        expressions.Add(expression);
    }

    public ISymbol Execute()
    {
        ISymbol lastSymbol = null;
        for (int index = 0; index < expressions.Count; index++)
        {
            object obj = expressions[index];
            ITreeNode expression = obj as ITreeNode;
            if (expression == null)
                continue;
            lastSymbol = expression.Execute();
        }
        return lastSymbol;
    }
}
