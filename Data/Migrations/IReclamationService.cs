using ADVYTEAM.Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVYTEAM.Services
{
    public interface IReclamationService : IService<reclamation>
    {
        IEnumerable<reclamation> GetMesReclmations(long id);
        IEnumerable<reclamation> GetReclmationsAttent();
        IEnumerable<reclamation> GetReclmationsEnCour();
        IEnumerable<reclamation> GetReclmationsTraite();
    }
}
