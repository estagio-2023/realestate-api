namespace RealEstateApi.Service
{
    public class ServiceResult<T>
    {
        public bool IsSuccess { get; set; }
        public string ProblemType { get; set; }
        public List<string> AdditionalInformation { get; set; }   
        public T Result { get; set; }
    }
}