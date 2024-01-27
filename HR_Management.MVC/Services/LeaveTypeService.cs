using AutoMapper;
using HR_Management.MVC.Contracts;
using HR_Management.MVC.Models;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC.Services
{
    public class LeaveTypeService(IMapper mapper, IClient httpClient, ILocalStorageService localStorageService) : 
        BaseHttpService(httpClient, localStorageService),ILeaveTypeService
    {
        public async Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM leaveType)
        {
            try
            {
                var response = new Response<int>();
                CreateLeaveTypeDTO createLeaveTypeDto =
                    mapper.Map<CreateLeaveTypeDTO>(leaveType);

                AddBearerToken();

                await _client.LeaveTypePOSTAsync(createLeaveTypeDto);

                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteLeaveType(int id)
        {
            try
            {
                AddBearerToken();
                await _client.LeaveTypeDELETEAsync(id);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
        {
            AddBearerToken();
            var leaveType = await _client.LeaveTypeGETAsync(id);
            return mapper.Map<LeaveTypeVM>(leaveType);
        }

        public async Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            AddBearerToken();
            var leaveTypes = await _client.LeaveTypeAllAsync();
            return mapper.Map<List<LeaveTypeVM>>(leaveTypes);
        }

        public async Task<Response<int>> UpdateLeaveType(int id, LeaveTypeVM leaveType)
        {
            try
            {
                UpdateLeaveTypeDTO leaveTypeDto = mapper.Map<UpdateLeaveTypeDTO>(leaveType);

                AddBearerToken();

                await _client.LeaveTypePUTAsync(id, leaveTypeDto);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
