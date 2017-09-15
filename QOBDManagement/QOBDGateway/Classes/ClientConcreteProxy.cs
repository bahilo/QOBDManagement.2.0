using System.Threading.Tasks;
using QOBDGateway.QOBDServiceReference;
using QOBDGateway.Abstracts;

namespace QOBDGateway.Classes
{
    public class ClientConcreteProxy : ClientProxy
    {
        public ClientConcreteProxy( string endpointConfigurationName) : 
                base( endpointConfigurationName) {
        }

        public ClientConcreteProxy(string endpointConfigurationName, string remoteAddress) : 
                base( endpointConfigurationName, remoteAddress) {
        }

        public ClientConcreteProxy(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base( endpointConfigurationName, remoteAddress) {
        }

        public ClientConcreteProxy(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }

        public override LicenseQOBD[] check_license_by_company(string company_name)
        {
            return base.Channel.check_license_by_company(company_name);
        }

        public override Task<LicenseQOBD[]> check_license_by_companyAsync(string company_name)
        {
            return base.Channel.check_license_by_companyAsync(company_name);
        }

        public override LicenseQOBD[] check_license_by_key(string license_key)
        {
            return base.Channel.check_license_by_key(license_key);
        }

        public override Task<LicenseQOBD[]> check_license_by_keyAsync(string license_key)
        {
            return base.Channel.check_license_by_keyAsync(license_key);
        }

        public override AgentQOBD[] get_authenticated_user(string companyName, string username, string password)
        {
            return base.Channel.get_authenticated_user(companyName, username, password);
        }

        public override Task<AgentQOBD[]> get_authenticated_userAsync(string companyName, string username, string password)
        {
            return base.Channel.get_authenticated_userAsync(companyName, username, password);
        }

        public override ActionQOBD[] get_data_action(string companyName, string nbLine)
        {
            return base.Channel.get_data_action(companyName, nbLine);
        }

        public override Task<ActionQOBD[]> get_data_actionAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_actionAsync(companyName, nbLine);
        }

        public override ActionQOBD[] delete_data_action(string companyName, ActionQOBD[] action_array_list)
        {
            return base.Channel.delete_data_action(companyName, action_array_list);
        }

        public override Task<ActionQOBD[]> delete_data_actionAsync(string companyName, ActionQOBD[] action_array_list)
        {
            return base.Channel.delete_data_actionAsync(companyName, action_array_list);
        }

        public override ActionQOBD[] insert_data_action(string companyName, ActionQOBD[] action_array_list)
        {
            return base.Channel.insert_data_action(companyName, action_array_list);
        }

        public override Task<ActionQOBD[]> insert_data_actionAsync(string companyName, ActionQOBD[] action_array_list)
        {
            return base.Channel.insert_data_actionAsync(companyName, action_array_list);
        }

        public override ActionQOBD[] update_data_action(string companyName, ActionQOBD[] action_array_list)
        {
            return base.Channel.update_data_action(companyName, action_array_list);
        }

        public override Task<ActionQOBD[]> update_data_actionAsync(string companyName, ActionQOBD[] action_array_list)
        {
            return base.Channel.update_data_actionAsync(companyName, action_array_list);
        }

        public override ActionQOBD[] get_data_action_by_id(string companyName, string id)
        {
            return base.Channel.get_data_action_by_id(companyName, id);
        }

        public override Task<ActionQOBD[]> get_data_action_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_action_by_idAsync(companyName, id);
        }

        public override ActionQOBD[] get_filter_action(string companyName, ActionFilterQOBD action_array_list)
        {
            return base.Channel.get_filter_action(companyName, action_array_list);
        }

        public override Task<ActionQOBD[]> get_filter_actionAsync(string companyName, ActionFilterQOBD action_array_list)
        {
            return base.Channel.get_filter_actionAsync(companyName, action_array_list);
        }

        public override Agent_roleQOBD[] get_data_agent_role(string companyName, string nbLine)
        {
            return base.Channel.get_data_agent_role(companyName, nbLine);
        }

