using Application.Interfaces;
using Application.Setting;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.ProductFeature.Commands
{
    public record DeleteProductCommandNew(
        Guid ProductId
        )
        : IRequest<ResponseHttp>
    {
        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandNew, ResponseHttp>
        {
            private readonly IProductRepository ProductRepository;
            public DeleteProductCommandHandler(IProductRepository ProductRepository)
            {
                this.ProductRepository = ProductRepository;
            }

            public async Task<ResponseHttp> Handle(DeleteProductCommandNew request, CancellationToken cancellationToken)
            {
                var product = await ProductRepository.GetById(request.ProductId);

                if (product == null)
                {
                    return new ResponseHttp
                    {
                        Fail_Messages = "No test found",
                        Status = StatusCodes.Status400BadRequest,
                    };
                }

                await ProductRepository.SoftDelete(request.ProductId);
                await ProductRepository.SaveChange(cancellationToken);

                return new ResponseHttp
                {
                    Status = StatusCodes.Status200OK,
                };
            }
        }
    }
}