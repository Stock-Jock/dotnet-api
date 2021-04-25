using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SJApi.ObjectModel.Models;

namespace SJApi.DataService.Interfaces
{
    public interface IIEXService
    {
        Task<Stock[]> RetrieveSymbols();
    }
}