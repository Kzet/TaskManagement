using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Projects.Dtos
{
    public record ProjectDto(Guid Id, string Name, string Description, int StatusId);

}
