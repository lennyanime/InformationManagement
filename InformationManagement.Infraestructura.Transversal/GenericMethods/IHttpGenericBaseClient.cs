﻿using InformationManagement.Aplication.Dto.DataTransfer_Object;
using System.Threading.Tasks;

namespace InformationManagement.Infraestructura.Transversal.GenericMethods
{
    public interface IHttpGenericBaseClient
    {
        Task<T> Get<T>(string path, string request) where T : class;

        Task<TResponse> Post<TResponse, TRequest>(string path, TRequest request) where TResponse : DataTransferObject;

        T Put<T>(string path, T request) where T : DataTransferObject;

        T Patch<T>(string path, T request) where T : DataTransferObject;
    }
}
