using MediatR;

namespace ViberBot.Application.Requests;

public record InvalidInputRequest(string ReceiverId) : IRequest;

