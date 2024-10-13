﻿using Microsoft.Extensions.DependencyInjection;

namespace NeredeKal.HotelService.Application.DIs
{
    public static class Dependencies
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services) => services.AddMediatR(configure => configure.RegisterServicesFromAssembly(typeof(Dependencies).Assembly));
    }
}
