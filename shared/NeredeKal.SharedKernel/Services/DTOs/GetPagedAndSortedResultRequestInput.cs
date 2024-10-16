namespace NeredeKal.SharedKernel.Services.DTOs
{
    public abstract class GetPagedAndSortedResultRequestInput
    {
        public int SkipCount { get; set; } = 0;
        public int MaxResultCount { get; set; } = int.MaxValue;
    }
}
