namespace TechNews.Core.Result
{
    public interface IDataResult<out T> : IResult
    {
        public T Data { get; }


    }
}
