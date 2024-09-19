using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

using Microsoft.Extensions.Logging;

namespace Zentient.Debugging
{
    public class DebugExpressionVisitor(ILogger logger) : ExpressionVisitor
    {
        public enum LogLevel
        {
            None,
            Basic,
            Detailed
        }

        public LogLevel LogLevel { get; set; } = LogLevel.Basic;
        public bool LogMethodCalls { get; set; } = true;
        public bool LogBinaryExpressions { get; set; } = true;
        public bool LogConstants { get; set; } = true;
        public bool LogLambdas { get; set; } = true;
        public bool LogParameters { get; set; } = true;
        public bool LogUnaryExpressions { get; set; } = true;
        public bool LogMembers { get; set; } = true;
        public bool LogExpressionStructure { get; set; } = true;
        public bool LogExpressionValues { get; set; } = true;
        public bool LogExpressionTypes { get; set; } = true;
        private readonly ILogger _logger = logger ?? throw new ArgumentNullException(nameof(logger), "Logger must be provided to DebugExpressionVisitor.");
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private bool ShouldLog(LogLevel level) => LogLevel >= level;

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (LogMethodCalls)
            {
                LogVisit("VisitMethodCall", node.Method.Name);
            }

            if (LogLevel == LogLevel.Detailed)
            {
                _stopwatch.Restart();
            }

            var result = base.VisitMethodCall(node);

            if (LogLevel == LogLevel.Detailed)
            {
                LogPerformance("VisitMethodCall", node.Method.Name);
            }

            return result;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (LogBinaryExpressions)
            {
                LogVisit("VisitBinary", "{0} {1} {2}", node.Left, node.NodeType, node.Right);
            }

            if (LogLevel == LogLevel.Detailed)
            {
                _stopwatch.Restart();
            }

            var result = base.VisitBinary(node);

            if (LogLevel == LogLevel.Detailed)
            {
                LogPerformance("VisitBinary", node.NodeType);
            }

            return result;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (LogConstants || LogExpressionValues || LogExpressionTypes)
            {
                LogVisit("VisitConstant", "{0}", node.Value;
            }
            return base.VisitConstant(node);
        }

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            if (LogLambdas)
            {
                LogVisit("VisitLambda", "{0}", node.Name);
            }
            return base.VisitLambda(node);
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (LogParameters)
            {
                LogVisit("VisitParameter", "{0}", node.Name);
            }
            return base.VisitParameter(node);
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            if (LogUnaryExpressions)
            {
                LogVisit("VisitUnary", "{0} {1}", node.NodeType, node.Operand);
            }

            if (LogLevel == LogLevel.Detailed)
            {
                _stopwatch.Restart();
            }

            var result = base.VisitUnary(node);

            if (LogLevel == LogLevel.Detailed)
            {
                LogPerformance("VisitUnary", node.NodeType);
            }

            return result;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (LogMembers || LogExpressionValues || LogExpressionTypes)
            {
                LogVisit("VisitMember", node.Member.Name);
            }
            return base.VisitMember(node);
        }

        protected override Expression VisitBlock(BlockExpression node)
        {
            if (LogExpressionStructure)
            {
                LogVisit("VisitBlock", "{0}", node.Variables.Count);
            }
            return base.VisitBlock(node);
        }

        protected override Expression VisitConditional(ConditionalExpression node)
        {
            if (LogExpressionStructure)
            {
                LogVisit("VisitConditional", "{0}", node.NodeType);
            }
            return base.VisitConditional(node);
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (LogConstants || LogExpressionValues || LogExpressionTypes)
            {
                LogVisit("VisitConstant", "{0}", node.Value ?);
            }
            return base.VisitConstant(node);
        }

        protected override Expression VisitDebugInfo(DebugInfoExpression node)
        {
            if (LogExpressionStructure)
            {
                LogVisit("VisitDebugInfo", node.Document.FileName);
            }
            return base.VisitDebugInfo(node);
        }

        protected override Expression VisitDefault(DefaultExpression node)
        {
            if (LogExpressionStructure)
            {
                LogVisit("VisitDefault", "{0}", node.NodeType);
            }
            return base.VisitDefault(node);
        }

