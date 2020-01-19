using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCalc.Domain
{
    class ParameterExtractionVisitor : LogicalExpressionVisitor
    {
        public HashSet<string> Parameters = new HashSet<string>();
        public override void Visit(LogicalExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(TernaryExpression expression)
        {
            expression.LeftExpression.Accept(this);
            expression.MiddleExpression.Accept(this);
            expression.RightExpression.Accept(this);
        }

        public override void Visit(BinaryExpression expression)
        {
            expression.LeftExpression.Accept(this);
            expression.RightExpression.Accept(this);
        }

        public override void Visit(UnaryExpression expression)
        {
           expression.Accept(this);
        }

        public override void Visit(ValueExpression expression)
        {
        }

        public override void Visit(Function function)
        {
            foreach (var item in function.Expressions)
            {
                item.Accept(this);
            }
        }

        public override void Visit(Identifier parameter)
        {
            Parameters.Add(parameter.Name);
        }
    }
}
