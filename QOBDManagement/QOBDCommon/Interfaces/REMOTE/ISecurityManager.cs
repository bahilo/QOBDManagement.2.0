using QOBDCommon;
using QOBDCommon.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
/// <summary>
///  An interface defining operations expected of ...
/// 
///  @see OtherClasses
///  @author Dago
/// </summary>
namespace QOBDCommon.Interfaces.REMOTE
{
    public interface ISecurityManager : IActionRecordManager, IRoleManager, ISecurityActionManager, IAgent_roleManager, IRole_actionManager, IPrivilegeManager , IDisposable
    {
        // Operations        

        void setServiceCredential(object channel);

        void setCompanyName(string companyName);

        Task<Agent> AuthenticateUserAsync(string username, string password, string licenseKey);

        Task<List<License>> checkLicenseByKeyAsync(string licenseKey);

        Task<List<License>> checkLicenseByCompanyAsync(string companyName);



    } /* end interface Isecurity */
}