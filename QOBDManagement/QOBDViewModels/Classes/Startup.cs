﻿using QOBDCommon.Classes;
using QOBDDAL.Core;
using QOBDGateway.Abstracts;
using QOBDGateway.Classes;
using QOBDGateway.Interfaces;
using QOBDViewModels.Core;
using QOBDViewModels.Interfaces;
using System;

namespace QOBDViewModels.Classes
{
    public class Startup: IStartup, ICommunication
    {
        private BusinessLogic _bl { get; set; }
        private DataAccess _dal { get; set; }
        private ClientProxy _proxyClient;
        private QOBDDAL.Interfaces.IQOBDSet _dataSet;
        
        public void initialize()
        {
            _dataSet = new QOBDDAL.Classes.QOBDDataSet();
            _proxyClient = getProxy();
            //_proxyClient.ChannelFactory.Closed += openChannel;
            _dal = new DataAccess(
                                new DALAgent(_proxyClient, _dataSet, this),
                                new DALClient(_proxyClient, _dataSet, this),
                                new DALItem(_proxyClient, _dataSet, this),
                                new DALOrder(_proxyClient, _dataSet, this),
                                new DALSecurity(_proxyClient, _dataSet, this),
                                new DALStatisitc(_proxyClient, _dataSet, this),
                                new DALReferential(_proxyClient, _dataSet, this),
                                new DALNotification(_proxyClient, _dataSet, this),
                                new DALChatRoom(_proxyClient, _dataSet, this));

            _bl = new BusinessLogic(
                                    new BLAgent(_dal),
                                    new BlCLient(_dal),
                                    new BLItem(_dal),
                                    new BLOrder(_dal),
                                    new BlSecurity(_dal),
                                    new BLStatisitc(_dal),
                                    new BlReferential(_dal),
                                    new BlNotification(_dal),
                                    new BLChatRoom(_dal));
        }

        public QOBDDAL.Interfaces.IQOBDSet DataSet
        {
            get { return _dataSet; }
        }

        public ClientProxy ProxyClient
        {
            get { return _proxyClient; }
        }

        public DataAccess Dal
        {
            get { return _dal; }
        }

        public BusinessLogic Bl
        {
            get { return _bl; }
            set { _bl = value; }
        }

        public void resetCommunication()
        {
            var newProxyClient = getProxy();
            Bl.BlAgent.setServiceCredential(newProxyClient);
            Bl.BlChatRoom.setServiceCredential(newProxyClient);
            Bl.BlClient.setServiceCredential(newProxyClient);
            Bl.BlItem.setServiceCredential(newProxyClient);
            Bl.BlNotification.setServiceCredential(newProxyClient);
            Bl.BlOrder.setServiceCredential(newProxyClient);
            Bl.BlReferential.setServiceCredential(newProxyClient);
            Bl.BlSecurity.setServiceCredential(newProxyClient);
            Bl.BlStatisitc.setServiceCredential(newProxyClient);
        }

        public ClientConcreteProxy getProxy()
        {
            var newProxyClient = new ClientConcreteProxy("QOBDWebServicePort");
            //var newProxyClient = new ClientConcreteProxy("QOBDWebServicePort");
            //newProxyClient.Endpoint.EndpointBehaviors.Add(new SimpleEndPointBehavior());
            return newProxyClient;
        }

        public void checkServiceCommunication(ClientProxy proxy)
        {
            object locker = new object();
            lock (locker)
            {
                if (proxy.State == System.ServiceModel.CommunicationState.Closed
                    || proxy.State == System.ServiceModel.CommunicationState.Closing
                    || proxy.State == System.ServiceModel.CommunicationState.Faulted)
                    resetCommunication();
            }
        }

        private void openChannel(object sender, EventArgs e)
        {
            resetCommunication();
        }



    }

}
