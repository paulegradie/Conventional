using System;
using System.Reflection;

namespace Conventional.Conventions
{
    public class ShouldHaveAttributeConventionSpecification : ConventionSpecification
    {
        private readonly Type _attributeType;

        public ShouldHaveAttributeConventionSpecification(Type attributeType)
        {
            if (typeof (Attribute).IsAssignableFrom(attributeType) == false)
            {
                throw new ArgumentException("Type supplied must be an attribute", "attributeType");
            }

            _attributeType = attributeType;
        }

        protected override string FailureMessage
        {
            get { return "Attribute {0} not found"; }
        }

        public override ConventionResult IsSatisfiedBy(Type type)
        {
            if (type.GetCustomAttribute(_attributeType) == null)
            {
                return ConventionResult.NotSatisfied(type.FullName, FailureMessage.FormatWith(type.FullName));
            }

            return ConventionResult.Satisfied(type.FullName);
        }
    }
}