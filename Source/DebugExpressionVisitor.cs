using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace Zentient.Debugging
{

    public class DebugExpressionVisitor : ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression node)
        {
            Debug.WriteLine($"VisitBinary: {node.NodeType}");
            return base.VisitBinary(node);
        }

        protected override Expression VisitBlock(BlockExpression node)
        {
            Debug.WriteLine($"VisitBlock: {node.NodeType}");
            return base.VisitBlock(node);
        }

        protected override Expression VisitConditional(ConditionalExpression node)
        {
            Debug.WriteLine($"VisitConditional: {node.NodeType}");
            return base.VisitConditional(node);
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            Debug.WriteLine($"VisitConstant: {node.NodeType}");
            return base.VisitConstant(node);
        }

        protected override Expression VisitDebugInfo(DebugInfoExpression node)
        {
            Debug.WriteLine($"VisitDebugInfo: {node.NodeType}");
            return base.VisitDebugInfo(node);
        }

        protected override Expression VisitDefault(DefaultExpression node)
        {
            Debug.WriteLine($"VisitDefault: {node.NodeType}");
            return base.VisitDefault(node);
        }

        protected override Expression VisitDynamic(DynamicExpression node)
        {
            Debug.WriteLine($"VisitDynamic: {node.NodeType}");
            return base.VisitDynamic(node);
        }

        protected override Expression VisitExtension(Expression node)
        {
            Debug.WriteLine($"VisitExtension: {node.NodeType}");
            return base.VisitExtension(node);
        }

        protected override Expression VisitGoto(GotoExpression node)
        {
            Debug.WriteLine($"VisitGoto: {node.NodeType}");
            return base.VisitGoto(node);
        }

        protected override Expression VisitIndex(IndexExpression node)
        {
            Debug.WriteLine($"VisitIndex: {node.NodeType}");
            return base.VisitIndex(node);
        }

        protected override Expression VisitInvocation(InvocationExpression node)
        {
            Debug.WriteLine($"VisitInvocation: {node.NodeType}");
            return base.VisitInvocation(node);
        }

        protected override Expression VisitLabel(LabelExpression node)
        {
            Debug.WriteLine($"VisitLabel: {node.NodeType}");
            return base.VisitLabel(node);
        }

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            Debug.WriteLine($"T>: {node.NodeType}");
            return base.VisitLambda<T>(node);
        }

        protected override Expression VisitListInit(ListInitExpression node)
        {
            Debug.WriteLine($"VisitListInit: {node.NodeType}");
            return base.VisitListInit(node);
        }

        protected override Expression VisitLoop(LoopExpression node)
        {
            Debug.WriteLine($"VisitLoop: {node.NodeType}");
            return base.VisitLoop(node);
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            Debug.WriteLine($"VisitMember: {node.NodeType}");
            return base.VisitMember(node);
        }

        protected override Expression VisitMemberInit(MemberInitExpression node)
        {
            Debug.WriteLine($"VisitMemberInit: {node.NodeType}");
            return base.VisitMemberInit(node);
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            Debug.WriteLine($"VisitMethodCall: {node.NodeType}");
            return base.VisitMethodCall(node);
        }

        protected override Expression VisitNew(NewExpression node)
        {
            Debug.WriteLine($"VisitNew: {node.NodeType}");
            return base.VisitNew(node);
        }

        protected override Expression VisitNewArray(NewArrayExpression node)
        {
            Debug.WriteLine($"VisitNewArray: {node.NodeType}");
            return base.VisitNewArray(node);
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            Debug.WriteLine($"VisitParameter: {node.NodeType}");
            return base.VisitParameter(node);
        }


        protected override Expression VisitRuntimeVariables(RuntimeVariablesExpression node)
        {
            Debug.WriteLine($"VisitRuntimeVariables: {node.NodeType}");
            return base.VisitRuntimeVariables(node);
        }

        protected override Expression VisitSwitch(SwitchExpression node)
        {
            Debug.WriteLine($"VisitSwitch: {node.NodeType}");
            return base.VisitSwitch(node);
        }

        protected override Expression VisitTry(TryExpression node)
        {
            Debug.WriteLine($"VisitTry: {node.NodeType}");
            return base.VisitTry(node);
        }

        protected override Expression VisitTypeBinary(TypeBinaryExpression node)
        {
            Debug.WriteLine($"VisitTypeBinary: {node.NodeType}");
            return base.VisitTypeBinary(node);
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            Debug.WriteLine($"VisitUnary: {node.NodeType}");
            return base.VisitUnary(node);
        }
    }
}