using HomeAutomation.Common.Entity;
using HomeAutomation.DAL;

namespace HomeAutomation.BLL.Services
{
    public class DeviceService
    {
        public bool UpdatePublicIp(Device device)
        {
            var deviceRepository = new DeviceRepository();
            return deviceRepository.UpdatePublicIp(device);
        }

        public Device GetDeviceInfo(string macId)
        {
            var deviceRepository = new DeviceRepository();
            return deviceRepository.GetDeviceInfo(macId);
        }
    }
}
