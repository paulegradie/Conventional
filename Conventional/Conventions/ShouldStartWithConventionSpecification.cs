using System;

namespace Conventional.Conventions
{
    public class NameShouldStartWithConventionSpecification : ConventionSpecification
    {
        private readonly string _prefix;

        public NameShouldStartWithConventionSpecification(string prefix)
        {
            _prefix = prefix;
        }

        protected override string FailureMessage
        {
            get { return "Type name does not start with {0}"; }
        }

        public override ConventionResult IsSatisfiedBy(Type type)
        {
            if (type.Name.StartsWith(_prefix) == false)
            {
                return ConventionResult.NotSatisfied(type.FullName, FailureMessage.FormatWith(type.FullName));
            }

            return ConventionResult.Satisfied(type.FullName);
        }
    }
}