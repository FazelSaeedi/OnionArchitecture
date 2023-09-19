using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace BlogManagement.Application
{
    public class Ping : IRequest<Pong>
    {
        public string Message { get; set; }
    }

    public class PingHandler : IRequestHandler<Ping, Pong>
    {
        // private readonly TextWriter _writer;

        public PingHandler()
        {
            // _writer = writer;
        }

        public async Task<Pong> Handle(Ping request, CancellationToken cancellationToken)
        {
            // await _writer.WriteLineAsync($"--- Handled Ping: {request.Message}");
            return new Pong { Message = request.Message + " Pong OK " };
        }
    }

    public class Pong
    {
        public string Message { get; set; }
    }
}