namespace RealEstateApi.Service
{
    public class ServiceResult<T>
    {
        public bool IsSuccess { get; set; }
        public string ProblemType { get; set; }
        public string AdditionalInformation { get; set; }   
        public T Result { get; set; }
    }
}
