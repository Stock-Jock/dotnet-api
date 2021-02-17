using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SJAPI.ObjectModel.Models;

namespace SJApi.DataService.Interfaces
{
    public interface IIEXService
    {
        Task<List<Object>> RetrieveSymbols();
    }
}