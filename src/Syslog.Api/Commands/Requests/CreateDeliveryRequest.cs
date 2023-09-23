﻿using System.ComponentModel.DataAnnotations;

using MediatR;

using Syslog.Api.Commands.Responses;

namespace Syslog.Api.Commands.Requests
{
    public class CreateDeliveryRequest : IRequest<CreateDeliveryResponse>
    {
        [Required]
        public required string OrderId { get; set; }

        [Required]
        public required string Address { get; set; }
    }
}