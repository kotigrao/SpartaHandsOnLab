using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Application.Helpers.Commands.Delete
{
    public class DeletePatientCommand: IRequest
    {
        public int Id { get; set; }
    }
}
