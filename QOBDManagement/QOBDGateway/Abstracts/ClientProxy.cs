using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using QOBDGateway.QOBDServiceReference;

namespace QOBDGateway.Abstracts
{
    public abstract class ClientProxy : System.ServiceModel.ClientBase<QOBDGateway.QOBDServiceReference.QOBDWebServicePortType>, QOBDGateway.QOBDServiceReference.QOBDWebServicePortType
    {
        public ClientProxy(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }

        public ClientProxy(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }

        public ClientProxy(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }

        public ClientProxy(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }

        [return: MessageParameter(Name = "return")]
        public virtual ActionQOBD[] delete_data_action(ActionQOBD[] action_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ActionQOBD[]> delete_data_actionAsync(ActionQOBD[] action_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ActionRecordQOBD[] delete_data_actionRecord(ActionRecordQOBD[] actionRecord_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ActionRecordQOBD[]> delete_data_actionRecordAsync(ActionRecordQOBD[] actionRecord_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AddressQOBD[] delete_data_address(AddressQOBD[] address_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AddressQOBD[]> delete_data_addressAsync(AddressQOBD[] address_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AgentQOBD[] delete_data_agent(AgentQOBD[] agent_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AgentQOBD[]> delete_data_agentAsync(AgentQOBD[] agent_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Agent_roleQOBD[] delete_data_agent_role(Agent_roleQOBD[] agent_role_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Agent_roleQOBD[]> delete_data_agent_roleAsync(Agent_roleQOBD[] agent_role_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Auto_refsQOBD[] delete_data_auto_ref(Auto_refsQOBD[] auto_ref_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Auto_refsQOBD[]> delete_data_auto_refAsync(Auto_refsQOBD[] auto_ref_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual BillQOBD[] delete_data_bill(BillQOBD[] bill_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<BillQOBD[]> delete_data_billAsync(BillQOBD[] bill_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ClientQOBD[] delete_data_client(ClientQOBD[] client_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ClientQOBD[]> delete_data_clientAsync(ClientQOBD[] client_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ContactQOBD[] delete_data_contact(ContactQOBD[] contact_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ContactQOBD[]> delete_data_contactAsync(ContactQOBD[] contact_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual CurrencyQOBD[] delete_data_currency(CurrencyQOBD[] currency_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<CurrencyQOBD[]> delete_data_currencyAsync(CurrencyQOBD[] currency_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DeliveryQOBD[] delete_data_delivery(DeliveryQOBD[] delivery_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DeliveryQOBD[]> delete_data_deliveryAsync(DeliveryQOBD[] delivery_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DiscussionChatRoom[] delete_data_discussion(DiscussionChatRoom[] discussion_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DiscussionChatRoom[]> delete_data_discussionAsync(DiscussionChatRoom[] discussion_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual InfosQOBD[] delete_data_infos(InfosQOBD[] infos_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<InfosQOBD[]> delete_data_infosAsync(InfosQOBD[] infos_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ItemQOBD[] delete_data_item(ItemQOBD[] item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ItemQOBD[]> delete_data_itemAsync(ItemQOBD[] item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Item_deliveryQOBD[] delete_data_item_delivery(Item_deliveryQOBD[] item_delivery_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Item_deliveryQOBD[]> delete_data_item_deliveryAsync(Item_deliveryQOBD[] item_delivery_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual MessageChatRoom[] delete_data_message(MessageChatRoom[] message_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<MessageChatRoom[]> delete_data_messageAsync(MessageChatRoom[] message_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual NotificationQOBD[] delete_data_notification(NotificationQOBD[] notification_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<NotificationQOBD[]> delete_data_notificationAsync(NotificationQOBD[] notification_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual OrdersQOBD[] delete_data_order(OrdersQOBD[] order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<OrdersQOBD[]> delete_data_orderAsync(OrdersQOBD[] order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Order_itemQOBD[] delete_data_order_item(Order_itemQOBD[] order_item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Order_itemQOBD[]> delete_data_order_itemAsync(Order_itemQOBD[] order_item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual PrivilegeQOBD[] delete_data_privilege(PrivilegeQOBD[] privilege_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<PrivilegeQOBD[]> delete_data_privilegeAsync(PrivilegeQOBD[] privilege_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ProviderQOBD[] delete_data_provider(ProviderQOBD[] provider_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ProviderQOBD[]> delete_data_providerAsync(ProviderQOBD[] provider_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Provider_itemQOBD[] delete_data_provider_item(Provider_itemQOBD[] provider_item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Provider_itemQOBD[]> delete_data_provider_itemAsync(Provider_itemQOBD[] provider_item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual RoleQOBD[] delete_data_role(RoleQOBD[] role_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<RoleQOBD[]> delete_data_roleAsync(RoleQOBD[] role_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Role_actionQOBD[] delete_data_role_action(Role_actionQOBD[] role_action_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Role_actionQOBD[]> delete_data_role_actionAsync(Role_actionQOBD[] role_action_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual StatisticQOBD[] delete_data_statistic(StatisticQOBD[] statistic_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<StatisticQOBD[]> delete_data_statisticAsync(StatisticQOBD[] statistic_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual TaxQOBD[] delete_data_tax(TaxQOBD[] tax_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<TaxQOBD[]> delete_data_taxAsync(TaxQOBD[] tax_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_itemQOBD[] delete_data_tax_item(Tax_itemQOBD[] tax_item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_itemQOBD[]> delete_data_tax_itemAsync(Tax_itemQOBD[] tax_item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_orderQOBD[] delete_data_tax_order(Tax_orderQOBD[] tax_order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_orderQOBD[]> delete_data_tax_orderAsync(Tax_orderQOBD[] tax_order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual UserChatRoom[] delete_data_user(UserChatRoom[] user_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<UserChatRoom[]> delete_data_userAsync(UserChatRoom[] user_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual User_discussionChatRoom[] delete_data_user_discussion(User_discussionChatRoom[] user_discussion_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<User_discussionChatRoom[]> delete_data_user_discussionAsync(User_discussionChatRoom[] user_discussion_array_list)
        {
            throw new NotImplementedException();
        }

        public virtual void generate_pdf(PdfQOBD order_array)
        {
            throw new NotImplementedException();
        }

        public virtual Task generate_pdfAsync(PdfQOBD order_array)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AgentQOBD get_authenticate_user(string username, string password)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AgentQOBD> get_authenticate_userAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ActionQOBD[] get_data_action(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ActionQOBD[]> get_data_actionAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ActionRecordQOBD[] get_data_actionRecord(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ActionRecordQOBD[]> get_data_actionRecordAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ActionRecordQOBD[] get_data_actionRecord_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ActionRecordQOBD[]> get_data_actionRecord_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ActionQOBD[] get_data_action_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ActionQOBD[]> get_data_action_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AddressQOBD[] get_data_address(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AddressQOBD[]> get_data_addressAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AddressQOBD[] get_data_address_by_client_list(ClientQOBD[] client_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AddressQOBD[]> get_data_address_by_client_listAsync(ClientQOBD[] client_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AddressQOBD[] get_data_address_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AddressQOBD[]> get_data_address_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AddressQOBD[] get_data_address_by_order_list(OrdersQOBD[] order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AddressQOBD[]> get_data_address_by_order_listAsync(OrdersQOBD[] order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AgentQOBD[] get_data_agent(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AgentQOBD[]> get_data_agentAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AgentQOBD[] get_data_agent_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AgentQOBD[]> get_data_agent_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AgentQOBD[] get_data_agent_by_order_list(OrdersQOBD[] order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AgentQOBD[]> get_data_agent_by_order_listAsync(OrdersQOBD[] order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AgentQOBD[] get_data_agent_credentail(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AgentQOBD[]> get_data_agent_credentailAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Agent_roleQOBD[] get_data_agent_role(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Agent_roleQOBD[]> get_data_agent_roleAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Agent_roleQOBD[] get_data_agent_role_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Agent_roleQOBD[]> get_data_agent_role_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Auto_refsQOBD[] get_data_auto_ref(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Auto_refsQOBD[]> get_data_auto_refAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Auto_refsQOBD[] get_data_auto_ref_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Auto_refsQOBD[]> get_data_auto_ref_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual BillQOBD[] get_data_bill(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<BillQOBD[]> get_data_billAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual BillQOBD[] get_data_bill_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<BillQOBD[]> get_data_bill_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual BillQOBD[] get_data_bill_by_order_list(OrdersQOBD[] order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<BillQOBD[]> get_data_bill_by_order_listAsync(OrdersQOBD[] order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual BillQOBD[] get_data_bill_by_unpaid(string agent_id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<BillQOBD[]> get_data_bill_by_unpaidAsync(string agent_id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ClientQOBD[] get_data_client(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ClientQOBD[]> get_data_clientAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ClientQOBD[] get_data_client_by_bill_list(BillQOBD[] bill_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ClientQOBD[]> get_data_client_by_bill_listAsync(BillQOBD[] bill_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ClientQOBD[] get_data_client_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ClientQOBD[]> get_data_client_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ClientQOBD[] get_data_client_by_max_credit_over(string agent_id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ClientQOBD[]> get_data_client_by_max_credit_overAsync(string agent_id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ClientQOBD[] get_data_client_by_order_list(OrdersQOBD[] order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ClientQOBD[]> get_data_client_by_order_listAsync(OrdersQOBD[] order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ContactQOBD[] get_data_contact(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ContactQOBD[]> get_data_contactAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ContactQOBD[] get_data_contact_by_client_list(ClientQOBD[] client_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ContactQOBD[]> get_data_contact_by_client_listAsync(ClientQOBD[] client_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ContactQOBD[] get_data_contact_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ContactQOBD[]> get_data_contact_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual CurrencyQOBD[] get_data_currency(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<CurrencyQOBD[]> get_data_currencyAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual CurrencyQOBD[] get_data_currency_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<CurrencyQOBD[]> get_data_currency_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual CurrencyQOBD[] get_data_currency_by_provider_item_list(Provider_itemQOBD[] item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<CurrencyQOBD[]> get_data_currency_by_provider_item_listAsync(Provider_itemQOBD[] item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DeliveryQOBD[] get_data_delivery(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DeliveryQOBD[]> get_data_deliveryAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DeliveryQOBD[] get_data_delivery_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DeliveryQOBD[]> get_data_delivery_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DeliveryQOBD[] get_data_delivery_by_order_list(OrdersQOBD[] order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DeliveryQOBD[]> get_data_delivery_by_order_listAsync(OrdersQOBD[] order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DiscussionChatRoom[] get_data_discussion(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DiscussionChatRoom[]> get_data_discussionAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DiscussionChatRoom[] get_data_discussion_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DiscussionChatRoom[]> get_data_discussion_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DiscussionChatRoom[] get_data_discussion_by_message_list(MessageChatRoom[] message_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DiscussionChatRoom[]> get_data_discussion_by_message_listAsync(MessageChatRoom[] message_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DiscussionChatRoom[] get_data_discussion_by_user_discussion_list(User_discussionChatRoom[] user_discussion_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DiscussionChatRoom[]> get_data_discussion_by_user_discussion_listAsync(User_discussionChatRoom[] user_discussion_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual InfosQOBD[] get_data_infos(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<InfosQOBD[]> get_data_infosAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual InfosQOBD[] get_data_infos_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<InfosQOBD[]> get_data_infos_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ItemQOBD[] get_data_item(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ItemQOBD[]> get_data_itemAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ItemQOBD[] get_data_item_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ItemQOBD[]> get_data_item_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ItemQOBD[] get_data_item_by_order_item_list(Order_itemQOBD[] order_item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ItemQOBD[]> get_data_item_by_order_item_listAsync(Order_itemQOBD[] order_item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Item_deliveryQOBD[] get_data_item_delivery(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Item_deliveryQOBD[]> get_data_item_deliveryAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Item_deliveryQOBD[] get_data_item_delivery_by_delivery_list(DeliveryQOBD[] delivery_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Item_deliveryQOBD[]> get_data_item_delivery_by_delivery_listAsync(DeliveryQOBD[] delivery_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Item_deliveryQOBD[] get_data_item_delivery_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Item_deliveryQOBD[]> get_data_item_delivery_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual MessageChatRoom[] get_data_message(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<MessageChatRoom[]> get_data_messageAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual MessageChatRoom[] get_data_message_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<MessageChatRoom[]> get_data_message_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual NotificationQOBD[] get_data_notification(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<NotificationQOBD[]> get_data_notificationAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual NotificationQOBD[] get_data_notification_by_client_list(ClientQOBD[] client_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<NotificationQOBD[]> get_data_notification_by_client_listAsync(ClientQOBD[] client_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual NotificationQOBD[] get_data_notification_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<NotificationQOBD[]> get_data_notification_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual NotificationQOBD[] get_data_notification_by_order_list(OrdersQOBD[] order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<NotificationQOBD[]> get_data_notification_by_order_listAsync(OrdersQOBD[] order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual OrdersQOBD[] get_data_order(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<OrdersQOBD[]> get_data_orderAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual OrdersQOBD[] get_data_order_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<OrdersQOBD[]> get_data_order_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Order_itemQOBD[] get_data_order_item(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Order_itemQOBD[]> get_data_order_itemAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Order_itemQOBD[] get_data_order_item_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Order_itemQOBD[]> get_data_order_item_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Order_itemQOBD[] get_data_order_item_by_order_list(OrdersQOBD[] order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Order_itemQOBD[]> get_data_order_item_by_order_listAsync(OrdersQOBD[] order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual PrivilegeQOBD[] get_data_privilege(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<PrivilegeQOBD[]> get_data_privilegeAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual PrivilegeQOBD[] get_data_privilege_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<PrivilegeQOBD[]> get_data_privilege_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ProviderQOBD[] get_data_provider(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ProviderQOBD[]> get_data_providerAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ProviderQOBD[] get_data_provider_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ProviderQOBD[]> get_data_provider_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ProviderQOBD[] get_data_provider_by_provider_item_list(Provider_itemQOBD[] provider_item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ProviderQOBD[]> get_data_provider_by_provider_item_listAsync(Provider_itemQOBD[] provider_item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Provider_itemQOBD[] get_data_provider_item(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Provider_itemQOBD[]> get_data_provider_itemAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Provider_itemQOBD[] get_data_provider_item_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Provider_itemQOBD[]> get_data_provider_item_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Provider_itemQOBD[] get_data_provider_item_by_item_list(ItemQOBD[] item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Provider_itemQOBD[]> get_data_provider_item_by_item_listAsync(ItemQOBD[] item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual RoleQOBD[] get_data_role(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<RoleQOBD[]> get_data_roleAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Role_actionQOBD[] get_data_role_action(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Role_actionQOBD[]> get_data_role_actionAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Role_actionQOBD[] get_data_role_action_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Role_actionQOBD[]> get_data_role_action_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual RoleQOBD[] get_data_role_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<RoleQOBD[]> get_data_role_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual StatisticQOBD[] get_data_statistic(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<StatisticQOBD[]> get_data_statisticAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual StatisticQOBD[] get_data_statistic_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<StatisticQOBD[]> get_data_statistic_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual TaxQOBD[] get_data_tax(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<TaxQOBD[]> get_data_taxAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual TaxQOBD[] get_data_tax_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<TaxQOBD[]> get_data_tax_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_itemQOBD[] get_data_tax_item(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_itemQOBD[]> get_data_tax_itemAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_itemQOBD[] get_data_tax_item_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_itemQOBD[]> get_data_tax_item_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_itemQOBD[] get_data_tax_item_by_item_list(ItemQOBD[] item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_itemQOBD[]> get_data_tax_item_by_item_listAsync(ItemQOBD[] item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_orderQOBD[] get_data_tax_order(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_orderQOBD[]> get_data_tax_orderAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_orderQOBD[] get_data_tax_order_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_orderQOBD[]> get_data_tax_order_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_orderQOBD[] get_data_tax_order_by_order_list(OrdersQOBD[] order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_orderQOBD[]> get_data_tax_order_by_order_listAsync(OrdersQOBD[] order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual UserChatRoom[] get_data_user(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<UserChatRoom[]> get_data_userAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual UserChatRoom[] get_data_user_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<UserChatRoom[]> get_data_user_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual UserChatRoom[] get_data_user_by_user_discussion_list(User_discussionChatRoom[] user_discussion_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<UserChatRoom[]> get_data_user_by_user_discussion_listAsync(User_discussionChatRoom[] user_discussion_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual User_discussionChatRoom[] get_data_user_discussion(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<User_discussionChatRoom[]> get_data_user_discussionAsync(string nbLine)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual User_discussionChatRoom[] get_data_user_discussion_by_id(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<User_discussionChatRoom[]> get_data_user_discussion_by_idAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ActionQOBD[] get_filter_action(ActionFilterQOBD action_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ActionQOBD[]> get_filter_actionAsync(ActionFilterQOBD action_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ActionRecordQOBD[] get_filter_actionRecord(ActionRecordFilterQOBD actionRecord_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ActionRecordQOBD[]> get_filter_actionRecordAsync(ActionRecordFilterQOBD actionRecord_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AddressQOBD[] get_filter_address(AddressFilterQOBD address_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AddressQOBD[]> get_filter_addressAsync(AddressFilterQOBD address_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AgentQOBD[] get_filter_agent(AgentFilterQOBD agent_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AgentQOBD[]> get_filter_agentAsync(AgentFilterQOBD agent_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Agent_roleQOBD[] get_filter_agent_role(Agent_roleFilterQOBD agent_role_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Agent_roleQOBD[]> get_filter_agent_roleAsync(Agent_roleFilterQOBD agent_role_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Auto_refsQOBD[] get_filter_auto_ref(Auto_refsFilterQOBD auto_ref_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Auto_refsQOBD[]> get_filter_auto_refAsync(Auto_refsFilterQOBD auto_ref_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual BillQOBD[] get_filter_bill(BillFilterQOBD bill_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<BillQOBD[]> get_filter_billAsync(BillFilterQOBD bill_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ClientQOBD[] get_filter_Client(ClientFilterQOBD client_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ClientQOBD[]> get_filter_ClientAsync(ClientFilterQOBD client_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ContactQOBD[] get_filter_contact(ContactFilterQOBD contact_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ContactQOBD[]> get_filter_contactAsync(ContactFilterQOBD contact_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual CurrencyQOBD[] get_filter_currency(CurrencyFilterQOBD currency_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<CurrencyQOBD[]> get_filter_currencyAsync(CurrencyFilterQOBD currency_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DeliveryQOBD[] get_filter_delivery(DeliveryFilterQOBD delivery_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DeliveryQOBD[]> get_filter_deliveryAsync(DeliveryFilterQOBD delivery_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DiscussionChatRoom[] get_filter_discussion(DiscussionFilterChatRoom discussion_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DiscussionChatRoom[]> get_filter_discussionAsync(DiscussionFilterChatRoom discussion_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual InfosQOBD[] get_filter_infos(InfosFilterQOBD infos_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<InfosQOBD[]> get_filter_infosAsync(InfosFilterQOBD infos_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ItemQOBD[] get_filter_item(ItemFilterQOBD item_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ItemQOBD[]> get_filter_itemAsync(ItemFilterQOBD item_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Item_deliveryQOBD[] get_filter_item_delivery(Item_deliveryFilterQOBD item_delivery_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Item_deliveryQOBD[]> get_filter_item_deliveryAsync(Item_deliveryFilterQOBD item_delivery_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual MessageChatRoom[] get_filter_message(MessageFilterChatRoom message_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<MessageChatRoom[]> get_filter_messageAsync(MessageFilterChatRoom message_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual NotificationQOBD[] get_filter_notification(NotificationFilterQOBD notification_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<NotificationQOBD[]> get_filter_notificationAsync(NotificationFilterQOBD notification_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual OrdersQOBD[] get_filter_order(OrderFilterQOBD order_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<OrdersQOBD[]> get_filter_orderAsync(OrderFilterQOBD order_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Order_itemQOBD[] get_filter_order_item(Order_itemFilterQOBD order_item_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Order_itemQOBD[]> get_filter_order_itemAsync(Order_itemFilterQOBD order_item_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual PrivilegeQOBD[] get_filter_privilege(PrivilegeFilterQOBD privilege_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<PrivilegeQOBD[]> get_filter_privilegeAsync(PrivilegeFilterQOBD privilege_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ProviderQOBD[] get_filter_provider(ProviderFilterQOBD provider_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ProviderQOBD[]> get_filter_providerAsync(ProviderFilterQOBD provider_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Provider_itemQOBD[] get_filter_provider_item(Provider_itemFilterQOBD provider_item_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Provider_itemQOBD[]> get_filter_provider_itemAsync(Provider_itemFilterQOBD provider_item_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual RoleQOBD[] get_filter_role(RoleFilterQOBD role_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<RoleQOBD[]> get_filter_roleAsync(RoleFilterQOBD role_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Role_actionQOBD[] get_filter_role_action(Role_actionFilterQOBD role_action_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Role_actionQOBD[]> get_filter_role_actionAsync(Role_actionFilterQOBD role_action_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual StatisticQOBD[] get_filter_statistic(StatisticFilterQOBD statistic_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<StatisticQOBD[]> get_filter_statisticAsync(StatisticFilterQOBD statistic_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual TaxQOBD[] get_filter_tax(TaxFilterQOBD tax_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<TaxQOBD[]> get_filter_taxAsync(TaxFilterQOBD tax_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_itemQOBD[] get_filter_tax_item(Tax_itemFilterQOBD tax_item_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_itemQOBD[]> get_filter_tax_itemAsync(Tax_itemFilterQOBD tax_item_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_orderQOBD[] get_filter_tax_order(Tax_orderFilterQOBD tax_order_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_orderQOBD[]> get_filter_tax_orderAsync(Tax_orderFilterQOBD tax_order_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual UserChatRoom[] get_filter_user(UserFilterChatRoom user_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<UserChatRoom[]> get_filter_userAsync(UserFilterChatRoom user_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual User_discussionChatRoom[] get_filter_user_discussion(User_discussionFilterChatRoom user_discussion_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<User_discussionChatRoom[]> get_filter_user_discussionAsync(User_discussionFilterChatRoom user_discussion_array_list_filter)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual OrdersQOBD[] get_orders_client(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<OrdersQOBD[]> get_orders_clientAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual OrdersQOBD[] get_quotes_client(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<OrdersQOBD[]> get_quotes_clientAsync(string id)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ActionQOBD[] insert_data_action(ActionQOBD[] action_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ActionQOBD[]> insert_data_actionAsync(ActionQOBD[] action_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ActionRecordQOBD[] insert_data_actionRecord(ActionRecordQOBD[] actionRecord_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ActionRecordQOBD[]> insert_data_actionRecordAsync(ActionRecordQOBD[] actionRecord_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AddressQOBD[] insert_data_address(AddressQOBD[] address_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AddressQOBD[]> insert_data_addressAsync(AddressQOBD[] address_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AgentQOBD[] insert_data_agent(AgentQOBD[] agent_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AgentQOBD[]> insert_data_agentAsync(AgentQOBD[] agent_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Agent_roleQOBD[] insert_data_agent_role(Agent_roleQOBD[] agent_role_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Agent_roleQOBD[]> insert_data_agent_roleAsync(Agent_roleQOBD[] agent_role_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Auto_refsQOBD[] insert_data_auto_ref(Auto_refsQOBD[] auto_ref_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Auto_refsQOBD[]> insert_data_auto_refAsync(Auto_refsQOBD[] auto_ref_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual BillQOBD[] insert_data_bill(BillQOBD[] bill_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<BillQOBD[]> insert_data_billAsync(BillQOBD[] bill_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ClientQOBD[] insert_data_client(ClientQOBD[] client_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ClientQOBD[]> insert_data_clientAsync(ClientQOBD[] client_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ContactQOBD[] insert_data_contact(ContactQOBD[] contact_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ContactQOBD[]> insert_data_contactAsync(ContactQOBD[] contact_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual CurrencyQOBD[] insert_data_currency(CurrencyQOBD[] currency_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<CurrencyQOBD[]> insert_data_currencyAsync(CurrencyQOBD[] currency_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DeliveryQOBD[] insert_data_delivery(DeliveryQOBD[] delivery_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DeliveryQOBD[]> insert_data_deliveryAsync(DeliveryQOBD[] delivery_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DiscussionChatRoom[] insert_data_discussion(DiscussionChatRoom[] discussion_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DiscussionChatRoom[]> insert_data_discussionAsync(DiscussionChatRoom[] discussion_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual InfosQOBD[] insert_data_infos(InfosQOBD[] infos_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<InfosQOBD[]> insert_data_infosAsync(InfosQOBD[] infos_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ItemQOBD[] insert_data_item(ItemQOBD[] item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ItemQOBD[]> insert_data_itemAsync(ItemQOBD[] item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Item_deliveryQOBD[] insert_data_item_delivery(Item_deliveryQOBD[] item_delivery_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Item_deliveryQOBD[]> insert_data_item_deliveryAsync(Item_deliveryQOBD[] item_delivery_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual MessageChatRoom[] insert_data_message(MessageChatRoom[] message_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<MessageChatRoom[]> insert_data_messageAsync(MessageChatRoom[] message_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual NotificationQOBD[] insert_data_notification(NotificationQOBD[] notification_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<NotificationQOBD[]> insert_data_notificationAsync(NotificationQOBD[] notification_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual OrdersQOBD[] insert_data_order(OrdersQOBD[] order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<OrdersQOBD[]> insert_data_orderAsync(OrdersQOBD[] order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Order_itemQOBD[] insert_data_order_item(Order_itemQOBD[] order_item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Order_itemQOBD[]> insert_data_order_itemAsync(Order_itemQOBD[] order_item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual PrivilegeQOBD[] insert_data_privilege(PrivilegeQOBD[] privilege_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<PrivilegeQOBD[]> insert_data_privilegeAsync(PrivilegeQOBD[] privilege_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ProviderQOBD[] insert_data_provider(ProviderQOBD[] provider_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ProviderQOBD[]> insert_data_providerAsync(ProviderQOBD[] provider_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Provider_itemQOBD[] insert_data_provider_item(Provider_itemQOBD[] provider_item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Provider_itemQOBD[]> insert_data_provider_itemAsync(Provider_itemQOBD[] provider_item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual RoleQOBD[] insert_data_role(RoleQOBD[] role_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<RoleQOBD[]> insert_data_roleAsync(RoleQOBD[] role_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Role_actionQOBD[] insert_data_role_action(Role_actionQOBD[] role_action_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Role_actionQOBD[]> insert_data_role_actionAsync(Role_actionQOBD[] role_action_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual StatisticQOBD[] insert_data_statistic(StatisticQOBD[] statistic_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<StatisticQOBD[]> insert_data_statisticAsync(StatisticQOBD[] statistic_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual TaxQOBD[] insert_data_tax(TaxQOBD[] tax_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<TaxQOBD[]> insert_data_taxAsync(TaxQOBD[] tax_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_itemQOBD[] insert_data_tax_item(Tax_itemQOBD[] tax_item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_itemQOBD[]> insert_data_tax_itemAsync(Tax_itemQOBD[] tax_item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_orderQOBD[] insert_data_tax_order(Tax_orderQOBD[] tax_order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_orderQOBD[]> insert_data_tax_orderAsync(Tax_orderQOBD[] tax_order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual UserChatRoom[] insert_data_user(UserChatRoom[] user_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<UserChatRoom[]> insert_data_userAsync(UserChatRoom[] user_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual User_discussionChatRoom[] insert_data_user_discussion(User_discussionChatRoom[] user_discussion_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<User_discussionChatRoom[]> insert_data_user_discussionAsync(User_discussionChatRoom[] user_discussion_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual string send_email_to_client(EmailQOBD client_email)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<string> send_email_to_clientAsync(EmailQOBD client_email)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ActionQOBD[] update_data_action(ActionQOBD[] action_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ActionQOBD[]> update_data_actionAsync(ActionQOBD[] action_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ActionRecordQOBD[] update_data_actionRecord(ActionRecordQOBD[] actionRecord_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ActionRecordQOBD[]> update_data_actionRecordAsync(ActionRecordQOBD[] actionRecord_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AddressQOBD[] update_data_address(AddressQOBD[] address_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AddressQOBD[]> update_data_addressAsync(AddressQOBD[] address_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AgentQOBD[] update_data_agent(AgentQOBD[] agent_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AgentQOBD[]> update_data_agentAsync(AgentQOBD[] agent_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Agent_roleQOBD[] update_data_agent_role(Agent_roleQOBD[] agent_role_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Agent_roleQOBD[]> update_data_agent_roleAsync(Agent_roleQOBD[] agent_role_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Auto_refsQOBD[] update_data_auto_ref(Auto_refsQOBD[] auto_ref_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Auto_refsQOBD[]> update_data_auto_refAsync(Auto_refsQOBD[] auto_ref_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual BillQOBD[] update_data_bill(BillQOBD[] bill_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<BillQOBD[]> update_data_billAsync(BillQOBD[] bill_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ClientQOBD[] update_data_client(ClientQOBD[] client_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ClientQOBD[]> update_data_clientAsync(ClientQOBD[] client_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ContactQOBD[] update_data_contact(ContactQOBD[] contact_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ContactQOBD[]> update_data_contactAsync(ContactQOBD[] contact_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual CurrencyQOBD[] update_data_currency(CurrencyQOBD[] currency_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<CurrencyQOBD[]> update_data_currencyAsync(CurrencyQOBD[] currency_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DeliveryQOBD[] update_data_delivery(DeliveryQOBD[] delivery_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DeliveryQOBD[]> update_data_deliveryAsync(DeliveryQOBD[] delivery_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DiscussionChatRoom[] update_data_discussion(DiscussionChatRoom[] discussion_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DiscussionChatRoom[]> update_data_discussionAsync(DiscussionChatRoom[] discussion_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual InfosQOBD[] update_data_infos(InfosQOBD[] infos_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<InfosQOBD[]> update_data_infosAsync(InfosQOBD[] infos_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ItemQOBD[] update_data_item(ItemQOBD[] item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ItemQOBD[]> update_data_itemAsync(ItemQOBD[] item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Item_deliveryQOBD[] update_data_item_delivery(Item_deliveryQOBD[] item_delivery_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Item_deliveryQOBD[]> update_data_item_deliveryAsync(Item_deliveryQOBD[] item_delivery_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual MessageChatRoom[] update_data_message(MessageChatRoom[] message_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<MessageChatRoom[]> update_data_messageAsync(MessageChatRoom[] message_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual NotificationQOBD[] update_data_notification(NotificationQOBD[] notification_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<NotificationQOBD[]> update_data_notificationAsync(NotificationQOBD[] notification_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual OrdersQOBD[] update_data_order(OrdersQOBD[] order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<OrdersQOBD[]> update_data_orderAsync(OrdersQOBD[] order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Order_itemQOBD[] update_data_order_item(Order_itemQOBD[] order_item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Order_itemQOBD[]> update_data_order_itemAsync(Order_itemQOBD[] order_item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual PrivilegeQOBD[] update_data_privilege(PrivilegeQOBD[] privilege_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<PrivilegeQOBD[]> update_data_privilegeAsync(PrivilegeQOBD[] privilege_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ProviderQOBD[] update_data_provider(ProviderQOBD[] provider_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ProviderQOBD[]> update_data_providerAsync(ProviderQOBD[] provider_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Provider_itemQOBD[] update_data_provider_item(Provider_itemQOBD[] provider_item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Provider_itemQOBD[]> update_data_provider_itemAsync(Provider_itemQOBD[] provider_item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual RoleQOBD[] update_data_role(RoleQOBD[] role_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<RoleQOBD[]> update_data_roleAsync(RoleQOBD[] role_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Role_actionQOBD[] update_data_role_action(Role_actionQOBD[] role_action_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Role_actionQOBD[]> update_data_role_actionAsync(Role_actionQOBD[] role_action_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual StatisticQOBD[] update_data_statistic(StatisticQOBD[] statistic_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<StatisticQOBD[]> update_data_statisticAsync(StatisticQOBD[] statistic_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual TaxQOBD[] update_data_tax(TaxQOBD[] tax_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<TaxQOBD[]> update_data_taxAsync(TaxQOBD[] tax_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_itemQOBD[] update_data_tax_item(Tax_itemQOBD[] tax_item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_itemQOBD[]> update_data_tax_itemAsync(Tax_itemQOBD[] tax_item_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_orderQOBD[] update_data_tax_order(Tax_orderQOBD[] tax_order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_orderQOBD[]> update_data_tax_orderAsync(Tax_orderQOBD[] tax_order_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual UserChatRoom[] update_data_user(UserChatRoom[] user_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<UserChatRoom[]> update_data_userAsync(UserChatRoom[] user_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual User_discussionChatRoom[] update_data_user_discussion(User_discussionChatRoom[] user_discussion_array_list)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<User_discussionChatRoom[]> update_data_user_discussionAsync(User_discussionChatRoom[] user_discussion_array_list)
        {
            throw new NotImplementedException();
        }
    }
}
