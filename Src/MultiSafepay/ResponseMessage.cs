namespace MultiSafepay
{
    public class ResponseMessage<T>
    {
        public string Success { get; set; }
        public T Data { get; set; }
    }
}
