﻿using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using rbkApiModules.Utilities;
using System;
using System.Linq;
using System.Threading.Tasks;
using rbkApiModules.Infrastructure.MediatR.Core;

namespace rbkApiModules.Analytics.Core
{
    public class GetDailyDatabaseUsage
    {
        public class Command : IRequest<QueryResponse>
        {
            public Command()
            {

            }
            public Command(DateTime from, DateTime to)
            {
                DateFrom = from;
                DateTo = to;
            }

            public DateTime DateFrom { get; set; }
            public DateTime DateTo { get; set; }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                CascadeMode = CascadeMode.Stop;
            }
        }

        public class Handler : BaseQueryHandler<Command>
        {
            private readonly IAnalyticModuleStore _context;

            public Handler(IHttpContextAccessor httpContextAccessor, IAnalyticModuleStore context)
                : base(httpContextAccessor)
            {
                _context = context;
            }

            protected override async Task<object> ExecuteAsync(Command request)
            {
                var data = await _context.FilterAsync(request.DateFrom, request.DateTo, null, null, null, null, null,
                    null, null, null, 0, null);

                var groupedData = data.GroupBy(x => x.Timestamp.Date).ToList();

                var chartData = ChartingUtilities.BuildLineChartAxis(request.DateFrom, request.DateTo);

                foreach (var itemData in groupedData)
                {
                    var date = itemData.Key;
                    var value = itemData.Sum(x => x.TotalTransactionTime);

                    var point = chartData.First(x => x.Date == date);

                    point.Value = value;
                }

                return chartData;
            }
        }
    }
}
