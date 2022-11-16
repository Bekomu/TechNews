using System;
using TechNews.Core.Enums;

namespace TechNews.Core.Result
{
    public interface IResult
    {
        string Message { get; }
        Exception Exception { get; }
        ResultStatus ResultStatus { get; }
    }
}
