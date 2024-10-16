using System.Collections.Generic;

namespace NeredeKal.SharedKernel.Services.DTOs
{
    public class PagedResponseDto<TEntity>
    {
        public ICollection<TEntity> Items { get; set; }
        public int Count { get; set; }

        public PagedResponseDto(List<TEntity> items, int count)
        {
            Items = items;
            Count = count;
        }
    }
}
