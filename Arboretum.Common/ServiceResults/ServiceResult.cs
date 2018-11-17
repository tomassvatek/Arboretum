using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arboretum.Common.ServiceResults
{
    public class ServiceResult
    {
        public List<Violation> Violations { get; set; }
        public bool HasViolations => Violations.Any();

        public ServiceResult()
        {
            Violations = new List<Violation>();
        }

        public void AddViolation(Exception exception)
        {
            Violations.Add(new Violation(exception));
        }

        public void AddViolation(string message)
        {
            Violations.Add(new Violation(message));
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var violation in Violations)
            {
                sb.AppendLine(violation.ToString());
            }

            return sb.ToString();
        }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T Data { get; set; }
    }
}
