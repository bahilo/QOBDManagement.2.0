using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using QOBDGateway.QOBDServiceReference;
using QOBDCommon.Exceptions;

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
        public virtual LicenseQOBD[] check_license_by_company(string company_name)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<LicenseQOBD[]> check_license_by_companyAsync(string company_name)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual LicenseQOBD[] check_license_by_key(string license_key)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<LicenseQOBD[]> check_license_by_keyAsync(string license_key)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ActionQOBD[] delete_data_action(string company_name, ActionQOBD[] action_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ActionQOBD[]> delete_data_actionAsync(string company_name, ActionQOBD[] action_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ActionRecordQOBD[] delete_data_actionRecord(string company_name, ActionRecordQOBD[] actionRecord_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ActionRecordQOBD[]> delete_data_actionRecordAsync(string company_name, ActionRecordQOBD[] actionRecord_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AddressQOBD[] delete_data_address(string company_name, AddressQOBD[] address_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AddressQOBD[]> delete_data_addressAsync(string company_name, AddressQOBD[] address_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AgentQOBD[] delete_data_agent(string company_name, AgentQOBD[] agent_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AgentQOBD[]> delete_data_agentAsync(string company_name, AgentQOBD[] agent_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Agent_roleQOBD[] delete_data_agent_role(string company_name, Agent_roleQOBD[] agent_role_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Agent_roleQOBD[]> delete_data_agent_roleAsync(string company_name, Agent_roleQOBD[] agent_role_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Auto_refsQOBD[] delete_data_auto_ref(string company_name, Auto_refsQOBD[] auto_ref_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Auto_refsQOBD[]> delete_data_auto_refAsync(string company_name, Auto_refsQOBD[] auto_ref_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual BillQOBD[] delete_data_bill(string company_name, BillQOBD[] bill_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<BillQOBD[]> delete_data_billAsync(string company_name, BillQOBD[] bill_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ClientQOBD[] delete_data_client(string company_name, ClientQOBD[] client_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ClientQOBD[]> delete_data_clientAsync(string company_name, ClientQOBD[] client_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ContactQOBD[] delete_data_contact(string company_name, ContactQOBD[] contact_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ContactQOBD[]> delete_data_contactAsync(string company_name, ContactQOBD[] contact_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual CurrencyQOBD[] delete_data_currency(string company_name, CurrencyQOBD[] currency_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<CurrencyQOBD[]> delete_data_currencyAsync(string company_name, CurrencyQOBD[] currency_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DeliveryQOBD[] delete_data_delivery(string company_name, DeliveryQOBD[] delivery_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DeliveryQOBD[]> delete_data_deliveryAsync(string company_name, DeliveryQOBD[] delivery_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DiscussionChatRoom[] delete_data_discussion(string company_name, DiscussionChatRoom[] discussion_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DiscussionChatRoom[]> delete_data_discussionAsync(string company_name, DiscussionChatRoom[] discussion_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual InfosQOBD[] delete_data_infos(string company_name, InfosQOBD[] infos_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<InfosQOBD[]> delete_data_infosAsync(string company_name, InfosQOBD[] infos_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ItemQOBD[] delete_data_item(string company_name, ItemQOBD[] item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ItemQOBD[]> delete_data_itemAsync(string company_name, ItemQOBD[] item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Item_deliveryQOBD[] delete_data_item_delivery(string company_name, Item_deliveryQOBD[] item_delivery_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Item_deliveryQOBD[]> delete_data_item_deliveryAsync(string company_name, Item_deliveryQOBD[] item_delivery_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual LicenseQOBD[] delete_data_license(string company_name, LicenseQOBD[] license_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<LicenseQOBD[]> delete_data_licenseAsync(string company_name, LicenseQOBD[] license_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual MessageChatRoom[] delete_data_message(string company_name, MessageChatRoom[] message_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<MessageChatRoom[]> delete_data_messageAsync(string company_name, MessageChatRoom[] message_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual NotificationQOBD[] delete_data_notification(string company_name, NotificationQOBD[] notification_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<NotificationQOBD[]> delete_data_notificationAsync(string company_name, NotificationQOBD[] notification_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual OrdersQOBD[] delete_data_order(string company_name, OrdersQOBD[] order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<OrdersQOBD[]> delete_data_orderAsync(string company_name, OrdersQOBD[] order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Order_itemQOBD[] delete_data_order_item(string company_name, Order_itemQOBD[] order_item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Order_itemQOBD[]> delete_data_order_itemAsync(string company_name, Order_itemQOBD[] order_item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual PrivilegeQOBD[] delete_data_privilege(string company_name, PrivilegeQOBD[] privilege_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<PrivilegeQOBD[]> delete_data_privilegeAsync(string company_name, PrivilegeQOBD[] privilege_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ProviderQOBD[] delete_data_provider(string company_name, ProviderQOBD[] provider_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ProviderQOBD[]> delete_data_providerAsync(string company_name, ProviderQOBD[] provider_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Provider_itemQOBD[] delete_data_provider_item(string company_name, Provider_itemQOBD[] provider_item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Provider_itemQOBD[]> delete_data_provider_itemAsync(string company_name, Provider_itemQOBD[] provider_item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual RoleQOBD[] delete_data_role(string company_name, RoleQOBD[] role_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<RoleQOBD[]> delete_data_roleAsync(string company_name, RoleQOBD[] role_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Role_actionQOBD[] delete_data_role_action(string company_name, Role_actionQOBD[] role_action_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Role_actionQOBD[]> delete_data_role_actionAsync(string company_name, Role_actionQOBD[] role_action_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual StatisticQOBD[] delete_data_statistic(string company_name, StatisticQOBD[] statistic_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<StatisticQOBD[]> delete_data_statisticAsync(string company_name, StatisticQOBD[] statistic_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual TaxQOBD[] delete_data_tax(string company_name, TaxQOBD[] tax_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<TaxQOBD[]> delete_data_taxAsync(string company_name, TaxQOBD[] tax_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_itemQOBD[] delete_data_tax_item(string company_name, Tax_itemQOBD[] tax_item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_itemQOBD[]> delete_data_tax_itemAsync(string company_name, Tax_itemQOBD[] tax_item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_orderQOBD[] delete_data_tax_order(string company_name, Tax_orderQOBD[] tax_order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_orderQOBD[]> delete_data_tax_orderAsync(string company_name, Tax_orderQOBD[] tax_order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual UserChatRoom[] delete_data_user(string company_name, UserChatRoom[] user_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<UserChatRoom[]> delete_data_userAsync(string company_name, UserChatRoom[] user_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual User_discussionChatRoom[] delete_data_user_discussion(string company_name, User_discussionChatRoom[] user_discussion_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<User_discussionChatRoom[]> delete_data_user_discussionAsync(string company_name, User_discussionChatRoom[] user_discussion_array_list)
        {
            throw new NotApplicableException();
        }

        public virtual void generate_pdf(string company_name, PdfQOBD order_array)
        {
            throw new NotApplicableException();
        }

        public virtual Task generate_pdfAsync(string company_name, PdfQOBD order_array)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AgentQOBD[] get_authenticated_user(string company_name, string username, string password)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AgentQOBD[]> get_authenticated_userAsync(string company_name, string username, string password)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ActionQOBD[] get_data_action(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ActionQOBD[]> get_data_actionAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ActionRecordQOBD[] get_data_actionRecord(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ActionRecordQOBD[]> get_data_actionRecordAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ActionRecordQOBD[] get_data_actionRecord_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ActionRecordQOBD[]> get_data_actionRecord_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ActionQOBD[] get_data_action_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ActionQOBD[]> get_data_action_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AddressQOBD[] get_data_address(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AddressQOBD[]> get_data_addressAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AddressQOBD[] get_data_address_by_client_list(string company_name, ClientQOBD[] client_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AddressQOBD[]> get_data_address_by_client_listAsync(string company_name, ClientQOBD[] client_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AddressQOBD[] get_data_address_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AddressQOBD[]> get_data_address_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AddressQOBD[] get_data_address_by_order_list(string company_name, OrdersQOBD[] order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AddressQOBD[]> get_data_address_by_order_listAsync(string company_name, OrdersQOBD[] order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AgentQOBD[] get_data_agent(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AgentQOBD[]> get_data_agentAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AgentQOBD[] get_data_agent_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AgentQOBD[]> get_data_agent_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AgentQOBD[] get_data_agent_by_order_list(string company_name, OrdersQOBD[] order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AgentQOBD[]> get_data_agent_by_order_listAsync(string company_name, OrdersQOBD[] order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AgentQOBD[] get_data_agent_credential(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AgentQOBD[]> get_data_agent_credentialAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Agent_roleQOBD[] get_data_agent_role(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Agent_roleQOBD[]> get_data_agent_roleAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Agent_roleQOBD[] get_data_agent_role_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Agent_roleQOBD[]> get_data_agent_role_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Auto_refsQOBD[] get_data_auto_ref(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Auto_refsQOBD[]> get_data_auto_refAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Auto_refsQOBD[] get_data_auto_ref_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Auto_refsQOBD[]> get_data_auto_ref_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual BillQOBD[] get_data_bill(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<BillQOBD[]> get_data_billAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual BillQOBD[] get_data_bill_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<BillQOBD[]> get_data_bill_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual BillQOBD[] get_data_bill_by_order_list(string company_name, OrdersQOBD[] order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<BillQOBD[]> get_data_bill_by_order_listAsync(string company_name, OrdersQOBD[] order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual BillQOBD[] get_data_bill_by_unpaid(string company_name, string agent_id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<BillQOBD[]> get_data_bill_by_unpaidAsync(string company_name, string agent_id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ClientQOBD[] get_data_client(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ClientQOBD[]> get_data_clientAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ClientQOBD[] get_data_client_by_bill_list(string company_name, BillQOBD[] bill_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ClientQOBD[]> get_data_client_by_bill_listAsync(string company_name, BillQOBD[] bill_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ClientQOBD[] get_data_client_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ClientQOBD[]> get_data_client_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ClientQOBD[] get_data_client_by_max_credit_over(string company_name, string agent_id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ClientQOBD[]> get_data_client_by_max_credit_overAsync(string company_name, string agent_id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ClientQOBD[] get_data_client_by_order_list(string company_name, OrdersQOBD[] order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ClientQOBD[]> get_data_client_by_order_listAsync(string company_name, OrdersQOBD[] order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ContactQOBD[] get_data_contact(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ContactQOBD[]> get_data_contactAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ContactQOBD[] get_data_contact_by_client_list(string company_name, ClientQOBD[] client_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ContactQOBD[]> get_data_contact_by_client_listAsync(string company_name, ClientQOBD[] client_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ContactQOBD[] get_data_contact_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ContactQOBD[]> get_data_contact_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual CurrencyQOBD[] get_data_currency(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<CurrencyQOBD[]> get_data_currencyAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual CurrencyQOBD[] get_data_currency_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<CurrencyQOBD[]> get_data_currency_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual CurrencyQOBD[] get_data_currency_by_provider_item_list(string company_name, Provider_itemQOBD[] item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<CurrencyQOBD[]> get_data_currency_by_provider_item_listAsync(string company_name, Provider_itemQOBD[] item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DeliveryQOBD[] get_data_delivery(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DeliveryQOBD[]> get_data_deliveryAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DeliveryQOBD[] get_data_delivery_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DeliveryQOBD[]> get_data_delivery_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DeliveryQOBD[] get_data_delivery_by_order_list(string company_name, OrdersQOBD[] order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DeliveryQOBD[]> get_data_delivery_by_order_listAsync(string company_name, OrdersQOBD[] order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DiscussionChatRoom[] get_data_discussion(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DiscussionChatRoom[]> get_data_discussionAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DiscussionChatRoom[] get_data_discussion_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DiscussionChatRoom[]> get_data_discussion_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DiscussionChatRoom[] get_data_discussion_by_message_list(string company_name, MessageChatRoom[] message_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DiscussionChatRoom[]> get_data_discussion_by_message_listAsync(string company_name, MessageChatRoom[] message_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DiscussionChatRoom[] get_data_discussion_by_user_discussion_list(string company_name, User_discussionChatRoom[] user_discussion_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DiscussionChatRoom[]> get_data_discussion_by_user_discussion_listAsync(string company_name, User_discussionChatRoom[] user_discussion_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual InfosQOBD[] get_data_infos(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<InfosQOBD[]> get_data_infosAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual InfosQOBD[] get_data_infos_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<InfosQOBD[]> get_data_infos_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ItemQOBD[] get_data_item(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ItemQOBD[]> get_data_itemAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ItemQOBD[] get_data_item_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ItemQOBD[]> get_data_item_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ItemQOBD[] get_data_item_by_order_item_list(string company_name, Order_itemQOBD[] order_item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ItemQOBD[]> get_data_item_by_order_item_listAsync(string company_name, Order_itemQOBD[] order_item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Item_deliveryQOBD[] get_data_item_delivery(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Item_deliveryQOBD[]> get_data_item_deliveryAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Item_deliveryQOBD[] get_data_item_delivery_by_delivery_list(string company_name, DeliveryQOBD[] delivery_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Item_deliveryQOBD[]> get_data_item_delivery_by_delivery_listAsync(string company_name, DeliveryQOBD[] delivery_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Item_deliveryQOBD[] get_data_item_delivery_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Item_deliveryQOBD[]> get_data_item_delivery_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual LicenseQOBD[] get_data_license(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<LicenseQOBD[]> get_data_licenseAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual LicenseQOBD[] get_data_license_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<LicenseQOBD[]> get_data_license_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual MessageChatRoom[] get_data_message(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<MessageChatRoom[]> get_data_messageAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual MessageChatRoom[] get_data_message_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<MessageChatRoom[]> get_data_message_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual NotificationQOBD[] get_data_notification(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<NotificationQOBD[]> get_data_notificationAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual NotificationQOBD[] get_data_notification_by_client_list(string company_name, ClientQOBD[] client_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<NotificationQOBD[]> get_data_notification_by_client_listAsync(string company_name, ClientQOBD[] client_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual NotificationQOBD[] get_data_notification_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<NotificationQOBD[]> get_data_notification_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual NotificationQOBD[] get_data_notification_by_order_list(string company_name, OrdersQOBD[] order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<NotificationQOBD[]> get_data_notification_by_order_listAsync(string company_name, OrdersQOBD[] order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual OrdersQOBD[] get_data_order(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<OrdersQOBD[]> get_data_orderAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual OrdersQOBD[] get_data_order_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<OrdersQOBD[]> get_data_order_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Order_itemQOBD[] get_data_order_item(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Order_itemQOBD[]> get_data_order_itemAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Order_itemQOBD[] get_data_order_item_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Order_itemQOBD[]> get_data_order_item_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Order_itemQOBD[] get_data_order_item_by_order_list(string company_name, OrdersQOBD[] order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Order_itemQOBD[]> get_data_order_item_by_order_listAsync(string company_name, OrdersQOBD[] order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual PrivilegeQOBD[] get_data_privilege(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<PrivilegeQOBD[]> get_data_privilegeAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual PrivilegeQOBD[] get_data_privilege_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<PrivilegeQOBD[]> get_data_privilege_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ProviderQOBD[] get_data_provider(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ProviderQOBD[]> get_data_providerAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ProviderQOBD[] get_data_provider_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ProviderQOBD[]> get_data_provider_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ProviderQOBD[] get_data_provider_by_provider_item_list(string company_name, Provider_itemQOBD[] provider_item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ProviderQOBD[]> get_data_provider_by_provider_item_listAsync(string company_name, Provider_itemQOBD[] provider_item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Provider_itemQOBD[] get_data_provider_item(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Provider_itemQOBD[]> get_data_provider_itemAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Provider_itemQOBD[] get_data_provider_item_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Provider_itemQOBD[]> get_data_provider_item_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Provider_itemQOBD[] get_data_provider_item_by_item_list(string company_name, ItemQOBD[] item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Provider_itemQOBD[]> get_data_provider_item_by_item_listAsync(string company_name, ItemQOBD[] item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual RoleQOBD[] get_data_role(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<RoleQOBD[]> get_data_roleAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Role_actionQOBD[] get_data_role_action(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Role_actionQOBD[]> get_data_role_actionAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Role_actionQOBD[] get_data_role_action_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Role_actionQOBD[]> get_data_role_action_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual RoleQOBD[] get_data_role_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<RoleQOBD[]> get_data_role_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual StatisticQOBD[] get_data_statistic(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<StatisticQOBD[]> get_data_statisticAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual StatisticQOBD[] get_data_statistic_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<StatisticQOBD[]> get_data_statistic_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual TaxQOBD[] get_data_tax(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<TaxQOBD[]> get_data_taxAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual TaxQOBD[] get_data_tax_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<TaxQOBD[]> get_data_tax_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_itemQOBD[] get_data_tax_item(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_itemQOBD[]> get_data_tax_itemAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_itemQOBD[] get_data_tax_item_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_itemQOBD[]> get_data_tax_item_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_itemQOBD[] get_data_tax_item_by_item_list(string company_name, ItemQOBD[] item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_itemQOBD[]> get_data_tax_item_by_item_listAsync(string company_name, ItemQOBD[] item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_orderQOBD[] get_data_tax_order(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_orderQOBD[]> get_data_tax_orderAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_orderQOBD[] get_data_tax_order_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_orderQOBD[]> get_data_tax_order_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_orderQOBD[] get_data_tax_order_by_order_list(string company_name, OrdersQOBD[] order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_orderQOBD[]> get_data_tax_order_by_order_listAsync(string company_name, OrdersQOBD[] order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual UserChatRoom[] get_data_user(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<UserChatRoom[]> get_data_userAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual UserChatRoom[] get_data_user_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<UserChatRoom[]> get_data_user_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual UserChatRoom[] get_data_user_by_user_discussion_list(string company_name, User_discussionChatRoom[] user_discussion_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<UserChatRoom[]> get_data_user_by_user_discussion_listAsync(string company_name, User_discussionChatRoom[] user_discussion_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual User_discussionChatRoom[] get_data_user_discussion(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<User_discussionChatRoom[]> get_data_user_discussionAsync(string company_name, string nbLine)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual User_discussionChatRoom[] get_data_user_discussion_by_id(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<User_discussionChatRoom[]> get_data_user_discussion_by_idAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ActionQOBD[] get_filter_action(string company_name, ActionFilterQOBD action_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ActionQOBD[]> get_filter_actionAsync(string company_name, ActionFilterQOBD action_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ActionRecordQOBD[] get_filter_actionRecord(string company_name, ActionRecordFilterQOBD actionRecord_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ActionRecordQOBD[]> get_filter_actionRecordAsync(string company_name, ActionRecordFilterQOBD actionRecord_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AddressQOBD[] get_filter_address(string company_name, AddressFilterQOBD address_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AddressQOBD[]> get_filter_addressAsync(string company_name, AddressFilterQOBD address_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AgentQOBD[] get_filter_agent(string company_name, AgentFilterQOBD agent_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AgentQOBD[]> get_filter_agentAsync(string company_name, AgentFilterQOBD agent_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Agent_roleQOBD[] get_filter_agent_role(string company_name, Agent_roleFilterQOBD agent_role_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Agent_roleQOBD[]> get_filter_agent_roleAsync(string company_name, Agent_roleFilterQOBD agent_role_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Auto_refsQOBD[] get_filter_auto_ref(string company_name, Auto_refsFilterQOBD auto_ref_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Auto_refsQOBD[]> get_filter_auto_refAsync(string company_name, Auto_refsFilterQOBD auto_ref_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual BillQOBD[] get_filter_bill(string company_name, BillFilterQOBD bill_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<BillQOBD[]> get_filter_billAsync(string company_name, BillFilterQOBD bill_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ClientQOBD[] get_filter_Client(string company_name, ClientFilterQOBD client_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ClientQOBD[]> get_filter_ClientAsync(string company_name, ClientFilterQOBD client_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ContactQOBD[] get_filter_contact(string company_name, ContactFilterQOBD contact_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ContactQOBD[]> get_filter_contactAsync(string company_name, ContactFilterQOBD contact_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual CurrencyQOBD[] get_filter_currency(string company_name, CurrencyFilterQOBD currency_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<CurrencyQOBD[]> get_filter_currencyAsync(string company_name, CurrencyFilterQOBD currency_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DeliveryQOBD[] get_filter_delivery(string company_name, DeliveryFilterQOBD delivery_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DeliveryQOBD[]> get_filter_deliveryAsync(string company_name, DeliveryFilterQOBD delivery_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DiscussionChatRoom[] get_filter_discussion(string company_name, DiscussionFilterChatRoom discussion_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DiscussionChatRoom[]> get_filter_discussionAsync(string company_name, DiscussionFilterChatRoom discussion_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual InfosQOBD[] get_filter_infos(string company_name, InfosFilterQOBD infos_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<InfosQOBD[]> get_filter_infosAsync(string company_name, InfosFilterQOBD infos_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ItemQOBD[] get_filter_item(string company_name, ItemFilterQOBD item_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ItemQOBD[]> get_filter_itemAsync(string company_name, ItemFilterQOBD item_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Item_deliveryQOBD[] get_filter_item_delivery(string company_name, Item_deliveryFilterQOBD item_delivery_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Item_deliveryQOBD[]> get_filter_item_deliveryAsync(string company_name, Item_deliveryFilterQOBD item_delivery_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual LicenseQOBD[] get_filter_license(string company_name, LicenseFilterQOBD license_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<LicenseQOBD[]> get_filter_licenseAsync(string company_name, LicenseFilterQOBD license_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual MessageChatRoom[] get_filter_message(string company_name, MessageFilterChatRoom message_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<MessageChatRoom[]> get_filter_messageAsync(string company_name, MessageFilterChatRoom message_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual NotificationQOBD[] get_filter_notification(string company_name, NotificationFilterQOBD notification_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<NotificationQOBD[]> get_filter_notificationAsync(string company_name, NotificationFilterQOBD notification_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual OrdersQOBD[] get_filter_order(string company_name, OrderFilterQOBD order_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<OrdersQOBD[]> get_filter_orderAsync(string company_name, OrderFilterQOBD order_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Order_itemQOBD[] get_filter_order_item(string company_name, Order_itemFilterQOBD order_item_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Order_itemQOBD[]> get_filter_order_itemAsync(string company_name, Order_itemFilterQOBD order_item_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual PrivilegeQOBD[] get_filter_privilege(string company_name, PrivilegeFilterQOBD privilege_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<PrivilegeQOBD[]> get_filter_privilegeAsync(string company_name, PrivilegeFilterQOBD privilege_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ProviderQOBD[] get_filter_provider(string company_name, ProviderFilterQOBD provider_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ProviderQOBD[]> get_filter_providerAsync(string company_name, ProviderFilterQOBD provider_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Provider_itemQOBD[] get_filter_provider_item(string company_name, Provider_itemFilterQOBD provider_item_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Provider_itemQOBD[]> get_filter_provider_itemAsync(string company_name, Provider_itemFilterQOBD provider_item_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual RoleQOBD[] get_filter_role(string company_name, RoleFilterQOBD role_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<RoleQOBD[]> get_filter_roleAsync(string company_name, RoleFilterQOBD role_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Role_actionQOBD[] get_filter_role_action(string company_name, Role_actionFilterQOBD role_action_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Role_actionQOBD[]> get_filter_role_actionAsync(string company_name, Role_actionFilterQOBD role_action_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual StatisticQOBD[] get_filter_statistic(string company_name, StatisticFilterQOBD statistic_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<StatisticQOBD[]> get_filter_statisticAsync(string company_name, StatisticFilterQOBD statistic_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual TaxQOBD[] get_filter_tax(string company_name, TaxFilterQOBD tax_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<TaxQOBD[]> get_filter_taxAsync(string company_name, TaxFilterQOBD tax_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_itemQOBD[] get_filter_tax_item(string company_name, Tax_itemFilterQOBD tax_item_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_itemQOBD[]> get_filter_tax_itemAsync(string company_name, Tax_itemFilterQOBD tax_item_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_orderQOBD[] get_filter_tax_order(string company_name, Tax_orderFilterQOBD tax_order_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_orderQOBD[]> get_filter_tax_orderAsync(string company_name, Tax_orderFilterQOBD tax_order_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual UserChatRoom[] get_filter_user(string company_name, UserFilterChatRoom user_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<UserChatRoom[]> get_filter_userAsync(string company_name, UserFilterChatRoom user_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual User_discussionChatRoom[] get_filter_user_discussion(string company_name, User_discussionFilterChatRoom user_discussion_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<User_discussionChatRoom[]> get_filter_user_discussionAsync(string company_name, User_discussionFilterChatRoom user_discussion_array_list_filter)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual OrdersQOBD[] get_orders_client(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<OrdersQOBD[]> get_orders_clientAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual OrdersQOBD[] get_quotes_client(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<OrdersQOBD[]> get_quotes_clientAsync(string company_name, string id)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ActionQOBD[] insert_data_action(string company_name, ActionQOBD[] action_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ActionQOBD[]> insert_data_actionAsync(string company_name, ActionQOBD[] action_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ActionRecordQOBD[] insert_data_actionRecord(string company_name, ActionRecordQOBD[] actionRecord_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ActionRecordQOBD[]> insert_data_actionRecordAsync(string company_name, ActionRecordQOBD[] actionRecord_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AddressQOBD[] insert_data_address(string company_name, AddressQOBD[] address_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AddressQOBD[]> insert_data_addressAsync(string company_name, AddressQOBD[] address_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AgentQOBD[] insert_data_agent(string company_name, AgentQOBD[] agent_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AgentQOBD[]> insert_data_agentAsync(string company_name, AgentQOBD[] agent_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Agent_roleQOBD[] insert_data_agent_role(string company_name, Agent_roleQOBD[] agent_role_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Agent_roleQOBD[]> insert_data_agent_roleAsync(string company_name, Agent_roleQOBD[] agent_role_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Auto_refsQOBD[] insert_data_auto_ref(string company_name, Auto_refsQOBD[] auto_ref_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Auto_refsQOBD[]> insert_data_auto_refAsync(string company_name, Auto_refsQOBD[] auto_ref_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual BillQOBD[] insert_data_bill(string company_name, BillQOBD[] bill_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<BillQOBD[]> insert_data_billAsync(string company_name, BillQOBD[] bill_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ClientQOBD[] insert_data_client(string company_name, ClientQOBD[] client_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ClientQOBD[]> insert_data_clientAsync(string company_name, ClientQOBD[] client_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ContactQOBD[] insert_data_contact(string company_name, ContactQOBD[] contact_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ContactQOBD[]> insert_data_contactAsync(string company_name, ContactQOBD[] contact_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual CurrencyQOBD[] insert_data_currency(string company_name, CurrencyQOBD[] currency_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<CurrencyQOBD[]> insert_data_currencyAsync(string company_name, CurrencyQOBD[] currency_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DeliveryQOBD[] insert_data_delivery(string company_name, DeliveryQOBD[] delivery_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DeliveryQOBD[]> insert_data_deliveryAsync(string company_name, DeliveryQOBD[] delivery_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DiscussionChatRoom[] insert_data_discussion(string company_name, DiscussionChatRoom[] discussion_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DiscussionChatRoom[]> insert_data_discussionAsync(string company_name, DiscussionChatRoom[] discussion_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual InfosQOBD[] insert_data_infos(string company_name, InfosQOBD[] infos_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<InfosQOBD[]> insert_data_infosAsync(string company_name, InfosQOBD[] infos_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ItemQOBD[] insert_data_item(string company_name, ItemQOBD[] item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ItemQOBD[]> insert_data_itemAsync(string company_name, ItemQOBD[] item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Item_deliveryQOBD[] insert_data_item_delivery(string company_name, Item_deliveryQOBD[] item_delivery_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Item_deliveryQOBD[]> insert_data_item_deliveryAsync(string company_name, Item_deliveryQOBD[] item_delivery_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual LicenseQOBD[] insert_data_license(string company_name, LicenseQOBD[] license_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<LicenseQOBD[]> insert_data_licenseAsync(string company_name, LicenseQOBD[] license_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual MessageChatRoom[] insert_data_message(string company_name, MessageChatRoom[] message_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<MessageChatRoom[]> insert_data_messageAsync(string company_name, MessageChatRoom[] message_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual NotificationQOBD[] insert_data_notification(string company_name, NotificationQOBD[] notification_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<NotificationQOBD[]> insert_data_notificationAsync(string company_name, NotificationQOBD[] notification_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual OrdersQOBD[] insert_data_order(string company_name, OrdersQOBD[] order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<OrdersQOBD[]> insert_data_orderAsync(string company_name, OrdersQOBD[] order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Order_itemQOBD[] insert_data_order_item(string company_name, Order_itemQOBD[] order_item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Order_itemQOBD[]> insert_data_order_itemAsync(string company_name, Order_itemQOBD[] order_item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual PrivilegeQOBD[] insert_data_privilege(string company_name, PrivilegeQOBD[] privilege_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<PrivilegeQOBD[]> insert_data_privilegeAsync(string company_name, PrivilegeQOBD[] privilege_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ProviderQOBD[] insert_data_provider(string company_name, ProviderQOBD[] provider_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ProviderQOBD[]> insert_data_providerAsync(string company_name, ProviderQOBD[] provider_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Provider_itemQOBD[] insert_data_provider_item(string company_name, Provider_itemQOBD[] provider_item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Provider_itemQOBD[]> insert_data_provider_itemAsync(string company_name, Provider_itemQOBD[] provider_item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual RoleQOBD[] insert_data_role(string company_name, RoleQOBD[] role_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<RoleQOBD[]> insert_data_roleAsync(string company_name, RoleQOBD[] role_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Role_actionQOBD[] insert_data_role_action(string company_name, Role_actionQOBD[] role_action_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Role_actionQOBD[]> insert_data_role_actionAsync(string company_name, Role_actionQOBD[] role_action_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual StatisticQOBD[] insert_data_statistic(string company_name, StatisticQOBD[] statistic_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<StatisticQOBD[]> insert_data_statisticAsync(string company_name, StatisticQOBD[] statistic_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual TaxQOBD[] insert_data_tax(string company_name, TaxQOBD[] tax_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<TaxQOBD[]> insert_data_taxAsync(string company_name, TaxQOBD[] tax_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_itemQOBD[] insert_data_tax_item(string company_name, Tax_itemQOBD[] tax_item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_itemQOBD[]> insert_data_tax_itemAsync(string company_name, Tax_itemQOBD[] tax_item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_orderQOBD[] insert_data_tax_order(string company_name, Tax_orderQOBD[] tax_order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_orderQOBD[]> insert_data_tax_orderAsync(string company_name, Tax_orderQOBD[] tax_order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual UserChatRoom[] insert_data_user(string company_name, UserChatRoom[] user_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<UserChatRoom[]> insert_data_userAsync(string company_name, UserChatRoom[] user_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual User_discussionChatRoom[] insert_data_user_discussion(string company_name, User_discussionChatRoom[] user_discussion_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<User_discussionChatRoom[]> insert_data_user_discussionAsync(string company_name, User_discussionChatRoom[] user_discussion_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ActionQOBD[] update_data_action(string company_name, ActionQOBD[] action_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ActionQOBD[]> update_data_actionAsync(string company_name, ActionQOBD[] action_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ActionRecordQOBD[] update_data_actionRecord(string company_name, ActionRecordQOBD[] actionRecord_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ActionRecordQOBD[]> update_data_actionRecordAsync(string company_name, ActionRecordQOBD[] actionRecord_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AddressQOBD[] update_data_address(string company_name, AddressQOBD[] address_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AddressQOBD[]> update_data_addressAsync(string company_name, AddressQOBD[] address_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual AgentQOBD[] update_data_agent(string company_name, AgentQOBD[] agent_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<AgentQOBD[]> update_data_agentAsync(string company_name, AgentQOBD[] agent_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Agent_roleQOBD[] update_data_agent_role(string company_name, Agent_roleQOBD[] agent_role_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Agent_roleQOBD[]> update_data_agent_roleAsync(string company_name, Agent_roleQOBD[] agent_role_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Auto_refsQOBD[] update_data_auto_ref(string company_name, Auto_refsQOBD[] auto_ref_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Auto_refsQOBD[]> update_data_auto_refAsync(string company_name, Auto_refsQOBD[] auto_ref_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual BillQOBD[] update_data_bill(string company_name, BillQOBD[] bill_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<BillQOBD[]> update_data_billAsync(string company_name, BillQOBD[] bill_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ClientQOBD[] update_data_client(string company_name, ClientQOBD[] client_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ClientQOBD[]> update_data_clientAsync(string company_name, ClientQOBD[] client_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ContactQOBD[] update_data_contact(string company_name, ContactQOBD[] contact_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ContactQOBD[]> update_data_contactAsync(string company_name, ContactQOBD[] contact_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual CurrencyQOBD[] update_data_currency(string company_name, CurrencyQOBD[] currency_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<CurrencyQOBD[]> update_data_currencyAsync(string company_name, CurrencyQOBD[] currency_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DeliveryQOBD[] update_data_delivery(string company_name, DeliveryQOBD[] delivery_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DeliveryQOBD[]> update_data_deliveryAsync(string company_name, DeliveryQOBD[] delivery_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual DiscussionChatRoom[] update_data_discussion(string company_name, DiscussionChatRoom[] discussion_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<DiscussionChatRoom[]> update_data_discussionAsync(string company_name, DiscussionChatRoom[] discussion_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual InfosQOBD[] update_data_infos(string company_name, InfosQOBD[] infos_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<InfosQOBD[]> update_data_infosAsync(string company_name, InfosQOBD[] infos_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ItemQOBD[] update_data_item(string company_name, ItemQOBD[] item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ItemQOBD[]> update_data_itemAsync(string company_name, ItemQOBD[] item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Item_deliveryQOBD[] update_data_item_delivery(string company_insertname, Item_deliveryQOBD[] item_delivery_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Item_deliveryQOBD[]> update_data_item_deliveryAsync(string company_name, Item_deliveryQOBD[] item_delivery_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual LicenseQOBD[] update_data_license(string company_name, LicenseQOBD[] license_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<LicenseQOBD[]> update_data_licenseAsync(string company_name, LicenseQOBD[] license_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual MessageChatRoom[] update_data_message(string company_name, MessageChatRoom[] message_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<MessageChatRoom[]> update_data_messageAsync(string company_name, MessageChatRoom[] message_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual NotificationQOBD[] update_data_notification(string company_name, NotificationQOBD[] notification_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<NotificationQOBD[]> update_data_notificationAsync(string company_name, NotificationQOBD[] notification_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual OrdersQOBD[] update_data_order(string company_name, OrdersQOBD[] order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<OrdersQOBD[]> update_data_orderAsync(string company_name, OrdersQOBD[] order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Order_itemQOBD[] update_data_order_item(string company_name, Order_itemQOBD[] order_item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Order_itemQOBD[]> update_data_order_itemAsync(string company_name, Order_itemQOBD[] order_item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual PrivilegeQOBD[] update_data_privilege(string company_name, PrivilegeQOBD[] privilege_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<PrivilegeQOBD[]> update_data_privilegeAsync(string company_name, PrivilegeQOBD[] privilege_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual ProviderQOBD[] update_data_provider(string company_name, ProviderQOBD[] provider_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<ProviderQOBD[]> update_data_providerAsync(string company_name, ProviderQOBD[] provider_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Provider_itemQOBD[] update_data_provider_item(string company_name, Provider_itemQOBD[] provider_item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Provider_itemQOBD[]> update_data_provider_itemAsync(string company_name, Provider_itemQOBD[] provider_item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual RoleQOBD[] update_data_role(string company_name, RoleQOBD[] role_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<RoleQOBD[]> update_data_roleAsync(string company_name, RoleQOBD[] role_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Role_actionQOBD[] update_data_role_action(string company_name, Role_actionQOBD[] role_action_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Role_actionQOBD[]> update_data_role_actionAsync(string company_name, Role_actionQOBD[] role_action_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual StatisticQOBD[] update_data_statistic(string company_name, StatisticQOBD[] statistic_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<StatisticQOBD[]> update_data_statisticAsync(string company_name, StatisticQOBD[] statistic_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual TaxQOBD[] update_data_tax(string company_name, TaxQOBD[] tax_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<TaxQOBD[]> update_data_taxAsync(string company_name, TaxQOBD[] tax_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_itemQOBD[] update_data_tax_item(string company_name, Tax_itemQOBD[] tax_item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_itemQOBD[]> update_data_tax_itemAsync(string company_name, Tax_itemQOBD[] tax_item_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Tax_orderQOBD[] update_data_tax_order(string company_name, Tax_orderQOBD[] tax_order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<Tax_orderQOBD[]> update_data_tax_orderAsync(string company_name, Tax_orderQOBD[] tax_order_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual UserChatRoom[] update_data_user(string company_name, UserChatRoom[] user_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<UserChatRoom[]> update_data_userAsync(string company_name, UserChatRoom[] user_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual User_discussionChatRoom[] update_data_user_discussion(string company_name, User_discussionChatRoom[] user_discussion_array_list)
        {
            throw new NotApplicableException();
        }

        [return: MessageParameter(Name = "return")]
        public virtual Task<User_discussionChatRoom[]> update_data_user_discussionAsync(string company_name, User_discussionChatRoom[] user_discussion_array_list)
        {
            throw new NotApplicableException();
        }
    }
}
