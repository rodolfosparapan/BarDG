using BarDG.Domain.Entities;
using BarDG.Domain.Interfaces;
using BarDG.Domain.Interfaces.Repositories;
using BarDG.Domain.Interfaces.Services;

namespace BarDG.Domain.Services
{
    internal class VendaService : ServiceBase, IVendaService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IVendaRepository vendaRepository;
        private readonly IVendaItemRepository vendaItemRepository;

        public VendaService(
            IUnitOfWork unitOfWork,
            IVendaRepository vendaRepository, IVendaItemRepository vendaItemRepository)
        {
            this.unitOfWork = unitOfWork;
            this.vendaRepository = vendaRepository;
            this.vendaItemRepository = vendaItemRepository;
        }

        public int AdicionarItem(VendaItem vendaItem)
        {
            if(vendaItem.Id == 0)
            {
                var venda = Venda.Nova();
                vendaRepository.Inserir(venda);
                vendaItem.VincularVenda(venda.Id);
            }

            vendaItemRepository.Inserir(vendaItem);
            
            unitOfWork.Commit();

            return vendaItem.Id;
        }

        public bool Finalizar(int vendaId)
        {
            var venda = vendaRepository.ObterPorId(vendaId);

            venda.Finalizar();

            vendaRepository.Atualizar(venda);
            
            unitOfWork.Commit();
            
            return true;
        }

        public bool Resetar(int vendaId)
        {
            var venda = vendaRepository.ObterPorId(vendaId);

            venda.Resetar();

            vendaRepository.Atualizar(venda);
            
            unitOfWork.Commit();

            return true;
        }
    }
}