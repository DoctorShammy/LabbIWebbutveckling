using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIW.Common.DTOs
{
    public record ClickModel(string PageType, int Id);
    public record ClickReferenceModel(string PageType, int firstId, int secondId);

}
