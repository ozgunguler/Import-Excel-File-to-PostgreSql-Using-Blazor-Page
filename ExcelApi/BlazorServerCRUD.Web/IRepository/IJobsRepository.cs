using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorServerCRUD.Web.Data;

namespace BlazorServerCRUD.Web.IRepository
{
    public interface IJobsRepository
    {
        List<JobAdvertisement> SaveExcel (string fileName);

        List<JobAdvertisement> Delete();

    }
}