        public override Task<Agent_roleQOBD[]> get_data_agent_roleAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_agent_roleAsync(companyName, nbLine);
        }

        public override Agent_roleQOBD[] delete_data_agent_role(string companyName, Agent_roleQOBD[] agent_role_array_list)
        {
            return base.Channel.delete_data_agent_role(companyName, agent_role_array_list);
        }

        public override Task<Agent_roleQOBD[]> delete_data_agent_roleAsync(string companyName, Agent_roleQOBD[] agent_role_array_list)
        {
            return base.Channel.delete_data_agent_roleAsync(companyName, agent_role_array_list);
        }

        public override Agent_roleQOBD[] insert_data_agent_role(string companyName, Agent_roleQOBD[] agent_role_array_list)
        {
            return base.Channel.insert_data_agent_role(companyName, agent_role_array_list);
        }

        public override Task<Agent_roleQOBD[]> insert_data_agent_roleAsync(string companyName, Agent_roleQOBD[] agent_role_array_list)
        {
            return base.Channel.insert_data_agent_roleAsync(companyName, agent_role_array_list);
        }

        public override Agent_roleQOBD[] update_data_agent_role(string companyName, Agent_roleQOBD[] agent_role_array_list)
        {
            return base.Channel.update_data_agent_role(companyName, agent_role_array_list);
        }

        public override Task<Agent_roleQOBD[]> update_data_agent_roleAsync(string companyName, Agent_roleQOBD[] agent_role_array_list)
        {
            return base.Channel.update_data_agent_roleAsync(companyName, agent_role_array_list);
        }

        public override Agent_roleQOBD[] get_data_agent_role_by_id(string companyName, string id)
        {
            return base.Channel.get_data_agent_role_by_id(companyName, id);
        }

        public override Task<Agent_roleQOBD[]> get_data_agent_role_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_agent_role_by_idAsync(companyName, id);
        }

        public override Agent_roleQOBD[] get_filter_agent_role(string companyName, Agent_roleFilterQOBD agent_role_array_list)
        {
            return base.Channel.get_filter_agent_role(companyName, agent_role_array_list);
        }

        public override Task<Agent_roleQOBD[]> get_filter_agent_roleAsync(string companyName, Agent_roleFilterQOBD agent_role_array_list)
        {
            return base.Channel.get_filter_agent_roleAsync(companyName, agent_role_array_list);
        }

        public override RoleQOBD[] get_data_role(string companyName, string nbLine)
        {
            return base.Channel.get_data_role(companyName, nbLine);
        }

        public override Task<RoleQOBD[]> get_data_roleAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_roleAsync(companyName, nbLine);
        }

        public override RoleQOBD[] delete_data_role(string companyName, RoleQOBD[] role_array_list)
        {
            return base.Channel.delete_data_role(companyName, role_array_list);
        }

        public override Task<RoleQOBD[]> delete_data_roleAsync(string companyName, RoleQOBD[] role_array_list)
        {
            return base.Channel.delete_data_roleAsync(companyName, role_array_list);
        }

        public override RoleQOBD[] insert_data_role(string companyName, RoleQOBD[] role_array_list)
        {
            return base.Channel.insert_data_role(companyName, role_array_list);
        }

        public override Task<RoleQOBD[]> insert_data_roleAsync(string companyName, RoleQOBD[] role_array_list)
        {
            return base.Channel.insert_data_roleAsync(companyName, role_array_list);
        }

        public override RoleQOBD[] update_data_role(string companyName, RoleQOBD[] role_array_list)
        {
            return base.Channel.update_data_role(companyName, role_array_list);
        }

        public override Task<RoleQOBD[]> update_data_roleAsync(string companyName, RoleQOBD[] role_array_list)
        {
            return base.Channel.update_data_roleAsync(companyName, role_array_list);
        }

        public override RoleQOBD[] get_data_role_by_id(string companyName, string id)
        {
            return base.Channel.get_data_role_by_id(companyName, id);
        }

        public override Task<RoleQOBD[]> get_data_role_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_role_by_idAsync(companyName, id);
        }

        public override RoleQOBD[] get_filter_role(string companyName, RoleFilterQOBD role_array_list)
        {
            return base.Channel.get_filter_role(companyName, role_array_list);
        }

        public override Task<RoleQOBD[]> get_filter_roleAsync(string companyName, RoleFilterQOBD role_array_list)
        {
            return base.Channel.get_filter_roleAsync(companyName, role_array_list);
        }

        public override Role_actionQOBD[] get_data_role_action(string companyName, string nbLine)
        {
            return base.Channel.get_data_role_action(companyName, nbLine);
        }

        public override Task<Role_actionQOBD[]> get_data_role_actionAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_role_actionAsync(companyName, nbLine);
        }

        public override Role_actionQOBD[] delete_data_role_action(string companyName, Role_actionQOBD[] role_action_array_list)
        {
            return base.Channel.delete_data_role_action(companyName, role_action_array_list);
        }

        public override Task<Role_actionQOBD[]> delete_data_role_actionAsync(string companyName, Role_actionQOBD[] role_action_array_list)
        {
            return base.Channel.delete_data_role_actionAsync(companyName, role_action_array_list);
        }

        public override Role_actionQOBD[] insert_data_role_action(string companyName, Role_actionQOBD[] role_action_array_list)
        {
            return base.Channel.insert_data_role_action(companyName, role_action_array_list);
        }

        public override Task<Role_actionQOBD[]> insert_data_role_actionAsync(string companyName, Role_actionQOBD[] role_action_array_list)
        {
            return base.Channel.insert_data_role_actionAsync(companyName, role_action_array_list);
        }

        public override Role_actionQOBD[] update_data_role_action(string companyName, Role_actionQOBD[] role_action_array_list)
        {
            return base.Channel.update_data_role_action(companyName, role_action_array_list);
        }

        public override Task<Role_actionQOBD[]> update_data_role_actionAsync(string companyName, Role_actionQOBD[] role_action_array_list)
        {
            return base.Channel.update_data_role_actionAsync(companyName, role_action_array_list);
        }

        public override Role_actionQOBD[] get_data_role_action_by_id(string companyName, string id)
        {
            return base.Channel.get_data_role_action_by_id(companyName, id);
        }

        public override Task<Role_actionQOBD[]> get_data_role_action_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_role_action_by_idAsync(companyName, id);
        }

        public override Role_actionQOBD[] get_filter_role_action(string companyName, Role_actionFilterQOBD role_action_array_list)
        {
            return base.Channel.get_filter_role_action(companyName, role_action_array_list);
        }

        public override Task<Role_actionQOBD[]> get_filter_role_actionAsync(string companyName, Role_actionFilterQOBD role_action_array_list)
        {
            return base.Channel.get_filter_role_actionAsync(companyName, role_action_array_list);
        }

        public override BillQOBD[] get_data_bill(string companyName, string nbLine)
        {
            return base.Channel.get_data_bill(companyName, nbLine);
        }

        public override Task<BillQOBD[]> get_data_billAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_billAsync(companyName, nbLine);
        }

        public override BillQOBD[] delete_data_bill(string companyName, BillQOBD[] bill_array_list)
        {
            return base.Channel.delete_data_bill(companyName, bill_array_list);
        }

        public override Task<BillQOBD[]> delete_data_billAsync(string companyName, BillQOBD[] bill_array_list)
        {
            return base.Channel.delete_data_billAsync(companyName, bill_array_list);
        }

        public override BillQOBD[] insert_data_bill(string companyName, BillQOBD[] bill_array_list)
        {
            return base.Channel.insert_data_bill(companyName, bill_array_list);
        }

        public override Task<BillQOBD[]> insert_data_billAsync(string companyName, BillQOBD[] bill_array_list)
        {
            return base.Channel.insert_data_billAsync(companyName, bill_array_list);
        }

        public override BillQOBD[] update_data_bill(string companyName, BillQOBD[] bill_array_list)
        {
            return base.Channel.update_data_bill(companyName, bill_array_list);
        }

        public override Task<BillQOBD[]> update_data_billAsync(string companyName, BillQOBD[] bill_array_list)
        {
            return base.Channel.update_data_billAsync(companyName, bill_array_list);
        }

        public override BillQOBD[] get_data_bill_by_id(string companyName, string id)
        {
            return base.Channel.get_data_bill_by_id(companyName, id);
        }

        public override Task<BillQOBD[]> get_data_bill_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_bill_by_idAsync(companyName, id);
        }

        public override BillQOBD[] get_filter_bill(string companyName, BillFilterQOBD bill_array_list)
        {
            return base.Channel.get_filter_bill(companyName, bill_array_list);
        }

        public override Task<BillQOBD[]> get_filter_billAsync(string companyName, BillFilterQOBD bill_array_list)
        {
            return base.Channel.get_filter_billAsync(companyName, bill_array_list);
        }

        public override BillQOBD[] get_data_bill_by_order_list(string companyName, OrdersQOBD[] order_array_list)
        {
            return base.Channel.get_data_bill_by_order_list(companyName, order_array_list);
        }

        public override Task<BillQOBD[]> get_data_bill_by_order_listAsync(string companyName, OrdersQOBD[] order_array_list)
        {
            return base.Channel.get_data_bill_by_order_listAsync(companyName, order_array_list);
        }

        public override BillQOBD[] get_data_bill_by_unpaid(string companyName, string agent_id)
        {
            return base.Channel.get_data_bill_by_unpaid(companyName, agent_id);
        }

        public override Task<BillQOBD[]> get_data_bill_by_unpaidAsync(string companyName, string agent_id)
        {
            return base.Channel.get_data_bill_by_unpaidAsync(companyName, agent_id);
        }

        public override OrdersQOBD[] get_data_order(string companyName, string nbLine)
        {
            return base.Channel.get_data_order(companyName, nbLine);
        }

        public override Task<OrdersQOBD[]> get_data_orderAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_orderAsync(companyName, nbLine);
        }

        public override OrdersQOBD[] delete_data_order(string companyName, OrdersQOBD[] order_array_list)
        {
            return base.Channel.delete_data_order(companyName, order_array_list);
        }

        public override Task<OrdersQOBD[]> delete_data_orderAsync(string companyName, OrdersQOBD[] order_array_list)
        {
            return base.Channel.delete_data_orderAsync(companyName, order_array_list);
        }

        public override OrdersQOBD[] insert_data_order(string companyName, OrdersQOBD[] order_array_list)
        {
            return base.Channel.insert_data_order(companyName, order_array_list);
        }

        public override Task<OrdersQOBD[]> insert_data_orderAsync(string companyName, OrdersQOBD[] order_array_list)
        {
            return base.Channel.insert_data_orderAsync(companyName, order_array_list);
        }

        public override OrdersQOBD[] update_data_order(string companyName, OrdersQOBD[] order_array_list)
        {
            return base.Channel.update_data_order(companyName, order_array_list);
        }

        public override Task<OrdersQOBD[]> update_data_orderAsync(string companyName, OrdersQOBD[] order_array_list)
        {
            return base.Channel.update_data_orderAsync(companyName, order_array_list);
        }

        public override OrdersQOBD[] get_data_order_by_id(string companyName, string id)
        {
            return base.Channel.get_data_order_by_id(companyName, id);
        }

        public override Task<OrdersQOBD[]> get_data_order_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_order_by_idAsync(companyName, id);
        }

        public override OrdersQOBD[] get_filter_order(string companyName, OrderFilterQOBD order_array_list_filter)
        {
            return base.Channel.get_filter_order(companyName, order_array_list_filter);
        }

        public override Task<OrdersQOBD[]> get_filter_orderAsync(string companyName, OrderFilterQOBD order_array_list_filter)
        {
            return base.Channel.get_filter_orderAsync(companyName, order_array_list_filter);
        }

        public override void generate_pdf(string companyName, PdfQOBD order_array)
        {
            base.Channel.generate_pdf(companyName, order_array);
        }

        public override Task generate_pdfAsync(string companyName, PdfQOBD order_array)
        {
            return base.Channel.generate_pdfAsync(companyName, order_array);
        }

        public override AgentQOBD[] get_data_agent(string companyName, string nbLine)
        {
            return base.Channel.get_data_agent(companyName, nbLine);
        }

        public override Task<AgentQOBD[]> get_data_agentAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_agentAsync(companyName, nbLine);
        }

        public override AgentQOBD[] get_data_agent_credential(string companyName, string nbLine)
        {
            return base.Channel.get_data_agent_credential(companyName, nbLine);
        }

        public override Task<AgentQOBD[]> get_data_agent_credentialAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_agent_credentialAsync(companyName, nbLine);
        }

        public override AgentQOBD[] delete_data_agent(string companyName, AgentQOBD[] agent_array_list)
        {
            return base.Channel.delete_data_agent(companyName, agent_array_list);
        }

        public override Task<AgentQOBD[]> delete_data_agentAsync(string companyName, AgentQOBD[] agent_array_list)
        {
            return base.Channel.delete_data_agentAsync(companyName, agent_array_list);
        }

        public override AgentQOBD[] insert_data_agent(string companyName, AgentQOBD[] agent_array_list)
        {
            return base.Channel.insert_data_agent(companyName, agent_array_list);
        }

        public override Task<AgentQOBD[]> insert_data_agentAsync(string companyName, AgentQOBD[] agent_array_list)
        {
            return base.Channel.insert_data_agentAsync(companyName, agent_array_list);
        }

        public override AgentQOBD[] update_data_agent(string companyName, AgentQOBD[] agent_array_list)
        {
            return base.Channel.update_data_agent(companyName, agent_array_list);
        }

        public override Task<AgentQOBD[]> update_data_agentAsync(string companyName, AgentQOBD[] agent_array_list)
        {
            return base.Channel.update_data_agentAsync(companyName, agent_array_list);
        }

        public override AgentQOBD[] get_data_agent_by_id(string companyName, string id)
        {
            return base.Channel.get_data_agent_by_id(companyName, id);
        }

        public override Task<AgentQOBD[]> get_data_agent_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_agent_by_idAsync(companyName, id);
        }

        public override AgentQOBD[] get_filter_agent(string companyName, AgentFilterQOBD agent_array_list_filter)
        {
            return base.Channel.get_filter_agent(companyName, agent_array_list_filter);
        }

        public override Task<AgentQOBD[]> get_filter_agentAsync(string companyName, AgentFilterQOBD agent_array_list_filter)
        {
            return base.Channel.get_filter_agentAsync(companyName, agent_array_list_filter);
        }

        public override AgentQOBD[] get_data_agent_by_order_list(string companyName, OrdersQOBD[] order_array_list)
        {
            return base.Channel.get_data_agent_by_order_list(companyName, order_array_list);
        }

        public override Task<AgentQOBD[]> get_data_agent_by_order_listAsync(string companyName, OrdersQOBD[] order_array_list)
        {
            return base.Channel.get_data_agent_by_order_listAsync(companyName, order_array_list);
        }

        public override StatisticQOBD[] get_data_statistic(string companyName, string nbLine)
        {
            return base.Channel.get_data_statistic(companyName, nbLine);
        }

        public override Task<StatisticQOBD[]> get_data_statisticAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_statisticAsync(companyName, nbLine);
        }

        public override StatisticQOBD[] delete_data_statistic(string companyName, StatisticQOBD[] statistic_array_list)
        {
            return base.Channel.delete_data_statistic(companyName, statistic_array_list);
        }

        public override Task<StatisticQOBD[]> delete_data_statisticAsync(string companyName, StatisticQOBD[] statistic_array_list)
        {
            return base.Channel.delete_data_statisticAsync(companyName, statistic_array_list);
        }

        public override StatisticQOBD[] insert_data_statistic(string companyName, StatisticQOBD[] statistic_array_list)
        {
            return base.Channel.insert_data_statistic(companyName, statistic_array_list);
        }

        public override Task<StatisticQOBD[]> insert_data_statisticAsync(string companyName, StatisticQOBD[] statistic_array_list)
        {
            return base.Channel.insert_data_statisticAsync(companyName, statistic_array_list);
        }

        public override StatisticQOBD[] update_data_statistic(string companyName, StatisticQOBD[] statistic_array_list)
        {
            return base.Channel.update_data_statistic(companyName, statistic_array_list);
        }

        public override Task<StatisticQOBD[]> update_data_statisticAsync(string companyName, StatisticQOBD[] statistic_array_list)
        {
            return base.Channel.update_data_statisticAsync(companyName, statistic_array_list);
        }

        public override StatisticQOBD[] get_data_statistic_by_id(string companyName, string id)
        {
            return base.Channel.get_data_statistic_by_id(companyName, id);
        }

        public override Task<StatisticQOBD[]> get_data_statistic_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_statistic_by_idAsync(companyName, id);
        }

        public override StatisticQOBD[] get_filter_statistic(string companyName, StatisticFilterQOBD statistic_array_list_filter)
        {
            return base.Channel.get_filter_statistic(companyName, statistic_array_list_filter);
        }

        public override Task<StatisticQOBD[]> get_filter_statisticAsync(string companyName, StatisticFilterQOBD statistic_array_list_filter)
        {
            return base.Channel.get_filter_statisticAsync(companyName, statistic_array_list_filter);
        }

        public override ItemQOBD[] get_data_item(string companyName, string nbLine)
        {
            return base.Channel.get_data_item(companyName, nbLine);
        }

        public override Task<ItemQOBD[]> get_data_itemAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_itemAsync(companyName, nbLine);
        }

        public override ItemQOBD[] delete_data_item(string companyName, ItemQOBD[] item_array_list)
        {
            return base.Channel.delete_data_item(companyName, item_array_list);
        }

        public override Task<ItemQOBD[]> delete_data_itemAsync(string companyName, ItemQOBD[] item_array_list)
        {
            return base.Channel.delete_data_itemAsync(companyName, item_array_list);
        }

        public override ItemQOBD[] insert_data_item(string companyName, ItemQOBD[] item_array_list)
        {
            return base.Channel.insert_data_item(companyName, item_array_list);
        }

        public override Task<ItemQOBD[]> insert_data_itemAsync(string companyName, ItemQOBD[] item_array_list)
        {
            return base.Channel.insert_data_itemAsync(companyName, item_array_list);
        }

        public override ItemQOBD[] update_data_item(string companyName, ItemQOBD[] item_array_list)
        {
            return base.Channel.update_data_item(companyName, item_array_list);
        }

        public override Task<ItemQOBD[]> update_data_itemAsync(string companyName, ItemQOBD[] item_array_list)
        {
            return base.Channel.update_data_itemAsync(companyName, item_array_list);
        }

        public override ItemQOBD[] get_data_item_by_id(string companyName, string id)
        {
            return base.Channel.get_data_item_by_id(companyName, id);
        }

        public override Task<ItemQOBD[]> get_data_item_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_item_by_idAsync(companyName, id);
        }

        public override ItemQOBD[] get_filter_item(string companyName, ItemFilterQOBD item_array_list_filter)
        {
            return base.Channel.get_filter_item(companyName, item_array_list_filter);
        }

        public override Task<ItemQOBD[]> get_filter_itemAsync(string companyName, ItemFilterQOBD item_array_list_filter)
        {
            return base.Channel.get_filter_itemAsync(companyName, item_array_list_filter);
        }

        public override ItemQOBD[] get_data_item_by_order_item_list(string companyName, Order_itemQOBD[] order_item_array_list)
        {
            return base.Channel.get_data_item_by_order_item_list(companyName, order_item_array_list);
        }

        public override Task<ItemQOBD[]> get_data_item_by_order_item_listAsync(string companyName, Order_itemQOBD[] order_item_array_list)
        {
            return base.Channel.get_data_item_by_order_item_listAsync(companyName, order_item_array_list);
        }

        public override ClientQOBD[] get_data_client(string companyName, string nbLine)
        {
            return base.Channel.get_data_client(companyName, nbLine);
        }

        public override Task<ClientQOBD[]> get_data_clientAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_clientAsync(companyName, nbLine);
        }

        public override ClientQOBD[] delete_data_client(string companyName, ClientQOBD[] client_array_list)
        {
            return base.Channel.delete_data_client(companyName, client_array_list);
        }

        public override Task<ClientQOBD[]> delete_data_clientAsync(string companyName, ClientQOBD[] client_array_list)
        {
            return base.Channel.delete_data_clientAsync(companyName, client_array_list);
        }

        public override ClientQOBD[] insert_data_client(string companyName, ClientQOBD[] client_array_list)
        {
            return base.Channel.insert_data_client(companyName, client_array_list);
        }

        public override Task<ClientQOBD[]> insert_data_clientAsync(string companyName, ClientQOBD[] client_array_list)
        {
            return base.Channel.insert_data_clientAsync(companyName, client_array_list);
        }

        public override ClientQOBD[] update_data_client(string companyName, ClientQOBD[] client_array_list)
        {
            return base.Channel.update_data_client(companyName, client_array_list);
        }

        public override Task<ClientQOBD[]> update_data_clientAsync(string companyName, ClientQOBD[] client_array_list)
        {
            return base.Channel.update_data_clientAsync(companyName, client_array_list);
        }

        public override ClientQOBD[] get_data_client_by_id(string companyName, string id)
        {
            return base.Channel.get_data_client_by_id(companyName, id);
        }

        public override Task<ClientQOBD[]> get_data_client_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_client_by_idAsync(companyName, id);
        }

        public override ClientQOBD[] get_filter_Client(string companyName, ClientFilterQOBD client_array_list_filter)
        {
            return base.Channel.get_filter_Client(companyName, client_array_list_filter);
        }

        public override Task<ClientQOBD[]> get_filter_ClientAsync(string companyName, ClientFilterQOBD client_array_list_filter)
        {
            return base.Channel.get_filter_ClientAsync(companyName, client_array_list_filter);
        }

        public override OrdersQOBD[] get_quotes_client(string companyName, string id)
        {
            return base.Channel.get_quotes_client(companyName, id);
        }

        public override Task<OrdersQOBD[]> get_quotes_clientAsync(string companyName, string id)
        {
            return base.Channel.get_quotes_clientAsync(companyName, id);
        }

        public override OrdersQOBD[] get_orders_client(string companyName, string id)
        {
            return base.Channel.get_orders_client(companyName, id);
        }

        public override Task<OrdersQOBD[]> get_orders_clientAsync(string companyName, string id)
        {
            return base.Channel.get_orders_clientAsync(companyName, id);
        }

        public override ClientQOBD[] get_data_client_by_bill_list(string companyName, BillQOBD[] bill_array_list)
        {
            return base.Channel.get_data_client_by_bill_list(companyName, bill_array_list);
        }

        public override Task<ClientQOBD[]> get_data_client_by_bill_listAsync(string companyName, BillQOBD[] bill_array_list)
        {
            return base.Channel.get_data_client_by_bill_listAsync(companyName, bill_array_list);
        }

        public override ClientQOBD[] get_data_client_by_order_list(string companyName, OrdersQOBD[] order_array_list)
        {
            return base.Channel.get_data_client_by_order_list(companyName, order_array_list);
        }

        public override Task<ClientQOBD[]> get_data_client_by_order_listAsync(string companyName, OrdersQOBD[] order_array_list)
        {
            return base.Channel.get_data_client_by_order_listAsync(companyName, order_array_list);
        }

        public override ClientQOBD[] get_data_client_by_max_credit_over(string companyName, string agent_id)
        {
            return base.Channel.get_data_client_by_max_credit_over(companyName, agent_id);
        }

        public override Task<ClientQOBD[]> get_data_client_by_max_credit_overAsync(string companyName, string agent_id)
        {
            return base.Channel.get_data_client_by_max_credit_overAsync(companyName, agent_id);
        }

        public override ActionRecordQOBD[] get_data_actionRecord(string companyName, string nbLine)
        {
            return base.Channel.get_data_actionRecord(companyName, nbLine);
        }

        public override Task<ActionRecordQOBD[]> get_data_actionRecordAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_actionRecordAsync(companyName, nbLine);
        }

        public override ActionRecordQOBD[] delete_data_actionRecord(string companyName, ActionRecordQOBD[] actionRecord_array_list)
        {
            return base.Channel.delete_data_actionRecord(companyName, actionRecord_array_list);
        }

        public override Task<ActionRecordQOBD[]> delete_data_actionRecordAsync(string companyName, ActionRecordQOBD[] actionRecord_array_list)
        {
            return base.Channel.delete_data_actionRecordAsync(companyName, actionRecord_array_list);
        }

        public override ActionRecordQOBD[] insert_data_actionRecord(string companyName, ActionRecordQOBD[] actionRecord_array_list)
        {
            return base.Channel.insert_data_actionRecord(companyName, actionRecord_array_list);
        }

        public override Task<ActionRecordQOBD[]> insert_data_actionRecordAsync(string companyName, ActionRecordQOBD[] actionRecord_array_list)
        {
            return base.Channel.insert_data_actionRecordAsync(companyName, actionRecord_array_list);
        }

        public override ActionRecordQOBD[] update_data_actionRecord(string companyName, ActionRecordQOBD[] actionRecord_array_list)
        {
            return base.Channel.update_data_actionRecord(companyName, actionRecord_array_list);
        }

        public override Task<ActionRecordQOBD[]> update_data_actionRecordAsync(string companyName, ActionRecordQOBD[] actionRecord_array_list)
        {
            return base.Channel.update_data_actionRecordAsync(companyName, actionRecord_array_list);
        }

        public override ActionRecordQOBD[] get_data_actionRecord_by_id(string companyName, string id)
        {
            return base.Channel.get_data_actionRecord_by_id(companyName, id);
        }

        public override Task<ActionRecordQOBD[]> get_data_actionRecord_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_actionRecord_by_idAsync(companyName, id);
        }

        public override ActionRecordQOBD[] get_filter_actionRecord(string companyName, ActionRecordFilterQOBD actionRecord_array_list)
        {
            return base.Channel.get_filter_actionRecord(companyName, actionRecord_array_list);
        }

        public override Task<ActionRecordQOBD[]> get_filter_actionRecordAsync(string companyName, ActionRecordFilterQOBD actionRecord_array_list)
        {
            return base.Channel.get_filter_actionRecordAsync(companyName, actionRecord_array_list);
        }

        public override AddressQOBD[] get_data_address(string companyName, string nbLine)
        {
            return base.Channel.get_data_address(companyName, nbLine);
        }

        public override Task<AddressQOBD[]> get_data_addressAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_addressAsync(companyName, nbLine);
        }

        public override AddressQOBD[] delete_data_address(string companyName, AddressQOBD[] address_array_list)
        {
            return base.Channel.delete_data_address(companyName, address_array_list);
        }

        public override Task<AddressQOBD[]> delete_data_addressAsync(string companyName, AddressQOBD[] address_array_list)
        {
            return base.Channel.delete_data_addressAsync(companyName, address_array_list);
        }

        public override AddressQOBD[] insert_data_address(string companyName, AddressQOBD[] address_array_list)
        {
            return base.Channel.insert_data_address(companyName, address_array_list);
        }

        public override Task<AddressQOBD[]> insert_data_addressAsync(string companyName, AddressQOBD[] address_array_list)
        {
            return base.Channel.insert_data_addressAsync(companyName, address_array_list);
        }

        public override AddressQOBD[] update_data_address(string companyName, AddressQOBD[] address_array_list)
        {
            return base.Channel.update_data_address(companyName, address_array_list);
        }

        public override Task<AddressQOBD[]> update_data_addressAsync(string companyName, AddressQOBD[] address_array_list)
        {
            return base.Channel.update_data_addressAsync(companyName, address_array_list);
        }

        public override AddressQOBD[] get_data_address_by_id(string companyName, string id)
        {
            return base.Channel.get_data_address_by_id(companyName, id);
        }

        public override Task<AddressQOBD[]> get_data_address_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_address_by_idAsync(companyName, id);
        }

        public override AddressQOBD[] get_filter_address(string companyName, AddressFilterQOBD address_array_list)
        {
            return base.Channel.get_filter_address(companyName, address_array_list);
        }

        public override Task<AddressQOBD[]> get_filter_addressAsync(string companyName, AddressFilterQOBD address_array_list)
        {
            return base.Channel.get_filter_addressAsync(companyName, address_array_list);
        }

        public override AddressQOBD[] get_data_address_by_order_list(string companyName, OrdersQOBD[] order_array_list)
        {
            return base.Channel.get_data_address_by_order_list(companyName, order_array_list);
        }

        public override Task<AddressQOBD[]> get_data_address_by_order_listAsync(string companyName, OrdersQOBD[] order_array_list)
        {
            return base.Channel.get_data_address_by_order_listAsync(companyName, order_array_list);
        }

        public override AddressQOBD[] get_data_address_by_client_list(string companyName, ClientQOBD[] client_array_list)
        {
            return base.Channel.get_data_address_by_client_list(companyName, client_array_list);
        }

        public override Task<AddressQOBD[]> get_data_address_by_client_listAsync(string companyName, ClientQOBD[] client_array_list)
        {
            return base.Channel.get_data_address_by_client_listAsync(companyName, client_array_list);
        }

        public override Order_itemQOBD[] get_data_order_item(string companyName, string nbLine)
        {
            return base.Channel.get_data_order_item(companyName, nbLine);
        }

        public override Task<Order_itemQOBD[]> get_data_order_itemAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_order_itemAsync(companyName, nbLine);
        }

        public override Order_itemQOBD[] delete_data_order_item(string companyName, Order_itemQOBD[] order_item_array_list)
        {
            return base.Channel.delete_data_order_item(companyName, order_item_array_list);
        }

        public override Task<Order_itemQOBD[]> delete_data_order_itemAsync(string companyName, Order_itemQOBD[] order_item_array_list)
        {
            return base.Channel.delete_data_order_itemAsync(companyName, order_item_array_list);
        }

        public override Order_itemQOBD[] insert_data_order_item(string companyName, Order_itemQOBD[] order_item_array_list)
        {
            return base.Channel.insert_data_order_item(companyName, order_item_array_list);
        }

        public override Task<Order_itemQOBD[]> insert_data_order_itemAsync(string companyName, Order_itemQOBD[] order_item_array_list)
        {
            return base.Channel.insert_data_order_itemAsync(companyName, order_item_array_list);
        }

        public override Order_itemQOBD[] update_data_order_item(string companyName, Order_itemQOBD[] order_item_array_list)
        {
            return base.Channel.update_data_order_item(companyName, order_item_array_list);
        }

        public override Task<Order_itemQOBD[]> update_data_order_itemAsync(string companyName, Order_itemQOBD[] order_item_array_list)
        {
            return base.Channel.update_data_order_itemAsync(companyName, order_item_array_list);
        }

        public override Order_itemQOBD[] get_data_order_item_by_id(string companyName, string id)
        {
            return base.Channel.get_data_order_item_by_id(companyName, id);
        }

        public override Task<Order_itemQOBD[]> get_data_order_item_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_order_item_by_idAsync(companyName, id);
        }

        public override Order_itemQOBD[] get_filter_order_item(string companyName, Order_itemFilterQOBD order_item_array_list_filter)
        {
            return base.Channel.get_filter_order_item(companyName, order_item_array_list_filter);
        }

        public override Task<Order_itemQOBD[]> get_filter_order_itemAsync(string companyName, Order_itemFilterQOBD order_item_array_list_filter)
        {
            return base.Channel.get_filter_order_itemAsync(companyName, order_item_array_list_filter);
        }

        public override Order_itemQOBD[] get_data_order_item_by_order_list(string companyName, OrdersQOBD[] order_array_list)
        {
            return base.Channel.get_data_order_item_by_order_list(companyName, order_array_list);
        }

        public override Task<Order_itemQOBD[]> get_data_order_item_by_order_listAsync(string companyName, OrdersQOBD[] order_array_list)
        {
            return base.Channel.get_data_order_item_by_order_listAsync(companyName, order_array_list);
        }

        public override ContactQOBD[] get_data_contact(string companyName, string nbLine)
        {
            return base.Channel.get_data_contact(companyName, nbLine);
        }

        public override Task<ContactQOBD[]> get_data_contactAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_contactAsync(companyName, nbLine);
        }

        public override ContactQOBD[] delete_data_contact(string companyName, ContactQOBD[] contact_array_list)
        {
            return base.Channel.delete_data_contact(companyName, contact_array_list);
        }

        public override Task<ContactQOBD[]> delete_data_contactAsync(string companyName, ContactQOBD[] contact_array_list)
        {
            return base.Channel.delete_data_contactAsync(companyName, contact_array_list);
        }

        public override ContactQOBD[] insert_data_contact(string companyName, ContactQOBD[] contact_array_list)
        {
            return base.Channel.insert_data_contact(companyName, contact_array_list);
        }

        public override Task<ContactQOBD[]> insert_data_contactAsync(string companyName, ContactQOBD[] contact_array_list)
        {
            return base.Channel.insert_data_contactAsync(companyName, contact_array_list);
        }

        public override ContactQOBD[] update_data_contact(string companyName, ContactQOBD[] contact_array_list)
        {
            return base.Channel.update_data_contact(companyName, contact_array_list);
        }

        public override Task<ContactQOBD[]> update_data_contactAsync(string companyName, ContactQOBD[] contact_array_list)
        {
            return base.Channel.update_data_contactAsync(companyName, contact_array_list);
        }

        public override ContactQOBD[] get_data_contact_by_id(string companyName, string id)
        {
            return base.Channel.get_data_contact_by_id(companyName, id);
        }

        public override Task<ContactQOBD[]> get_data_contact_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_contact_by_idAsync(companyName, id);
        }

        public override ContactQOBD[] get_filter_contact(string companyName, ContactFilterQOBD contact_array_list_filter)
        {
            return base.Channel.get_filter_contact(companyName, contact_array_list_filter);
        }

        public override Task<ContactQOBD[]> get_filter_contactAsync(string companyName, ContactFilterQOBD contact_array_list_filter)
        {
            return base.Channel.get_filter_contactAsync(companyName, contact_array_list_filter);
        }

        public override ContactQOBD[] get_data_contact_by_client_list(string companyName, ClientQOBD[] client_array_list)
        {
            return base.Channel.get_data_contact_by_client_list(companyName, client_array_list);
        }

        public override Task<ContactQOBD[]> get_data_contact_by_client_listAsync(string companyName, ClientQOBD[] client_array_list)
        {
            return base.Channel.get_data_contact_by_client_listAsync(companyName, client_array_list);
        }

        public override DeliveryQOBD[] get_data_delivery(string companyName, string nbLine)
        {
            return base.Channel.get_data_delivery(companyName, nbLine);
        }

        public override Task<DeliveryQOBD[]> get_data_deliveryAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_deliveryAsync(companyName, nbLine);
        }

        public override DeliveryQOBD[] delete_data_delivery(string companyName, DeliveryQOBD[] delivery_array_list)
        {
            return base.Channel.delete_data_delivery(companyName, delivery_array_list);
        }

        public override Task<DeliveryQOBD[]> delete_data_deliveryAsync(string companyName, DeliveryQOBD[] delivery_array_list)
        {
            return base.Channel.delete_data_deliveryAsync(companyName, delivery_array_list);
        }

        public override DeliveryQOBD[] insert_data_delivery(string companyName, DeliveryQOBD[] delivery_array_list)
        {
            return base.Channel.insert_data_delivery(companyName, delivery_array_list);
        }

        public override Task<DeliveryQOBD[]> insert_data_deliveryAsync(string companyName, DeliveryQOBD[] delivery_array_list)
        {
            return base.Channel.insert_data_deliveryAsync(companyName, delivery_array_list);
        }

        public override DeliveryQOBD[] update_data_delivery(string companyName, DeliveryQOBD[] delivery_array_list)
        {
            return base.Channel.update_data_delivery(companyName, delivery_array_list);
        }

        public override Task<DeliveryQOBD[]> update_data_deliveryAsync(string companyName, DeliveryQOBD[] delivery_array_list)
        {
            return base.Channel.update_data_deliveryAsync(companyName, delivery_array_list);
        }

        public override DeliveryQOBD[] get_data_delivery_by_id(string companyName, string id)
        {
            return base.Channel.get_data_delivery_by_id(companyName, id);
        }

        public override Task<DeliveryQOBD[]> get_data_delivery_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_delivery_by_idAsync(companyName, id);
        }

        public override DeliveryQOBD[] get_filter_delivery(string companyName, DeliveryFilterQOBD delivery_array_list_filter)
        {
            return base.Channel.get_filter_delivery(companyName, delivery_array_list_filter);
        }

        public override Task<DeliveryQOBD[]> get_filter_deliveryAsync(string companyName, DeliveryFilterQOBD delivery_array_list_filter)
        {
            return base.Channel.get_filter_deliveryAsync(companyName, delivery_array_list_filter);
        }

        public override DeliveryQOBD[] get_data_delivery_by_order_list(string companyName, OrdersQOBD[] order_array_list)
        {
            return base.Channel.get_data_delivery_by_order_list(companyName, order_array_list);
        }

        public override Task<DeliveryQOBD[]> get_data_delivery_by_order_listAsync(string companyName, OrdersQOBD[] order_array_list)
        {
            return base.Channel.get_data_delivery_by_order_listAsync(companyName, order_array_list);
        }

        public override InfosQOBD[] get_data_infos(string companyName, string nbLine)
        {
            return base.Channel.get_data_infos(companyName, nbLine);
        }

        public override Task<InfosQOBD[]> get_data_infosAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_infosAsync(companyName, nbLine);
        }

        public override InfosQOBD[] delete_data_infos(string companyName, InfosQOBD[] infos_array_list)
        {
            return base.Channel.delete_data_infos(companyName, infos_array_list);
        }

        public override Task<InfosQOBD[]> delete_data_infosAsync(string companyName, InfosQOBD[] infos_array_list)
        {
            return base.Channel.delete_data_infosAsync(companyName, infos_array_list);
        }

        public override InfosQOBD[] insert_data_infos(string companyName, InfosQOBD[] infos_array_list)
        {
            return base.Channel.insert_data_infos(companyName, infos_array_list);
        }

        public override Task<InfosQOBD[]> insert_data_infosAsync(string companyName, InfosQOBD[] infos_array_list)
        {
            return base.Channel.insert_data_infosAsync(companyName, infos_array_list);
        }

        public override InfosQOBD[] update_data_infos(string companyName, InfosQOBD[] infos_array_list)
        {
            return base.Channel.update_data_infos(companyName, infos_array_list);
        }

        public override Task<InfosQOBD[]> update_data_infosAsync(string companyName, InfosQOBD[] infos_array_list)
        {
            return base.Channel.update_data_infosAsync(companyName, infos_array_list);
        }

        public override InfosQOBD[] get_data_infos_by_id(string companyName, string id)
        {
            return base.Channel.get_data_infos_by_id(companyName, id);
        }

        public override Task<InfosQOBD[]> get_data_infos_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_infos_by_idAsync(companyName, id);
        }

        public override InfosQOBD[] get_filter_infos(string companyName, InfosFilterQOBD infos_array_list_filter)
        {
            return base.Channel.get_filter_infos(companyName, infos_array_list_filter);
        }

        public override Task<InfosQOBD[]> get_filter_infosAsync(string companyName, InfosFilterQOBD infos_array_list_filter)
        {
            return base.Channel.get_filter_infosAsync(companyName, infos_array_list_filter);
        }

        public override Auto_refsQOBD[] get_data_auto_ref(string companyName, string nbLine)
        {
            return base.Channel.get_data_auto_ref(companyName, nbLine);
        }

        public override Task<Auto_refsQOBD[]> get_data_auto_refAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_auto_refAsync(companyName, nbLine);
        }

        public override Auto_refsQOBD[] delete_data_auto_ref(string companyName, Auto_refsQOBD[] auto_ref_array_list)
        {
            return base.Channel.delete_data_auto_ref(companyName, auto_ref_array_list);
        }

        public override Task<Auto_refsQOBD[]> delete_data_auto_refAsync(string companyName, Auto_refsQOBD[] auto_ref_array_list)
        {
            return base.Channel.delete_data_auto_refAsync(companyName, auto_ref_array_list);
        }

        public override Auto_refsQOBD[] insert_data_auto_ref(string companyName, Auto_refsQOBD[] auto_ref_array_list)
        {
            return base.Channel.insert_data_auto_ref(companyName, auto_ref_array_list);
        }

        public override Task<Auto_refsQOBD[]> insert_data_auto_refAsync(string companyName, Auto_refsQOBD[] auto_ref_array_list)
        {
            return base.Channel.insert_data_auto_refAsync(companyName, auto_ref_array_list);
        }

        public override Auto_refsQOBD[] update_data_auto_ref(string companyName, Auto_refsQOBD[] auto_ref_array_list)
        {
            return base.Channel.update_data_auto_ref(companyName, auto_ref_array_list);
        }

        public override Task<Auto_refsQOBD[]> update_data_auto_refAsync(string companyName, Auto_refsQOBD[] auto_ref_array_list)
        {
            return base.Channel.update_data_auto_refAsync(companyName, auto_ref_array_list);
        }

        public override Auto_refsQOBD[] get_data_auto_ref_by_id(string companyName, string id)
        {
            return base.Channel.get_data_auto_ref_by_id(companyName, id);
        }

        public override Task<Auto_refsQOBD[]> get_data_auto_ref_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_auto_ref_by_idAsync(companyName, id);
        }

        public override Auto_refsQOBD[] get_filter_auto_ref(string companyName, Auto_refsFilterQOBD auto_ref_array_list)
        {
            return base.Channel.get_filter_auto_ref(companyName, auto_ref_array_list);
        }

        public override Task<Auto_refsQOBD[]> get_filter_auto_refAsync(string companyName, Auto_refsFilterQOBD auto_ref_array_list)
        {
            return base.Channel.get_filter_auto_refAsync(companyName, auto_ref_array_list);
        }

        public override Item_deliveryQOBD[] get_data_item_delivery(string companyName, string nbLine)
        {
            return base.Channel.get_data_item_delivery(companyName, nbLine);
        }

        public override Task<Item_deliveryQOBD[]> get_data_item_deliveryAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_item_deliveryAsync(companyName, nbLine);
        }

        public override Item_deliveryQOBD[] delete_data_item_delivery(string companyName, Item_deliveryQOBD[] item_delivery_array_list)
        {
            return base.Channel.delete_data_item_delivery(companyName, item_delivery_array_list);
        }

        public override Task<Item_deliveryQOBD[]> delete_data_item_deliveryAsync(string companyName, Item_deliveryQOBD[] item_delivery_array_list)
        {
            return base.Channel.delete_data_item_deliveryAsync(companyName, item_delivery_array_list);
        }

        public override Item_deliveryQOBD[] insert_data_item_delivery(string companyName, Item_deliveryQOBD[] item_delivery_array_list)
        {
            return base.Channel.insert_data_item_delivery(companyName, item_delivery_array_list);
        }

        public override Task<Item_deliveryQOBD[]> insert_data_item_deliveryAsync(string companyName, Item_deliveryQOBD[] item_delivery_array_list)
        {
            return base.Channel.insert_data_item_deliveryAsync(companyName, item_delivery_array_list);
        }

        public override Item_deliveryQOBD[] update_data_item_delivery(string companyName, Item_deliveryQOBD[] item_delivery_array_list)
        {
            return base.Channel.update_data_item_delivery(companyName, item_delivery_array_list);
        }

        public override Task<Item_deliveryQOBD[]> update_data_item_deliveryAsync(string companyName, Item_deliveryQOBD[] item_delivery_array_list)
        {
            return base.Channel.update_data_item_deliveryAsync(companyName, item_delivery_array_list);
        }

        public override Item_deliveryQOBD[] get_data_item_delivery_by_id(string companyName, string id)
        {
            return base.Channel.get_data_item_delivery_by_id(companyName, id);
        }

        public override Task<Item_deliveryQOBD[]> get_data_item_delivery_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_item_delivery_by_idAsync(companyName, id);
        }

        public override Item_deliveryQOBD[] get_filter_item_delivery(string companyName, Item_deliveryFilterQOBD item_delivery_array_list_filter)
        {
            return base.Channel.get_filter_item_delivery(companyName, item_delivery_array_list_filter);
        }

        public override Task<Item_deliveryQOBD[]> get_filter_item_deliveryAsync(string companyName, Item_deliveryFilterQOBD item_delivery_array_list_filter)
        {
            return base.Channel.get_filter_item_deliveryAsync(companyName, item_delivery_array_list_filter);
        }

        public override Item_deliveryQOBD[] get_data_item_delivery_by_delivery_list(string companyName, DeliveryQOBD[] delivery_array_list)
        {
            return base.Channel.get_data_item_delivery_by_delivery_list(companyName, delivery_array_list);
        }

        public override Task<Item_deliveryQOBD[]> get_data_item_delivery_by_delivery_listAsync(string companyName, DeliveryQOBD[] delivery_array_list)
        {
            return base.Channel.get_data_item_delivery_by_delivery_listAsync(companyName, delivery_array_list);
        }

        public override Provider_itemQOBD[] get_data_provider_item(string companyName, string nbLine)
        {
            return base.Channel.get_data_provider_item(companyName, nbLine);
        }

        public override Task<Provider_itemQOBD[]> get_data_provider_itemAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_provider_itemAsync(companyName, nbLine);
        }

        public override Provider_itemQOBD[] delete_data_provider_item(string companyName, Provider_itemQOBD[] provider_item_array_list)
        {
            return base.Channel.delete_data_provider_item(companyName, provider_item_array_list);
        }

        public override Task<Provider_itemQOBD[]> delete_data_provider_itemAsync(string companyName, Provider_itemQOBD[] provider_item_array_list)
        {
            return base.Channel.delete_data_provider_itemAsync(companyName, provider_item_array_list);
        }

        public override Provider_itemQOBD[] insert_data_provider_item(string companyName, Provider_itemQOBD[] provider_item_array_list)
        {
            return base.Channel.insert_data_provider_item(companyName, provider_item_array_list);
        }

        public override Task<Provider_itemQOBD[]> insert_data_provider_itemAsync(string companyName, Provider_itemQOBD[] provider_item_array_list)
        {
            return base.Channel.insert_data_provider_itemAsync(companyName, provider_item_array_list);
        }

        public override Provider_itemQOBD[] update_data_provider_item(string companyName, Provider_itemQOBD[] provider_item_array_list)
        {
            return base.Channel.update_data_provider_item(companyName, provider_item_array_list);
        }

        public override Task<Provider_itemQOBD[]> update_data_provider_itemAsync(string companyName, Provider_itemQOBD[] provider_item_array_list)
        {
            return base.Channel.update_data_provider_itemAsync(companyName, provider_item_array_list);
        }

        public override Provider_itemQOBD[] get_data_provider_item_by_id(string companyName, string id)
        {
            return base.Channel.get_data_provider_item_by_id(companyName, id);
        }

        public override Task<Provider_itemQOBD[]> get_data_provider_item_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_provider_item_by_idAsync(companyName, id);
        }

        public override Provider_itemQOBD[] get_filter_provider_item(string companyName, Provider_itemFilterQOBD provider_item_array_list_filter)
        {
            return base.Channel.get_filter_provider_item(companyName, provider_item_array_list_filter);
        }

        public override Task<Provider_itemQOBD[]> get_filter_provider_itemAsync(string companyName, Provider_itemFilterQOBD provider_item_array_list_filter)
        {
            return base.Channel.get_filter_provider_itemAsync(companyName, provider_item_array_list_filter);
        }

        public override Provider_itemQOBD[] get_data_provider_item_by_item_list(string companyName, ItemQOBD[] item_array_list)
        {
            return base.Channel.get_data_provider_item_by_item_list(companyName, item_array_list);
        }

        public override Task<Provider_itemQOBD[]> get_data_provider_item_by_item_listAsync(string companyName, ItemQOBD[] item_array_list)
        {
            return base.Channel.get_data_provider_item_by_item_listAsync(companyName, item_array_list);
        }

        public override ProviderQOBD[] get_data_provider(string companyName, string nbLine)
        {
            return base.Channel.get_data_provider(companyName, nbLine);
        }

        public override Task<ProviderQOBD[]> get_data_providerAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_providerAsync(companyName, nbLine);
        }

        public override ProviderQOBD[] delete_data_provider(string companyName, ProviderQOBD[] provider_array_list)
        {
            return base.Channel.delete_data_provider(companyName, provider_array_list);
        }

        public override Task<ProviderQOBD[]> delete_data_providerAsync(string companyName, ProviderQOBD[] provider_array_list)
        {
            return base.Channel.delete_data_providerAsync(companyName, provider_array_list);
        }

        public override ProviderQOBD[] insert_data_provider(string companyName, ProviderQOBD[] provider_array_list)
        {
            return base.Channel.insert_data_provider(companyName, provider_array_list);
        }

        public override Task<ProviderQOBD[]> insert_data_providerAsync(string companyName, ProviderQOBD[] provider_array_list)
        {
            return base.Channel.insert_data_providerAsync(companyName, provider_array_list);
        }

        public override ProviderQOBD[] update_data_provider(string companyName, ProviderQOBD[] provider_array_list)
        {
            return base.Channel.update_data_provider(companyName, provider_array_list);
        }

        public override Task<ProviderQOBD[]> update_data_providerAsync(string companyName, ProviderQOBD[] provider_array_list)
        {
            return base.Channel.update_data_providerAsync(companyName, provider_array_list);
        }

        public override ProviderQOBD[] get_data_provider_by_id(string companyName, string id)
        {
            return base.Channel.get_data_provider_by_id(companyName, id);
        }

        public override Task<ProviderQOBD[]> get_data_provider_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_provider_by_idAsync(companyName, id);
        }

        public override ProviderQOBD[] get_filter_provider(string companyName, ProviderFilterQOBD provider_array_list_filter)
        {
            return base.Channel.get_filter_provider(companyName, provider_array_list_filter);
        }

        public override Task<ProviderQOBD[]> get_filter_providerAsync(string companyName, ProviderFilterQOBD provider_array_list_filter)
        {
            return base.Channel.get_filter_providerAsync(companyName, provider_array_list_filter);
        }

        public override ProviderQOBD[] get_data_provider_by_provider_item_list(string companyName, Provider_itemQOBD[] provider_item_array_list)
        {
            return base.Channel.get_data_provider_by_provider_item_list(companyName, provider_item_array_list);
        }

        public override Task<ProviderQOBD[]> get_data_provider_by_provider_item_listAsync(string companyName, Provider_itemQOBD[] provider_item_array_list)
        {
            return base.Channel.get_data_provider_by_provider_item_listAsync(companyName, provider_item_array_list);
        }

        public override Tax_orderQOBD[] get_data_tax_order(string companyName, string nbLine)
        {
            return base.Channel.get_data_tax_order(companyName, nbLine);
        }

        public override Task<Tax_orderQOBD[]> get_data_tax_orderAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_tax_orderAsync(companyName, nbLine);
        }

        public override Tax_orderQOBD[] delete_data_tax_order(string companyName, Tax_orderQOBD[] tax_order_array_list)
        {
            return base.Channel.delete_data_tax_order(companyName, tax_order_array_list);
        }

        public override Task<Tax_orderQOBD[]> delete_data_tax_orderAsync(string companyName, Tax_orderQOBD[] tax_order_array_list)
        {
            return base.Channel.delete_data_tax_orderAsync(companyName, tax_order_array_list);
        }

        public override Tax_orderQOBD[] insert_data_tax_order(string companyName, Tax_orderQOBD[] tax_order_array_list)
        {
            return base.Channel.insert_data_tax_order(companyName, tax_order_array_list);
        }

        public override Task<Tax_orderQOBD[]> insert_data_tax_orderAsync(string companyName, Tax_orderQOBD[] tax_order_array_list)
        {
            return base.Channel.insert_data_tax_orderAsync(companyName, tax_order_array_list);
        }

        public override Tax_orderQOBD[] update_data_tax_order(string companyName, Tax_orderQOBD[] tax_order_array_list)
        {
            return base.Channel.update_data_tax_order(companyName, tax_order_array_list);
        }

        public override Task<Tax_orderQOBD[]> update_data_tax_orderAsync(string companyName, Tax_orderQOBD[] tax_order_array_list)
        {
            return base.Channel.update_data_tax_orderAsync(companyName, tax_order_array_list);
        }

        public override Tax_orderQOBD[] get_data_tax_order_by_id(string companyName, string id)
        {
            return base.Channel.get_data_tax_order_by_id(companyName, id);
        }

        public override Task<Tax_orderQOBD[]> get_data_tax_order_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_tax_order_by_idAsync(companyName, id);
        }

        public override Tax_orderQOBD[] get_filter_tax_order(string companyName, Tax_orderFilterQOBD tax_order_array_list_filter)
        {
            return base.Channel.get_filter_tax_order(companyName, tax_order_array_list_filter);
        }

        public override Task<Tax_orderQOBD[]> get_filter_tax_orderAsync(string companyName, Tax_orderFilterQOBD tax_order_array_list_filter)
        {
            return base.Channel.get_filter_tax_orderAsync(companyName, tax_order_array_list_filter);
        }

        public override Tax_orderQOBD[] get_data_tax_order_by_order_list(string companyName, OrdersQOBD[] order_array_list)
        {
            return base.Channel.get_data_tax_order_by_order_list(companyName, order_array_list);
        }

        public override Task<Tax_orderQOBD[]> get_data_tax_order_by_order_listAsync(string companyName, OrdersQOBD[] order_array_list)
        {
            return base.Channel.get_data_tax_order_by_order_listAsync(companyName, order_array_list);
        }

        public override Tax_itemQOBD[] get_data_tax_item(string companyName, string nbLine)
        {
            return base.Channel.get_data_tax_item(companyName, nbLine);
        }

        public override Task<Tax_itemQOBD[]> get_data_tax_itemAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_tax_itemAsync(companyName, nbLine);
        }

        public override Tax_itemQOBD[] delete_data_tax_item(string companyName, Tax_itemQOBD[] tax_item_array_list)
        {
            return base.Channel.delete_data_tax_item(companyName, tax_item_array_list);
        }

        public override Task<Tax_itemQOBD[]> delete_data_tax_itemAsync(string companyName, Tax_itemQOBD[] tax_item_array_list)
        {
            return base.Channel.delete_data_tax_itemAsync(companyName, tax_item_array_list);
        }

        public override Tax_itemQOBD[] insert_data_tax_item(string companyName, Tax_itemQOBD[] tax_item_array_list)
        {
            return base.Channel.insert_data_tax_item(companyName, tax_item_array_list);
        }

        public override Task<Tax_itemQOBD[]> insert_data_tax_itemAsync(string companyName, Tax_itemQOBD[] tax_item_array_list)
        {
            return base.Channel.insert_data_tax_itemAsync(companyName, tax_item_array_list);
        }

        public override Tax_itemQOBD[] update_data_tax_item(string companyName, Tax_itemQOBD[] tax_item_array_list)
        {
            return base.Channel.update_data_tax_item(companyName, tax_item_array_list);
        }

        public override Task<Tax_itemQOBD[]> update_data_tax_itemAsync(string companyName, Tax_itemQOBD[] tax_item_array_list)
        {
            return base.Channel.update_data_tax_itemAsync(companyName, tax_item_array_list);
        }

        public override Tax_itemQOBD[] get_data_tax_item_by_id(string companyName, string id)
        {
            return base.Channel.get_data_tax_item_by_id(companyName, id);
        }

        public override Task<Tax_itemQOBD[]> get_data_tax_item_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_tax_item_by_idAsync(companyName, id);
        }

        public override Tax_itemQOBD[] get_filter_tax_item(string companyName, Tax_itemFilterQOBD tax_item_array_list_filter)
        {
            return base.Channel.get_filter_tax_item(companyName, tax_item_array_list_filter);
        }

        public override Task<Tax_itemQOBD[]> get_filter_tax_itemAsync(string companyName, Tax_itemFilterQOBD tax_item_array_list_filter)
        {
            return base.Channel.get_filter_tax_itemAsync(companyName, tax_item_array_list_filter);
        }

        public override Tax_itemQOBD[] get_data_tax_item_by_item_list(string companyName, ItemQOBD[] item_array_list)
        {
            return base.Channel.get_data_tax_item_by_item_list(companyName, item_array_list);
        }

        public override Task<Tax_itemQOBD[]> get_data_tax_item_by_item_listAsync(string companyName, ItemQOBD[] item_array_list)
        {
            return base.Channel.get_data_tax_item_by_item_listAsync(companyName, item_array_list);
        }

        public override TaxQOBD[] get_data_tax(string companyName, string nbLine)
        {
            return base.Channel.get_data_tax(companyName, nbLine);
        }

        public override Task<TaxQOBD[]> get_data_taxAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_taxAsync(companyName, nbLine);
        }

        public override TaxQOBD[] delete_data_tax(string companyName, TaxQOBD[] tax_array_list)
        {
            return base.Channel.delete_data_tax(companyName, tax_array_list);
        }

        public override Task<TaxQOBD[]> delete_data_taxAsync(string companyName, TaxQOBD[] tax_array_list)
        {
            return base.Channel.delete_data_taxAsync(companyName, tax_array_list);
        }

        public override TaxQOBD[] insert_data_tax(string companyName, TaxQOBD[] tax_array_list)
        {
            return base.Channel.insert_data_tax(companyName, tax_array_list);
        }

        public override Task<TaxQOBD[]> insert_data_taxAsync(string companyName, TaxQOBD[] tax_array_list)
        {
            return base.Channel.insert_data_taxAsync(companyName, tax_array_list);
        }

        public override TaxQOBD[] update_data_tax(string companyName, TaxQOBD[] tax_array_list)
        {
            return base.Channel.update_data_tax(companyName, tax_array_list);
        }

        public override Task<TaxQOBD[]> update_data_taxAsync(string companyName, TaxQOBD[] tax_array_list)
        {
            return base.Channel.update_data_taxAsync(companyName, tax_array_list);
        }

        public override TaxQOBD[] get_data_tax_by_id(string companyName, string id)
        {
            return base.Channel.get_data_tax_by_id(companyName, id);
        }

        public override Task<TaxQOBD[]> get_data_tax_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_tax_by_idAsync(companyName, id);
        }

        public override TaxQOBD[] get_filter_tax(string companyName, TaxFilterQOBD tax_array_list_filter)
        {
            return base.Channel.get_filter_tax(companyName, tax_array_list_filter);
        }

        public override Task<TaxQOBD[]> get_filter_taxAsync(string companyName, TaxFilterQOBD tax_array_list_filter)
        {
            return base.Channel.get_filter_taxAsync(companyName, tax_array_list_filter);
        }

        public override PrivilegeQOBD[] get_data_privilege(string companyName, string nbLine)
        {
            return base.Channel.get_data_privilege(companyName, nbLine);
        }

        public override Task<PrivilegeQOBD[]> get_data_privilegeAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_privilegeAsync(companyName, nbLine);
        }

        public override PrivilegeQOBD[] delete_data_privilege(string companyName, PrivilegeQOBD[] privilege_array_list)
        {
            return base.Channel.delete_data_privilege(companyName, privilege_array_list);
        }

        public override Task<PrivilegeQOBD[]> delete_data_privilegeAsync(string companyName, PrivilegeQOBD[] privilege_array_list)
        {
            return base.Channel.delete_data_privilegeAsync(companyName, privilege_array_list);
        }

        public override PrivilegeQOBD[] insert_data_privilege(string companyName, PrivilegeQOBD[] privilege_array_list)
        {
            return base.Channel.insert_data_privilege(companyName, privilege_array_list);
        }

        public override Task<PrivilegeQOBD[]> insert_data_privilegeAsync(string companyName, PrivilegeQOBD[] privilege_array_list)
        {
            return base.Channel.insert_data_privilegeAsync(companyName, privilege_array_list);
        }

        public override PrivilegeQOBD[] update_data_privilege(string companyName, PrivilegeQOBD[] privilege_array_list)
        {
            return base.Channel.update_data_privilege(companyName, privilege_array_list);
        }

        public override Task<PrivilegeQOBD[]> update_data_privilegeAsync(string companyName, PrivilegeQOBD[] privilege_array_list)
        {
            return base.Channel.update_data_privilegeAsync(companyName, privilege_array_list);
        }

        public override PrivilegeQOBD[] get_data_privilege_by_id(string companyName, string id)
        {
            return base.Channel.get_data_privilege_by_id(companyName, id);
        }

        public override Task<PrivilegeQOBD[]> get_data_privilege_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_privilege_by_idAsync(companyName, id);
        }

        public override PrivilegeQOBD[] get_filter_privilege(string companyName, PrivilegeFilterQOBD privilege_array_list_filter)
        {
            return base.Channel.get_filter_privilege(companyName, privilege_array_list_filter);
        }

        public override Task<PrivilegeQOBD[]> get_filter_privilegeAsync(string companyName, PrivilegeFilterQOBD privilege_array_list_filter)
        {
            return base.Channel.get_filter_privilegeAsync(companyName, privilege_array_list_filter);
        }

        public override NotificationQOBD[] get_data_notification(string companyName, string nbLine)
        {
            return base.Channel.get_data_notification(companyName, nbLine);
        }

        public override Task<NotificationQOBD[]> get_data_notificationAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_notificationAsync(companyName, nbLine);
        }

        public override NotificationQOBD[] delete_data_notification(string companyName, NotificationQOBD[] notification_array_list)
        {
            return base.Channel.delete_data_notification(companyName, notification_array_list);
        }

        public override Task<NotificationQOBD[]> delete_data_notificationAsync(string companyName, NotificationQOBD[] notification_array_list)
        {
            return base.Channel.delete_data_notificationAsync(companyName, notification_array_list);
        }

        public override NotificationQOBD[] insert_data_notification(string companyName, NotificationQOBD[] notification_array_list)
        {
            return base.Channel.insert_data_notification(companyName, notification_array_list);
        }

        public override Task<NotificationQOBD[]> insert_data_notificationAsync(string companyName, NotificationQOBD[] notification_array_list)
        {
            return base.Channel.insert_data_notificationAsync(companyName, notification_array_list);
        }

        public override NotificationQOBD[] update_data_notification(string companyName, NotificationQOBD[] notification_array_list)
        {
            return base.Channel.update_data_notification(companyName, notification_array_list);
        }

        public override Task<NotificationQOBD[]> update_data_notificationAsync(string companyName, NotificationQOBD[] notification_array_list)
        {
            return base.Channel.update_data_notificationAsync(companyName, notification_array_list);
        }

        public override NotificationQOBD[] get_data_notification_by_id(string companyName, string id)
        {
            return base.Channel.get_data_notification_by_id(companyName, id);
        }

        public override Task<NotificationQOBD[]> get_data_notification_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_notification_by_idAsync(companyName, id);
        }

        public override NotificationQOBD[] get_filter_notification(string companyName, NotificationFilterQOBD notification_array_list)
        {
            return base.Channel.get_filter_notification(companyName, notification_array_list);
        }

        public override Task<NotificationQOBD[]> get_filter_notificationAsync(string companyName, NotificationFilterQOBD notification_array_list)
        {
            return base.Channel.get_filter_notificationAsync(companyName, notification_array_list);
        }

        public override NotificationQOBD[] get_data_notification_by_order_list(string companyName, OrdersQOBD[] order_array_list)
        {
            return base.Channel.get_data_notification_by_order_list(companyName, order_array_list);
        }

        public override Task<NotificationQOBD[]> get_data_notification_by_order_listAsync(string companyName, OrdersQOBD[] order_array_list)
        {
            return base.Channel.get_data_notification_by_order_listAsync(companyName, order_array_list);
        }

        public override NotificationQOBD[] get_data_notification_by_client_list(string companyName, ClientQOBD[] client_array_list)
        {
            return base.Channel.get_data_notification_by_client_list(companyName, client_array_list);
        }

        public override Task<NotificationQOBD[]> get_data_notification_by_client_listAsync(string companyName, ClientQOBD[] client_array_list)
        {
            return base.Channel.get_data_notification_by_client_listAsync(companyName, client_array_list);
        }

        public override UserChatRoom[] get_data_user(string companyName, string nbLine)
        {
            return base.Channel.get_data_user(companyName, nbLine);
        }

        public override Task<UserChatRoom[]> get_data_userAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_userAsync(companyName, nbLine);
        }

        public override UserChatRoom[] delete_data_user(string companyName, UserChatRoom[] user_array_list)
        {
            return base.Channel.delete_data_user(companyName, user_array_list);
        }

        public override Task<UserChatRoom[]> delete_data_userAsync(string companyName, UserChatRoom[] user_array_list)
        {
            return base.Channel.delete_data_userAsync(companyName, user_array_list);
        }

        public override UserChatRoom[] insert_data_user(string companyName, UserChatRoom[] user_array_list)
        {
            return base.Channel.insert_data_user(companyName, user_array_list);
        }

        public override Task<UserChatRoom[]> insert_data_userAsync(string companyName, UserChatRoom[] user_array_list)
        {
            return base.Channel.insert_data_userAsync(companyName, user_array_list);
        }

        public override UserChatRoom[] update_data_user(string companyName, UserChatRoom[] user_array_list)
        {
            return base.Channel.update_data_user(companyName, user_array_list);
        }

        public override Task<UserChatRoom[]> update_data_userAsync(string companyName, UserChatRoom[] user_array_list)
        {
            return base.Channel.update_data_userAsync(companyName, user_array_list);
        }

        public override UserChatRoom[] get_data_user_by_id(string companyName, string id)
        {
            return base.Channel.get_data_user_by_id(companyName, id);
        }

        public override Task<UserChatRoom[]> get_data_user_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_user_by_idAsync(companyName, id);
        }

        public override UserChatRoom[] get_filter_user(string companyName, UserFilterChatRoom user_array_list_filter)
        {
            return base.Channel.get_filter_user(companyName, user_array_list_filter);
        }

        public override Task<UserChatRoom[]> get_filter_userAsync(string companyName, UserFilterChatRoom user_array_list_filter)
        {
            return base.Channel.get_filter_userAsync(companyName, user_array_list_filter);
        }

        public override UserChatRoom[] get_data_user_by_user_discussion_list(string companyName, User_discussionChatRoom[] user_discussion_array_list)
        {
            return base.Channel.get_data_user_by_user_discussion_list(companyName, user_discussion_array_list);
        }

        public override Task<UserChatRoom[]> get_data_user_by_user_discussion_listAsync(string companyName, User_discussionChatRoom[] user_discussion_array_list)
        {
            return base.Channel.get_data_user_by_user_discussion_listAsync(companyName, user_discussion_array_list);
        }

        public override MessageChatRoom[] get_data_message(string companyName, string nbLine)
        {
            return base.Channel.get_data_message(companyName, nbLine);
        }

        public override Task<MessageChatRoom[]> get_data_messageAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_messageAsync(companyName, nbLine);
        }

        public override MessageChatRoom[] delete_data_message(string companyName, MessageChatRoom[] message_array_list)
        {
            return base.Channel.delete_data_message(companyName, message_array_list);
        }

        public override Task<MessageChatRoom[]> delete_data_messageAsync(string companyName, MessageChatRoom[] message_array_list)
        {
            return base.Channel.delete_data_messageAsync(companyName, message_array_list);
        }

        public override MessageChatRoom[] insert_data_message(string companyName, MessageChatRoom[] message_array_list)
        {
            return base.Channel.insert_data_message(companyName, message_array_list);
        }

        public override Task<MessageChatRoom[]> insert_data_messageAsync(string companyName, MessageChatRoom[] message_array_list)
        {
            return base.Channel.insert_data_messageAsync(companyName, message_array_list);
        }

        public override MessageChatRoom[] update_data_message(string companyName, MessageChatRoom[] message_array_list)
        {
            return base.Channel.update_data_message(companyName, message_array_list);
        }

        public override Task<MessageChatRoom[]> update_data_messageAsync(string companyName, MessageChatRoom[] message_array_list)
        {
            return base.Channel.update_data_messageAsync(companyName, message_array_list);
        }

        public override MessageChatRoom[] get_data_message_by_id(string companyName, string id)
        {
            return base.Channel.get_data_message_by_id(companyName, id);
        }

        public override Task<MessageChatRoom[]> get_data_message_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_message_by_idAsync(companyName, id);
        }

        public override MessageChatRoom[] get_filter_message(string companyName, MessageFilterChatRoom message_array_list_filter)
        {
            return base.Channel.get_filter_message(companyName, message_array_list_filter);
        }

        public override Task<MessageChatRoom[]> get_filter_messageAsync(string companyName, MessageFilterChatRoom message_array_list_filter)
        {
            return base.Channel.get_filter_messageAsync(companyName, message_array_list_filter);
        }

        public override DiscussionChatRoom[] get_data_discussion(string companyName, string nbLine)
        {
            return base.Channel.get_data_discussion(companyName, nbLine);
        }

        public override Task<DiscussionChatRoom[]> get_data_discussionAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_discussionAsync(companyName, nbLine);
        }

        public override DiscussionChatRoom[] delete_data_discussion(string companyName, DiscussionChatRoom[] discussion_array_list)
        {
            return base.Channel.delete_data_discussion(companyName, discussion_array_list);
        }

        public override Task<DiscussionChatRoom[]> delete_data_discussionAsync(string companyName, DiscussionChatRoom[] discussion_array_list)
        {
            return base.Channel.delete_data_discussionAsync(companyName, discussion_array_list);
        }

        public override DiscussionChatRoom[] insert_data_discussion(string companyName, DiscussionChatRoom[] discussion_array_list)
        {
            return base.Channel.insert_data_discussion(companyName, discussion_array_list);
        }

        public override Task<DiscussionChatRoom[]> insert_data_discussionAsync(string companyName, DiscussionChatRoom[] discussion_array_list)
        {
            return base.Channel.insert_data_discussionAsync(companyName, discussion_array_list);
        }

        public override DiscussionChatRoom[] update_data_discussion(string companyName, DiscussionChatRoom[] discussion_array_list)
        {
            return base.Channel.update_data_discussion(companyName, discussion_array_list);
        }

        public override Task<DiscussionChatRoom[]> update_data_discussionAsync(string companyName, DiscussionChatRoom[] discussion_array_list)
        {
            return base.Channel.update_data_discussionAsync(companyName, discussion_array_list);
        }

        public override DiscussionChatRoom[] get_data_discussion_by_id(string companyName, string id)
        {
            return base.Channel.get_data_discussion_by_id(companyName, id);
        }

        public override Task<DiscussionChatRoom[]> get_data_discussion_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_discussion_by_idAsync(companyName, id);
        }

        public override DiscussionChatRoom[] get_filter_discussion(string companyName, DiscussionFilterChatRoom discussion_array_list_filter)
        {
            return base.Channel.get_filter_discussion(companyName, discussion_array_list_filter);
        }

        public override Task<DiscussionChatRoom[]> get_filter_discussionAsync(string companyName, DiscussionFilterChatRoom discussion_array_list_filter)
        {
            return base.Channel.get_filter_discussionAsync(companyName, discussion_array_list_filter);
        }

        public override DiscussionChatRoom[] get_data_discussion_by_user_discussion_list(string companyName, User_discussionChatRoom[] user_discussion_array_list)
        {
            return base.Channel.get_data_discussion_by_user_discussion_list(companyName, user_discussion_array_list);
        }

        public override Task<DiscussionChatRoom[]> get_data_discussion_by_user_discussion_listAsync(string companyName, User_discussionChatRoom[] user_discussion_array_list)
        {
            return base.Channel.get_data_discussion_by_user_discussion_listAsync(companyName, user_discussion_array_list);
        }

        public override DiscussionChatRoom[] get_data_discussion_by_message_list(string companyName, MessageChatRoom[] message_array_list)
        {
            return base.Channel.get_data_discussion_by_message_list(companyName, message_array_list);
        }

        public override Task<DiscussionChatRoom[]> get_data_discussion_by_message_listAsync(string companyName, MessageChatRoom[] message_array_list)
        {
            return base.Channel.get_data_discussion_by_message_listAsync(companyName, message_array_list);
        }

        public override User_discussionChatRoom[] get_data_user_discussion(string companyName, string nbLine)
        {
            return base.Channel.get_data_user_discussion(companyName, nbLine);
        }

        public override Task<User_discussionChatRoom[]> get_data_user_discussionAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_user_discussionAsync(companyName, nbLine);
        }

        public override User_discussionChatRoom[] delete_data_user_discussion(string companyName, User_discussionChatRoom[] user_discussion_array_list)
        {
            return base.Channel.delete_data_user_discussion(companyName, user_discussion_array_list);
        }

        public override Task<User_discussionChatRoom[]> delete_data_user_discussionAsync(string companyName, User_discussionChatRoom[] user_discussion_array_list)
        {
            return base.Channel.delete_data_user_discussionAsync(companyName, user_discussion_array_list);
        }

        public override User_discussionChatRoom[] insert_data_user_discussion(string companyName, User_discussionChatRoom[] user_discussion_array_list)
        {
            return base.Channel.insert_data_user_discussion(companyName, user_discussion_array_list);
        }

        public override Task<User_discussionChatRoom[]> insert_data_user_discussionAsync(string companyName, User_discussionChatRoom[] user_discussion_array_list)
        {
            return base.Channel.insert_data_user_discussionAsync(companyName, user_discussion_array_list);
        }

        public override User_discussionChatRoom[] update_data_user_discussion(string companyName, User_discussionChatRoom[] user_discussion_array_list)
        {
            return base.Channel.update_data_user_discussion(companyName, user_discussion_array_list);
        }

        public override Task<User_discussionChatRoom[]> update_data_user_discussionAsync(string companyName, User_discussionChatRoom[] user_discussion_array_list)
        {
            return base.Channel.update_data_user_discussionAsync(companyName, user_discussion_array_list);
        }

        public override User_discussionChatRoom[] get_data_user_discussion_by_id(string companyName, string id)
        {
            return base.Channel.get_data_user_discussion_by_id(companyName, id);
        }

        public override Task<User_discussionChatRoom[]> get_data_user_discussion_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_user_discussion_by_idAsync(companyName, id);
        }

        public override User_discussionChatRoom[] get_filter_user_discussion(string companyName, User_discussionFilterChatRoom user_discussion_array_list_filter)
        {
            return base.Channel.get_filter_user_discussion(companyName, user_discussion_array_list_filter);
        }

        public override Task<User_discussionChatRoom[]> get_filter_user_discussionAsync(string companyName, User_discussionFilterChatRoom user_discussion_array_list_filter)
        {
            return base.Channel.get_filter_user_discussionAsync(companyName, user_discussion_array_list_filter);
        }
        
        public override CurrencyQOBD[] get_data_currency(string companyName, string nbLine)
        {
            return base.Channel.get_data_currency(companyName, nbLine);
        }
        
        public override Task<CurrencyQOBD[]> get_data_currencyAsync(string companyName, string nbLine)
        {
            return base.Channel.get_data_currencyAsync(companyName, nbLine);
        }

        
        public override CurrencyQOBD[] delete_data_currency(string companyName, CurrencyQOBD[] currency_array_list)
        {
            return base.Channel.delete_data_currency(companyName, currency_array_list);
        }

        
        public override Task<CurrencyQOBD[]> delete_data_currencyAsync(string companyName, CurrencyQOBD[] currency_array_list)
        {
            return base.Channel.delete_data_currencyAsync(companyName, currency_array_list);
        }
        
        public override CurrencyQOBD[] insert_data_currency(string companyName, CurrencyQOBD[] currency_array_list)
        {
            return base.Channel.insert_data_currency(companyName, currency_array_list);
        }

        
        public override Task<CurrencyQOBD[]> insert_data_currencyAsync(string companyName, CurrencyQOBD[] currency_array_list)
        {
            return base.Channel.insert_data_currencyAsync(companyName, currency_array_list);
        }

        
        public override CurrencyQOBD[] update_data_currency(string companyName, CurrencyQOBD[] currency_array_list)
        {
            return base.Channel.update_data_currency(companyName, currency_array_list);
        }

        
        public override Task<CurrencyQOBD[]> update_data_currencyAsync(string companyName, CurrencyQOBD[] currency_array_list)
        {
            return base.Channel.update_data_currencyAsync(companyName, currency_array_list);
        }

        
        public override CurrencyQOBD[] get_data_currency_by_id(string companyName, string id)
        {
            return base.Channel.get_data_currency_by_id(companyName, id);
        }

        
        public override Task<CurrencyQOBD[]> get_data_currency_by_idAsync(string companyName, string id)
        {
            return base.Channel.get_data_currency_by_idAsync(companyName, id);
        }

        
        public override CurrencyQOBD[] get_filter_currency(string companyName, CurrencyFilterQOBD currency_array_list_filter)
        {
            return base.Channel.get_filter_currency(companyName, currency_array_list_filter);
        }

        
        public override Task<CurrencyQOBD[]> get_filter_currencyAsync(string companyName, CurrencyFilterQOBD currency_array_list_filter)
        {
            return base.Channel.get_filter_currencyAsync(companyName, currency_array_list_filter);
        }

        
        public override CurrencyQOBD[] get_data_currency_by_provider_item_list(string companyName, Provider_itemQOBD[] provider_item_array_list)
        {
            return base.Channel.get_data_currency_by_provider_item_list(companyName, provider_item_array_list);
        }

        
        public override Task<CurrencyQOBD[]> get_data_currency_by_provider_item_listAsync(string companyName, Provider_itemQOBD[] provider_item_array_list)
        {
            return base.Channel.get_data_currency_by_provider_item_listAsync(companyName, provider_item_array_list);
        }
        
        public override LicenseQOBD[] get_filter_license(string company_name, LicenseFilterQOBD license_array_list)
        {
            return base.Channel.get_filter_license(company_name, license_array_list);
        }
        
        public override Task<LicenseQOBD[]> get_filter_licenseAsync(string company_name, LicenseFilterQOBD license_array_list)
        {
            return base.Channel.get_filter_licenseAsync(company_name, license_array_list);
        }
        
        public override LicenseQOBD[] update_data_license(string company_name, LicenseQOBD[] license_array_list)
        {
            return base.Channel.update_data_license(company_name, license_array_list);
        }
        
        public override Task<LicenseQOBD[]> update_data_licenseAsync(string company_name, LicenseQOBD[] license_array_list)
        {
            return base.Channel.update_data_licenseAsync(company_name, license_array_list);
        }
        
        public override LicenseQOBD[] insert_data_license(string company_name, LicenseQOBD[] license_array_list)
        {
            return base.Channel.insert_data_license(company_name, license_array_list);
        }
        
        public override Task<LicenseQOBD[]> insert_data_licenseAsync(string company_name, LicenseQOBD[] license_array_list)
        {
            return base.Channel.insert_data_licenseAsync(company_name, license_array_list);
        }
        
        public override LicenseQOBD[] get_data_license(string company_name, string nbLine)
        {
            return base.Channel.get_data_license(company_name, nbLine);
        }
        
        public override Task<LicenseQOBD[]> get_data_licenseAsync(string company_name, string nbLine)
        {
            return base.Channel.get_data_licenseAsync(company_name, nbLine);
        }
        
        public override LicenseQOBD[] get_data_license_by_id(string company_name, string id)
        {
            return base.Channel.get_data_license_by_id(company_name, id);
        }
        
        public override Task<LicenseQOBD[]> get_data_license_by_idAsync(string company_name, string id)
        {
            return base.Channel.get_data_license_by_idAsync(company_name, id);
        }
        
        public override LicenseQOBD[] delete_data_license(string company_name, LicenseQOBD[] license_array_list)
        {
            return base.Channel.delete_data_license(company_name, license_array_list);
        }
        
        public override Task<LicenseQOBD[]> delete_data_licenseAsync(string company_name, LicenseQOBD[] license_array_list)
        {
            return base.Channel.delete_data_licenseAsync(company_name, license_array_list);
        }
    }
}
