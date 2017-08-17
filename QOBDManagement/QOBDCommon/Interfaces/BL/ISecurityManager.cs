using QOBDCommon;
using QOBDCommon.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
/// <summary>
///  An interface defining operations expected of ...
/// 
///  @see OtherClasses
///  @author Dago
/// </summary>
namespace QOBDCommon.Interfaces.BL
{
    public interface ISecurityManager : DAC.ISecurityManager
    {
        // Operations

        Agent GetAuthenticatedUser();

        bool IsUserAuthenticated();

        Task DisconnectAuthenticatedUser();

        Task<List<Agent>> DisableAgent(List<Agent> listAgent);

        Task<List<Agent>> EnableAgent(List<Agent> listAgent);

        Task<Agent> UseAgentAsync(Agent inAgent);
        

    } /* end interface Isecurity */
}