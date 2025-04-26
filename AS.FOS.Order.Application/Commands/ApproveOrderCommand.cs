using AS.FOS.Order.Application.Response;
using MediatR;

namespace AS.FOS.Order.Application.Commands;

public record ApproveOrderCommand(Guid OrderId) : IRequest<ApproveOrderResponse>;

