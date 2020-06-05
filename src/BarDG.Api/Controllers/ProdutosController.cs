using BarDG.Domain.Produtos.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarDG.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ApiBase
    {
        private readonly IProdutoRepository produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository) : base(null)
        {
            this.produtoRepository = produtoRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(produtoRepository.Listar());
        }
    }
}