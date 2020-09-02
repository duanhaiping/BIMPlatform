using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace BIMPlatform.Application.Contracts
{
    public class BasePagedAndSortedResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
