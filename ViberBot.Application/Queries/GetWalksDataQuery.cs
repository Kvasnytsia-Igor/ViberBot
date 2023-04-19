using Application.Queries.DTOs;
using MediatR;

namespace Application.Queries
{
    public record GetWalksDataQuery(string IMEI, string Receiver) : IRequest;
}