        protected override Expression VisitDynamic(DynamicExpression node)
        {
            if (LogExpressionStructure)
            {
                LogVisit("VisitDynamic", "{0}", node.NodeType);
            }
            return base.VisitDynamic(node);
        }

        protected override Expression VisitExtension(Expression node)
        {
            if (LogExpressionStructure)
            {
                LogVisit("VisitExtension", "{0}", node.NodeType);
            }
            return base.VisitExtension(node);
        }

        protected override Expression VisitGoto(GotoExpression node)
        {
            if (LogExpressionStructure)
            {
                LogVisit("VisitGoto", "{0}", node.NodeType);
            }
            return base.VisitGoto(node);
        }

        protected override Expression VisitIndex(IndexExpression node)
        {
            if (LogExpressionStructure || LogExpressionValues || LogExpressionTypes)
            {
                LogVisit("VisitIndex", "{0}", node.NodeType);
            }
            return base.VisitIndex(node);
        }

        protected override Expression VisitInvocation(InvocationExpression node)
        {
            if (LogExpressionStructure || LogExpressionValues || LogExpressionTypes)
            {
                LogVisit("VisitInvocation", "{0}", node.NodeType);
            }
            return base.VisitInvocation(node);
        }

        protected override Expression VisitLabel(LabelExpression node)
        {
            if (LogExpressionStructure)
            {
                LogVisit("VisitLabel", "{0}", node.NodeType);
            }
            return base.VisitLabel(node);
        }

        protected override Expression VisitListInit(ListInitExpression node)
        {
            if (LogExpressionStructure)
            {
                LogVisit("VisitListInit", "{0}", node.NodeType);
            }
            return base.VisitListInit(node);
        }

        protected override Expression VisitLoop(LoopExpression node)
        {
            if (LogExpressionStructure)
            {
                LogVisit("VisitLoop", "{0}", node.NodeType);
            }
            return base.VisitLoop(node);
        }

        protected override Expression VisitMemberInit(MemberInitExpression node)
        {
            if (LogExpressionStructure)
            {
                LogVisit("VisitMemberInit", "{0}", node.NodeType);
            }
            return base.VisitMemberInit(node);
        }

        protected override Expression VisitNew(NewExpression node)
        {
            if (LogExpressionStructure || LogExpressionValues || LogExpressionTypes)
            {
                LogVisit("VisitNew", "{0}", node.NodeType);
            }
            return base.VisitNew(node);
        }

        protected override Expression VisitNewArray(NewArrayExpression node)
        {
            if (LogExpressionStructure || LogExpressionValues || LogExpressionTypes)
            {
                LogVisit("VisitNewArray", "{0}", node.NodeType);
            }
            return base.VisitNewArray(node);
        }

        protected override Expression VisitRuntimeVariables(RuntimeVariablesExpression node)
        {
            if (LogExpressionStructure)
            {
                LogVisit("VisitRuntimeVariables", "{0}", node.NodeType);
            }
            return base.VisitRuntimeVariables(node);
        }

        protected override Expression VisitSwitch(SwitchExpression node)
        {
            if (LogExpressionStructure)
            {
                LogVisit("VisitSwitch", "{0}", node.NodeType);
            }
            return base.VisitSwitch(node);
        }

        protected override Expression VisitTry(TryExpression node)
        {
            if (LogExpressionStructure)
            {
                LogVisit("VisitTry", "{0}", node.NodeType);
            }
            return base.VisitTry(node);
        }

        protected override Expression VisitTypeBinary(TypeBinaryExpression node)
        {
            if (LogExpressionStructure || LogExpressionTypes)
            {
                LogVisit("VisitTypeBinary", "{0}", node.NodeType);
            }
            return base.VisitTypeBinary(node);
        }

        private void LogVisit(string methodName, string detail, params object[] args)
        {
            if (ShouldLog(LogLevel.Basic))
            {
                _logger.LogInformation($"{methodName}: {detail}", args);
            }
        }

        private void LogPerformance(string methodName, string detail)
        {
            if (ShouldLog(LogLevel.Detailed))
            {
                _logger.LogDebug($"{methodName} {detail} took {_stopwatch.ElapsedMilliseconds:0.00} ms");
            }
        }
    }
}