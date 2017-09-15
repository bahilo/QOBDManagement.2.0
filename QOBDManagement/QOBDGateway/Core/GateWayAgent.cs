using QOBDCommon.Entities;
using QOBDCommon.Interfaces.REMOTE;
using QOBDGateway.Helper.ChannelHelper;
using QOBDGateway.QOBDServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Linq;
using QOBDCommon.Enum;
using QOBDGateway.Classes;
using QOBDGateway.Abstracts;
/// <summary>
///  A class that represents ...
/// 
///  @see OtherClasses
///  @author Dago
/// </summary>
namespace QOBDGateway.Core
{
    public class GateWayAgent : IAgentManager
    {
        private ClientProxy _channel;
        private string _companyName;

        public event PropertyChangedEventHandler PropertyChanged;
        

        public GateWayAgent(ClientProxy servicePort)
        {
            _channel = servicePort;
        }

        public void setServiceCredential(object channel)
        {            
            _channel = (ClientProxy)channel;
        }

        private void onPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public ClientProxy AgentGatWayChannel
        {
            get
            {
                return _channel;
            }
        }

        public void setCompanyName(string companyName)
        {
            _companyName = companyName;
        }

        public async Task<List<Agent>> DeleteAgentAsync(List<Agent> listAgent)
        {
            List<Agent> result = new List<Agent>();
            try
            {                
                result = (await _channel.delete_data_agentAsync(_companyName, listAgent.AgentTypeToArray())).ArrayTypeToAgent();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<Agent>> GetAgentDataAsync(int nbLine)
        {
            List<Agent> result = new List<Agent>();
            try
            {
                result = (await _channel.get_data_agentAsync(_companyName, nbLine.ToString())).ArrayTypeToAgent().OrderBy(x=>x.ID).ToList();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<Agent>> GetAgentDataByIdAsync(int id)
        {
            List<Agent> result = new List<Agent>();
            try
            {                
                result = (await _channel.get_data_agent_by_idAsync(_companyName, id.ToString())).ArrayTypeToAgent();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<Agent>> GetAgentDataByOrderListAsync(List<Order> orderList)
        {
            List<Agent> result = new List<Agent>();
            try
            {
                result = (await _channel.get_data_agent_by_order_listAsync(_companyName, orderList.OrderTypeToArray())).ArrayTypeToAgent();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }


        public async Task<List<Agent>> InsertAgentAsync(List<Agent> listAgent)
        {
            List<Agent> result = new List<Agent>();
            try
            {                
                result = (await _channel.insert_data_agentAsync(_companyName, listAgent.AgentTypeToArray())).ArrayTypeToAgent();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<Agent>> UpdateAgentAsync(List<Agent> listAgent)
        {
            List<Agent> result = new List<Agent>();
            try
            {                
                result = (await _channel.update_data_agentAsync(_companyName, listAgent.AgentTypeToArray())).ArrayTypeToAgent();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<Agent>> searchAgentAsync(Agent agent, ESearchOption filterOperator)
        {
            List<Agent> result = new List<Agent>();
            try
            {                
                result = (await _channel.get_filter_agentAsync(_companyName, agent.AgentTypeToFilterArray(filterOperator))).ArrayTypeToAgent();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public void Dispose()
        {
            if(_channel.State == CommunicationState.Opened)
            _channel.Close();
        }
    } /* end class BLAgent */
}