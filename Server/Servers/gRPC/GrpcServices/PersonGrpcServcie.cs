using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Person;
using Rira.BackEnd.SeniorTask.Dtos;
using Rira.BackEnd.SeniorTask.Logic;
using static Person.PersonService;
using System.Linq;

namespace Rira.BackEnd.SeniorTask.gRPC.Services
{
    public class PersonGrpcServcie : PersonServiceBase
    {
        PersonLogic _personLogic;

        public PersonGrpcServcie(PersonLogic personLogic)
        {
            _personLogic = personLogic;
        }

        public override async Task<Empty> Create(CreatePersonRequest request, ServerCallContext context)
        {
            try
            {
                await _personLogic.CreateAsync(new CreatePersonDto()
                {
                    BirthDay = request.BirthDay,
                    FamilyName = request.FamilyName,
                    Name = request.Name,
                    NationalCode = request.NationalCode
                });
                return new Empty();
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, ex.Message));
            }
        }

        public override async Task<Empty> Update(UpdatePersonRequest request, ServerCallContext context)
        {
            try
            {
                await _personLogic.UpdateAsync(new EditPersonDto()
                {
                    Id = request.Id,
                    BirthDay = request.BirthDay,
                    FamilyName = request.FamilyName,
                    Name = request.Name,
                    NationalCode = request.NationalCode
                });
                return new Empty();
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, ex.Message));
            }
        }

        public override async Task<Empty> Delete(DeletePersonRequest request, ServerCallContext context)
        {
            try
            {
                await _personLogic.DeleteAsync(new DeletePersonDto()
                {
                    Id = request.Id,
                });
                return new Empty();
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, ex.Message));
            }
        }

        public override async Task<PersonReponseListResponse> GetAll(Empty request, ServerCallContext context)
        {
             var results = await _personLogic.GetAllAsync();

            var response = new PersonReponseListResponse();
            response.Persons.AddRange(results.Select(t=> new PersonReponse()
            {
                Id= t.Id,
                BirthDay = t.BirthDay,
                FamilyName = t.FamilyName,
                Name = t.Name,
                NationalCode = t.NationalCode,
            }));

            return response;
        }
    }
}
