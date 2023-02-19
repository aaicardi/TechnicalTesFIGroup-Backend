
using TecnicalTest.FIGroup.Infrastructure.Interface.IPersistence;

namespace TecnicalTest.FIGroup.Infrastructure.Persistence;

public class FacadeRepository : UnitOfWork, IFacadeRepository
{
    public FacadeRepository(FIGroupDBContext context) : base(context)
    {

    }


}

