﻿using System;
using Covid19Radar.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.AspNetCore.Http;
using Covid19Radar.DataAccess;

[assembly: FunctionsStartup(typeof(Covid19Radar.Startup))]

namespace Covid19Radar
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddLogging();
            builder.Services.AddSingleton<DataStore.ICosmos, DataStore.Cosmos>();
            builder.Services.AddSingleton<DataStore.IStoringCosmos, DataStore.StoringCosmos>();
            builder.Services.AddSingleton<INotificationService, NotificationService>();
            builder.Services.AddSingleton<ISequenceRepository, CosmosSequenceRepository>();
            builder.Services.AddSingleton<ITemporaryExposureKeyExportRepository, CosmosTemporaryExposureKeyExportRepository>();
            builder.Services.AddSingleton<ITemporaryExposureKeyService, TemporaryExposureKeyService>();

        }
    }
}

