
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyAuthServer.Core.Repositories;
using UdemyAuthServer.Core.Services;
using UdemyAuthServer.Core.UnitOfWork;
using UdemyAuthServer.Data.Repositories;

namespace UdemyAuthServer.Service.Services
{
    public class ServiceGeneric<TEntity, TDto> : IServiceGeneric<TEntity, TDto> where TEntity : class where TDto : class
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _genericRepository;

        public ServiceGeneric(IUnitOfWork unitOfWork, IGenericRepository<TEntity> genericRepository)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;

        }
        public async Task<Response<TDto>> AddAsync(TDto entity)
        {
            var newEnity = ObjectMapper.Mapper.Map<TEntity>(entity);
            await _genericRepository.AddAysync(newEnity);
            await _unitOfWork.CommitAsync();
            var newDto = ObjectMapper.Mapper.Map<TDto>(newEnity);
            return Response<TDto>.Success(newDto, 200);


        }

        public async Task<Response<IEnumerable<TDto>>> GetAllAsync()
        {

            var productsEntity = await _genericRepository.GetAllAsync();
            var products = ObjectMapper.Mapper.Map<List<TDto>>(productsEntity);
            return Response<IEnumerable<TDto>>.Success(products, 200);
        }

        public async Task<Response<TDto>> GetByIdAsync(int id)
        {
            var product = await _genericRepository.GetByIdAsync(id);
            if (product == null)
            {
                return Response<TDto>.Fail("Id Not Found", 404, true);

            }


            return Response<TDto>.Success(ObjectMapper.Mapper.Map<TDto>(product), 200);
        }

        public async Task<Response<NoDataDto>> Remove(int id)
        {

            var isExistEntity = await _genericRepository.GetByIdAsync(id);
            if (isExistEntity == null)
            {
                return Response<NoDataDto>.Fail("Id not found", 404, true);

            }

            _genericRepository.Remove(isExistEntity);//burda memoryde silinecek diye işaretledik 
            await _unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success(204);

            //  _genericRepository.Remove() yazabiliriz ama 
        }

        public async Task<Response<NoDataDto>> Update(TDto entity, int id)
        {

            var isExistEntity = await _genericRepository.GetByIdAsync(id);
            if (isExistEntity == null)
            {
                return Response<NoDataDto>.Fail("Id Not Found", 404, true);


            }

            var updateEntity = ObjectMapper.Mapper.Map<TEntity>(entity);
            _genericRepository.Update(updateEntity);
            await _unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success(204);// NO CONTENT STTSUS CODE,bu drum kodunda hiç bir data olmayacak

        }

        public async Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            // where (x=>x.id>5)
            var list=_genericRepository.Where(predicate);
            var listDto = ObjectMapper.Mapper.Map<IEnumerable<TDto>>(await list.ToListAsync());
            return Response<IEnumerable<TDto>>.Success(listDto, 200);

            //list.ToList() burda veri tabınına yansır 
            //list.ToImmutableList() dediğimizde veritabınıan yansır 

                
        }
    }
}
