using System.Collections;
using System.Collections.Generic;

namespace NeredeKal.SharedKernel.Entities.Abstracts
{
    public interface IHasExtraProperties
    {
        IDictionary<string, object> ExtraProperties { get; }
    }
}
