namespace OutsourceSystem.Common.Dto.Base
{
    public class ResponseBaseDto<T> where T : new()
    {
        public T Data { get; set; }

        public bool IsSuccess { get; set; }

        public string Error { get; set; }
    }
}