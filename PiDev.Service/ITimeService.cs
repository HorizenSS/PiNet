using PiDev.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiDev.Domain.Entities;

namespace PiDev.Service
{
    public interface ITimeService: IServices<timesheet>
    {
        void addLog(timesheet t,user u);

    }
}
