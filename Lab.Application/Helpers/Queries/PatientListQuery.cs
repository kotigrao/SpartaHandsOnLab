﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Application.Helpers.Queries
{
    public class PatientListQuery: IRequest<List<PatientDto>>
    {
        public PatientListQuery() { }
    }
}